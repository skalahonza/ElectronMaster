using System.Windows;
using ElectronMaster.Model.Wolfram;

namespace ElectronMaster.Controls
{
    public class ElementInfoView : AppUserControl
    {
        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            nameof(ElementInfo), typeof(ElementInfo), typeof(ElementInfoView), new PropertyMetadata(default(ElementInfo)));

        public ElementInfo ElementInfo
        {
            get => (ElementInfo) GetValue(PropertyTypeProperty);
            set => SetValue(PropertyTypeProperty, value);
        }
    }
}