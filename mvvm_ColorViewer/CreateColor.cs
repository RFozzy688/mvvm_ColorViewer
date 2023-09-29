using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace mvvm_ColorViewer
{
    // model
    class CreateColor
    {
        public CreateColor() 
        {
            //Red = 50;
            //Green = 231;
            //Blue = 100;
            //Alpha = 255;
        }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }
        public SolidColorBrush ResultColor()
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromArgb(Alpha, Red, Green, Blue);
            return brush;
        }
        public string ColorFormatX()
        {
            return String.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", Alpha, Red, Green, Blue);
        }
    }
}
