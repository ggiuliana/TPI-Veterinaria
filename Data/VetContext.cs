using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModeloDominio;
using Microsoft.Extensions.Configuration;

namespace Data
{
    internal class VetContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Duenio> Duenios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public VetContext(DbContextOptions<VetContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        internal VetContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                        NombreRol = "Admin"
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

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.Property(e => e.IdPersona)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.NombrePersona)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(e => e.Mail)
                .IsRequired()
                .HasMaxLength(255);

                entity.HasIndex(e => e.Mail)
                .IsUnique();

                entity.Property(e => e.Dni)
                .IsRequired();

                entity.Property(e => e.Direccion)
                .IsRequired();

                entity.HasOne(e => e.Usuario)
                .WithOne(u => u.Persona);
            });

            modelBuilder.Entity<Persona>()
                .HasDiscriminator<string>("TipoPersona")
                .HasValue<Persona>("Persona")
                .HasValue<Veterinario>("Veterinario")
                .HasValue<Duenio>("Duenio");

            modelBuilder.Entity<Veterinario>(entity =>
            {
                entity.Property(v => v.Matricula)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(v => v.Especialidad)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(v => v.Matricula)
                    .IsUnique();

                entity.HasData(
                    new { IdPersona = 1, NombrePersona = "Gerardo", Apellido = "Díaz", Telefono = "341252554", Mail = "vet1@veterinaria.com", Dni = "5125124", Direccion = "Calle falsa 123", Matricula = "AF1124", Especialidad = "Cardiología" }
                    );
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(m => m.IdMascota);

                entity.Property(e => e.IdMascota)
                .ValueGeneratedOnAdd();

                entity.Property(m => m.NombreMascota)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m => m.Especie)
                .IsRequired()
                .HasMaxLength(30);

                entity.Property(m => m.Raza)
                .IsRequired()
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
                .HasMaxLength(20);

                entity.Property(u => u.Contrasenia)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(u => u.EstadoUsuario)
                .IsRequired();

                entity.Property(u => u.FechaAlta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(u => u.Persona)
                .WithOne(p => p.Usuario);

                entity.HasOne(u => u.Rol)
                .WithMany()
                .IsRequired();

                entity.HasIndex(u => u.NombreUsuario)
                .IsUnique();

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
