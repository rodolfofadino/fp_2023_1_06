using fiap.Models;
using Microsoft.AspNetCore.Mvc;

namespace fiap.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes)
        {
            //simulando um repository
            var noticias = new List<Noticia>();
            for (int i = 0; i < total; i++)
            {
                noticias.Add(new Noticia() { Id = i + 1, Titulo = $"Noticia {i}", Link = "https://fiap.com.br" });
            }

            var viewName = "Noticias";

            if (noticiasUrgentes)
            {
                viewName = "NoticiasUrgentes";
            }

            return View(viewName, noticias);
            
        }
    }
}
