using Architecture.Services;
using Architecture.Services.Impl;
using Metrics;
using UnityEngine;
using Zenject;

namespace Architecture.Bootstrappers {
    public class ProjectBootstrapper : MonoInstaller, ICoroutineRunner {
	    [SerializeField] private GameMetric _metric;
	    
		public override void InstallBindings()
		{
			Container.Bind<int>().FromInstance(_metric.Seed).WhenInjectedInto<RandomService>();
			Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle().NonLazy();
			
			BindService<UnitySceneLoadService>();
			BindService<ResourcesMetricProvider>();
			BindService<ResourcesPrefabProvider>();
			BindService<ResourcesUIProvider>();
			BindService<UnityTimeProvider>();
			BindService<UnityInstantiateProvider>();
		}

        private void BindService<TService>() 
			=> Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}