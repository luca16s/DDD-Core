namespace CoreLibrary.Wpf.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool Reverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility trueValue = !Reverse ? Visibility.Visible : Visibility.Collapsed;
            Visibility falseValue = !Reverse ? Visibility.Collapsed : Visibility.Visible;
            return value is bool boolValue
                ? boolValue
                ? trueValue
                : falseValue
                : (object)falseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool trueValue = !Reverse;
            bool falseValue = Reverse;

            if (value is Visibility visibilityValue)
            {
                return visibilityValue == Visibility.Visible ? trueValue : falseValue;
            }

            return falseValue;
        }
    }
}