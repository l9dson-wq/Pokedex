using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Navigation Property
        public ICollection<Pokemon> Pokemones { get; set; }
    }
}
