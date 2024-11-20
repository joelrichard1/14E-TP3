using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Automate.Utils
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? Visibility.Visible : Visibility.Hidden;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Hidden;
            }
            return false;
        }
    }

}