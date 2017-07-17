namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tarjeta")]
    public partial class Tarjeta
    {
        [Key]
        public int id_tarjeta { get; set; }

        public int id_solicitud { get; set; }

        [StringLength(100)]
        public string nombre_titular { get; set; }

        [Column(TypeName = "numeric")]
        public decimal nro_tarjeta { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cod_seguridad { get; set; }

        public DateTime fecha_emision { get; set; }

        public DateTime fecha_vencimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string entidad_emisora { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? extension_de { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? limite_credito { get; set; }

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

        public virtual Solicitud Solicitud { get; set; }
    }
}
