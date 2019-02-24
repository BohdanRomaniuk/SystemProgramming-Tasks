using System.Windows;
using SystemProgramming_Tasks.ViewModels;

namespace SystemProgramming_Tasks
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
