using fiap.application.Interfaces;
using fiap.application.Services;
using fiap.domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace fiap.test.application
{

    public class NoticiaServiceTests
    {
        [Fact]
        public void Nome_Metodo_Cenario_Resultado_Esperado()
        //public void should_ReturnTheLastUpdatedTimeAtNews()
        {
            var datetime = new DateTime(2019, 1, 1);
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.GetNow()).Returns(datetime);

            var memoryCacheMock = new Mock<IMemoryCache>(MockBehavior.Strict);
            List<Noticia> news = new List<Noticia>();

            int expectedNumber = 1;
            object expectedValue = expectedNumber;
            memoryCacheMock.Setup(x => x.TryGetValue(It.IsAny<string>, out expectedValue)).Returns(false);
            //memoryCacheMock.Setup(x =>
            //x.Set<>(It.IsAny<string>, It.IsAny<object>, It.IsAny<MemoryCacheEntryOptions>);

            var readerMock = new Mock<INoticiaReader>();
            readerMock.Setup(a => a.Load()).Returns(new List<Noticia>() {
            new Noticia(){ Id=1, Titulo="lala", Imagem="https://" }
            });



            var noticiaService = new NoticiaService(memoryCacheMock.Object, readerMock.Object, dateTimeProviderMock.Object);


            var noticias = noticiaService.Load(3);

            readerMock.Verify(x => x.Load(), Times.Once);
            //Xunit.Assert.Equal(noticias.First().UltimaAtualizacao, datetime);

        }
    }
}