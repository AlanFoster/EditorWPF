using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using EditorWPF.Models;
using EditorWPF.Models.Shapes;
using EditorWPF.Models.Tools;
using Ninject;
using Rectangle = EditorWPF.Models.Shapes.Rectangle;

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

        public Task<Bitmap> TakeScreenshot()
        {
            var task = Task.Factory.StartNew(() =>
            {
                // TODO create a single large bitmap 
                Bitmap bitmap = null;

                foreach (var screen in Screen.AllScreens)
                {
                    var bounds = screen.Bounds;
                    bitmap = new Bitmap(bounds.Width, bounds.Height);

                    var graphics = Graphics.FromImage(bitmap);
                    graphics.CopyFromScreen(
                        // Source
                        bounds.X, bounds.Y,
                        // Destination
                        0, 0,
                        // bounds.X, bounds.Y,
                        bounds.Size,
                        CopyPixelOperation.SourceCopy);
                }
                return bitmap;
            });
            return task;
        }
    }
}
