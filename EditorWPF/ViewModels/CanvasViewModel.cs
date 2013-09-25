using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using EditorWPF.Commands;
using EditorWPF.Models;
using EditorWPF.Models.Shapes;
using EditorWPF.Models.Tools;

namespace EditorWPF.ViewModels
{
    class CanvasViewModel
    {
        public ObservableCollection<IDrawable> Drawables { get; set; }

        public ICommand ClickTest { get; set; }

        public CanvasViewModel(ObservableWrapper<ITool> currentTool)
        {
            Drawables = new ObservableCollection<IDrawable>();

            ClickTest = new InsertShapeCommand(Drawables, currentTool);
        }

    }
}
