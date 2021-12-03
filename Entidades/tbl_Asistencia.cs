namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Asistencia
    {
        [Key]
        public int asi_id_asistencia { get; set; }

        public int? est_id_estudiante { get; set; }

        public int? cla_id_clase { get; set; }

        public DateTime asi_fecha_asistencia { get; set; }

        public bool asi_tomar_asistencia { get; set; }

        public virtual tbl_Clase tbl_Clase { get; set; }

        public virtual tbl_Estudiante tbl_Estudiante { get; set; }
    }
}
