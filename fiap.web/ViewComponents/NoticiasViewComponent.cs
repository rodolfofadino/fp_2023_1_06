using fiap.core.Models;
using fiap.core.Services;
using Microsoft.AspNetCore.Mvc;

namespace fiap.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        private NoticiaService _noticiaService;

        public NoticiasViewComponent(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;

        }
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes)
        {
            var noticias = _noticiaService.Load(total);
            
            var viewName = "Noticias";

            if (noticiasUrgentes)
            {
                viewName = "NoticiasUrgentes";
            }

            return View(viewName, noticias);
            
        }
    }
}
