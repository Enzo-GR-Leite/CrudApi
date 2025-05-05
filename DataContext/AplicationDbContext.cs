using Api_Completa.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Completa.DataContext
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
