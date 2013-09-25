using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using EditorWPF.Models;
using EditorWPF.Models.Shapes;
using Ninject;

namespace EditorWPF.Commands
{
    public class TakeScreenshotCommand : Command
    {
        private readonly ObservableCollection<IDrawable> _drawables;
        private readonly ObservableWrapper<Vector> _canvasSize;

        [Inject]
        public TakeScreenshotCommand(ObservableCollection<IDrawable> drawables, ObservableWrapper<Vector> canvasSize)
        {
            _drawables = drawables;
            _canvasSize = canvasSize;
        }

        /// <summary>
        /// Note, this Screenshot task is performed asynchronously.
        /// </summary>
        public override void Execute()
        {
            var screenshotTask = TakeScreenshot();
            screenshotTask
                .ContinueWith(
                    result =>
                    {
                        var bitmap = screenshotTask.Result;
                        _drawables.Add(new Screenshot(new Vector(0, 0), screenshotTask.Result));
                        // Force a Screen resize for better a better UX
                        // TODO Should this could be handled within the Canvas logic instead
                        _canvasSize.Value =
                            new Vector(
                                Math.Max(_canvasSize.Value.X, bitmap.Width),
                                Math.Max(_canvasSize.Value.Y, bitmap.Height));
                    },
                    TaskScheduler.FromCurrentSynchronizationContext()
                );
        }

        /// <summary>
        /// Takes a screenshot of all screens combined. 
        /// TODO Ordering may be incorrect.
        /// </summary>
        /// <returns></returns>
        public Task<Bitmap> TakeScreenshot()
        {
            var task = Task.Factory.StartNew(() =>
            {
                var bounds = Screen.AllScreens.Select(_ => _.Bounds).ToList();

                // Calculate the total image size we'll need thorugh the sum of all screen width and heights
                var totalSize = bounds
                    .Aggregate(new Vector(0, 0),
                        (summation, bound) =>
                            new Vector(summation.X + bound.Width, summation.Y + bound.Height));

                // Calculate the leftmost screen so we can draw relatively to that point, instead of screen 1's 0,0
                var leftMostScreen = bounds.Select(_ => _.Left).Min();
                var topMostScreen = bounds.Select(_ => _.Top).Min();

                // Write all screens to a single bitmap
                var bitmap = new Bitmap((int) totalSize.X, (int) totalSize.Y);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    foreach(var bound in bounds)
                    {
                        graphics.CopyFromScreen(
                            // Source
                             bound.X, bound.Y,
                            // Destination
                            //0, 0,
                             bound.X - leftMostScreen, bound.Y - topMostScreen,
                             bound.Size,
                             CopyPixelOperation.SourceCopy);
                    }
                }

                return bitmap;
            });
            return task;
        }
    }
}
