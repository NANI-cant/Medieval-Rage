using Architecture.Services.Impl;
using Zenject;

namespace Architecture.Bootstrappers {
    public class ProjectBootstrapper : MonoInstaller{
		public override void InstallBindings()
		{
			Container.Bind<int>().FromInstance(0).WhenInjectedInto<RandomService>();
			BindService<RandomService>();
			BindService<ResourcesMetricProvider>();
			BindService<ResourcesPrefabProvider>();
			BindService<ResourcesUIProvider>();
			BindService<UnityTimeProvider>();
			BindService<UIFactory>();
		}

        private void BindService<TService>() 
			=> Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}