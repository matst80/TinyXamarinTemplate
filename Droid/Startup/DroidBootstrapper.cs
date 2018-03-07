using System;
using Android.Content;
using Autofac;

namespace defaulttemplate.Droid
{
    public class DroidBootstrapper : IBootstrapper
    {
        public void Initialize(App app, ContainerBuilder builder)
        {
            builder.RegisterInstance<IToolbarHelper>(new ToolbarHelper());
        }
    }
}
