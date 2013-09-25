using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using EditorWPF.Annotations;
using EditorWPF.Commands;
using EditorWPF.Models;
using EditorWPF.Models.Shapes;
using EditorWPF.Models.Tools;
using Microsoft.Practices.ServiceLocation;

namespace EditorWPF.ViewModels
{
    class CanvasViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<IDrawable> Drawables { get; set; }
        public ICommand ClickTest { get; set; }

        private Vector _size;
        public Vector Size
        {
            get { return _size; }
            set
            {
                _size = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Size"));
            }
        }

        public CanvasViewModel(ObservableWrapper<ITool> currentTool)
        {
            Drawables = ServiceLocator.Current.GetInstance<ObservableCollection<IDrawable>>();
            ClickTest = new InsertShapeCommand(Drawables, currentTool);
            Size = new Vector(500, 350);

            Drawables.CollectionChanged += DrawablesOnCollectionChanged;
        }

        private void DrawablesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            // We automatically resize to all newly added screenshots for a better user experience
            var screenshots = notifyCollectionChangedEventArgs.NewItems.OfType<Screenshot>();
            var newSize = screenshots
                .Aggregate(Size, (size, screenshot) =>
                    new Vector(
                        Math.Max(size.X, screenshot.Size.X),
                        Math.Max(size.Y, screenshot.Size.Y)));

            Size = newSize;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}


