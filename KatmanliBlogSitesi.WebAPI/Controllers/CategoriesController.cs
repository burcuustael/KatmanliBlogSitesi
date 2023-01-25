using KatmanliBlogSitesi.Entities;
using KatmanliBlogSitesi.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _categoryService.GetAllAsync();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<Category> GetAsync(int id)
        {
            return await _categoryService.GetCategoryByPostsAsync(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<Category> PostAsync([FromBody] Category value)
        {
            await _categoryService.AddAsync(value);
            await _categoryService.SaveChangesAsync();
            return value;
            
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Category value)
        {
            _categoryService.Update(value);
            _categoryService.SaveChanges();
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var kayit = _categoryService.Find(id);
            if(kayit== null)
            {
                return BadRequest();
            }
            _categoryService.Delete(kayit);
            _categoryService.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
