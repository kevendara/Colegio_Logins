namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Clase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Clase()
        {
            tbl_Asistencia = new HashSet<tbl_Asistencia>();
            tbl_Nota = new HashSet<tbl_Nota>();
        }

        [Key]
        public int cla_id_clase { get; set; }

        public int mat_id_materia { get; set; }

        public int doc_id_docente { get; set; }

        public int au_id_aula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Asistencia> tbl_Asistencia { get; set; }

        public virtual tbl_Aula tbl_Aula { get; set; }

        public virtual tbl_Docente tbl_Docente { get; set; }

        public virtual tbl_Materia tbl_Materia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Nota> tbl_Nota { get; set; }
    }
}
