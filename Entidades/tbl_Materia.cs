namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Materia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Materia()
        {
            tbl_Clase = new HashSet<tbl_Clase>();
        }

        [Key]
        public int mat_id_materia { get; set; }

        [StringLength(5)]
        public string mat_cod_materia { get; set; }

        [StringLength(50)]
        public string mat_nombre_materia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Clase> tbl_Clase { get; set; }
    }
}
