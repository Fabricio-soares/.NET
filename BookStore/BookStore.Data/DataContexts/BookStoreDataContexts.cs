using BookStore.Data.Mapp;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.DataContexts
{
    public class BookStoreDataContexts : DbContext
    {
        public BookStoreDataContexts()
            :base("BookStoreConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMapp());
            modelBuilder.Configurations.Add(new AuthorMapp());

            base.OnModelCreating(modelBuilder);
        }
    }
}
