using KatmanliBlogSitesi.Data.Abstract;
using KatmanliBlogSitesi.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebUI.Controllers
{
  
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _service.GetCategoryByPostsAsync(id);

            return View(model);
        }
    }
}
