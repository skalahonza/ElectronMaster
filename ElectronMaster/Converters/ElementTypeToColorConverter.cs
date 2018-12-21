using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using ElectronMaster.Model;

namespace ElectronMaster
{
    public class ElementTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ElementType type)
            {
                switch (type)
                {
                    case ElementType.Nekov:
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE44424"));
                    case ElementType.Polokov:
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF67BCDB"));
                    case ElementType.Kov:
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA2AB58"));
                    default:
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom("#252526"));
                }
            }
            throw new ArgumentException($"Expected type {typeof(ElementType)} instead {value?.GetType()} given.",nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}