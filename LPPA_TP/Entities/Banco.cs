namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banco")]
    public partial class Banco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Banco()
        {
            Persona = new HashSet<Persona>();
        }

        [Key]
        public int id_banco { get; set; }

        [StringLength(40)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string descripcion { get; set; }

        [StringLength(200)]
        public string direccion_central { get; set; }

        [StringLength(40)]
        public string email { get; set; }

        [StringLength(40)]
        public string responsable { get; set; }

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
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
