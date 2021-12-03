using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto
{
    public partial class ContextoUniversidad : DbContext
    {
        public ContextoUniversidad()
            : base("Name=ITE_Colegio")
        {
            this.Configuration.ValidateOnSaveEnabled = true;

        }

        public virtual DbSet<tbl_Asistencia> tbl_Asistencia { get; set; }
        public virtual DbSet<tbl_Aula> tbl_Aula { get; set; }
        public virtual DbSet<tbl_Clase> tbl_Clase { get; set; }
        public virtual DbSet<tbl_Docente> tbl_Docente { get; set; }
        public virtual DbSet<tbl_Estudiante> tbl_Estudiante { get; set; }
        public virtual DbSet<tbl_Materia> tbl_Materia { get; set; }
        public virtual DbSet<tbl_Nota> tbl_Nota { get; set; }
        public virtual DbSet<tbl_Quimestre> tbl_Quimestre { get; set; }

        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.nombreCuenta)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.tipoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.nombrePersona)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Aula>()
                    .Property(e => e.au_nombre_aula)
                    .IsUnicode(false);

            modelBuilder.Entity<tbl_Aula>()
                .HasMany(e => e.tbl_Clase)
                .WithRequired(e => e.tbl_Aula)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Docente>()
                .Property(e => e.doc_cedula)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Docente>()
                .Property(e => e.doc_nombres)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Docente>()
                .Property(e => e.doc_apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Docente>()
                .Property(e => e.doc_telefono)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Docente>()
                .HasMany(e => e.tbl_Clase)
                .WithRequired(e => e.tbl_Docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Estudiante>()
                .Property(e => e.est_cedula)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Estudiante>()
                .Property(e => e.est_nombres)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Estudiante>()
                .Property(e => e.est_apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Estudiante>()
                .Property(e => e.est_telefono)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Materia>()
                .Property(e => e.mat_cod_materia)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Materia>()
                .Property(e => e.mat_nombre_materia)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Materia>()
                .HasMany(e => e.tbl_Clase)
                .WithRequired(e => e.tbl_Materia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Nota>()
                .Property(e => e.not_nota1)
                .HasPrecision(8, 2);

            modelBuilder.Entity<tbl_Nota>()
                .Property(e => e.not_nota2)
                .HasPrecision(8, 2);

            modelBuilder.Entity<tbl_Nota>()
                .Property(e => e.not_nota3)
                .HasPrecision(8, 2);

            modelBuilder.Entity<tbl_Nota>()
                .Property(e => e.not_nota4)
                .HasPrecision(8, 2);

            modelBuilder.Entity<tbl_Quimestre>()
                .Property(e => e.qui_numero_quimestre)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }

}