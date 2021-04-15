namespace CoreLibrary.Wpf.Converter
{
    using CoreLibrary.Extensions;
    using CoreLibrary.Models;

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;

    [ValueConversion(typeof(Enum), typeof(IEnumerable<EnumModel>))]
    public class EnumToCollectionConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Enum enumerador ? enumerador.GetAllValuesAndDescriptions() : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}