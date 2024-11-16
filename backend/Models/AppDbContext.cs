using Microsoft.EntityFrameworkCore;
using WorkshopApi.Models;

namespace APIWorkshop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Colaborador> Colaboradores { get; set; } = null!;
        public DbSet<Workshop> Workshops { get; set; } = null!;
    }
}

