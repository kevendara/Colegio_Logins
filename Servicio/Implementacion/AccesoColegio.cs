using Entidades;
using Repositorio.Interfaz;
using Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Implementacion
{
    public class AccesoColegio : IAccesoColegio
    {

        IEstudianteRepositorio alumnoRepositorio;
        IDocenteRepositorio docenteRepositorio;
        IQuimestreRepositorio quimestreRepositorio;
        IAulaRepositorio aulaRepositorio;
        IMateriaRepositorio materiaRepositorio;
        IClaseRepositorio claseRepositorio;
        IAsistenciaRepositorio asistenciaRepositorio;
        INotaRepositorio notaRepositorio;
        IVistaClaseRepositorio vistaClaseRepositorio;
        Itbl_UserRepositorio userRepositorio;

        public AccesoColegio(
            IEstudianteRepositorio alumnoRepositorio,
            IDocenteRepositorio docenteRepositorio,
            IQuimestreRepositorio quimestreRepositorio,
            IAulaRepositorio aulaRepositorio,
            IMateriaRepositorio materiaRepositorio,
            IClaseRepositorio claseRepositorio,
            IAsistenciaRepositorio asistenciaRepositorio,
            INotaRepositorio notaRepositorio,
            IVistaClaseRepositorio vistaClaseRepositorio,
            Itbl_UserRepositorio userRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
            this.docenteRepositorio = docenteRepositorio;
            this.quimestreRepositorio = quimestreRepositorio;
            this.aulaRepositorio = aulaRepositorio;
            this.materiaRepositorio = materiaRepositorio;
            this.claseRepositorio = claseRepositorio;
            this.asistenciaRepositorio = asistenciaRepositorio;
            this.notaRepositorio = notaRepositorio;
            this.vistaClaseRepositorio = vistaClaseRepositorio;
            this.userRepositorio = userRepositorio;
        }

        //public AccesoColegio(IDocenteRepositorio docenteRepositorio)
        //{
        //    this.docenteRepositorio = docenteRepositorio;
        //}

        public void Inicializar()
        {
            alumnoRepositorio.Inicializar();
            docenteRepositorio.Inicializar();
            quimestreRepositorio.Inicializar();
            aulaRepositorio.Inicializar();
            materiaRepositorio.Inicializar();
            claseRepositorio.Inicializar();
            asistenciaRepositorio.Inicializar();
            notaRepositorio.Inicializar();
            vistaClaseRepositorio.Inicializar();
        }


        //IMPLEMENTACION ESTUDIANTE
        /*Listar todos los alumnos*/
        public List<tbl_user> GetUser()
        {
            List<tbl_user> users = this.userRepositorio.All().ToList();

            return (from a in users
                    select new tbl_user
                    {
                        id = a.id,
                        nombreCuenta = a.nombreCuenta,
                        contraseña = a.contraseña,
                        tipoUsuario = a.tipoUsuario,
                        nombrePersona = a.nombrePersona
                    }).ToList();
        }

        /*Crear un alumno*/
        public void InsertUser(tbl_user nuevoAlumno)
        {
            this.userRepositorio.Create(nuevoAlumno);
        }

        /*Actualizar un alumno*/
        public void UpdateUser(tbl_user actualizarUser)
        {
            tbl_user encontrarEstudiante = this.userRepositorio.Find(
                t => t.id.Equals(actualizarUser.id));
            encontrarEstudiante.contraseña = actualizarUser.contraseña;
            encontrarEstudiante.nombreCuenta = actualizarUser.nombreCuenta;
            encontrarEstudiante.nombrePersona = actualizarUser.nombrePersona;
            encontrarEstudiante.tipoUsuario = actualizarUser.tipoUsuario;
            this.userRepositorio.Update(encontrarEstudiante);
        }


        public void DeleteUser(tbl_user deleteUser)
        {
            tbl_user encontrarEstudiante = this.userRepositorio.Find(
                t => t.id.Equals(deleteUser.id));
            this.userRepositorio.Delete(encontrarEstudiante);
        }
        public string Login(string usuario, string password)
        {

            tbl_user encontrarAdmin = this.userRepositorio.Find(
                    t => t.nombreCuenta == usuario && t.contraseña == password && t.tipoUsuario=="Administrador");

            tbl_user encontrarDocente = this.userRepositorio.Find(
                    t => t.nombreCuenta == usuario && t.contraseña == password && t.tipoUsuario == "Profesor");

            tbl_user encontrarEstudiante = this.userRepositorio.Find(
                    t => t.nombreCuenta == usuario && t.contraseña == password && t.tipoUsuario == "Estudiante");

            if (encontrarAdmin != null)
            {
                return "administrador";
            }
            else
            {
                if (encontrarDocente != null)
                {
                    return "docente";
                }
                else
                {
                    if (encontrarEstudiante != null)
                    {
                        return "estudiante";
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }



        //IMPLEMENTACION ESTUDIANTE
        /*Listar todos los alumnos*/
        public List<tbl_Estudiante> GetAlumnos()
        {
            List<tbl_Estudiante> alumnos = this.alumnoRepositorio.All().ToList();

            return (from a in alumnos
                    select new tbl_Estudiante
                    {
                        est_id_estudiante = a.est_id_estudiante,
                        est_cedula = a.est_cedula,
                        est_nombres = a.est_nombres,
                        est_apellidos = a.est_apellidos,
                        est_telefono = a.est_telefono
                    }).ToList();
        }

        /*Crear un alumno*/
        public void InsertAlumno(tbl_Estudiante nuevoAlumno)
        {
            this.alumnoRepositorio.Create(nuevoAlumno);
        }

        /*Actualizar un alumno*/
        public void UpdateAlumno(tbl_Estudiante actualizarEstudiante)
        {
            tbl_Estudiante encontrarEstudiante = this.alumnoRepositorio.Find(
                t => t.est_id_estudiante.Equals(actualizarEstudiante.est_id_estudiante));
            encontrarEstudiante.est_cedula = actualizarEstudiante.est_cedula;
            encontrarEstudiante.est_nombres = actualizarEstudiante.est_nombres;
            encontrarEstudiante.est_apellidos = actualizarEstudiante.est_apellidos;
            encontrarEstudiante.est_telefono = actualizarEstudiante.est_telefono;
            this.alumnoRepositorio.Update(encontrarEstudiante);
        }


        //IMPLEMENTACION DOCENTE
        /*Listar todos los docentes*/
        public List<tbl_Docente> GetDocentes()
        {
            List<tbl_Docente> docentes = this.docenteRepositorio.All().ToList();
            return (from d in docentes
                    select new tbl_Docente
                    {
                        doc_id_docente = d.doc_id_docente,
                        doc_cedula = d.doc_cedula,
                        doc_nombres = d.doc_nombres,
                        doc_apellidos = d.doc_apellidos,
                        doc_telefono = d.doc_telefono
                    }).ToList();
        }

        /*Crear un docente*/
        public void InsertDocente(tbl_Docente nuevoDocente)
        {
            this.docenteRepositorio.Create(nuevoDocente);
        }

        /*Actualizar un docente*/
        public void UpdateDocente(tbl_Docente actualizarDocente)
        {

            tbl_Docente encontrarDocente = this.docenteRepositorio.Find(t => t.doc_id_docente.Equals(actualizarDocente.doc_id_docente));
            encontrarDocente.doc_cedula = actualizarDocente.doc_cedula;
            encontrarDocente.doc_nombres = actualizarDocente.doc_nombres;
            encontrarDocente.doc_apellidos = actualizarDocente.doc_apellidos;
            encontrarDocente.doc_telefono = actualizarDocente.doc_telefono;
            this.docenteRepositorio.Update(encontrarDocente);
        }

        //IMPLEMENTACION QUIMESTRE
        /*Listar todos los quimestres*/
        public List<tbl_Quimestre> GetQuimestres()
        {
            List<tbl_Quimestre> quimestres = this.quimestreRepositorio.All().ToList();
            return (from q in quimestres
                    select new tbl_Quimestre
                    {
                        qui_id_quimestre = q.qui_id_quimestre,
                        qui_fecha_inicio = q.qui_fecha_inicio,
                        qui_fecha_fin = q.qui_fecha_fin,
                        qui_numero_quimestre = q.qui_numero_quimestre
                    }).ToList();
        }

        /*Crear un quimestre*/
        public void InsertQuimestre(tbl_Quimestre nuevoQuimestre)
        {
            this.quimestreRepositorio.Create(nuevoQuimestre);
        }

        /*Actualizar un quimestre*/
        public void UpdateQuimestre(tbl_Quimestre actualizarQuimestre)
        {
            tbl_Quimestre encontrarQuimestre = this.quimestreRepositorio.Find(t => t.qui_id_quimestre.Equals(actualizarQuimestre.qui_id_quimestre));
            encontrarQuimestre.qui_fecha_inicio = actualizarQuimestre.qui_fecha_inicio;
            encontrarQuimestre.qui_fecha_fin = actualizarQuimestre.qui_fecha_fin;
            encontrarQuimestre.qui_numero_quimestre = actualizarQuimestre.qui_numero_quimestre;
            this.quimestreRepositorio.Update(encontrarQuimestre);
        }

        //IMPLEMENTACION AULA
        /*Listar todas las aulas*/
        public List<tbl_Aula> GetAulas()
        {
            List<tbl_Aula> aulas = this.aulaRepositorio.All().ToList();
            return (from a in aulas
                    select new tbl_Aula
                    {
                        au_id_aula = a.au_id_aula,
                        au_nombre_aula = a.au_nombre_aula
                    }).ToList();
        }

        /*Crear un aula*/
        public void InsertAula(tbl_Aula nuevaAula)
        {
            this.aulaRepositorio.Create(nuevaAula);
        }

        /*Actualizar un aula*/
        public void UpdateAula(tbl_Aula actualizarAula)
        {
            tbl_Aula encontrarAula = this.aulaRepositorio.Find(t => t.au_id_aula.Equals(actualizarAula.au_id_aula));
            encontrarAula.au_nombre_aula = actualizarAula.au_nombre_aula;
            this.aulaRepositorio.Update(encontrarAula);
        }

        //IMPLEMENTACION MATERIA
        /*Listar todas las materias*/
        public List<tbl_Materia> GetMaterias()
        {
            List<tbl_Materia> materias = this.materiaRepositorio.All().ToList();
            return (from m in materias
                    select new tbl_Materia
                    {
                        mat_id_materia = m.mat_id_materia,
                        mat_cod_materia = m.mat_cod_materia,
                        mat_nombre_materia = m.mat_nombre_materia
                    }).ToList();
        }

        /*Crear una materia*/
        public void InsertMateria(tbl_Materia nuevaMateria)
        {
            this.materiaRepositorio.Create(nuevaMateria);
        }

        /*Actualizar una materia*/
        public void UpdateMateria(tbl_Materia actualizarMateria)
        {
            tbl_Materia encontrarMateria = this.materiaRepositorio.Find(t => t.mat_id_materia.Equals(actualizarMateria.mat_id_materia));
            encontrarMateria.mat_nombre_materia = actualizarMateria.mat_nombre_materia;
            encontrarMateria.mat_cod_materia = actualizarMateria.mat_cod_materia;
            this.materiaRepositorio.Update(encontrarMateria);
        }

        //IMPLEMENTACION CLASE
        /*Listar todas las clases*/
        public List<tbl_Clase> GetClases()
        {
            List<tbl_Clase> clases = this.claseRepositorio.All().ToList();
            return (from c in clases
                    select new tbl_Clase
                    {
                        cla_id_clase = c.cla_id_clase,
                        mat_id_materia = c.mat_id_materia,
                        doc_id_docente = c.doc_id_docente,
                        au_id_aula = c.au_id_aula
                    }).ToList();
        }

        /*Crear una materia*/
        public void InsertClase(tbl_Clase nuevaClase)
        {
            this.claseRepositorio.Create(nuevaClase);
        }

        /*Actualizar una clase*/
        public void UpdateClase(tbl_Clase actualizarClase)
        {
            tbl_Clase encontrarClase = this.claseRepositorio.Find(t => t.cla_id_clase.Equals(actualizarClase.cla_id_clase));
            encontrarClase.mat_id_materia = actualizarClase.mat_id_materia;
            encontrarClase.doc_id_docente = actualizarClase.doc_id_docente;
            encontrarClase.au_id_aula = actualizarClase.au_id_aula;
            this.claseRepositorio.Update(encontrarClase);
        }

        //IMPLEMENTACION ASISTENCIA
        /*Listar todas las asistencias*/
        public List<tbl_Asistencia> GetAsistencias()
        {
            List<tbl_Asistencia> asistenicias = this.asistenciaRepositorio.All().ToList();
            return (from a in asistenicias
                    select new tbl_Asistencia
                    {
                        asi_id_asistencia = a.asi_id_asistencia,
                        est_id_estudiante = a.est_id_estudiante,
                        cla_id_clase = a.cla_id_clase,
                        asi_fecha_asistencia = a.asi_fecha_asistencia,
                        asi_tomar_asistencia = a.asi_tomar_asistencia
                    }).ToList();
        }

        /*Crear una asistencia*/
        public void InsertAsistencia(tbl_Asistencia nuevaAsistencia)
        {
            this.asistenciaRepositorio.Create(nuevaAsistencia);
        }

        /*Actualizar una asistencia*/
        public void UpdateAsistencia(tbl_Asistencia actualizarAsitencia)
        {
            tbl_Asistencia encontrarAsistencia = this.asistenciaRepositorio.Find(t => t.asi_id_asistencia.Equals(actualizarAsitencia.asi_id_asistencia));
            encontrarAsistencia.est_id_estudiante = actualizarAsitencia.est_id_estudiante;
            encontrarAsistencia.cla_id_clase = actualizarAsitencia.cla_id_clase;
            encontrarAsistencia.asi_fecha_asistencia = actualizarAsitencia.asi_fecha_asistencia;
            encontrarAsistencia.asi_tomar_asistencia = actualizarAsitencia.asi_tomar_asistencia;
            this.asistenciaRepositorio.Update(encontrarAsistencia);
        }

        //IMPLEMENTACION NOTA
        /*Listar todas las notas*/
        public List<tbl_Nota> GetNotas()
        {
            List<tbl_Nota> notas = this.notaRepositorio.All().ToList();
            return (from n in notas
                    select new tbl_Nota
                    {
                        not_id_nota = n.not_id_nota,
                        est_id_estudiante = n.est_id_estudiante,
                        qui_id_quimestre = n.qui_id_quimestre,
                        cla_id_clase = n.cla_id_clase,
                        not_nota1 = n.not_nota1,
                        not_nota2 = n.not_nota2,
                        not_nota3 = n.not_nota3,
                        not_nota4 = n.not_nota4
                    }).ToList();
        }

        /*Crear una nota*/
        public void InsertNota(tbl_Nota nuevaNota)
        {
            this.notaRepositorio.Create(nuevaNota);
        }

        /*Actualizar una nota*/
        public void UpdateNota(tbl_Nota actualizarNota)
        {
            tbl_Nota encontrarNota = this.notaRepositorio.Find(t => t.not_id_nota.Equals(actualizarNota.not_id_nota));
            encontrarNota.est_id_estudiante = actualizarNota.est_id_estudiante;
            encontrarNota.qui_id_quimestre = actualizarNota.qui_id_quimestre;
            encontrarNota.cla_id_clase = actualizarNota.cla_id_clase;
            encontrarNota.not_nota1 = actualizarNota.not_nota1;
            encontrarNota.not_nota2 = actualizarNota.not_nota2;
            encontrarNota.not_nota3 = actualizarNota.not_nota3;
            encontrarNota.not_nota4 = actualizarNota.not_nota4;
            this.notaRepositorio.Update(encontrarNota);
        }


        //
        public List<vta_Clase> GetVistaClases()
        {
            List<vta_Clase> clases = this.vistaClaseRepositorio.All().ToList();
            return (from vc in clases
                    select new vta_Clase
                    {
                        cla_id_clase = vc.cla_id_clase,
                        doc_id_docente = vc.doc_id_docente,
                        doc_nombres = vc.doc_nombres,
                        doc_apellidos = vc.doc_apellidos,
                        mat_id_materia = vc.mat_id_materia,
                        mat_nombre_materia = vc.mat_nombre_materia,
                        au_id_aula = vc.au_id_aula,
                        au_nombre_aula = vc.au_nombre_aula
                    }).ToList();
        }
    }
}
