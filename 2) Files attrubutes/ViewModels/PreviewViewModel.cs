using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Files_attrubutes.ViewModels
{
    public class PreviewViewModel : INotifyPropertyChanged
    {
        private string fileName;
        private string text;

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public PreviewViewModel(string fileName, string fullPath)
        {
            FileName = fileName;
            ReadFileData(fullPath);
        }

        private async void ReadFileData(string fullPath)
        {
            using (var reader = new StreamReader(fullPath))
            {
                Text = await reader.ReadToEndAsync();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
