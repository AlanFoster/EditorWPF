using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EditorWPF.Commands;

namespace EditorWPF.ViewModels
{
    class MenuViewModel
    {
        public ICommand SaveLocal { get; set; }

        public MenuViewModel()
        {
            SaveLocal = new SaveLocalCommand();
        }

    }
}
