using KatmanliBlogSitesi.Entities;
using KatmanliBlogSitesi.Service.Abstract;
using KatmanliBlogSitesi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KatmanliBlogSitesi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Post> _postService;
        private readonly IService<Contact> _contactService;

        public HomeController(IService<Post> postService, IService<Contact> contactService)
        {
            _postService = postService;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var model= await _postService.GetAllAsync();
            return View(model);
        }

        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {

            return View();
        }

        [Route("iletisim")]
        public IActionResult ContactMe()
        {
                        
            return View();
        }

        [Route("iletisim"),HttpPost]
        public async Task<IActionResult> ContactMeAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _contactService.AddAsync(contact); 
                    await _contactService.SaveChangesAsync();
                    TempData["Mesaj"] = "<div class= 'alert alert-success'> Mesajınız Gönderildi. Teşekkürler.. </div> ";
                    return RedirectToAction("ContactMe");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu! Mesajınız Gönderilemedi!");
                }

            }

            return View(contact);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}