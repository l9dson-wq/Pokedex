using Application.Repoitory;
using Application.ViewModel;
using Database.Models;
using Database;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegionService
    {
        private readonly RegionRepository _RegionRepository;

        public RegionService(DatabaseContext dbContext)
        {
            _RegionRepository = new(dbContext);
        }

        //para agregar un registro nuevo
        public async Task Add(SaveRegionViewModel sp)
        {
            Region region = new Region();
            region.Name = sp.Name;

            await _RegionRepository.AddAsync(region);
        }

        //reescribiendo datos ( update )
        public async Task Update(SaveRegionViewModel sp)
        {
            Region region = new Region();
            region.Id = sp.Id; 
            region.Name = sp.Name;

            await _RegionRepository.UpdateAsync(region);
        }

        //eliminar un registro
        public async Task Delete(int id)
        {
            var region = await _RegionRepository.GetByIdAsync(id);
            await _RegionRepository.DeleteAsync(region);
        }

        //si seleccionamos editar un registro esto devolvera los datos de dicho registro y los mostrara.
        public async Task<SaveRegionViewModel> GetByIdSaveViewModel(int id)
        {
            var region = await _RegionRepository.GetByIdAsync(id);

            SaveRegionViewModel vm = new();
            vm.Id = region.Id;
            vm.Name = region.Name;

            return vm;
        }

        //este metodo devuelve una lista de todos los registro de una tabla
        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var RegionList = await _RegionRepository.GetAllAsync();

            return RegionList.Select(pokemon => new RegionViewModel
            {
                Name = pokemon.Name,
                Id = pokemon.Id,
            }).ToList();
        }
    }
}
