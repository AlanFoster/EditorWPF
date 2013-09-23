using System.Windows;
using System.Windows.Media;

namespace EditorWPF.Models.Shapes
{
    class Shape : IShape
    {
        public Vector Location { get; private set; }
        public Vector Size { get; private set; }
        public Color Color { get; private set; }

        public Shape(Vector location, Vector size, Color color)
        {
            Location = location;
            Size = size;
            Color = color;
        }
    }
}
