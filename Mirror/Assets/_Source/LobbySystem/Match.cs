using System.Collections.Generic;
using PlayerSystem;

namespace LobbySystem
{
    [System.Serializable]
    public class Match
    {
        public string ID { get; private set; }
        public List<PlayerController> Players { get; private set; }

        public Match() { }

        public Match(string id, PlayerController player)
        {
            Players = new List<PlayerController>();
            ID = id;
            Players.Add(player);
        }
    }
}