using KatmanliBlogSitesi.Data.Abstract;
using KatmanliBlogSitesi.Entities;
using KatmanliBlogSitesi.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public async Task<IEnumerable<Post>> GetAsync()
        {
            return await _postService.GetAllPostsByCategoriesAsync();
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public async Task<Post> GetAsync(int id)
        {
            return await _postService.GetPostByCategoriesAsync(id);
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task<Post> PostAsync([FromBody] Post value)
        {
            await _postService.AddAsync(value);
            await _postService.SaveChangesAsync();
            return value;
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync( [FromBody] Post value)
        {
            _postService.Update(value);
            await _postService.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var kayit= _postService.Find(id);
            if (kayit==null)
            {
                return BadRequest();
            }

            _postService.Delete(kayit);
            await _postService.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
