using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Fiszka
{
    public class ResponseToColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.White;

            int response = (int) value;

            if (response == 1)
            {
                brush.Color = Colors.LightGreen;
            } 
            else if(response == -1)
            {
                brush.Color = Colors.Salmon;
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}