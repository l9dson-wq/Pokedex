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
    public class PokemonService
    {
        private readonly PokemonRepoitory _pokemonRepository;

        public PokemonService(DatabaseContext dbContext)
        {
            _pokemonRepository = new(dbContext);
        }

        public async Task Add(SavePokemonViewModel sp)
        {
            Pokemon pokemon = new Pokemon();
            pokemon.Name = sp.Name;
            pokemon.Imagepath = sp.Imagepath;
            pokemon.PrimaryType_Id = sp.PrimaryType_Id;
            pokemon.SecundaryType_Id = sp.SecundaryType_Id;
            pokemon.Region_Id = sp.Region_Id;

            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();

            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Name = pokemon.Name,
                Imagepath = pokemon.Imagepath,
                Id = pokemon.Id,
                PrimaryType_Id = pokemon.PrimaryType_Id,
                SecundaryType_Id = pokemon.SecundaryType_Id,
                Region_Id = pokemon.Region_Id,
                Region = pokemon.Region,
                Secundary_pokemonType = pokemon.Secundary_pokemonType,
                Pokemon_type = pokemon.Pokemon_type,
            }).ToList();
        }


        //reescribiendo datos ( update )
        public async Task Update(SavePokemonViewModel sp)
        {
            Pokemon pokemon = new Pokemon();
            pokemon.Id = sp.Id;
            pokemon.Name = sp.Name;
            pokemon.Imagepath = sp.Imagepath;
            pokemon.PrimaryType_Id = sp.PrimaryType_Id;
            pokemon.SecundaryType_Id = sp.SecundaryType_Id;
            pokemon.Region_Id = sp.Region_Id;

            await _pokemonRepository.UpdateAsync(pokemon);
        }

        //eliminar un registro
        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            await _pokemonRepository.DeleteAsync(pokemon);
        }

        //si seleccionamos editar un registro esto devolvera los datos de dicho registro y los mostrara.
        public async Task<SavePokemonViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name;
            vm.Imagepath = pokemon.Imagepath;
            vm.PrimaryType_Id = pokemon.PrimaryType_Id;
            vm.SecundaryType_Id = pokemon.SecundaryType_Id;
            vm.Region_Id = pokemon.Region_Id;

            return vm;
        }

    }
}
