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
        private static bool hasRunEarlyInit = false;

        private static ContainerBuilder builder = new ContainerBuilder();

        private static System.Reflection.Assembly mainAsm = typeof(StartView).Assembly;
        private static System.Reflection.Assembly logicAsm = typeof(ViewModels.StartViewModel).Assembly;

        public static void EarlyInitialize()
        {
            
            // Views
            builder.RegisterAssemblyTypes(mainAsm)
                   .Where(x => x.Name.EndsWith("View", StringComparison.Ordinal));

            // ViewModels
            builder.RegisterAssemblyTypes(logicAsm)
                   .Where(x => x.Name.EndsWith("ViewModel", StringComparison.Ordinal));

            // Services
            builder.RegisterAssemblyTypes(logicAsm)
                   .Where(x => x.Name.EndsWith("Service", StringComparison.Ordinal)).SingleInstance();
            hasRunEarlyInit = true;
        }

        public static void Initialize(App app)
        {
            if (!hasRunEarlyInit)
                EarlyInitialize();

            // Navigation
            var navigationHelper = new TinyNavigationHelper.Forms.FormsNavigationHelper(app);
            navigationHelper.RegisterViewsInAssembly(mainAsm);
            builder.RegisterInstance<INavigationHelper>(navigationHelper);

            // Platform specifics
            Platform?.Initialize(app, builder);

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


        }

        public static IBootstrapper Platform { get; set; }
    }

    public interface IBootstrapper
    {
        void Initialize(App app, ContainerBuilder builder);
    }
}
