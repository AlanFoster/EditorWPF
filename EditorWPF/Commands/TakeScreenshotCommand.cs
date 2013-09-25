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

        [Inject]
        public TakeScreenshotCommand(ObservableCollection<IDrawable> drawables)
        {
            _drawables = drawables;
        }

        /// <summary>
        /// Note, this Screenshot task is performed asynchronously.
        /// </summary>
        public override void Execute()
        {
            var screenshotTask = TakeScreenshot();
            screenshotTask
                .ContinueWith(
                    result => _drawables.Add(new Screenshot(new Vector(0, 0), screenshotTask.Result)),
                    TaskScheduler.FromCurrentSynchronizationContext()
                );
        }

        /// <summary>
        /// Takes a screenshot of all screens combined. 
        /// </summary>
        /// <returns></returns>
        public Task<Bitmap> TakeScreenshot()
        {
            var task = Task.Factory.StartNew(() =>
            {
                var bounds = Screen.AllScreens.Select(_ => _.Bounds).ToList();

                // Calculate the total image size we'll need through the sum of all screen width and heights
                var totalSize = bounds
                    .Aggregate(new Vector(0, 0),
                        (summation, bound) =>
                            new Vector(summation.X + bound.Width, summation.Y + bound.Height));

                // Calculate the leftmost, topmost screen location so we can draw relatively to that point, instead of screen one's 0,0
                var relativeX = bounds.Select(_ => _.Left).Min();
                var relativeY = bounds.Select(_ => _.Top).Min();

                // Write all screens to a single bitmap
                var bitmap = new Bitmap((int) totalSize.X, (int) totalSize.Y);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    foreach(var bound in bounds)
                    {
                        graphics.CopyFromScreen(
                            // Source
                             bound.X, bound.Y,
                             // Destination, relative to the leftmost/topmost location
                             bound.X - relativeX, bound.Y - relativeY,
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
