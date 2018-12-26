using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using ElectronMaster.Model;
using NodaTime;

namespace ElectronMaster.Controls
{
    public class TimeLineNode:AppUserControl
    {
        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            nameof(Elements), typeof(ObservableCollection<Element>), typeof(TimeLineNode), new PropertyMetadata(default(ObservableCollection<Element>)));

        public ObservableCollection<Element> Elements
        {
            get => (ObservableCollection<Element>) GetValue(PropertyTypeProperty);
            set
            {
                SetValue(PropertyTypeProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty DiscoveredProperty = DependencyProperty.Register(
            nameof(Discovered), typeof(LocalDateTime), typeof(TimeLineNode), new PropertyMetadata(default(LocalDateTime)));

        public LocalDateTime Discovered
        {
            get => (LocalDateTime) GetValue(DiscoveredProperty);
            set
            {
                SetValue(DiscoveredProperty, value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(DiscoveredText));
            }
        }

        public string DiscoveredText => Discovered.ToString("yyyy gg", DateTimeFormatInfo.CurrentInfo);        
    }
}