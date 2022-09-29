using Application.Repoitory;
using Application.ViewModel;
using Database.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonTypeService
    {
        private readonly Pokemon_typeRepository _pokemonTypeRepository;

        public PokemonTypeService(DatabaseContext dbContext)
        {
            _pokemonTypeRepository = new(dbContext);
        }

        public async Task Add(SavePokemonTypeViewModel sp)
        {
            Pokemon_type pokemonType = new Pokemon_type();
            pokemonType.Name = sp.Name;

            await _pokemonTypeRepository.AddAsync(pokemonType);
        }

        public async Task Update(SavePokemonTypeViewModel sp)
        {
            Pokemon_type pokemonType = new Pokemon_type();
            pokemonType.Id = sp.Id;
            pokemonType.Name = sp.Name;

            await _pokemonTypeRepository.UpdateAsync(pokemonType);
        }

        public async Task Delete(int id)
        {
            var pokemonType = await _pokemonTypeRepository.GetByIdAsync(id);
            await _pokemonTypeRepository.DeleteAsync(pokemonType);
        }

        public async Task<SavePokemonTypeViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemonType = await _pokemonTypeRepository.GetByIdAsync(id);

            SavePokemonTypeViewModel vm = new();
            vm.Id = pokemonType.Id;
            vm.Name = pokemonType.Name;

            return vm;
        }

        public async Task<List<PokemonTypeViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonTypeRepository.GetAllAsync();

            return pokemonList.Select(pokemon => new PokemonTypeViewModel
            {
                Name = pokemon.Name,
                Id = pokemon.Id,
            }).ToList();
        }
    }
}
