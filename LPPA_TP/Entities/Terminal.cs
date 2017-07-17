namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Terminal")]
    public partial class Terminal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Terminal()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        [Key]
        public int id_terminal { get; set; }

        [StringLength(40)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string descripcion { get; set; }

        [StringLength(200)]
        public string direccion { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
