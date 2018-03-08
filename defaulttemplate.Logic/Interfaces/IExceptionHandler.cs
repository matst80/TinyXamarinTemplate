using System;
using System.Threading.Tasks;

namespace defaulttemplate
{
    public interface IExceptionHandler
    {
        Task HandleSilent(Exception ex, string message = "");
        Task HandleWithUi(Exception ex, string message = "");
    }
}