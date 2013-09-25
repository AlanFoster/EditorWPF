using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EditorWPF.Models.Shapes
{
    interface IDrawable
    {
        /// <summary>
        /// Represents the top left location of the Shape.
        /// Where Vector(0,0) is the top left of the screen
        /// </summary>
        Vector Location { get; }
    }
}
