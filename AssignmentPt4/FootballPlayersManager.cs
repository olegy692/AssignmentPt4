using Assignment1_Prog_n_tech;

namespace AssignmentPt4
{
    public class FootballPlayersManager
    {

        private static int _nextId = 1;
        private static readonly List<FootballPlayer> PlayerList = new List<FootballPlayer>
        {
            new FootballPlayer {Id = _nextId++, Name = "Bo", Age = 25, ShirtNumber = 35},
            new FootballPlayer {Id = _nextId++, Name = "Bob", Age = 27, ShirtNumber = 32},
            new FootballPlayer {Id = _nextId++, Name = "Bobby", Age = 24, ShirtNumber = 13},
            new FootballPlayer {Id = _nextId++, Name = "Boooob", Age = 29, ShirtNumber = 3},

        };


        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(PlayerList);
            
        }

        public FootballPlayer? GetById(int id)
        {
            return PlayerList.Find(player => player.Id == id);
        }

        public FootballPlayer? Add(FootballPlayer newPlayer)
        {
            newPlayer.Id = _nextId++;
            PlayerList.Add(newPlayer);
            return newPlayer;
        }

        public FootballPlayer? Delete(int id)
        {
            FootballPlayer? players = PlayerList.Find(player1 => player1.Id == id);
            if (players == null) return null;
            PlayerList.Remove(players);
            return players;
        }

        public FootballPlayer? Update(int id, FootballPlayer updates)
        {
            FootballPlayer? player = PlayerList.Find(player1 => player1.Id == id);
            if (player == null) return null;
            player.Age = updates.Age;
            player.Name = updates.Name;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }



    }




}
