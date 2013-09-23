using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EditorWPF.Models.Shapes;

namespace EditorWPF.ViewModels
{
    class CanvasViewModel
    {
        public ObservableCollection<IShape> Shapes { get; set; } 

    }
}
