namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Estudiante()
        {
            tbl_Asistencia = new HashSet<tbl_Asistencia>();
            tbl_Nota = new HashSet<tbl_Nota>();
        }

        [Key]
        public int est_id_estudiante { get; set; }

        [Required]
        [StringLength(10)]
        public string est_cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string est_nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string est_apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string est_telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Asistencia> tbl_Asistencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Nota> tbl_Nota { get; set; }
    }
}
