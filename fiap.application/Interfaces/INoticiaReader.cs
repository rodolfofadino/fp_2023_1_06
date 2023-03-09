using fiap.domain.Models;

namespace fiap.application.Interfaces
{
    public interface INoticiaReader
    {
        public List<Noticia> Load();
    }
}
