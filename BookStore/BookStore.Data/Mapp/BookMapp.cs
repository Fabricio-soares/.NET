using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Mapp
{
    public class BookMapp : EntityTypeConfiguration<Book>
    {
        public BookMapp()
        {
            ToTable("Book");
            HasKey(x => x.Id);
            Property(x => x.Title).HasMaxLength(255).IsRequired();
            Property(x => x.Price).IsRequired().HasColumnType("Money");
            Property(x => x.ReliaseDate).IsRequired();
            HasMany(x => x.Authors).WithMany(x=> x.Books);
        }
    }
}
