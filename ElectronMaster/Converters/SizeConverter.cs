using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace ElectronMaster
{
    public class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
    CultureInfo culture)
        {
            double width = Double.Parse(value.ToString());
            return (width / 3) - 2; //Dvojka se odečítá aby nevznikly dva řádky
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
