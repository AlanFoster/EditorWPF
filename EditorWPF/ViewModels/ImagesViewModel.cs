using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EditorWPF.Commands;
using Image = EditorWPF.Models.domain.Image;

namespace EditorWPF.ViewModels
{
    public class ImagesViewModel : INotifyPropertyChanged
    {
        private Image _selectedImage;
        public ObservableCollection<Image> Images { get; set; }

        public Image SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedImage"));
            }
        }

        public ICommand Unselect { get; set; }

        public ImagesViewModel()
        {
            var randomBitmap = new Func<int, Bitmap>(i =>
            {
                var bitmap = new Bitmap(100, 100);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    var randomColor = Color.FromKnownColor(((KnownColor[]) Enum.GetValues(typeof (KnownColor)))[i]);
                    using (var brush = new SolidBrush(randomColor))
                    {
                        graphics.FillRectangle(brush, 0, 0, 100, 100);
                    }
                }
                return bitmap;
            });

            Images = new ObservableCollection<Image>(Enumerable.Range(1, 20).Select(i => new Image
            {
                Id = i,
                Author = "Alan",
                Description = string.Format("Image #{0}", i),
                Bitmap = randomBitmap(i)
            }));


            Unselect = new DelegateCommand<Object>(_ => SelectedImage = null);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
