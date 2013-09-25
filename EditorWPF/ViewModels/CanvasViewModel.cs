using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using EditorWPF.Commands;
using EditorWPF.Models;
using EditorWPF.Models.Shapes;
using EditorWPF.Models.Tools;
using Microsoft.Practices.ServiceLocation;

namespace EditorWPF.ViewModels
{
    class CanvasViewModel
    {
        public ObservableCollection<IDrawable> Drawables { get; set; }
        public ICommand ClickTest { get; set; }
        public ObservableWrapper<Vector> Size { get; set; }

        public CanvasViewModel(ObservableWrapper<ITool> currentTool, ObservableWrapper<Vector> canvasSize)
        {
            Drawables = ServiceLocator.Current.GetInstance<ObservableCollection<IDrawable>>();
            ClickTest = new InsertShapeCommand(Drawables, currentTool);
            Size = canvasSize;
        }
    }
}


