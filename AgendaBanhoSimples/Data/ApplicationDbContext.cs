using AgendaBanhoSimples.Models;
using Microsoft.EntityFrameworkCore;


namespace PacotesPetShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<AgendaModel> Agenda { get; set; }
    }


}