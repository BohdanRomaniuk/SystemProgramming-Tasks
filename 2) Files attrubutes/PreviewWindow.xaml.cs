using Files_attrubutes.ViewModels;
using System.Windows;

namespace Files_attrubutes
{
    public partial class PreviewWindow : Window
    {
        public PreviewWindow(string fileName, string fullPath)
        {
            DataContext = new PreviewViewModel(fileName, fullPath);
            InitializeComponent();
        }
    }
}
