using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EditorWPF.Models;
using EditorWPF.Models.Tools;

namespace EditorWPF.ViewModels
{
    public class StatusBarViewModel
    {
        public ObservableWrapper<ITool> CurrentTool { get; private set; }

        public StatusBarViewModel(ObservableWrapper<ITool> currentTool)
        {
            CurrentTool = currentTool;
        }
    }
}
