using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EditorWPF.Models;
using EditorWPF.Models.Tools;
using EditorWPF.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Point = System.Windows.Point;

namespace EditorWPF.Views
{
    public interface IBitmappable
    {
        Bitmap GetBitmap();
    }

    /// <summary>
    /// Interaction logic for Canvas.xaml
    /// </summary>
    public partial class Canvas : UserControl, IBitmappable
    {
        public Canvas()
        {
            InitializeComponent();
            // TODO
            DataContext = ServiceLocator.Current.GetInstance<CanvasViewModel>();
        }

        public Bitmap GetBitmap()
        {
            var width = (int)Width;
            var height = (int)Height;

            var bitmapSource = BitmapSource(CanvasContainer, width, height, 96, 96);

            // GifBitmapEncoder, PngBitmapEncoer, JpegBitmapEncoder
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));


            Bitmap createdBitmap;
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                stream.Seek(0, SeekOrigin.Begin);

                createdBitmap = new Bitmap(stream);
            }
            return createdBitmap;
        }

        private static BitmapSource BitmapSource(Visual target, int width, int height, double dpiX, double dpiY)
        {
            if (target == null) return null;

            var renderTarget = new RenderTargetBitmap(
                width, height,
                dpiX, dpiY, PixelFormats.Default);

            var bounds = VisualTreeHelper.GetDescendantBounds(target);
            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
            {
                var visualBrush = new VisualBrush(target);
                drawingContext.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
            }

            renderTarget.Render(drawingVisual);
            return renderTarget;
        }

    }
}
