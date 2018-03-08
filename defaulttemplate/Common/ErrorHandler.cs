using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace defaulttemplate
{
    public class InsightsErrorHandler : IExceptionHandler
    {
        public async Task HandleSilent(Exception ex, string message = "")
        {
            await TinyInsightsLib.TinyInsights.TrackErrorAsync(ex);
        }

        public Task HandleWithUi(Exception ex, string message = "")
        {
            return HandleSilent(ex, message);
        }
    }

    public class DebugErrorHandler : IExceptionHandler
    {
        public DebugErrorHandler(Action<string> displayError) {
            DisplayError = displayError;
        }

        public Task HandleSilent(Exception ex, string message = "")
        {
            var msg = ex.Message;
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine($"ERROR: {message} ->");
                msg = message;
            }
            Console.WriteLine(ex);
            DisplayError?.Invoke(msg);
            return Task.CompletedTask;
        }

        public Action<string> DisplayError { get; internal set; }

        public Task HandleWithUi(Exception ex, string message = "")
        {
            return HandleSilent(ex, message);
        }
    }

    public static class ErrorHandler
    {
        private static List<IExceptionHandler> _handlers = new List<IExceptionHandler>();

        public static void AddHandler(IExceptionHandler handler)
        {
            if (!_handlers.Contains(handler))
            {
                _handlers.Add(handler);
            }
        }

        public static bool HandleSilent(Exception ex, string message = "")
        {
            var handled = false;
            foreach (var hdl in _handlers)
            {
                handled = true;
                Task.Run(async () =>
                {
                    await hdl.HandleSilent(ex, message);
                });
            }
            return handled;
        }

        public static bool HandleWithUi(Exception ex, string message = "")
        {
            var handled = false;
            foreach (var hdl in _handlers)
            {
                handled = true;
                Task.Run(async () =>
                {
                    await hdl.HandleWithUi(ex, message);
                });
            }
            return handled;
        }
    }
}
