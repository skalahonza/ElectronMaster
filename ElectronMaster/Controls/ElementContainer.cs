using System.Windows;
using ElectronMaster.Model;

namespace ElectronMaster.Controls
{
    public class ElementContainer:AppUserControl
    {
        public static readonly DependencyProperty ElementProperty = DependencyProperty.Register(
            nameof(Element), typeof(Element), typeof(ElementContainer), new PropertyMetadata(default(Element)));

        public Element Element
        {
            get => (Element) GetValue(ElementProperty);
            set
            {
                SetValue(ElementProperty, value);
                OnPropertyChanged();
            }
        }
    }
}