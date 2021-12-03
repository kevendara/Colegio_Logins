using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Servicio.Implementacion;
using Transaccion.Interfaz;

namespace Transaccion.Implementacion
{
    public class TransaccionColegio: ITransaccionColegio
    {
        public AccesoColegio accesoColegio;
        public TransaccionColegio(AccesoColegio accesoColegio)
        {
            this.accesoColegio = accesoColegio;
        }


        public List<tbl_user> GetUser()
        {
            List<tbl_user> user = accesoColegio.GetUser();
            return user;
        }

        public void InsertUser(tbl_user nuevoAlumno)
        {
            accesoColegio.InsertUser(nuevoAlumno);
        }

        public void UpdateUser(tbl_user actualizarAlumno)
        {
            accesoColegio.UpdateUser(actualizarAlumno);
        }

        public void DeleteUser(tbl_user eliminarAlumno)
        {
            accesoColegio.DeleteUser(eliminarAlumno);
        }

        public string Login(string usuario, string password)
        {
            return accesoColegio.Login(usuario, password);
        }

        //TANSACCION ESTUDIANTE
        /*Listar todos los alumnos*/
        public List<tbl_Estudiante> GetAlumnos()
        {
            List<tbl_Estudiante>  alumnos = accesoColegio.GetAlumnos();
            // Procesamiento de Data
            return alumnos;
        }

        /*Crear un alumno*/
        public void InsertAlumno(tbl_Estudiante nuevoAlumno)
        {
            accesoColegio.InsertAlumno(nuevoAlumno);
        }

        /*Actualizar un alumno*/
        public void UpdateAlumno(tbl_Estudiante actualizarAlumno)
        {
            accesoColegio.UpdateAlumno(actualizarAlumno);
        }

        //TANSACCION DOCENTE
        /*Listar todos los docentes*/
        public List<tbl_Docente> GetDocentes()
        {
            List<tbl_Docente> docentes = accesoColegio.GetDocentes();
            return docentes;
        }

        /*Crear un docente*/
        public void InsertDocente(tbl_Docente nuevoDocente)
        {
            accesoColegio.InsertDocente(nuevoDocente);
        }

        /*Actualizar un docente*/
        public void UpdateDocente(tbl_Docente actualizarDocente)
        {
            accesoColegio.UpdateDocente(actualizarDocente);
        }

        //TANSACCION QUIMESTRE
        /*Listar todos los quimestres*/
        public List<tbl_Quimestre> GetQuimestres()
        {
            List<tbl_Quimestre> quimestres = accesoColegio.GetQuimestres();
            return quimestres;
        }

        /*Crear un quimestre*/
        public void InsertQuimestre(tbl_Quimestre nuevoQuimestre)
        {
            accesoColegio.InsertQuimestre(nuevoQuimestre);
        }

        /*Actualizar un quimestre*/
        public void UpdateQuimestre(tbl_Quimestre actualizarQuimestre)
        {
            accesoColegio.UpdateQuimestre(actualizarQuimestre);
        }

        //TANSACCION AULA
        /*Listar todas las aulas*/
        public List<tbl_Aula> GetAulas()
        {
            List<tbl_Aula> aulas = accesoColegio.GetAulas();
            return aulas;
        }

        /*Crear un aula*/
        public void InsertAula(tbl_Aula nuevaAula)
        {
            accesoColegio.InsertAula(nuevaAula);
        }

        /*Actualizar un aula*/
        public void UpdateAula(tbl_Aula actualizarAula)
        {
            accesoColegio.UpdateAula(actualizarAula);
        }

        //TANSACCION MATERIA
        /*Listar todas las materias*/
        public List<tbl_Materia> GetMaterias()
        {
            List<tbl_Materia> materias = accesoColegio.GetMaterias();
            return materias;
        }

        /*Crear una materia*/
        public void InsertMateria(tbl_Materia nuevaMateria)
        {
            accesoColegio.InsertMateria(nuevaMateria);
        }

        /*Actualizar una materia*/
        public void UpdateMateria(tbl_Materia actualizarMateria)
        {
            accesoColegio.UpdateMateria(actualizarMateria);
        }

        //TANSACCION CLASE
        /*Listar todas las clases*/
        public List<tbl_Clase> GetClases()
        {
            List<tbl_Clase> clases = accesoColegio.GetClases();
            return clases;
        }

        /*Crear una clase*/
        public void InsertClase(tbl_Clase nuevaClase)
        {
            accesoColegio.InsertClase(nuevaClase);
        }

        /*Actualizar una clase*/
        public void UpdateClase(tbl_Clase actualizarClase)
        {
            accesoColegio.UpdateClase(actualizarClase);
        }

        //TANSACCION ASISTENCIA
        /*Listar todas las asistencias*/
        public List<tbl_Asistencia> GetAsistencias()
        {
            List<tbl_Asistencia> asistencias = accesoColegio.GetAsistencias();
            return asistencias;
        }

        /*Crear una asistencia*/
        public void InsertAsistencia(tbl_Asistencia nuevaAsistencia)
        {
            accesoColegio.InsertAsistencia(nuevaAsistencia);
        }

        /*Actualizar una asistencia*/
        public void UpdateAsistencia(tbl_Asistencia actualizarAsitencia)
        {
            accesoColegio.UpdateAsistencia(actualizarAsitencia);
        }

        //TANSACCION NOTA
        /*Listar todas las notas*/
        public List<tbl_Nota> GetNotas()
        {
            List<tbl_Nota> notas = accesoColegio.GetNotas();
            return notas;
        }

        /*Crear una nota*/
        public void InsertNota(tbl_Nota nuevaNota)
        {
            accesoColegio.InsertNota(nuevaNota);
        }

        /*Actualizar una nota*/
        public void UpdateNota(tbl_Nota actualizarNota)
        {
            accesoColegio.UpdateNota(actualizarNota);
        }

        //VISTAS
        /*Vista vta_Clase*/
        public List<vta_Clase> GetVistaClases()
        {
            List<vta_Clase> vistaClases = accesoColegio.GetVistaClases();
            return vistaClases;
        }
    }
}
