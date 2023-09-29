using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace mvvm_ColorViewer
{
    // VM
    class AppVM : INotifyPropertyChanged
    {
        CreateColor _model;
        byte _alpha;
        byte _red;
        byte _green;
        byte _blue;
        SolidColorBrush _brush;
        string _formatX;
        public AppVM() 
        {
            _model = new CreateColor();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        public byte AlphaComponent
        {
            get => _alpha;
            set
            {
                _alpha = value;
                _model.Alpha = _alpha;
                ResultColor = _model.ResultColor();
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(AlphaComponent)));
            }
        }
        public byte RedComponent
        {
            get => _red;
            set
            {
                _red = value;
                _model.Red = _red;
                ResultColor = _model.ResultColor();
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(RedComponent)));
            }
        }
        public byte GreenComponent
        {
            get => _green;
            set
            {
                _green = value;
                _model.Green = _green;
                ResultColor = _model.ResultColor();
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(GreenComponent)));
            }
        }
        public byte BlueComponent
        {
            get => _blue;
            set
            {
                _blue = value;
                _model.Blue = _blue;
                ResultColor = _model.ResultColor();
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(BlueComponent)));
            }
        }
        public SolidColorBrush ResultColor
        {
            get => _brush;
            set
            {
                _brush = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ResultColor)));
            }
        }
        public string FormatX
        {
            get => _formatX;
            set
            {
                _formatX = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(FormatX)));
            }
        }
    }
}
