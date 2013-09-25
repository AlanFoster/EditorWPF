using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EditorWPF.Models.Shapes
{
    class Screenshot : IDrawable
    {
        private Bitmap _bitmap;
        public Vector Location { get; private set; }

        /// <summary>
        /// Represents the size of the Shape, IE the rightmost and bottom most Vector.
        /// This size should be in relation to the Shape's Location.
        /// </summary>
        public Vector Size { get; private set; }

        public Bitmap Bitmap
        {
            get { return _bitmap; }
            private set
            {
                _bitmap = value;
                Size = new Vector(_bitmap.Width, _bitmap.Height);
            }
        }

        public Screenshot(Vector location, Bitmap bitmap)
        {
            Location = location;
            Bitmap = bitmap;
        }
    }
}
