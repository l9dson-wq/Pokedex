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
    public class PokemonType2Service
    {
        private readonly PokemonType2Repository _PokemonType2Repository;

        public PokemonType2Service(DatabaseContext dbContext)
        {
            _PokemonType2Repository = new(dbContext);
        }

        public async Task Add(SavePokemonType2ViewModel sp)
        {
            Pokemon_type2 pokemonType = new Pokemon_type2();
            pokemonType.Name = sp.Name;

            await _PokemonType2Repository.AddAsync(pokemonType);
        }

        public async Task Update(SavePokemonType2ViewModel sp)
        {
            Pokemon_type2 pokemonType = new Pokemon_type2();
            pokemonType.Id = sp.Id;
            pokemonType.Name = sp.Name;

            await _PokemonType2Repository.UpdateAsync(pokemonType);
        }

        public async Task Delete(int id)
        {
            var Pokemon_type2 = await _PokemonType2Repository.GetByIdAsync(id);
            await _PokemonType2Repository.DeleteAsync(Pokemon_type2);
        }

        public async Task<SavePokemonType2ViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemonType = await _PokemonType2Repository.GetByIdAsync(id);

            SavePokemonType2ViewModel vm = new();
            vm.Id = pokemonType.Id;
            vm.Name = pokemonType.Name;

            return vm;
        }

        public async Task<List<PokemonType2ViewModel>> GetAllViewModel()
        {
            var pokemonList = await _PokemonType2Repository.GetAllAsync();

            return pokemonList.Select(pokemon => new PokemonType2ViewModel
            {
                Name = pokemon.Name,
                Id = pokemon.Id,
            }).ToList();
        }
    }
}
