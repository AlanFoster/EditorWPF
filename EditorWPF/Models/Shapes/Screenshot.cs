using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EditorWPF.Models.Shapes
{
    class Screenshot : IDrawable
    {
        public Vector Location { get; private set; }
    }
}
