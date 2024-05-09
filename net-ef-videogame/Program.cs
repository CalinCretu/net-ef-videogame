namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                // Creazione di una nuova software house
                SoftwareHouse softwareHouse = new SoftwareHouse()
                {
                    Name = "Giochi Brutti2",
                    TaxId = "Tax ID 1233",
                    City = "Città del Vaticano2",
                    Country = "Coutry House2",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Aggiunta della software house al database
                using (VideogameContext db = new VideogameContext())
                {
                    db.SoftwareHouses.Add(softwareHouse);
                    db.SaveChanges();
                }

                // Creazione di un nuovo videogioco
                Videogame videogame = new Videogame()
                {
                    Name = "Super Luigi",
                    Overview = "Game about bros fighting ninja turtles",
                    ReleaseDate = new DateTime(),
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    SoftwareHouseId = softwareHouse.SoftrwareHouseId // Utilizzo dell'ID della software house appena inserita
                };

                // Aggiunta del videogioco al database
                using (VideogameContext db = new VideogameContext())
                {
                    db.Videogames.Add(videogame);
                    db.SaveChanges();
                }
            }
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a new videogame");
                Console.WriteLine("2. Search a videogame by Id");
                Console.WriteLine("3. Search for all the videogames with this word in their name");
                Console.WriteLine("4. Delete a videogame");
                Console.WriteLine("5. Quit");
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewGame();
                        break;
                    case "2":
                        SearchGameById();
                        break;
                    case "3":
                        SearchGamesByName();
                        break;
                    case "4":
                        DeleteGame();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again!\n");
                        break;
                }
            }
        }

        static void AddNewGame()
        {
            Console.WriteLine("\nAdd a new game to the library:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Overview: ");
            string overview = Console.ReadLine();

            VideogameManager.InsertVideogame(name, overview);
            Console.WriteLine("\nNew videogame added to library!    ***********\n");
        }
        static void SearchGameById()
        {
            Console.Write("\nSearch a videogame by its ID: ");
            string inputId = Console.ReadLine();
            int id;

            if (int.TryParse(inputId, out id))
            {
                Videogame game = VideogameManager.GetVideogameById(id);
                if (game != null)
                {
                    Console.WriteLine($"\nA videogame has been found: {game.Name}\n");
                }
                else
                {
                    Console.WriteLine("\nNo videogames has been found.\n");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid ID.\n");
            }
        }
        static void SearchGamesByName()
        {
            Console.Write("\nWrite the word you are looking for: ");
            string searchName = Console.ReadLine();

            var games = VideogameManager.SearchGamesByName(searchName);
            if (games.Count > 0)
            {
                Console.WriteLine("\nVidegames found:");
                foreach (var game in games)
                {
                    Console.WriteLine($"\nName: {game.Name}\n");
                }
            }
            else
            {
                Console.WriteLine("\nNo videogames has been found.\n");
            }
        }
        static void DeleteGame()
        {
            Console.Write("\nWrite the videogame Id you would like to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nInvalid Id.\n");
                return;
            }

            VideogameManager.DeleteVideogame(id);
        }
    }
}
