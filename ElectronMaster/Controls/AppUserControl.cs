using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ElectronMaster.Annotations;

namespace ElectronMaster.Controls
{
    public class AppUserControl:UserControl,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
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