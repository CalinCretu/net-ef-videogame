using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public static class VideogameManager
    {
        public static void InsertVideogame(string name, string overview)
        {
            using (var context = new VideogameContext()) 
            {
                try
                {
                    var newVideogame = new Videogame
                    {
                        Name = name,
                        Overview = overview,
                        ReleaseDate = new DateTime(1985, 1, 1),
                        CreatedAt = new DateTime(1985, 1, 1),
                        UpdatedAt = new DateTime(2002, 1, 1),
                        SoftwareHouseId = 1 // Sostituisci con l'ID effettivo della software house
                    };

                    context.Videogames.Add(newVideogame);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public static Videogame GetVideogameById(int id)
        {
            using (var context = new VideogameContext()) 
            {
                return context.Videogames.FirstOrDefault(v => v.Id == id);
            }
        }

        public static List<Videogame> SearchGamesByName(string searchName)
        {
            using (var context = new VideogameContext()) 
            {
                return context.Videogames.Where(v => v.Name.Contains(searchName)).ToList();
            }
        }

        public static void DeleteVideogame(int id)
        {
            using (var context = new VideogameContext()) 
            {
                var videogame = context.Videogames.FirstOrDefault(v => v.Id == id);
                if (videogame != null)
                {
                    context.Videogames.Remove(videogame);
                    context.SaveChanges();
                    Console.WriteLine("Videogame successfully deleted.");
                }
                else
                {
                    Console.WriteLine("No videogames found with this Id.");
                }
            }
        }
    }
}
