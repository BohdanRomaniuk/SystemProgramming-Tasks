using Files_attrubutes.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Files_attrubutes.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FileInformation> Files { get; set; }
        public ICommand AnalyzeCommand { get; private set; }
        public ICommand PreviewCommand { get; private set; }
        public ICommand CalculateSumCommand { get; private set; }

        public MainViewModel()
        {
            Files = new ObservableCollection<FileInformation>();
            AnalyzeCommand = new Command(Analyze);
            PreviewCommand = new Command(Preview);
            CalculateSumCommand = new Command(CalculateSum);
        }

        public void Analyze(object parameter)
        {
            Files.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(".");
            var subDiresctories = dirInfo.GetDirectories();
            if (subDiresctories.Where(sub => sub.Name.Equals("problem", System.StringComparison.InvariantCultureIgnoreCase)).Any())
            {
                dirInfo = new DirectoryInfo("./problem/");
            }
            var files = dirInfo.GetFiles().Where(s => s.Extension == ".dat").Take(2);
            foreach (var file in files)
            {
                Files.Add(new FileInformation(file.Name, file.FullName, file.Length, file.CreationTime));
            }
        }

        private void Preview(object parameter)
        {
            var file = (FileInformation)parameter;
            var previewWindow = new PreviewWindow(file.Name, file.FullPath);
            previewWindow.Show();
        }

        private void CalculateSum(object parameter)
        {
            foreach (var file in Files)
            {
                using (var reader = new StreamReader(file.FullPath))
                {
                    var sum = 0;
                    var stringResult = reader.ReadToEnd();
                    var numbers = stringResult.Split(' ');
                    foreach (var num in numbers)
                    {
                        int digit;
                        int.TryParse(num, out digit);
                        if (digit != 0)
                        {
                            sum += digit;
                        }
                    }
                    file.Sum = sum;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
