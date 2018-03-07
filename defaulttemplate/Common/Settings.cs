using System;

namespace defaulttemplate
{
    public class Settings
    {
        private static Settings _current;
        public static Settings Current
        {
            get
            {
                return _current ?? (_current = new Settings());
            }
        }

        public TimeSpan FetchTimeout { get; set; } = TimeSpan.FromSeconds(2);
    }
}
