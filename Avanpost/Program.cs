using Avanpost.DataStruct.Abstract;
using Avanpost.DataStruct.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        const string CommandLookAround = "1";
        const string CommandGo = "2";
        const string CommandTake = "3";
        const string CommandExit = "4";

        Player player = new Player("");
        Dictionary<string, Location> locations = new Dictionary<string, Location>();

        bool isWork = true;

        InitGame(ref locations, ref player);

        while (isWork)
        {
            Console.WriteLine("\nВыберите команду:");
            Console.WriteLine("1. Осмотреться");
            Console.WriteLine("2. Идти");
            Console.WriteLine("3. Взять");
            Console.WriteLine("4. Выйти");
            string playerCommand = Console.ReadLine();

            switch (playerCommand)
            {
                case CommandLookAround:

                    LookAround(player, locations);
                    break;

                case CommandGo:

                    Go(player, locations);
                    break;

                case CommandTake:

                    Take(player, locations);
                    break;

                case CommandExit:
                    isWork = false;
                    Console.WriteLine("Игра завершена.");
                    break;

                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }

    static void LookAround(Player player, Dictionary<string, Location> locations)
    {
        Location currentLocation = locations[player.CurrentLocation];
        Console.WriteLine(currentLocation.Description);

        Console.WriteLine("Доступные пути:");

        foreach (var path in currentLocation.Paths)
        {
            Console.WriteLine($"- {path.Key}");
        }

        Console.WriteLine("Доступные предметы:");

        foreach (var item in currentLocation.Items)
        {
            Console.WriteLine($"- {item.Key}: {item.Value}");
        }
    }

    static void Go(Player player, Dictionary<string, Location> locations)
    {
        Console.WriteLine("Введите направление:");
        string direction = Console.ReadLine();

        if (locations[player.CurrentLocation].Paths.ContainsKey(direction))
        {
            player.CurrentLocation = locations[player.CurrentLocation].Paths[direction];
            Console.WriteLine($"Ты переместился в локацию: {player.CurrentLocation}");
        }
        else
        {
            Console.WriteLine($"Нет пути в направлении '{direction}'.");
        }
    }

    static void Take(Player player, Dictionary<string, Location> locations)
    {
        Console.WriteLine("Введите предмет, который хотите взять:");
        string itemToTake = Console.ReadLine();

        if (locations[player.CurrentLocation].Items.ContainsKey(itemToTake))
        {
            player.Inventory.Add(itemToTake);
            Console.WriteLine($"Предмет '{itemToTake}' добавлен в инвентарь.");
            locations[player.CurrentLocation].Items.Remove(itemToTake);
        }
        else
        {
            Console.WriteLine($"Предмет '{itemToTake}' не найден в этой локации.");
        }
    }

    static void InitGame(ref Dictionary<string, Location> locations, ref Player player)
    {
        locations = CreateLocations();
        player = CreatePlayer("Коридор");
    }

    static Dictionary<string, Location> CreateLocations()
    {
        var locations = new Dictionary<string, Location>();

        var kitchenBuilder = new LocationBuilder();
        var kitchen = kitchenBuilder
            .SetName("Кухня")
            .SetDescription("Ты находишься на кухне. Можно поесть")
            .AddPath("коридор", "Коридор")
            .AddItem("рюкзак", "Рюкзак")
            .Build();
        locations.Add("Кухня", kitchen);

        var corridorBuilder = new LocationBuilder();
        var corridor = corridorBuilder
            .SetName("Коридор")
            .SetDescription("Ты стоишь в коридоре.")
            .AddPath("кухня", "Кухня")
            .AddPath("комната", "Комната")
            .AddPath("улица", "Улица")
            .Build();
        locations.Add("Коридор", corridor);

        var roomBuilder = new LocationBuilder();
        var room = roomBuilder
            .SetName("Комната")
            .SetDescription("Ты в своей комнате. Сейчас бы поспать")
            .AddPath("коридор", "Коридор")
            .AddItem("ключи", "Ключи")
            .Build();
        locations.Add("Комната", room);

        var streetBuilder = new LocationBuilder();
        var street = streetBuilder
            .SetName("Улица")
            .SetDescription("Ты стоишь на улице. Там сегодня холодно(")
            .AddPath("домой", "Коридор")
            .Build();
        locations.Add("Улица", street);

        return locations;
    }

    static Player CreatePlayer(string startingLocation)
    {
        return new Player(startingLocation);
    }
}
