using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using ModeloDominio;
using System;

namespace Data
{
    public class VeterinariaContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Duenio> Duenios { get; set; } = null!;
        public DbSet<Mascota> Mascotas { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options)
        {
            this.Database.EnsureCreated();
            SeedInitialData();
        }
        internal VeterinariaContext()
        {
            this.Database.EnsureCreated();
            SeedInitialData();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("VeterinariaDB")!;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasDiscriminator<string>("TipoPersona")
                .HasValue<Duenio>("Duenio")
                .HasValue<Veterinario>("Veterinario");

                entity.HasKey(p => p.IdPersona);
                entity.Property(p => p.IdPersona).ValueGeneratedOnAdd();

                entity.Property(p => p.NombrePersona)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.Dni)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(p => p.Telefono)
                .HasMaxLength(20);

                entity.Property(p => p.Mail)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .HasIndex(p => p.Mail)
                .IsUnique();
            });
            modelBuilder.Entity<Veterinario>(entity =>
            {
                entity.Property(v => v.Especialidad)
                .HasMaxLength(50);

                entity.Property(v => v.Matricula)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(v => v.Matricula)
                .IsUnique();
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(m => m.IdMascota);

                entity.Property(m => m.IdMascota)
                .ValueGeneratedOnAdd();

                entity.Property(m => m.NombreMascota)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m => m.Especie)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m => m.Raza)
                .HasMaxLength(50);
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.IdUsuario);

                entity.Property(u => u.IdUsuario)
                .ValueGeneratedOnAdd();

                entity.Property(u => u.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasIndex(u => u.NombreUsuario)
                .IsUnique();

                entity.Property(u => u.Contrasenia)
                .IsRequired()
                .HasMaxLength(50);
            });
        }
        private void SeedInitialData() { }
    }
}