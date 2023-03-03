using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Advanced_Database_and_ORM_Concepts_Lab01.Models;

namespace Advanced_Database_and_ORM_Concepts_Lab01.Data
{
    public class Advanced_Database_and_ORM_Concepts_Lab01Context : DbContext
    {
        public Advanced_Database_and_ORM_Concepts_Lab01Context (DbContextOptions<Advanced_Database_and_ORM_Concepts_Lab01Context> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; } = default!;

        public DbSet<Address> Address { get; set; } = default!;
    }
}
