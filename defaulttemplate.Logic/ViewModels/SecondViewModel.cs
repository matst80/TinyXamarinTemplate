using System;
using System.Threading.Tasks;
using System.Windows.Input;
using defaulttemplate.Logic;
using TinyMvvm.IoC;

namespace defaulttemplate.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public ICommand CreateError => new Command(() =>
        {
            Task.Run(() =>
            {
                throw new NotSupportedException();
            });
        });
    }
}
