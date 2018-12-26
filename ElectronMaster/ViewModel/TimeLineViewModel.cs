using System.Collections.ObjectModel;
using System.Globalization;
using ElectronMaster.Model;
using NodaTime;

namespace ElectronMaster.ViewModel
{
    public class TimeLineViewModel:ViewModelBase
    {
        private ObservableCollection<Element> _elements = new ObservableCollection<Element>();
        private LocalDateTime _discovered;

        public ObservableCollection<Element> Elements
        {
            get => _elements;
            set
            {
                if (Equals(value, _elements)) return;
                _elements = value;
                OnPropertyChanged();
            }
        }

        public LocalDateTime Discovered
        {
            get => _discovered;
            set
            {
                if (value.Equals(_discovered)) return;
                _discovered = value;
                OnPropertyChanged();                
            }
        }       
    }
}