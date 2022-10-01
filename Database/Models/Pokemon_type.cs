using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon_type
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Navigation property
        public ICollection<Pokemon> Pokemones { get; set; }
        
    }
}
