namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Solicitud")]
    public partial class Solicitud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud()
        {
            Tarjeta = new HashSet<Tarjeta>();
        }

        [Key]
        public int id_solicitud { get; set; }

        public DateTime? fecha_solicitud { get; set; }

        [StringLength(50)]
        public string estado_tramite { get; set; }

        public int id_terminal { get; set; }

        public int id_persona { get; set; }

        [StringLength(20)]
        public string entidad_emisora { get; set; }

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

        public virtual Persona Persona { get; set; }

        public virtual Terminal Terminal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
