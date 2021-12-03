namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Nota
    {
        [Key]
        public int not_id_nota { get; set; }

        public int? est_id_estudiante { get; set; }

        public int? qui_id_quimestre { get; set; }

        public int? cla_id_clase { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? not_nota1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? not_nota2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? not_nota3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? not_nota4 { get; set; }

        public virtual tbl_Clase tbl_Clase { get; set; }

        public virtual tbl_Estudiante tbl_Estudiante { get; set; }

        public virtual tbl_Quimestre tbl_Quimestre { get; set; }
    }
}
