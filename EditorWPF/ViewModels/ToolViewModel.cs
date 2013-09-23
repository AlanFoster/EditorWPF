using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EditorWPF.Commands;
using EditorWPF.Models;
using Ninject;

namespace EditorWPF.ViewModels
{
    public class ToolViewModel
    {
        public ObservableCollection<ITool> Tools { get; set; }
        public ObservableWrapper<ITool> CurrentTool { get; private set; }
        public ICommand UpdateTool { get; private set; }

        [Inject]
        public ToolViewModel(ObservableCollection<ITool> tools, ObservableWrapper<ITool> currentTool)
        {
            Tools = tools;
            CurrentTool = currentTool;
            UpdateTool = new DelegateCommand<ITool>(Alert);
        }

        public void Alert(ITool newTool)
        {
            MessageBox.Show("New Tool :: " + newTool);
        }
    }
}
