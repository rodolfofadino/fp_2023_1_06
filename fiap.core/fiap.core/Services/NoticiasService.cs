using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using fiap.core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace fiap.core.Services
{
    public class NoticiaService
    {
        private IMemoryCache _memoryCache;

        public NoticiaService(IMemoryCache memoryCache )
        {
            _memoryCache = memoryCache;
        }
        

        public List<Noticia> Load(int totalDeNoticias)
        {
            var key = $"cache_noticias";
            var noticias = new List<Noticia>();
            if (!_memoryCache.TryGetValue(key, out noticias))
            {
                noticias = new List<Noticia>();
                var feed = FeedReader.ReadAsync("https://g1.globo.com/rss/g1/turismo-e-viagem/").Result;

                foreach (var item in feed.Items)
                {
                    var feedItem = item.SpecificItem as CodeHollow.FeedReader.Feeds.MediaRssFeedItem;
                    var media = feedItem.Media;
                    var url = "";
                    if (media.Any())
                        url = media.FirstOrDefault().Url;
                    noticias.Add(new Noticia() { Id = 1, Titulo = item.Title, Link = item.Link, Imagem = url });
                }

                //sliding expiration
                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                //absolute expiration
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5));

                _memoryCache.Set(key, noticias, cacheEntryOptions);

            }


          

            return noticias.Where(a => a.Imagem != "").ToList();
        }

    }
}