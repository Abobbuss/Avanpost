using Avanpost.DataStruct.Models;
using System.Collections.Generic;

namespace Avanpost.DataStruct.Abstract
{
    public class LocationBuilder
    {
        private string _name;
        private string _description;
        private Dictionary<string, string> _paths;
        private Dictionary<string, string> _items;

        public LocationBuilder() => Reset();

        public void Reset()
        {
            _name = "";
            _description = "";
            _paths = new Dictionary<string, string>();
            _items = new Dictionary<string, string>();
        }

        public LocationBuilder SetName(string name)
        {
            _name = name;

            return this;
        }

        public LocationBuilder SetDescription(string description)
        {
            _description = description;

            return this;
        }

        public LocationBuilder AddPath(string direction, string destination)
        {
            _paths[direction] = destination;

            return this;
        }

        public LocationBuilder AddItem(string itemName, string itemDescription)
        {
            _items[itemName] = itemDescription;

            return this;
        }

        public Location Build()
        {
            var location = new Location(_name, _description);

            foreach (var path in _paths)
            {
                location.Paths.Add(path.Key, path.Value);
            }

            foreach (var item in _items)
            {
                location.Items.Add(item.Key, item.Value);
            }

            return location;
        }
    }
}
