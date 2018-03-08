using System;
using System.ComponentModel;
using System.Threading.Tasks;
using TinyMvvm.Forms;

namespace defaulttemplate
{
    public abstract class NormalViewBase<T> : ViewBase<T> where T : INotifyPropertyChanged
    {
        private string _viewName;
        internal string ViewName
        {
            get
            {
                if (string.IsNullOrEmpty(_viewName))
                {
                    _viewName = this.GetType().Name;
                }
                return _viewName;
            }
        }

        protected override void OnAppearing()
        {
            ViewHelper.Current.OnViewAppearing?.Invoke(this, this);
            base.OnAppearing();
            Task.Run(async () => await TrackView());
        }

        private async Task TrackView()
        {
            await TinyInsightsLib.TinyInsights.TrackPageViewAsync(ViewName);
        }

        protected override void OnDisappearing()
        {
            ViewHelper.Current.OnViewDisappearing?.Invoke(this, this);
            base.OnDisappearing();
        }
    }
}
