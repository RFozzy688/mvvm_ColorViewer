using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        MainWindow _view;
        public AppVM(MainWindow view) 
        {
            _model = new CreateColor();
            _addColorCommand = new Commands(AddColorExecute);
            _deleteItemCommand = new Commands(DeleteItemExecute);

            _view = view;
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

        Commands _addColorCommand;
        Commands _deleteItemCommand;
        public Commands AddColor
        {
            get
            {
                return _addColorCommand;
            }
        }
        public Commands DeleteItem
        {
            get
            {
                return _deleteItemCommand;
            }
        }
        private void AddColorExecute(object param)
        {
            CreateItemListBox();
        }
        private void DeleteItemExecute(object param)
        {
            DeleteListBoxItem((ListBoxItem)param);
        }

        private bool CanExecuteCalculate(object param)
        {
            return true;
        }
        private void CreateItemListBox()
        {
            ListBoxItem lbi = new ListBoxItem();
            Grid grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition{ Width = new GridLength(75) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });

            TextBlock colorNameX = new TextBlock();
            colorNameX.Text = _model.ColorFormatX();
            colorNameX.VerticalAlignment = VerticalAlignment.Center;

            TextBlock color = new TextBlock();
            color.Background = ResultColor;

            Button button = new Button();
            button.Content = "Delete";
            button.Margin = new Thickness(2);
            button.CommandParameter = lbi;
            button.Command = DeleteItem;
            button.CommandTarget = _view.ListColors;

            grid.Children.Add(colorNameX);
            grid.Children.Add(color);
            grid.Children.Add(button);

            Grid.SetColumn(colorNameX, 0);
            Grid.SetColumn(color, 1);
            Grid.SetColumn(button, 2);

            lbi.Content = grid;
            _view.ListColors.Items.Add(lbi);
        }
        private void DeleteListBoxItem(ListBoxItem item)
        {
            _view.ListColors.Items.Remove(item);
        }
    }
}
