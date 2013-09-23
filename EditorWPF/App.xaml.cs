using System.Windows;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using EditorWPF.Views;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace EditorWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            // Wire up our IoC module and grab the startup window to show
            var injectionModel = new InjectionModule().Load();

            // We have to wire up a service locator adapter for Ninject, otherwise WPF always called the View's Empty constructors and NPE'd
            // TODO Investigate why Ninject doesn't work in this scenario
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(injectionModel));
            MainWindow = injectionModel.Get<MainWindow>();

            MainWindow.Show();
        }
    }


}
