using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using EditorWPF.Views;
using Microsoft.Win32;

namespace EditorWPF.Commands
{
    class SaveLocalCommand : Command<IBitmappable>
    {
        public override void Execute(IBitmappable bitmappable)
        {
            // TODO Model this appropiately with the MVVM pattern
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".png",
                Filter = "Png Image (.png)|*.png|Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf",
                FileName = string.Format("New-{0}", DateTime.Now.ToString("yy-mm-dd-hh-mm-ss"))
            };
            var showDialogResult = saveFileDialog.ShowDialog();
            if (showDialogResult == false) return;

            var fileName = saveFileDialog.FileName;

            var bitmap = bitmappable.GetBitmap();
            bitmap.Save(fileName);
        }
    }
}
