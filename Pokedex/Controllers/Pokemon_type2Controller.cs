using Application.Services;
using Application.ViewModel;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class Pokemon_type2Controller : Controller
    {
        private readonly PokemonType2Service _pokemonType2Repository;

        public Pokemon_type2Controller(DatabaseContext dbContext)
        {
            _pokemonType2Repository = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonType2Repository.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SavePokemonType", new SavePokemonType2ViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonType2ViewModel savePokemon2TypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", savePokemon2TypeViewModel);
            }
            else
            {
                await _pokemonType2Repository.Add(savePokemon2TypeViewModel);
                return RedirectToRoute(new { controller = "Pokemon_type2", action = "Index" });
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SavePokemonType", await _pokemonType2Repository.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonType2ViewModel saveType)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", saveType);
            }
            else
            {
                await _pokemonType2Repository.Update(saveType);
                return RedirectToRoute(new { controller = "Pokemon_type2", action = "Index" });
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonType2Repository.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonType2Repository.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon_type2", action = "Index" });
        }

    }
}
