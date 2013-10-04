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
using EditorWPF.Models.Shapes;
using EditorWPF.Models.Tools;
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
           var kernal = new StandardKernel(
                new ToolModule(),
                new DrawableModule(),
                new CommandModule()
            );

            return kernal;
        }
    }

    public class DrawableModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ObservableCollection<IDrawable>>()
                .ToConstant(new ObservableCollection<IDrawable>())
                .InSingletonScope();
        }
    }

    public class ToolModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ITool>().To<PenTool>().InSingletonScope();
            Kernel.Bind<ITool>().To<LineTool>().InSingletonScope();
            Kernel.Bind<ITool>().To<PolygonalTool>().InSingletonScope();
            Kernel.Bind<ITool>().To<TextTool>().InSingletonScope();
            Kernel.Bind<ITool>().To<RectangleTool>().InSingletonScope();

            var allTools = Kernel.GetAll<ITool>();

            Kernel.Bind<ObservableCollection<ITool>>()
                .ToConstant(new ObservableCollection<ITool>(allTools))
                .InSingletonScope();

            Kernel.Bind<ObservableWrapper<ITool>>()
                .ToConstant(new ObservableWrapper<ITool>(new EmptyTool()))
                .InSingletonScope();
        }
    }

    public class CommandModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<UpdateTool>().ToSelf().InSingletonScope();
            Kernel.Bind<SaveLocalCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<SaveHostCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<TakeScreenshotCommand>().ToSelf().InSingletonScope();
        }
    }

    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<TakeScreenshotCommand>().ToSelf().InSingletonScope();
            Kernel.Bind<CanvasViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<ImagesViewModel>().ToSelf().InSingletonScope();
        }
    }
}
