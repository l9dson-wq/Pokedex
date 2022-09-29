using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{

    public class SavePokemonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Debe colocar el nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la URL de la imagen")]
        public string Imagepath { get; set; }

        [Required(ErrorMessage = "Debe colocar el Tipo priario")]
        public int PrimaryType_Id { get; set; }

        public int? SecundaryType_Id { get; set; }

        [Required(ErrorMessage = "Debe colocar la region")]
        public int Region_Id { get; set; }
    }
}
