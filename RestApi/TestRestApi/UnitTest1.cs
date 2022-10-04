using ClassLibrary;
using RestApi.Managers;

namespace TestRestApi
{
    [TestClass]
    public class UnitTest1
    {
        FootballPlayersManager _manager = new FootballPlayersManager();

       

        [TestMethod]
        public void Test_Add_Success()
        {
            FootballPlayer player = new FootballPlayer() { Id = 0, Name = "adamaaaa", Age = 45, ShirtNumber = 21 };
            _manager.Add(player);
        }

        [TestMethod]
        public void Test_Add_ThrowsOutOfRangeExeption()
        {
            FootballPlayer player = new FootballPlayer() { Id = 0, Name = "adamaaaa", Age = 45, ShirtNumber = 210 };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _manager.Add(player));
        }

        [TestMethod]
        public void Test_GetById_ReturnsNull()
        {
            Assert.IsNull(_manager.GetById(99));
        }
    }
}