using System;
using Autofac;
using TinyCache;
using TinyMvvm.Autofac;
using TinyMvvm.IoC;
using TinyNavigationHelper;

namespace defaulttemplate
{

    public static class Bootstrapper
    {
        public static void Initialize(App app)
        {
            var builder = new ContainerBuilder();

            var asm = app.GetType().Assembly;
            var vmAsm = typeof(ViewModels.StartViewModel).Assembly;

            // Views
            builder.RegisterAssemblyTypes(asm)
                   .Where(x => x.Name.EndsWith("View", StringComparison.Ordinal));

            // ViewModels
            builder.RegisterAssemblyTypes(vmAsm)
                   .Where(x => x.Name.EndsWith("ViewModel", StringComparison.Ordinal));

            // Services
            builder.RegisterAssemblyTypes(vmAsm)
                   .Where(x => x.Name.EndsWith("Service", StringComparison.Ordinal)).SingleInstance();

            // Navigation
            var navigationHelper = new TinyNavigationHelper.Forms.FormsNavigationHelper(app);
            navigationHelper.RegisterViewsInAssembly(asm);
            builder.RegisterInstance<INavigationHelper>(navigationHelper);

            // Build and set
            var container = builder.Build();
            var resolver = new AutofacResolver(container);
            Resolver.SetResolver(resolver);

            // Init TinyMvvm
            TinyMvvm.Forms.TinyMvvm.Initialize();

            // Init TinyPubSub
            TinyPubSubLib.TinyPubSubForms.Init(app);

            // Init TinyCache
            var cacheFirstPolicy = new TinyCachePolicy().SetMode(TinyCacheModeEnum.CacheFirst).SetFetchTimeout(Settings.Current.FetchTimeout);
            TinyCache.TinyCache.SetCacheStore(new XamarinPropertyStorage());
            TinyCache.TinyCache.SetBasePolicy(cacheFirstPolicy);

            // Platform specifics
            Platform?.Initialize(app, builder);
        }

        public static IBootstrapper Platform { get; set; }
    }

    public interface IBootstrapper
    {
        void Initialize(App app, ContainerBuilder builder);
    }
}
