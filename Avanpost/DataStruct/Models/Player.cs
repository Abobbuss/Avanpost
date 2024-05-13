using System.Collections.Generic;

namespace Avanpost.DataStruct.Models
{
    public class Player
    {
        public string CurrentLocation { get; set; }
        public List<string> Inventory { get; set; }
        public List<PlayerCommands> Commands { get; set; }

        public Player(string startingLocation)
        {
            CurrentLocation = startingLocation;
            Inventory = new List<string>();
            Commands = new List<PlayerCommands> { PlayerCommands.LookAround, PlayerCommands.Go, PlayerCommands.Take };
        }
    }
}
