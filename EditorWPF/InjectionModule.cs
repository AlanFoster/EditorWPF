using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EditorWPF.Models;
using EditorWPF.ViewModels;
using EditorWPF.Views;
using Ninject;
using Ninject.Modules;

namespace EditorWPF
{
    public class InjectionModule
    {
        public IKernel Load()
        {
            // If only we had a dependency injection framework to inject this kernal! :)
            var kernel = new StandardKernel(
                new ToolModule()
            );

            return kernel;
        }
    }

    public class ToolModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ITool>().To<Pen>().InSingletonScope();
            Kernel.Bind<ITool>().To<Line>().InSingletonScope();
            Kernel.Bind<ITool>().To<Polygonal>().InSingletonScope();
            Kernel.Bind<ITool>().To<Text>().InSingletonScope();

            var allTools = Kernel.GetAll<ITool>();

            Kernel.Bind<ObservableCollection<ITool>>()
                .ToConstant(new ObservableCollection<ITool>(allTools))
                .InSingletonScope();

            Kernel.Bind<ObservableWrapper<ITool>>()
                .ToConstant(new ObservableWrapper<ITool>(new EmptyTool()))
                .InSingletonScope();
        }
    }

    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            
        }
    }
}
