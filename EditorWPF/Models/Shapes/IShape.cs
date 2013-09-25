using System.Windows;
using System.Windows.Media;

namespace EditorWPF.Models.Shapes
{
    interface IShape : IDrawable
    {

        /// <summary>
        /// Represents the size of the Shape, IE the rightmost and bottom most Vector.
        /// This size should be in relation to the Shape's Location.
        /// </summary>
        Vector Size { get; }

        /// <summary>
        /// Represents the color of the current shape.
        /// </summary>
        Color Color { get; }
    }
}
