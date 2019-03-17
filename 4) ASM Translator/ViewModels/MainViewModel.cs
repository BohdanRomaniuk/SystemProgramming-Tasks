using _4__ASM_Translator.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace _4__ASM_Translator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string assemblerCode;
        private string translatedCode;
        private bool isBinary;

        public string AssemblerCode
        {
            get
            {
                return assemblerCode;
            }
            set
            {
                assemblerCode = value;
                OnPropertyChanged(nameof(AssemblerCode));
            }
        }
        public string TranslatedCode
        {
            get
            {
                return translatedCode;
            }
            set
            {
                translatedCode = value;
                OnPropertyChanged(nameof(TranslatedCode));
            }
        }
        public bool IsBinary
        {
            get
            {
                return isBinary;
            }
            set
            {
                isBinary = value;
                OnPropertyChanged(nameof(IsBinary));
            }
        }
        public bool IsHex
        {
            get
            {
                return !IsBinary;
            }
            set
            {
                IsBinary = !value;
                OnPropertyChanged(nameof(IsHex));
            }
        }

        public ICommand TranslateCommand { get; }
        public ICommand ChangeTransTypeCommand { get; }

        public MainViewModel()
        {
            AssemblerCode = "MOV AX,BX\nADD CX,AX";
            IsBinary = true;
            TranslateCommand = new Command(Translate);
            ChangeTransTypeCommand = new Command(ChangeTransType);
        }

        private void Translate(object parameter)
        {
            if (!string.IsNullOrEmpty(AssemblerCode))
            {
                TranslatedCode = string.Empty;
                string[] lines = AssemblerCode.Split('\n');
                foreach (var line in lines)
                {
                    TranslatedCode += Translator.TranslateLine(line, IsBinary) + "\n";
                }
            }
            else
            {
                MessageBox.Show("Немає асемблер коду", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeTransType(object parameter)
        {
            IsHex = ((string)parameter == "hex") ? true : false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
