using Advanced_Database_and_ORM_Concepts_Lab01.Data;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Advanced_Database_and_ORM_Concepts_Lab01.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            Advanced_Database_and_ORM_Concepts_Lab01Context context = new Advanced_Database_and_ORM_Concepts_Lab01Context
                (serviceProvider.GetRequiredService<DbContextOptions<Advanced_Database_and_ORM_Concepts_Lab01Context>>());

            using (TransactionScope scope = new TransactionScope())
            {
                Customer customer01 = new Customer("Orlando", "Gee", "A Bike Store", "245-555-0173");
                Customer customer02 = new Customer("Keith", "Harris", "Progressive Sports", "170-555-0127");
                Customer customer03 = new Customer("Donna", "Carreras", "Advanced Bike Components", "279-555-0130");
                if (!context.Customer.Any())
                {
                    context.Customer.Add(customer01);
                    context.Customer.Add(customer02);
                    context.Customer.Add(customer03);

                    context.SaveChanges();
                }

                Address address01 = new Address("8713 Yosemite Ct", "NULL", "Bothell", "Washington", "United States");
                Address address02 = new Address("1318 Lasalle Street", "NULL", "Bothell", "Washington", "United States");
                Address address03 = new Address("9178 Jumping St", "NULL", "Dallas", "Texas", "United States");

                if (!context.Address.Any())
                {
                    context.Address.Add(address01);
                    context.Address.Add(address02);
                    context.Address.Add(address03);

                    context.SaveChanges();
                }

                if (!context.CustomerAddress.Any())
                {
                    context.CustomerAddress.Add(new CustomerAddress(customer01.Id, address01.Id, true));
                    context.CustomerAddress.Add(new CustomerAddress(customer02.Id, address02.Id, true));
                    context.CustomerAddress.Add(new CustomerAddress(customer03.Id, address03.Id, true));

                    context.SaveChanges();
                }

                scope.Complete();
            }



        }
    }
}