using fiap.domain.Models;

namespace fiap.application.Services
{
    public interface INoticiaService
    {
        List<Noticia> Load(int totalDeNoticias);
    }
}