using Application.Services;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using System.Diagnostics;
using System.Linq;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly DatabaseContext dbContext;

        public HomeController(DatabaseContext dbContext)
        {
            _pokemonService = new(dbContext);
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var listRegions = dbContext.Regions.ToList();
            ViewBag.listTypes = listRegions;

            var pokemon = dbContext.pokemones
                     .Include("Region")
                     .Include("Pokemon_type")
                     .Include("Secundary_pokemonType")
                     .ToList();

            return View(pokemon);
        }

        [HttpPost]
        public IActionResult Index(int? SearchByType, string? SearchString)
        {
            var listRegions = dbContext.Regions.ToList();
            ViewBag.listTypes = listRegions;

            var types = dbContext.pokemones
                     .Where(p => p.Region_Id == SearchByType)
                     .Include("Region")
                     .Include("Pokemon_type")
                     .Include("Secundary_pokemonType")
                     .ToList();

            var pokemon = dbContext.pokemones
                     .Where(p => p.Name == SearchString)
                     .Include("Region")
                     .Include("Pokemon_type")
                     .Include("Secundary_pokemonType")
                     .ToList();

            return View((pokemon.Count == 0 ? types : pokemon));
        }
    }
}