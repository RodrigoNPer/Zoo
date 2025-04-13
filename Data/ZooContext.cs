using Microsoft.EntityFrameworkCore;
using ZooAPI.Models;

namespace ZooAPI.Data;

public class ZooContext : DbContext
{
    public ZooContext(DbContextOptions<ZooContext> options) : base(options) {}

    // DbSets para as entidades
    public DbSet<Animal> Animais { get; set; }
    public DbSet<Cuidado> Cuidados { get; set; }
    public DbSet<AnimalCuidado> AnimalCuidados { get; set; } // Tabela de junção

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração da tabela de junção (chave composta)
        modelBuilder.Entity<AnimalCuidado>()
            .HasKey(ac => new { ac.AnimalId, ac.CuidadoId });

        // Relacionamento Animal → AnimalCuidado
        modelBuilder.Entity<AnimalCuidado>()
            .HasOne(ac => ac.Animal)
            .WithMany(a => a.AnimalCuidados)
            .HasForeignKey(ac => ac.AnimalId);

        // Relacionamento Cuidado → AnimalCuidado
        modelBuilder.Entity<AnimalCuidado>()
            .HasOne(ac => ac.Cuidado)
            .WithMany(c => c.AnimalCuidados)
            .HasForeignKey(ac => ac.CuidadoId);

        // Configurações adicionais (se necessário)
        base.OnModelCreating(modelBuilder);
    }
}