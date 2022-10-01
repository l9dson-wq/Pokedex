using Application.Repoitory;
using Application.Services;
using Application.ViewModel;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class Pokemon_typeController : Controller
    {
        private readonly PokemonTypeService _pokemonTypeRepository;

        public Pokemon_typeController(DatabaseContext dbContext)
        {
            _pokemonTypeRepository = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonTypeRepository.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SavePokemonType", new SavePokemonTypeViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonTypeViewModel savePokemonTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", savePokemonTypeViewModel);
            }
            else
            {
                await _pokemonTypeRepository.Add(savePokemonTypeViewModel);
                return RedirectToRoute(new { controller = "Pokemon_type", action = "Index" });
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SavePokemonType", await _pokemonTypeRepository.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonTypeViewModel saveType)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", saveType);
            }
            else
            {
                await _pokemonTypeRepository.Update(saveType);
                return RedirectToRoute(new { controller = "Pokemon_type", action = "Index" });
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonTypeRepository.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonTypeRepository.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon_type", action = "Index" });
        }

        // Datos para la segundo tabla de las tipo secundarios

    }
}
