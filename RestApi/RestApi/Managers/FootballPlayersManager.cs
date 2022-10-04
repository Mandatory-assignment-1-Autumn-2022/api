using ClassLibrary;
namespace RestApi.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextID = 1;
        private static readonly List<FootballPlayer> _data = new List<FootballPlayer>()
        {
            new FootballPlayer() {Id = _nextID++, Name = "Adam", Age = 20, ShirtNumber = 15},
            new FootballPlayer() {Id = _nextID++, Name = "Patrik", Age = 22, ShirtNumber = 45},
            new FootballPlayer() {Id = _nextID++, Name = "Martin", Age = 21, ShirtNumber = 55},
            new FootballPlayer() {Id = _nextID++, Name = "Mo", Age = 20, ShirtNumber = 66},
        };

        public IEnumerable<FootballPlayer> GetAll()
        {
            List<FootballPlayer> result = new List<FootballPlayer>(_data);
          
            return result;
        }

        public FootballPlayer? GetById(int Id)
        {
            return _data.Find(flower => flower.Id == Id);
        }

        public FootballPlayer Add(FootballPlayer newPlayer)
        {
            newPlayer.Validate();
            newPlayer.Id = _nextID++;
            _data.Add(newPlayer);
            return newPlayer;
        }

        public FootballPlayer? Delete(int Id)
        {
            FootballPlayer? player = GetById(Id);
            if (player == null)
            {
                return null;
            }
            _data.Remove(player);
            return player;
        }

        public FootballPlayer? Update(int id, FootballPlayer updates)
        {
            updates.Validate();
            FootballPlayer? player = GetById(id);
            if (player == null)
            {
                return null;
            }
            player.Name = updates.Name;
            player.Age = updates.Age;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }
    }
}
