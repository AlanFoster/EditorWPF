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
using EditorWPF.Models.Tools;
using Ninject;

namespace EditorWPF.ViewModels
{
    public class ToolViewModel
    {
        public ObservableCollection<ITool> Tools { get; set; }
        public ICommand UpdateTool { get; private set; }
        public ICommand SaveLocal { get; private set; }
        public ICommand SaveHost { get; private set; }
        public ICommand TakeScreenshot { get; private set; }

        [Inject]
        public ToolViewModel(ObservableCollection<ITool> tools,
            UpdateTool updateToolCommand,
            SaveLocalCommand saveLocalCommand,
            TakeScreenshotCommand takeScreenshotCommmand,
            SaveHostCommand saveHostCommand)
        {
            Tools = tools;
            UpdateTool = updateToolCommand;
            SaveLocal = saveLocalCommand;
            SaveHost = saveHostCommand;
            TakeScreenshot = takeScreenshotCommmand;
        }
    }
}
