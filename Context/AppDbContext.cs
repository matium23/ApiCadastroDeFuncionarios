using ControleDeFuncionarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeFuncionarios.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<FuncionarioModel>Funcionarios { get; set; }

      
    }
}

