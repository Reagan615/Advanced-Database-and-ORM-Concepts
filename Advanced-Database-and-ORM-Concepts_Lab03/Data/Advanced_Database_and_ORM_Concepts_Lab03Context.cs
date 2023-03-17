using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Advanced_Database_and_ORM_Concepts_Lab03.Models;

namespace Advanced_Database_and_ORM_Concepts_Lab03.Data
{
    public class Advanced_Database_and_ORM_Concepts_Lab03Context : DbContext
    {
        public Advanced_Database_and_ORM_Concepts_Lab03Context (DbContextOptions<Advanced_Database_and_ORM_Concepts_Lab03Context> options)
            : base(options)
        {
        }

        public DbSet<Advanced_Database_and_ORM_Concepts_Lab03.Models.Client> Client { get; set; } = default!;
    }
}
