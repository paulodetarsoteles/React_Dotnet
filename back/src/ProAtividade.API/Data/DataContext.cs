using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.src.ProAtividade.API.Models;
using Microsoft.EntityFrameworkCore;

namespace back.src.ProAtividade.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Atividade> Atividades { get; set; }
    }
}