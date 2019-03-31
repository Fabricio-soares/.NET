using BookStore.Data.Repositories;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using BookStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace BookStore.Controllers
{
    [RoutePrefix("api/public")]
    public class BookController : ApiController
    {
        private IBookRepository _repository;
        public BookController(IBookRepository repository)
        {
            this._repository = repository;
        }
        [GzipCompression]
        [CacheOutput(ClientTimeSpan =100,ServerTimeSpan =100)]
        [BasicAuthentication]
        [Route("v1/livros")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage _response = new HttpResponseMessage();
            try
            {
                var livros = _repository.Get();
                if (livros != null && livros.Count > 0)
                    _response = Request.CreateResponse(HttpStatusCode.OK, livros);
                else
                    _response = Request.CreateResponse(HttpStatusCode.NotFound, "Nenhum livro encontrado");

            }
            catch (Exception ex)
            {

                _response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                
            }
            return _response;
        }
        public Task<HttpResponseMessage> GetById( int id)
        {
            HttpResponseMessage _response = new HttpResponseMessage();
            try
            {
                var livros = _repository.Get(id);
                if (livros != null)
                    _response = Request.CreateResponse(HttpStatusCode.OK, livros);
                else
                    _response = Request.CreateResponse(HttpStatusCode.NotFound, "Nenhum livro encontrado");
            }
            catch (Exception ex)
            {
                _response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(_response);
            return tsc.Task ;
        }




        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }

    }
}
