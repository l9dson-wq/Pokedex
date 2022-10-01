using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class SavePokemonType2ViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre para poder continuar")]
        public string Name { get; set; }
    }
}
