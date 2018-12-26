using System;
using System.Globalization;
using System.Windows.Data;

namespace ElectronMaster.Converters
{
    public class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
    CultureInfo culture)
        {
            var width = double.Parse(value?.ToString() ?? throw new ArgumentNullException(nameof(value)));
            return (width / 3) - 2; //Dvojka se odečítá aby nevznikly dva řádky
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class BoolOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return b ? 1 : 0.5;
            }
            else
            {
                throw new ArgumentException($@"Expected type {typeof(bool).Name}. Instead {value?.GetType().Name} given.",nameof(value));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
