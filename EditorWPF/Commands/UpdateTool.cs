using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EditorWPF.Models;
using EditorWPF.Models.Tools;
using Ninject;

namespace EditorWPF.Commands
{
    public class UpdateTool : Command<ITool>
    {
        public ObservableWrapper<ITool> CurrentTool { get; private set; }

        [Inject]
        public UpdateTool(ObservableWrapper<ITool> currentTool) : base()
        {
            CurrentTool = currentTool;
        }

        public override void Execute(ITool tool)
        {
            CurrentTool.Value = tool;
        }
    }
}
