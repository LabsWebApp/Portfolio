using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Portfolio.Shared.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Protected methods
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}