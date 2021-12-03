namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Quimestre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Quimestre()
        {
            tbl_Nota = new HashSet<tbl_Nota>();
        }

        [Key]
        public int qui_id_quimestre { get; set; }

        public DateTime qui_fecha_inicio { get; set; }

        public DateTime qui_fecha_fin { get; set; }

        [Required]
        [StringLength(2)]
        public string qui_numero_quimestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Nota> tbl_Nota { get; set; }
    }
}
