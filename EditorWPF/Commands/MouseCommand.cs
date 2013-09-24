using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EditorWPF.Commands
{
    abstract class MouseCommand : Command<IInputElement>
    {
        public override void Execute(IInputElement element)
        {
            var point = Mouse.GetPosition(element);
            Execute(new Vector(point.X, point.Y));
        }

        public abstract void Execute(Vector mouse);
    }
}
