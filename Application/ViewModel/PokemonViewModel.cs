using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imagepath { get; set; }
        public int PrimaryType_Id { get; set; }
        public int? SecundaryType_Id { get; set; }
        public int Region_Id { get; set; }

        public Pokemon_type Pokemon_type { get; set; }
        public Region Region { get; set; }
        public Pokemon_type Secundary_pokemonType { get; set; }
    }
}
