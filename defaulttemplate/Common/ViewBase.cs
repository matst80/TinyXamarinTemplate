using System;
using System.ComponentModel;
using TinyMvvm.Forms;

namespace defaulttemplate
{
    public abstract class NormalViewBase<T> : ViewBase<T> where T : INotifyPropertyChanged
    {
        protected override void OnAppearing()
        {
            ViewHelper.Current.OnViewAppearing?.Invoke(this, this);
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            ViewHelper.Current.OnViewDisappearing?.Invoke(this, this);
            base.OnDisappearing();
        }
    }
}
