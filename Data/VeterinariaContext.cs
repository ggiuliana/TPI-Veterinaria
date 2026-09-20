using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModeloDominio;

namespace Data
{
    public class VeterinariaContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Duenio> Duenios { get; set; } = null!;
        public DbSet<Veterinario> Veterinarios { get; set; } = null!;
        public DbSet<Mascota> Mascotas { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Estudio> Estudios { get; set; } = null!;
        public DbSet<TipoVacuna> TipoVacunas { get; set; } = null!;
        public DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public DbSet<Turno> Turnos { get; set; } = null!;
        public DbSet<Consulta> Consultas { get; set; } = null!;
        public DbSet<MedicamentosUsados> MedicamentosUsados { get; set; } = null!;
        public DbSet<Vacuna> Vacunas { get; set; } = null!;
        public DbSet<Permiso> Permisos { get; set; } = null!;
        public DbSet<GrupoPermiso> GruposPermisos { get; set; } = null!;
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options)
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        internal VeterinariaContext()
        {
            //this.Database.EnsureDeleted();
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
                entity.Property(p => p.IdPersona)
                .ValueGeneratedOnAdd();

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
                    new
                    {
                        IdPersona = 1,
                        NombrePersona = "Gerardo",
                        Apellido = "Díaz",
                        Telefono = "341252554",
                        Mail = "gdiaz@veterinaria.com",
                        Dni = "5125124",
                        Direccion = "Génova 1344",
                        Matricula = "AF1124",
                        Especialidad = "Cardiología"
                    },
                    new
                    {
                        IdPersona = 2,
                        NombrePersona = "Mariana",
                        Apellido = "Locre",
                        Telefono = "341251142",
                        Mail = "mlocre@veterinaria.com",
                        Dni = "55123142",
                        Direccion = "Corrientes 4880",
                        Matricula = "51W124",
                        Especialidad = "Oncología"
                    }
                    );

            });
            modelBuilder.Entity<Duenio>()
                .HasData(
                    new 
                    { 
                        IdPersona = 3,
                        NombrePersona = "Juan",
                        Apellido = "Perez",
                        Telefono = "341324125",
                        Mail = "jperez@veterinaria.com",
                        Dni = "5165256",
                        Direccion = "San Martin 1234"
                    }
                );
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                entity.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(p => p.Categoria)
                .IsRequired()
                .HasMaxLength(30);

                entity.Property(p => p.Activo)
                .IsRequired();
            });
            modelBuilder.Entity<GrupoPermiso>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.Id)
                .ValueGeneratedOnAdd();

                entity.Property(g => g.Nombre)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(g => g.Descripcion)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(g => g.FechaCreacion)
                .IsRequired();

                entity.Property(g => g.Activo)
                .IsRequired();
            });
            modelBuilder.Entity<GrupoPermiso>()
                .HasMany(g => g.Permisos)
                .WithMany(p => p.Grupos)
                .UsingEntity<Dictionary<string, object>>(
                    "GrupoPermisoPermiso",
                    j => j.HasOne<Permiso>().WithMany().HasForeignKey("PermisosId"),
                    j => j.HasOne<GrupoPermiso>().WithMany().HasForeignKey("GruposId"),
                    j =>
                    {
                        j.HasKey("GruposId", "PermisosId");
                    });
            modelBuilder.Entity<Permiso>().HasData(
                // Permisos para Duenios
                new { Id = 1, Nombre = "leer", Descripcion = "Leer dueños", Categoria = "duenios", Activo = true },
                new { Id = 2, Nombre = "agregar", Descripcion = "Agregar dueños", Categoria = "duenios", Activo = true },
                new { Id = 3, Nombre = "actualizar", Descripcion = "Actualizar dueños", Categoria = "duenios", Activo = true },
                new { Id = 4, Nombre = "eliminar", Descripcion = "Eliminar dueños", Categoria = "duenios", Activo = true },
                // Permisos para Mascotas
                new { Id = 5, Nombre = "leer", Descripcion = "Leer mascotas", Categoria = "mascotas", Activo = true },
                new { Id = 6, Nombre = "agregar", Descripcion = "Agregar mascotas", Categoria = "mascotas", Activo = true },
                new { Id = 7, Nombre = "actualizar", Descripcion = "Actualizar mascotas", Categoria = "mascotas", Activo = true },
                new { Id = 8, Nombre = "eliminar", Descripcion = "Eliminar mascotas", Categoria = "mascotas", Activo = true },
                // Permisos para Estudios
                new { Id = 9, Nombre = "leer", Descripcion = "Leer estudios", Categoria = "estudios", Activo = true },
                new { Id = 10, Nombre = "agregar", Descripcion = "Agregar estudios", Categoria = "estudios", Activo = true },
                new { Id = 11, Nombre = "actualizar", Descripcion = "Actualizar estudios", Categoria = "estudios", Activo = true },
                new { Id = 12, Nombre = "eliminar", Descripcion = "Eliminar estudios", Categoria = "estudios", Activo = true },
                // Permisos para Usuarios
                new { Id = 13, Nombre = "leer", Descripcion = "Leer usuarios", Categoria = "usuarios", Activo = true },
                new { Id = 14, Nombre = "agregar", Descripcion = "Agregar usuarios", Categoria = "usuarios", Activo = true },
                new { Id = 15, Nombre = "actualizar", Descripcion = "Actualizar usuarios", Categoria = "usuarios", Activo = true },
                new { Id = 16, Nombre = "eliminar", Descripcion = "Eliminar usuarios", Categoria = "usuarios", Activo = true },
                //Permisos para Tipos Vacunas
                new { Id = 17, Nombre = "leer", Descripcion = "Leer tipos vacunas", Categoria = "tipos vacunas", Activo = true },
                new { Id = 18, Nombre = "agregar", Descripcion = "Agregar tipos vacunas", Categoria = "tipos vacunas", Activo = true },
                new { Id = 19, Nombre = "actualizar", Descripcion = "Actualizar tipos vacunas", Categoria = "tipos vacunas", Activo = true },
                new { Id = 20, Nombre = "eliminar", Descripcion = "Eliminar tipos vacunas", Categoria = "tipos vacunas", Activo = true },
                // Permisos para Medicamentos
                new { Id = 21, Nombre = "leer", Descripcion = "Leer medicamentos", Categoria = "medicamentos", Activo = true },
                new { Id = 22, Nombre = "agregar", Descripcion = "Agregar medicamentos", Categoria = "medicamentos", Activo = true },
                new { Id = 23, Nombre = "actualizar", Descripcion = "Actualizar medicamentos", Categoria = "medicamentos", Activo = true },
                new { Id = 24, Nombre = "eliminar", Descripcion = "Eliminar medicamentos", Categoria = "medicamentos", Activo = true },
                // Permisos para Estudios
                new { Id = 25, Nombre = "leer", Descripcion = "Leer estudios", Categoria = "estudios", Activo = true },
                new { Id = 26, Nombre = "agregar", Descripcion = "Agregar estudios", Categoria = "estudios", Activo = true },
                new { Id = 27, Nombre = "actualizar", Descripcion = "Actualizar estudios", Categoria = "estudios", Activo = true },
                new { Id = 28, Nombre = "eliminar", Descripcion = "Eliminar estudios", Categoria = "estudios", Activo = true },
                // Permisos para Turnos
                new { Id = 29, Nombre = "leer", Descripcion = "Leer turnos", Categoria = "turnos", Activo = true },
                new { Id = 30, Nombre = "agregar", Descripcion = "Agregar turnos", Categoria = "turnos", Activo = true },
                new { Id = 31, Nombre = "actualizar", Descripcion = "Actualizar turnos", Categoria = "turnos", Activo = true },
                new { Id = 32, Nombre = "eliminar", Descripcion = "Eliminar turnos", Categoria = "turnos", Activo = true },
                // Permisos para Consultas
                new { Id = 33, Nombre = "leer", Descripcion = "Leer consultas", Categoria = "consultas", Activo = true },
                new { Id = 34, Nombre = "agregar", Descripcion = "Agregar consultas", Categoria = "consultas", Activo = true },
                new { Id = 35, Nombre = "actualizar", Descripcion = "Actualizar consultas", Categoria = "consultas", Activo = true },
                new { Id = 36, Nombre = "eliminar", Descripcion = "Eliminar consultas", Categoria = "consultas", Activo = true },
                // Permisos para Veterinarios
                new { Id = 37, Nombre = "leer", Descripcion = "Leer veterinarios", Categoria = "veterinaios", Activo = true },
                new { Id = 38, Nombre = "agregar", Descripcion = "Agregar veterinarios", Categoria = "veterinarios", Activo = true },
                new { Id = 39, Nombre = "actualizar", Descripcion = "Actualizar veterinarios", Categoria = "veterinarios", Activo = true },
                new { Id = 40, Nombre = "eliminar", Descripcion = "Eliminar veterinarios", Categoria = "veterinarios", Activo = true }
            );
            var fechaCreacion = DateTime.Now;
            modelBuilder.Entity<GrupoPermiso>().HasData(
                new { Id = 1, Nombre = "Administrador", Descripcion = "Acceso completo a todas las funcionalidades", Activo = true, FechaCreacion = fechaCreacion },
                new { Id = 2, Nombre = "Veterinario", Descripcion = "Acceso a turnos y consulta de mascotas", Activo = true, FechaCreacion = fechaCreacion },
                new { Id = 3, Nombre = "Duenio", Descripcion = "Acceso a las mascotas y turnos", Activo = true, FechaCreacion = fechaCreacion }
            );
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
                .IsRequired()
                .HasDefaultValue("Activo");

                entity.Property(u => u.FechaAlta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(u => u.Persona)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(u => u.IdPersona)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.Grupo)
                .WithMany()
                .HasForeignKey(u => u.GrupoPermisoId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasData(
                    new
                    {
                        IdUsuario = 1,
                        NombreUsuario = "admin",
                        Contrasenia = "admin123",
                        GrupoPermisoId = 1
                    },
                    new
                    {
                        IdUsuario = 2,
                        NombreUsuario = "vet",
                        Contrasenia = "vet123",
                        IdPersona = 1,
                        GrupoPermisoId = 2
                    },
                    new
                    {
                        IdUsuario = 3,
                        NombreUsuario = "duenio",
                        Contrasenia = "duenio123",
                        IdPersona = 3,
                        GrupoPermisoId = 3
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

                entity.HasMany(m => m.Vacunas)
                .WithOne(v => v.Mascota)
                .HasForeignKey(v => v.IdMascota)
                .IsRequired(false);
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
                .WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(u => u.IdPersona)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.Grupo)
                .WithMany()
                .HasForeignKey(u => u.GrupoPermisoId);

            });
            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => e.IdEstudio);

                entity.Property(e => e.IdEstudio)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(e => e.NombreEstudio)
                .IsRequired()
                .HasMaxLength(60);

                entity.Property(e => e.DescripcionEstudio)
                .IsRequired()
                .HasMaxLength(200);

                entity.HasData(
                    new
                    {
                        IdEstudio = 1,
                        NombreEstudio = "Resonancia Magnética",
                        DescripcionEstudio = "Se introduce el animal en un cilindro para visualizar su interior."
                    });
            });
            modelBuilder.Entity<TipoVacuna>(entity =>
            {
                entity.HasKey(t => t.IdTipoVacuna);

                entity.Property(t => t.IdTipoVacuna)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(t => t.NombreTipoVacuna)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(t => t.DescripcionTipoVacuna)
                .IsRequired()
                .HasMaxLength(100);

                entity.HasData(
                        new
                        {
                            IdTipoVacuna = 1,
                            NombreTipoVacuna = "Antitetanica",
                            DescripcionTipoVacuna = "Vacuna contra la bacteria del tetanos."
                        },
                        new
                        {
                            IdTipoVacuna = 2,
                            NombreTipoVacuna = "Antiviral",
                            DescripcionTipoVacuna = "Vacuna contra multiples viruses."
                        }
                    );

            });
            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(m => m.IdMedicamento);

                entity.Property(m => m.IdMedicamento)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(m => m.NombreMedicamento)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m => m.CantidadRestante)
                .IsRequired();

                entity.HasData(
                    new
                    {
                        IdMedicamento = 1,
                        NombreMedicamento = "Albendazol",
                        CantidadRestante = 4
                    });
            });
            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(t => t.IdTurno);

                entity.Property(t => t.IdTurno)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(t => t.FechaTurno)
                .IsRequired();

                entity.Property(t => t.HoraTurno)
                .IsRequired();

                entity.Property(t => t.EstadoTurno)
                .IsRequired()
                .HasMaxLength(30);

                entity.HasOne(t => t.Mascota)
                .WithMany()
                .HasForeignKey(t => t.IdMascota)
                .IsRequired(false);

                entity.HasOne(t => t.Veterinario)
                .WithMany()
                .HasForeignKey(t => t.IdVeterinario)
                .IsRequired();
            });
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(c => c.IdConsulta);

                entity.Property(c => c.IdConsulta)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity.Property(c => c.Diagnostico)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(c => c.Tratamiento)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(c => c.Peso)
                .IsRequired();

                entity.Property(c => c.Observaciones)
                .HasMaxLength(200);

                entity.HasMany(c => c.Estudios)
                .WithMany()
                .UsingEntity("ConsultaEstudio");

                entity.HasMany(c => c.MedicamentosUsados)
                .WithOne()
                .HasForeignKey("IdConsulta")
                .IsRequired(false);

                entity.HasOne(c => c.Turno)
                .WithMany()
                .HasForeignKey(c => c.IdTurno)
                .IsRequired();
            });
            modelBuilder.Entity<MedicamentosUsados>(entity =>
            {
                entity.HasKey(mu => new { mu.IdConsulta, mu.IdMedicamento });

                entity.Property(mu => mu.CantidadUsada)
                .IsRequired();
            });
            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.HasKey(v => new { v.IdTipoVacuna, v.IdMascota, v.FechaColocacion });

                entity.Property(v => v.FechaColocacion)
                .IsRequired();

                entity.HasOne(v => v.TipoVacuna)
                .WithMany()
                .HasForeignKey(v => v.IdTipoVacuna)
                .IsRequired();

                entity.HasOne(v => v.Mascota)
                .WithMany()
                .HasForeignKey(v => v.IdMascota)
                .IsRequired();
            }); 
        }
        private void SeedInitialData()
        {
            try
            {
                if (!Usuarios.Any(u => u.GrupoPermisoId != null) &&
                    Usuarios.Any() &&
                    GruposPermisos.Any() &&
                    Permisos.Any())
                {
                    var adminUser = Usuarios.Include(u => u.Grupo).FirstOrDefault(u => u.NombreUsuario == "admin");
                    var veterinarioUser = Usuarios.Include(u => u.Grupo).FirstOrDefault(u => u.NombreUsuario == "veterinario");
                    var duenioUser = Usuarios.Include(u => u.Grupo).FirstOrDefault(u => u.NombreUsuario == "duenio");
                    var grupoAdmin = GruposPermisos.Include(g => g.Permisos).FirstOrDefault(g => g.Nombre == "Administrador");
                    var grupoVeterinario = GruposPermisos.Include(g => g.Permisos).FirstOrDefault(g => g.Nombre == "Veterinario");
                    var grupoDuenio = GruposPermisos.Include(g => g.Permisos).FirstOrDefault(g => g.Nombre == "Duenio");
                    var todosLosPermisos = Permisos.ToList();

                    if (grupoAdmin != null && grupoVeterinario != null && grupoDuenio != null && todosLosPermisos.Any())
                    {
                        foreach (var permiso in todosLosPermisos)
                        {
                            if (!grupoAdmin.Permisos.Contains(permiso))
                            {
                                grupoAdmin.Permisos.Add(permiso);
                            }
                        }
                        var permisosVeterinario = todosLosPermisos.Where(p =>
                            (p.Categoria == "turnos" && p.Nombre != "actualizar") ||
                            (p.Categoria == "mascotas" && p.Nombre == "leer") || 
                            (p.Categoria == "estudios" && p.Nombre == "leer") ||
                            (p.Categoria == "medicamentos" && p.Nombre == "leer") ||
                            (p.Categoria == "consultas")
                        ).ToList();

                        foreach (var permiso in permisosVeterinario)
                        {
                            if (!grupoVeterinario.Permisos.Contains(permiso))
                            {
                                grupoVeterinario.Permisos.Add(permiso);
                            }
                        }

                        var permisosDuenio = todosLosPermisos.Where(p =>
                            (p.Categoria == "turnos" && (p.Nombre == "actualizar" || p.Nombre == "leer")) ||
                            (p.Categoria == "mascotas") ||
                            (p.Categoria == "consultas" && p.Nombre == "leer")
                        ).ToList();

                        foreach (var permiso in permisosDuenio)
                        {
                            if (!grupoDuenio.Permisos.Contains(permiso))
                            {
                                grupoDuenio.Permisos.Add(permiso);
                            }
                        }

                        if (adminUser != null)
                        {
                            adminUser.SetGrupo(grupoAdmin);
                        }

                        if (veterinarioUser != null)
                        {
                            veterinarioUser.SetGrupo(grupoVeterinario);
                        }

                        if (duenioUser != null)
                        {
                            duenioUser.SetGrupo(grupoDuenio);
                        }

                        SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }       
    }
}
