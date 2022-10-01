using Application.Services;
using Application.ViewModel;
using Database;
using Database.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {

        private readonly PokemonService _pokemonService;
        private readonly DatabaseContext _dbContext;

        public PokemonController(DatabaseContext dbContext)
        {
            _pokemonService = new(dbContext);
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            var listRegions = _dbContext.Regions.ToList();
            ViewBag.listRegions = listRegions;

            var listTypes = _dbContext.pokemon_type.ToList();
            ViewBag.listTypes = listTypes;

            var listTypes2 = _dbContext.pokemon_type2.ToList();
            ViewBag.listypes2 = listTypes2;

            return RedirectToAction("SavePokemon");
        }

        public IActionResult SavePokemon()
        {
            var listRegions = _dbContext.Regions.ToList();
            ViewBag.listRegions = listRegions;

            var listTypes = _dbContext.pokemon_type.ToList();
            ViewBag.listTypes = listTypes;

            var listTypes2 = _dbContext.pokemon_type2.ToList();
            ViewBag.listypes2 = listTypes2;

            return View(new SavePokemonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel savePokemonViewModel)
        {
            var listRegions = _dbContext.Regions.ToList();
            ViewBag.listRegions = listRegions;

            var listTypes = _dbContext.pokemon_type.ToList();
            ViewBag.listTypes = listTypes;

            var listTypes2 = _dbContext.pokemon_type2.ToList();
            ViewBag.listypes2 = listTypes2;

            if (!ModelState.IsValid)
            { 
                return View("SavePokemon", savePokemonViewModel);
            }else
            {
                await _pokemonService.Add(savePokemonViewModel);
                return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var listRegions = _dbContext.Regions.ToList();
            ViewBag.listRegions = listRegions;

            var listTypes = _dbContext.pokemon_type.ToList();
            ViewBag.listTypes = listTypes;

            var listTypes2 = _dbContext.pokemon_type2.ToList();
            ViewBag.listypes2 = listTypes2;

            return View("SavePokemon", await _pokemonService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel savePokemon)
        {
            var listRegions = _dbContext.Regions.ToList();
            ViewBag.listRegions = listRegions;

            var listTypes = _dbContext.pokemon_type.ToList();
            ViewBag.listTypes = listTypes;

            var listTypes2 = _dbContext.pokemon_type2.ToList();
            ViewBag.listypes2 = listTypes2;

            if (!ModelState.IsValid)
            {
                return View("SavePokemon", savePokemon);
            }
            else
            {
                await _pokemonService.Update(savePokemon);
                return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
    }
}
