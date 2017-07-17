namespace Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LPPA_Model : DbContext
    {
        public LPPA_Model()
            : base("name=LPPA_Model")
        {
        }

        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<Terminal> Terminal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banco>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .Property(e => e.direccion_central)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .Property(e => e.responsable)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .Property(e => e.ChangedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .Property(e => e.DeletedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.tipo_documento)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.nro_documento)
                .HasPrecision(11, 0);

            modelBuilder.Entity<Persona>()
                .Property(e => e.domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.telefono)
                .HasPrecision(20, 0);

            modelBuilder.Entity<Persona>()
                .Property(e => e.situacion_laboral)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.ingreso_promedio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Persona>()
                .Property(e => e.documentacion_adjunta)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.ChangedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.DeletedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Persona1)
                .WithOptional(e => e.Persona2)
                .HasForeignKey(e => e.conyugue_de);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Solicitud)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.estado_tramite)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.entidad_emisora)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.ChangedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.DeletedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .HasMany(e => e.Tarjeta)
                .WithRequired(e => e.Solicitud)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.nombre_titular)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.nro_tarjeta)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.cod_seguridad)
                .HasPrecision(4, 0);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.entidad_emisora)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.extension_de)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.limite_credito)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.ChangedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.DeletedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Terminal>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Terminal>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Terminal>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Terminal>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Terminal>()
                .Property(e => e.ChangedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Terminal>()
                .Property(e => e.DeletedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Terminal>()
                .HasMany(e => e.Solicitud)
                .WithRequired(e => e.Terminal)
                .WillCascadeOnDelete(false);
        }
    }
}
