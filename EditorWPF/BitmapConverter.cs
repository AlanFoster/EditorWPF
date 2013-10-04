using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using EditorWPF.Views;

namespace EditorWPF
{
    class BitmapConverter : MarkupExtension, IValueConverter
    {
        private static readonly Lazy<BitmapConverter> Converter = new Lazy<BitmapConverter>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bitmap = value as Bitmap;
            if (bitmap == null) return null;

            var bitmapImage = new BitmapImage();
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                memoryStream.Seek(0, SeekOrigin.Begin);

                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Converter.Value;
        }
    }
}
