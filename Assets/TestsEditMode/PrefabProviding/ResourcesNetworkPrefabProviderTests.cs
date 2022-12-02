using Architecture.Services.Network.Impl;
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
    }
}
