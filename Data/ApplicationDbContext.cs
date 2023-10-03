using BankProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BankProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
            
        }
        // Crearea tabelului cu coloanele din clasa Bank
        public DbSet<Bank> Banks { get; set; }

        public DbSet<Client> Clients { get; set; }


    }
}
