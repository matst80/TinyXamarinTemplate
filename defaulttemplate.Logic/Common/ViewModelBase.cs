using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace defaulttemplate.Logic
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ViewModelBase : TinyMvvm.ViewModelBase
    {
        protected bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (value == null ? field != null : !value.Equals(field))
            {
                field = value;

                RaisePropertyChanged(propertyName);
                return true;
            }
            return false;
        }
    }
}
