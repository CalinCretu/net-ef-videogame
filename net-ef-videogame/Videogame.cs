using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace net_ef_videogame
{
    public class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long SoftwareHouseId { get; set; } // chiave esterna tabella software_houses

        public Videogame(string name, string overview, DateTime releaseDate, DateTime createdAt, DateTime updatedAt, long softwareHouseId)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            SoftwareHouseId = softwareHouseId;
        }
    }
}
