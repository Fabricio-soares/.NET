using BookStore.Data.DataContexts;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreDataContexts _db;
        public BookRepository()
        {
            _db = new BookStoreDataContexts();

        }

        public void Create(Book entity)
        {
            _db.Books.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Books.Remove(_db.Books.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public List<Book> Get(int skip = 0, int take = 25)
        {
            return _db.Books.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public Book Get(int id)
        {
            return _db.Books.OrderBy(x => x.Id == id).FirstOrDefault();
        }

        public List<Book> GetWithAuthors(int skip = 0, int take = 25)
        {
            return _db.Books.Include(x=> x.Authors).OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public Book GetWithAuthors(int id)
        {
            return _db.Books.Include(x => x.Authors).Where(x=> x.Id == id).OrderBy(x => x.Title).FirstOrDefault();
        }

        public void Update(Book entity)
        {
            _db.Entry<Book>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

    }
}
