using Application.Services;
using Application.ViewModel;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionService _regionService;

        public RegionController(DatabaseContext dbContext)
        {
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel saveRegion)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", saveRegion);
            }
            else
            {
                await _regionService.Add(saveRegion);
                return RedirectToRoute(new { controller = "Region", action = "Index" });
            }
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel saveRegion)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", saveRegion);
            }
            else
            {
                await _regionService.Update(saveRegion);
                return RedirectToRoute(new { controller = "Region", action = "Index" });
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
              await _regionService.Delete(id);
              return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
    }
}
