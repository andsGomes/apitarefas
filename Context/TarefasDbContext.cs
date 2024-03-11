using Microsoft.EntityFrameworkCore;
using TarefasAPI.Domain.Model;
using TarefasAPI.Domain.DTOs;

namespace TarefasAPI.Context
{
    public class TarefasDbContext : DbContext
    {
        public DbSet<Tarefas> Tarefas { get; set; }
        //public DbSet<Usuarios> Usuarios { get; set; }

        public TarefasDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Usuarios>()
        //        .HasMany(a => a.Tarefas)
        //        .WithOne(b => b.Usuarios)
        //        .HasForeignKey(b => b.usuarioId);
        //}


    }
}
