using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using EditorWPF.Models;
using EditorWPF.Models.Shapes;
using EditorWPF.Models.Tools;

namespace EditorWPF.Commands
{
    class InsertShapeCommand : MouseCommand
    {
        private readonly ObservableCollection<IShape> _shapes;
        private readonly ObservableWrapper<ITool> _currentTool;


        public InsertShapeCommand(ObservableCollection<IShape> shapes, ObservableWrapper<ITool> currentTool)
        {
            _shapes = shapes;
            _currentTool = currentTool;
        }

        public override void Execute(Vector mouse)
        {
            var rectangleSize = new Vector(30, 30);

            _shapes.Add(new Rectangle(mouse - (rectangleSize / 2), rectangleSize, Colors.Red));
        }
    }
}
