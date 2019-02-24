using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Files_attrubutes.Models
{
    public class FileInformation : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public long FileSize { get; set; }
        public DateTime CreateDate { get; set; }

        private int sum;
        public int Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }

        public FileInformation(string name, string path, long size, DateTime createDate)
        {
            Name = name;
            FullPath = path;
            FileSize = size;
            CreateDate = createDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
