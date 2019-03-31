using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Mapp
{
    public class AuthorMapp  : EntityTypeConfiguration<Author>   
    {
        public AuthorMapp()
        {
            HasKey(x => x.Id);
            Property(x => x.FistName).HasMaxLength(100).IsRequired();
            Property(x => x.LastName).HasMaxLength(100).IsRequired();
            HasMany(x => x.Books).WithMany(x => x.Authors);

        }
    }
}
