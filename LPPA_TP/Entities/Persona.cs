namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persona")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Persona1 = new HashSet<Persona>();
            Solicitud = new HashSet<Solicitud>();
        }

        [Key]
        public int id_persona { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        public int? conyugue_de { get; set; }

        public DateTime fecha_nacimiento { get; set; }

        [Required]
        [StringLength(10)]
        public string sexo { get; set; }

        [Required]
        [StringLength(4)]
        public string tipo_documento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal nro_documento { get; set; }

        [Required]
        [StringLength(200)]
        public string domicilio { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? telefono { get; set; }

        [StringLength(50)]
        public string situacion_laboral { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ingreso_promedio { get; set; }

        public int? id_banco { get; set; }

        [StringLength(300)]
        public string documentacion_adjunta { get; set; }

        [StringLength(300)]
        public string foto { get; set; }

        public Guid? RowId { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(60)]
        public string CreatedBy { get; set; }

        public DateTime? ChangedOn { get; set; }

        [StringLength(60)]
        public string ChangedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        [StringLength(60)]
        public string DeletedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Banco Banco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Persona1 { get; set; }

        public virtual Persona Persona2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
