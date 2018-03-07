using System;
using Xamarin.Forms;

namespace defaulttemplate
{
    public class ViewHelper
    {
        private static ViewHelper _current;
        public static ViewHelper Current
        {
            get
            {
                return _current ?? (_current = new ViewHelper());
            }
        }

        public EventHandler<Page> OnViewAppearing;

        public EventHandler<Page> OnViewDisappearing;

        public ViewHelper()
        {
        }
    }
}
