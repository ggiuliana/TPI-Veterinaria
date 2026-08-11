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
        }
        internal VeterinariaContext()
        {
            this.Database.EnsureCreated();
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

                entity.HasOne(p => p.Usuario)
               .WithOne(u => u.Persona);
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

                entity.HasData(
                    new { IdPersona = 1, NombrePersona = "Gerardo", Apellido = "Díaz", Telefono = "341252554", Mail = "vet1@veterinaria.com", Dni = "5125124", Direccion = "Calle falsa 123", Matricula = "AF1124", Especialidad = "Cardiología" }
                    );

            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(r => r.IdRol);

                entity.Property(r => r.IdRol)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(r => r.NombreRol)
                .IsRequired()
                .HasMaxLength(15);

                entity.HasData(
                    new
                    {
                        IdRol = 1,
                        NombreRol = "Administrador"
                    },
                    new
                    {
                        IdRol = 2,
                        NombreRol = "Veterinario"
                    },
                    new
                    {
                        IdRol = 3,
                        NombreRol = "Duenio"
                    }
                    );
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

                entity.Property(m => m.Castrado)
                .IsRequired();

                entity.Property(m => m.Sexo)
                .IsRequired();

                entity.Property(m => m.FechaNac)
                .IsRequired();

                entity.HasOne(m => m.Duenio)
                .WithMany();
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

                entity.Property(u => u.EstadoUsuario)
                .IsRequired();

                entity.Property(u => u.FechaAlta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(u => u.Persona)
                .WithOne(p => p.Usuario);

                entity.HasOne(u => u.Rol)
                .WithMany()
                .IsRequired();

                entity.HasData(
                    new
                    {
                        IdUsuario = 1,
                        NombreUsuario = "admin",
                        Contrasenia = "admin123",
                        EstadoUsuario = "Activo",
                        Rol = 1
                    },
                    new
                    {
                        IdUsuario = 2,
                        NombreUsuario = "vet1",
                        Contrasenia = "vet123",
                        EstadoUsuario = "Activo",
                        Persona = 1,
                        Rol = 2
                    }
                );
            });
        }
    }
}