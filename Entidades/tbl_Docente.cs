namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Docente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Docente()
        {
            tbl_Clase = new HashSet<tbl_Clase>();
        }

        [Key]
        public int doc_id_docente { get; set; }

        [Required]
        [StringLength(10)]
        public string doc_cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string doc_nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string doc_apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string doc_telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Clase> tbl_Clase { get; set; }
    }
}
