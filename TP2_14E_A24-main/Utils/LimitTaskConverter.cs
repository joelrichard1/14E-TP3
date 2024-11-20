using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Automate.Utils
{
    public class LimitTasksConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable tasks)
            {
                return tasks.Cast<object>().Take(3).ToList();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
