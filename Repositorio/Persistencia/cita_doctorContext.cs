using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    public partial class cita_doctorContext : /*DbContext*/ IdentityDbContext<ApplicationUser>
    {
        public cita_doctorContext()
        {
        }

        public cita_doctorContext(DbContextOptions<cita_doctorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<ClinicaDoctor> ClinicaDoctor { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<DoctorEspecialidad> DoctorEspecialidad { get; set; }
        public virtual DbSet<DoctorTitulo> DoctorTitulo { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Titulo> Titulo { get; set; }
        public virtual DbSet<UltimaHora> UltimaHora { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // Directiva #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseMySql("Server=localhost;port=3306;Database=cita_doctor;user id=root;");
                //optionsBuilder.UseMySql("mysql://zxn9mus9bw9f4diq:r5gy2qtpjxnng0zb@pqxt96p7ysz6rn1f.cbetxkdyhwsb.us-east-1.rds.amazonaws.com:3306/pmtlsr6rotqho5bl");
                optionsBuilder.UseMySql("Server=pqxt96p7ysz6rn1f.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;port=3306;Database=pmtlsr6rotqho5bl;user id=zxn9mus9bw9f4diq;password=r5gy2qtpjxnng0zb");
#pragma warning restore CS1030 // Directiva #warning
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             *Para eliminar este error que salio: The entity type 'IdentityUserLogin<string>' 
             * requires a primary key to be defined
             * */
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FK_AspNetRoleClaims_AspNetRoles_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Name).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_AspNetUserClaims_AspNetUsers_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_AspNetUserLogins_AspNetUsers_UserId");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderKey).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderDisplayName).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId).HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Email).HasColumnType("varchar(256)");

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedUserName).HasColumnType("varchar(256)");

                entity.Property(e => e.PasswordHash).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumber).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SecurityStamp).HasColumnType("longtext");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.Value).HasColumnType("longtext");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.ToTable("calendario");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("cliente_calendario_fk");

                entity.HasIndex(e => e.IdClinica)
                   .HasName("clinica_calendario_fk");

                entity.HasIndex(e => e.IdDoctor)
                    .HasName("doctor_calendario_fk");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("estado_calendario_fk");                

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FinFechaHora)
                    .HasColumnName("finFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdClinica)
                    .HasColumnName("idClinica")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdDoctor)
                    .HasColumnName("idDoctor")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.InicioFechaHora)
                    .HasColumnName("inicioFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Diagnostico)
                    .HasColumnName("diagnostico")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.Indicaciones)
                    .HasColumnName("indicaciones")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.Sintomas)
                    .HasColumnName("sintomas")
                    .HasColumnType("varchar(1024)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Calendario)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_calendario_fk");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Calendario)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clinica_calendario_fk");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Calendario)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_calendario_fk");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Calendario)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estado_calendario_fk");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("ciudad");

                entity.HasIndex(e => e.IdProvincia)
                    .HasName("fk_ciudad_provincia");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdProvincia)
                    .IsRequired()
                    .HasColumnName("idProvincia")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Ciudad)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ciudad_provincia");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.ToTable("clinica");

                entity.HasIndex(e => e.IdCiudad)
                    .HasName("fk_ciudad");

                entity.HasIndex(e => e.IdProvincia)
                    .HasName("fk_provincia");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_usuario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("idUsuario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InfoGeneral)
                    .HasColumnName("infoGeneral")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasColumnName("razonSocial")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.IdCiudad)
                    .IsRequired()
                    .HasColumnName("idCiudad")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdProvincia)
                    .IsRequired()
                    .HasColumnName("idProvincia")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clinica)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Clinica)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ciudad");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Clinica)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_provincia");
            });

            modelBuilder.Entity<ClinicaDoctor>(entity =>
            {
                entity.ToTable("clinica_doctor");

                entity.HasIndex(e => e.IdClinica)
                    .HasName("clinica_doctor_fk1");

                entity.HasIndex(e => e.IdDoctor)
                    .HasName("clinica_doctor_fk2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdClinica)
                    .HasColumnName("idClinica")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdDoctor)
                    .HasColumnName("idDoctor")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.ClinicaDoctor)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clinica_doctor_fk1");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.ClinicaDoctor)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clinica_doctor_fk2");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.InfoGeneral)
                    .IsRequired()
                    .HasColumnName("infoGeneral")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<DoctorEspecialidad>(entity =>
            {
                entity.ToTable("doctor_especialidad");

                entity.HasIndex(e => e.IdDoctor)
                    .HasName("doctor_especialidad_fk1");

                entity.HasIndex(e => e.IdEspecialidad)
                    .HasName("doctor_especialidad_fk2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdDoctor)
                    .HasColumnName("idDoctor")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdEspecialidad)
                    .HasColumnName("idEspecialidad")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.DoctorEspecialidad)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_especialidad_fk1");

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.DoctorEspecialidad)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_especialidad_fk2");
            });

            modelBuilder.Entity<DoctorTitulo>(entity =>
            {
                entity.ToTable("doctor_titulo");

                entity.HasIndex(e => e.IdDoctor)
                    .HasName("doctor_titulo_fk1");

                entity.HasIndex(e => e.IdTitulo)
                    .HasName("doctor_titulo_fk2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdDoctor)
                    .HasColumnName("idDoctor")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.IdTitulo)
                    .HasColumnName("idTitulo")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.DoctorTitulo)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_titulo_fk1");

                entity.HasOne(d => d.IdTituloNavigation)
                    .WithMany(p => p.DoctorTitulo)
                    .HasForeignKey(d => d.IdTitulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_titulo_fk2");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.ToTable("especialidad");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Especialidad1)
                    .IsRequired()
                    .HasColumnName("especialidad")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Estado1)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.ToTable("provincia");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");
            });

            modelBuilder.Entity<Titulo>(entity =>
            {
                entity.ToTable("titulo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Titulo1)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<UltimaHora>(entity =>
            {
                entity.ToTable("ultima_hora");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Comunicado)
                    .IsRequired()
                    .HasColumnName("comunicado")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fechaCreado")
                    .HasColumnType("date");

                entity.Property(e => e.HoraFin)
                    .HasColumnName("horaFin")
                    .HasColumnType("datetime");

                entity.Property(e => e.HoraInicio)
                    .HasColumnName("horaInicio")
                    .HasColumnType("datetime");
            });
        }
    }
}
