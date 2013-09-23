using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EditorWPF.Models;
using EditorWPF.Views;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;

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
            var injectionModel = new InjectionModule();
            MainWindow = injectionModel.Load().Get<MainWindow>();
            MainWindow.Show();
        }
    }


}
