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
        public ITool Tool { get; private set; }
        public ICommand UpdateTool { get; private set; }

        [Inject]
        public ToolViewModel(ObservableCollection<ITool> tools)
        {
            Tools = tools;
            Tool = Tools.OfType<Pen>().First();
            UpdateTool = new DelegateCommand<ITool>(Alert);
        }

        public void Alert(ITool newTool)
        {
            MessageBox.Show("New Tool :: " + newTool);
        }
    }
}
