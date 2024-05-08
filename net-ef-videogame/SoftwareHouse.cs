using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("software_houses")]
    [Index(nameof(SoftrwareHouseId))]
    public class SoftwareHouse
    {
        [Key] public int SoftrwareHouseId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Videogame> Videogame { get; set; }  // chiave esterna rapporto 1:N

        public SoftwareHouse(string name, string taxId, string city, string country,  DateTime createdAt, DateTime updatedAt)
        {
            Name = name;
            TaxId = taxId;
            City = city;
            Country = country;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public SoftwareHouse()
        {
        }
    }
}