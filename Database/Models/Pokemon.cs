using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Imagepath { get; set; }

        public int PrimaryType_Id { get; set; }

        public int? SecundaryType_Id { get; set; } //puede ser o tener un valor null

        public int Region_Id { get; set; }

        public Pokemon_type Pokemon_type { get; set; }
        public Region Region { get; set; }
        public Pokemon_type2? Secundary_pokemonType { get; set; }
    }
}
