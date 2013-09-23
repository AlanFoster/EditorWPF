using System;
using System.Collections.ObjectModel;
using System.Windows;
using EditorWPF.Models;
using EditorWPF.ViewModels;
using Ninject;

namespace EditorWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Inject]
        public MainWindow(ToolViewModel toolViewModel)
        {
            InitializeComponent();
            DataContext = toolViewModel;
        }

    }
}
