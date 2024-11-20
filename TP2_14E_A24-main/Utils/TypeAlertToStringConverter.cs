using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Data;

namespace Automate.Utils
{
    public class TypeAlertToStringConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            if (value is not Enum enumValue)
                return DependencyProperty.UnsetValue;

            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field == null)
                return enumValue.ToString();

            return Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute ? attribute.Value : enumValue.ToString();
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            foreach (var field in targetType.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute && attribute.Value == value.ToString())
                    return Enum.Parse(targetType, field.Name);
            }

            return Enum.Parse(targetType, (string)value);
        }
    }

}
