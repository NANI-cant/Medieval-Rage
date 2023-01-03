﻿using Architecture.Services.Network.Impl;
using Zenject;

namespace Architecture.Bootstrappers {
    public class GameplayNetworkBootstrapper : MonoInstaller {
        public override void InstallBindings() {
            BindService<ResourcesNetworkPrefabProvider>();
            BindService<GameClockSync>();
            
            //BindService<NetworkGameplayFactory>();
            BindService<NewNetworkGameplayFactory>();
            BindService<GameplayFactorySync>();
            
            BindService<NetworkGameEnd>();
            BindService<GameEndSync>();
        }

        private void BindService<TService>() 
            => Container.BindInterfacesAndSelfTo<TService>().AsSingle().NonLazy();
    }
}