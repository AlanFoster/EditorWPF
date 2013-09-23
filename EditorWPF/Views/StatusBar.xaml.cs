using System.Windows.Controls;
using EditorWPF.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace EditorWPF.Views
{
    /// <summary>
    /// Interaction logic for StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();
            // TODO FInd out why WPF always calls the empty constructor, which forced me to use this antipattern =[
            DataContext = ServiceLocator.Current.GetInstance<StatusBarViewModel>();
        }
    }
}
