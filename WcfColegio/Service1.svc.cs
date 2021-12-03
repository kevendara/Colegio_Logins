using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entidades;
using Transaccion.Interfaz;

namespace WcfColegio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        ITransaccionColegio transaccionColegio;
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Service1(ITransaccionColegio transaccionColegio)
        {
            this.transaccionColegio = transaccionColegio;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }



        public List<tbl_user> GetUser()
        {
            List<tbl_user> user = transaccionColegio.GetUser();
            return user;
        }

        public void InsertUser(tbl_user nuevoAlumno)
        {
            transaccionColegio.InsertUser(nuevoAlumno);
        }

        public void UpdateUser(tbl_user actualizarAlumno)
        {
            transaccionColegio.UpdateUser(actualizarAlumno);
        }

        public void DeleteUser(tbl_user eliminarAlumno)
        {
            transaccionColegio.DeleteUser(eliminarAlumno);
        }

        public string Login(string usuario, string password)
        {
            return transaccionColegio.Login(usuario, password);
        }


        //ESTUDIANTES
        /*Listar todos los alumons*/
        public List<tbl_Estudiante> GetAlumnos()
        {
            return transaccionColegio.GetAlumnos();
        }

        /*Crear un alumno*/
        public void InsertAlumno(tbl_Estudiante nuevoAlumno)
        {
            transaccionColegio.InsertAlumno(nuevoAlumno);
        }

        /*Actualizar un alumno*/
        public void UpdateAlumno(tbl_Estudiante actualizarAlumno)
        {
            transaccionColegio.UpdateAlumno(actualizarAlumno);
        }

        //DOCENTES
        /*Listar todos los docentes*/
        public List<tbl_Docente> GetDocentes()
        {
            return transaccionColegio.GetDocentes();
        }

        /*Crear un docente*/
        public void InsertDocente(tbl_Docente nuevoDocente)
        {
            transaccionColegio.InsertDocente(nuevoDocente);
        }

        /*Actualizar un docente*/
        public void UpdateDocente(tbl_Docente actualizarDocente)
        {
            transaccionColegio.UpdateDocente(actualizarDocente);
        }

        //QUIMESTRES
        /*Listar todos los quimestres*/
        public List<tbl_Quimestre> GetQuimestres()
        {
            return transaccionColegio.GetQuimestres();
        }

        /*Crear un quimestre*/
        public void InsertQuimestre(tbl_Quimestre nuevoQuimestre)
        {
            transaccionColegio.InsertQuimestre(nuevoQuimestre);
        }

        /*Actualizar un quimestre*/
        public void UpdateQuimestre(tbl_Quimestre actualizarQuimestre)
        {
            transaccionColegio.UpdateQuimestre(actualizarQuimestre);
        }

        //AULAS
        /*Listar todas las aulas*/
        public List<tbl_Aula> GetAulas()
        {
            return transaccionColegio.GetAulas();
        }

        /*Crear un aula*/
        public void InsertAula(tbl_Aula nuevaAula)
        {
            transaccionColegio.InsertAula(nuevaAula);
        }

        /*Actualizar un aula*/
        public void UpdateAula(tbl_Aula actualizarAula)
        {
            transaccionColegio.UpdateAula(actualizarAula);
        }

        //MATERIAS
        /*Listar todas las materias*/
        public List<tbl_Materia> GetMaterias()
        {
            return transaccionColegio.GetMaterias();
        }

        /*Crear una materia*/
        public void InsertMateria(tbl_Materia nuevaMateria)
        {
            transaccionColegio.InsertMateria(nuevaMateria);
        }

        /*Actualizar una materia*/
        public void UpdateMateria(tbl_Materia actualizarMateria)
        {
            transaccionColegio.UpdateMateria(actualizarMateria);
        }

        //CLASES
        /*Listar todas las clases*/
        public List<tbl_Clase> GetClases()
        {
            return transaccionColegio.GetClases();
        }

        /*Crear una clase*/
        public void InsertClase(tbl_Clase nuevaClase)
        {
            transaccionColegio.InsertClase(nuevaClase);
        }

        /*Actualizar una clase*/
        public void UpdateClase(tbl_Clase actualizarClase)
        {
            transaccionColegio.UpdateClase(actualizarClase);
        }

        //ASISTENCIAS
        /*Listar todas las asistencias*/
        public List<tbl_Asistencia> GetAsistencias()
        {
            return transaccionColegio.GetAsistencias();
        }

        /*Crear una asistencia*/
        public void InsertAsistencia(tbl_Asistencia nuevaAsistencia)
        {
            transaccionColegio.InsertAsistencia(nuevaAsistencia);
        }

        /*Actualizar una asistencia*/
        public void UpdateAsistencia(tbl_Asistencia actualizarAsitencia)
        {
            transaccionColegio.UpdateAsistencia(actualizarAsitencia);
        }

        //NOTAS
        /*Listar todas las notas*/
        public List<tbl_Nota> GetNotas()
        {
            return transaccionColegio.GetNotas();
        }

        /*Crear una nota*/
        public void InsertNota(tbl_Nota nuevaNota)
        {
            transaccionColegio.InsertNota(nuevaNota);
        }

        /*Actualizar una nota*/
        public void UpdateNota(tbl_Nota actualizarNota)
        {
            transaccionColegio.UpdateNota(actualizarNota);
        }


        //VISTAS
        public List<vta_Clase> GetVistaClases()
        {
            return transaccionColegio.GetVistaClases();
        }
    }
}
