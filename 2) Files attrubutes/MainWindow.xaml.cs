using Files_attrubutes.ViewModels;
using System.Windows;

namespace Files_attrubutes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
