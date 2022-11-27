using Architecture.Services.Impl;
using Metrics;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class ProjectBootstrapper : MonoInstaller {
	    [SerializeField] private GameMetric _metric;
	    
		public override void InstallBindings()
		{
			Container.Bind<int>().FromInstance(_metric.Seed).WhenInjectedInto<RandomService>();
			BindService<RandomService>();
			BindService<ResourcesMetricProvider>();
			BindService<ResourcesPrefabProvider>();
			BindService<ResourcesUIProvider>();
			BindService<UnityTimeProvider>();
			BindService<UnityInstantiateProvider>();
			BindService<ResetUnitService>();
		}

        private void BindService<TService>() 
			=> Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}