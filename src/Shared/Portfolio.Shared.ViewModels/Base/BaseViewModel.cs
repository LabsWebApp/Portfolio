using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Portfolio.Shared.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Protected methods
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            //PropertyChanged?.Invoke(
            //    this,
            //    new PropertyChangedEventArgs(propertyName));

            if (PropertyChanged is null)
                return;
            var handler = PropertyChanged;
            var invocationList = handler.GetInvocationList();

            var arg = new PropertyChangedEventArgs(propertyName);
            foreach (var action in invocationList)
                action.DynamicInvoke(this, arg);
        }

        protected virtual bool set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
        #endregion

        #region Dispose
        //~BaseViewModel()
        //{
        //    Dispose(false);
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _disposed) return;
            _disposed = true;
            // Освобождение управляемых ресурсов
        }
        #endregion
    }
}