using Architecture.Services.Impl;
using Gameplay.Player;
using Gameplay.Setup;
using NUnit.Framework;

namespace TestsEditMode.PrefabProviding {
    public class ResourcesPrefabProviderTests {
        [Test]
        public void Player_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var player = provider.Player;

            //Assert
            Assert.IsNotNull(player);
        }
        
        [Test]
        public void Player_Is_Character() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var player = provider.Player;
            var character = player.GetComponent<Character>();

            //Assert
            Assert.IsNotNull(character);
        }
        
        [Test]
        public void Orc_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var enemy = provider.Enemy(EnemyId.Orc);

            //Assert
            Assert.IsNotNull(enemy);
        }
        
        [Test]
        public void Beholder_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var enemy = provider.Enemy(EnemyId.Beholder);

            //Assert
            Assert.IsNotNull(enemy);
        }
        
        [Test]
        public void Spiky_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Spiky);

            //Assert
            Assert.IsNotNull(orc);
        }
        
        [Test]
        public void Slime_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Slime);

            //Assert
            Assert.IsNotNull(orc);
        }
        
        [Test]
        public void Golem_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Golem);

            //Assert
            Assert.IsNotNull(orc);
        }
        
        [Test]
        public void Lich_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Lich);

            //Assert
            Assert.IsNotNull(orc);
        }
        
        [Test]
        public void Mimic_Is_Not_Null() {
            //Arrage
            var provider = new ResourcesPrefabProvider();

            //Act
            var orc = provider.Enemy(EnemyId.Mimic);

            //Assert
            Assert.IsNotNull(orc);
        }
    }
}