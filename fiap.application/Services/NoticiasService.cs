using fiap.application.Interfaces;
using fiap.domain.Models;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace fiap.application.Services
{
    public class NoticiaService : INoticiaService
    {
        private IMemoryCache _memoryCache;
        private INoticiaReader _reader;
        private IDateTimeProvider _dateTime;

        public NoticiaService(IMemoryCache memoryCache, INoticiaReader reader, IDateTimeProvider dateTime)
        {
            _memoryCache = memoryCache;
            _reader = reader;
            _dateTime = dateTime;
        }

        public List<Noticia> Load(int totalDeNoticias)
        {
            var key = $"cache_noticias";
            var noticias = new List<Noticia>();
            if (!_memoryCache.TryGetValue(key, out noticias))
            {
                
                noticias = _reader.Load();
                noticias = _reader.Load();
                var agora = _dateTime.GetNow();
                foreach (var item in noticias)
                {
                    item.UltimaAtualizacao = agora;
                }


                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5));

                _memoryCache.Set(key, noticias, cacheEntryOptions);

            }


            return noticias.Where(a => a.Imagem != "").ToList();
        }

    }
}