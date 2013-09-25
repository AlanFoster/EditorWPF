using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EditorWPF.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

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
            var bitmapSource = BitmapSource(CanvasContainer);

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

        private static BitmapSource BitmapSource(UIElement target, double dpiX = 96, double dpiY = 96)
        {
            if (target == null) return null;

            target.Measure(target.RenderSize);
            target.Arrange(new Rect(target.RenderSize));

            var renderTarget = new RenderTargetBitmap(
                (int)target.RenderSize.Width, (int)target.RenderSize.Height,
                dpiX, dpiY, PixelFormats.Pbgra32);

            renderTarget.Render(target);

            return renderTarget;
        }

    }
}
