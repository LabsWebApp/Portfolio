using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Portfolio.Shared.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //private string _mainDiskName;

        //public string MainDiskName
        //{
        //    get => _mainDiskName;
        //    set
        //    {
        //        _mainDiskName = value;
        //        OnPropertyChanged();
        //    }
        //}
        #region Public Properties
        public string MainDiskName { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Construktors
        public MainViewModel()
        {
            // _mainDiskName = Environment.SystemDirectory;
            MainDiskName = Environment.SystemDirectory;
        }
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
