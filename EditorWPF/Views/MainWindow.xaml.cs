using System.Windows;
using EditorWPF.ViewModels;

namespace EditorWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // TODO DI
            DataContext = new ToolViewModel();
        }
    }
}
