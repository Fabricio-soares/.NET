using BookStore.Data.Repositories;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Api.Controllers
{
    [RoutePrefix("api/public")]
    public class BookController : ApiController
    {
        private IBookRepository _repository;
        public BookController(IBookRepository repository)
        {
            this._repository = repository;
        }
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




        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }

    }
}
