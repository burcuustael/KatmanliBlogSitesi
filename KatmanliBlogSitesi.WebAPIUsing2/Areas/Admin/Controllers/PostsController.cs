using KatmanliBlogSitesi.Entities;
using KatmanliBlogSitesi.WebAPIUsing2.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBlogSitesi.WebAPIUsing2.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class PostsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7126/api/Posts";

        public PostsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: PostsController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres);
            return View(model);
        }

        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Post post, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    post.Image = await FileHelper.FileLoaderAsync(Image);
                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, post);
                   if(response.IsSuccessStatusCode)       return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View();
        }

        // GET: PostsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Post>(_apiAdres + "/" + id);
            return View(model);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Post post, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(Image is not null) post.Image = await FileHelper.FileLoaderAsync(Image);
                    var cevap = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, post);
                    if(cevap.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(post);

        }

        // GET: PostsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Post>(_apiAdres + "/" + id);
            return View(model);
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Post post)
        {
            try
            {
                var sonuc = await _httpClient.DeleteAsync(_apiAdres + "/" + id);
                if(sonuc.IsSuccessStatusCode)      return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }

            return View(post);
        }
    }
}
