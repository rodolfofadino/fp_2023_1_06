using fiap.Models;
using Microsoft.AspNetCore.Mvc;

namespace fiap.Controllers
{
  
    public class MusicasController : Controller
    {
        private MusicaContext _context;

        public MusicasController(MusicaContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]Musica model)
        {
            if (ModelState.IsValid)
            {
                //salva no banco

                _context.Musicas.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }
    }
}
