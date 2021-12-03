namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vta_Clase
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cla_id_clase { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int doc_id_docente { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string doc_nombres { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string doc_apellidos { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mat_id_materia { get; set; }

        [StringLength(50)]
        public string mat_nombre_materia { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int au_id_aula { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string au_nombre_aula { get; set; }
    }
}
