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
        public ObservableCollection<IShape> Shapes { get; set; }

        public ICommand ClickTest { get; set; }

        public CanvasViewModel(ObservableWrapper<ITool> currentTool)
        {
            Shapes = new ObservableCollection<IShape>()
            {
                new Rectangle(new Vector(2, 50), new Vector(50, 50), Colors.AliceBlue),
                new Rectangle(new Vector(325, 33), new Vector(50, 50), Colors.Red),
                new Rectangle(new Vector(235, 50), new Vector(50, 50), Colors.AntiqueWhite),
                new Rectangle(new Vector(800, 49), new Vector(50, 50), Colors.CornflowerBlue)
            };

            ClickTest = new InsertShapeCommand(Shapes, currentTool);
        }

    }
}
