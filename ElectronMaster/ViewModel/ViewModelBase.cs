using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ElectronMaster.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected T FluentOnPropertyChanged<T>(T value, [CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            return value;
        }
    }
}
