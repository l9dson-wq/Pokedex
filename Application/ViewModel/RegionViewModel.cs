using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class RegionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Navigation Property
        public ICollection<Pokemon> Pokemones { get; set; }
    }
}
