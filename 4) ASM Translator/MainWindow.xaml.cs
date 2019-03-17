using _4__ASM_Translator.ViewModels;
using System.Windows;

namespace _4__ASM_Translator
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
