using System.Windows;

namespace EditorWPF.Models.Shapes
{
    class Shape : IShape
    {
        public Vector Location { get; private set; }

        public Shape(Vector location)
        {
            Location = location;
        }
    }
}
