﻿using ElectronMaster.Model;

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
            set => _element = FluentOnPropertyChanged(value);
        }

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = FluentOnPropertyChanged(value);
        }
    }
}