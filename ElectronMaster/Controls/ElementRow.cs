using System.Windows;
using ElectronMaster.Model;

namespace ElectronMaster.Controls
{
    public class ElementRow:AppUserControl
    {
        public static readonly DependencyProperty ElementProperty = DependencyProperty.Register(
            nameof(Element), typeof(Element), typeof(ElementRow), new PropertyMetadata(default(Element)));

        public Element Element
        {
            get => (Element) GetValue(ElementProperty);
            set => SetValue(ElementProperty, FluentOnPropertyChanged(value));
        }
    }
}