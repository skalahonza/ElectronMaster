using ElectronMaster.Model;

namespace ElectronMaster.ViewModel
{
    public class ElementViewModel:ViewModelBase
    {
        public ElementViewModel()
        {            
        }

        public ElementViewModel(Element element)
        {
            _element = element;
        }

        private Element _element;
        private bool _isActive;
        public Element Element
        {
            get => _element;
            set
            {
                _element = value;
                OnPropertyChanged();
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnPropertyChanged();
            }
        }
    }

    public class ElementFrameViewModel: ElementViewModel
    {
        private int row;
        private int column;
        public ElementFrameViewModel()
        {            
        }

        public ElementFrameViewModel(Element element):base(element)
        {            
        }

        public int Row
        {
            get => row;
            set
            {
                if (value == row) return;
                row = value;
                OnPropertyChanged();
            }
        }

        public int Column
        {
            get => column;
            set
            {
                if (value == column) return;
                column = value;
                OnPropertyChanged();
            }
        }
    }
}