using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Input;
using EditorWPF.Commands;
using EditorWPF.EditorService;
using Ninject.Infrastructure.Language;
using Image = EditorWPF.EditorService.Image;

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
        public ICommand Delete { get; set; }

        private IEditorService _editorService;

        public ImagesViewModel()
        {

            _editorService = new EditorServiceClient();
            Images = new ObservableCollection<Image>(_editorService.GetImages());

            Unselect = new DelegateCommand<Object>(_ => SelectedImage = null);
            Delete = new DelegateCommand<Object>(_ =>
            {
                var id = SelectedImage.Id;

                // Perform local modifications to provide a richer user experience
                Unselect.Execute(null);
                Images.Remove(Images.FirstOrDefault(image => image.Id == id));

                _editorService.RemoveImageAsync(id);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
