using Architecture.Services.Network.Impl;
using Gameplay.Setup;
using NUnit.Framework;

namespace TestsEditMode.PrefabProviding {
    public class ResourcesNetworkPrefabProviderTests {
        [Test]
        public void Player_Is_Not_Null() {
            //Arrange
            var provider = new ResourcesNetworkPrefabProvider();
        
            //Act
            var player = provider.Player;
        
            //Assert
            Assert.NotNull(player);
        }
        
        [Test]
        public void Orc_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesNetworkPrefabProvider();

            //Act
            var enemy = provider.Enemy(EnemyId.Orc);

            //Assert
            Assert.IsNotNull(enemy);
        }
        
        [Test]
        public void Beholder_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesNetworkPrefabProvider();

            //Act
            var enemy = provider.Enemy(EnemyId.Beholder);

            //Assert
            Assert.IsNotNull(enemy);
        }
        
        [Test]
        public void Spiky_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesNetworkPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Spiky);

            //Assert
            Assert.IsNotNull(orc);
        }
        
        [Test]
        public void Slime_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesNetworkPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Slime);

            //Assert
            Assert.IsNotNull(orc);
        }
        
        [Test]
        public void Golem_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesNetworkPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Golem);

            //Assert
            Assert.IsNotNull(orc);
        }
        
        [Test]
        public void Lich_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesNetworkPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Lich);

            //Assert
            Assert.IsNotNull(orc);
        }
        
        [Test]
        public void Mimic_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesNetworkPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Mimic);

            //Assert
            Assert.IsNotNull(orc);
        }
    }
}
