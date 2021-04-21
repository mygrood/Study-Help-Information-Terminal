using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SHIT.Views.Calendar.PageModels
{
    public class BasePageModel : INotifyPropertyChanged
    {
        public BasePageModel()
        {
        }
        
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<TData>(ref TData storage, TData value, [CallerMemberName] string propertyName = "")
        {
            if (storage.Equals(value))
                return;

            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
