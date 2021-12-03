using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto
{
    public partial class Vistas : DbContext
    {
        public Vistas()
            : base("name=ITE_Colegio")
        {
        }

        public virtual DbSet<vta_Clase> vta_Clase { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vta_Clase>()
                .Property(e => e.doc_nombres)
                .IsUnicode(false);

            modelBuilder.Entity<vta_Clase>()
                .Property(e => e.doc_apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<vta_Clase>()
                .Property(e => e.mat_nombre_materia)
                .IsUnicode(false);

            modelBuilder.Entity<vta_Clase>()
                .Property(e => e.au_nombre_aula)
                .IsUnicode(false);
        }
    }
}
