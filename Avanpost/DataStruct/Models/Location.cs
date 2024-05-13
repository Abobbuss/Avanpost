using System.Collections.Generic;

namespace Avanpost.DataStruct.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Paths { get; set; }
        public Dictionary<string, string> Items { get; set; }
        public List<PlayerCommands> PossibleActions { get; set; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Paths = new Dictionary<string, string>();
            Items = new Dictionary<string, string>();
            PossibleActions = new List<PlayerCommands>();
        }

        public void AddAction(PlayerCommands action)
        {
            PossibleActions.Add(action);
        }

        public void RemoveAction(PlayerCommands action)
        {
            PossibleActions.Remove(action);
        }

        public void AddItem(string itemName, string itemDescription)
        {
            Items.Add(itemName, itemDescription);
        }

        public void RemoveItem(string itemName)
        {
            Items.Remove(itemName);
        }
    }
}
