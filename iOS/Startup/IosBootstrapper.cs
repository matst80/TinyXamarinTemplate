using System;
using Autofac;

namespace defaulttemplate.iOS
{
    public class IosBootstrapper : IBootstrapper
    {
        public void Initialize(App app, ContainerBuilder builder)
        {
            var toolbarHelper = new PlatformHelper();
            builder.RegisterInstance<IPlatformHelper>(toolbarHelper);
        }
    }
}
