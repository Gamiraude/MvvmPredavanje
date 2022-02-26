using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmPredavanje
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _labelText;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            LabelText = "Hello from ViewModel";
            ButtonClickCommand = new Command(OnButtonClicked);
            NumericClickCommand = new Command<int>(OnNumberClick);
        }

        private void OnNumberClick(int number)
        {
            LabelText  = $"Number {number} was clicked";
        }

        private void OnButtonClicked()
        {
            LabelText = "Hello from the other side";
        }

        public string LabelText { 
            get => _labelText;
            set
            {
                _labelText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LabelText)));
            }
        }

        public ICommand ButtonClickCommand { get; }

        public ICommand NumericClickCommand { get; }
    }
}
