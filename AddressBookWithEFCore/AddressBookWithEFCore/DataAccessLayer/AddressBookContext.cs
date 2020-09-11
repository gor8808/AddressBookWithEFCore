using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AddressBookWithEFCore.DataAccessLayer
{
    public class AddressBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            (@"Server=(localdb)\MSSQLLocalDB;Database=AddressBookWithEfCore;Trusted_Connection=True;");
        }

        public DbSet<Address> Addresses { get; set; }
    }

}
