using ElectronMaster.Model;

namespace ElectronMaster.ViewModel
{
    public class ElementFrameViewModel: ElementViewModel
    {
        private int _row;
        private int _column;
        public ElementFrameViewModel()
        {            
        }

        public ElementFrameViewModel(Element element):base(element)
        {            
        }

        public int Row
        {
            get => _row;
            set
            {
                if (value == _row) return;
                _row = value;
                OnPropertyChanged();
            }
        }

        public int Column
        {
            get => _column;
            set
            {
                if (value == _column) return;
                _column = value;
                OnPropertyChanged();
            }
        }
    }
}