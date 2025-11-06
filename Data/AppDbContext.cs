using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exemplo.model;
using Microsoft.EntityFrameworkCore;

namespace exemplo.Data
{
    // Herança
    public class AppDbContext : DbContext
    {
        // construtor da minha classe AppDbContext
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        // todos os models podem ser iseridos aqui:
        public DbSet<Gastos> tb_gastos { get; set; }
        
    }
}