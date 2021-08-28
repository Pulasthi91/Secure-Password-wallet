using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace PasswordGenerater
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            try
            {
                PropertyChangedEventHandler propertyChanged = PropertyChanged;

                if (propertyChanged != null)
                    propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception)
            {

            }
        }

        protected object GetValue(NotifyingProperty notifyingProperty)
        {
            return notifyingProperty.Value;
        }

        protected void SetValue(NotifyingProperty notifyingProperty, object value, bool forceUpdate = false)
        {
            if (notifyingProperty.Value != value || forceUpdate)
            {
                notifyingProperty.Value = value;

                OnPropertyChanged(notifyingProperty.Name);
            }
        }
    }
}
