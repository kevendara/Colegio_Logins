using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transaccion.Interfaz
{
    public interface ITransaccionColegio
    {
        List<tbl_Estudiante> GetAlumnos();
        List<tbl_Docente> GetDocentes();
        List<tbl_Quimestre> GetQuimestres();
        List<tbl_Aula> GetAulas();
        List<tbl_Materia> GetMaterias();
        List<tbl_Clase> GetClases();
        List<tbl_Asistencia> GetAsistencias();
        List<tbl_Nota> GetNotas();

        List<vta_Clase> GetVistaClases();

        void InsertAlumno(tbl_Estudiante nuevoAlumno);
        void InsertDocente(tbl_Docente nuevoDocente);
        void InsertMateria(tbl_Materia nuevaMateria);
        void InsertAula(tbl_Aula nuevaAula);
        void InsertQuimestre(tbl_Quimestre nuevoQuimestre);
        void InsertClase(tbl_Clase nuevaClase);
        void InsertNota(tbl_Nota nuevaNota);
        void InsertAsistencia(tbl_Asistencia nuevaAsitencia);

        void UpdateAlumno(tbl_Estudiante actualizarAlumno);
        void UpdateDocente(tbl_Docente actualizarDocente);
        void UpdateMateria(tbl_Materia actualizarMateria);
        void UpdateAula(tbl_Aula actualizarAula);
        void UpdateQuimestre(tbl_Quimestre actualizarQuimestre);
        void UpdateClase(tbl_Clase actualizarClase);
        void UpdateNota(tbl_Nota actualizarNota);
        void UpdateAsistencia(tbl_Asistencia actualizarAsitencia);


        List<tbl_user> GetUser();

        void InsertUser(tbl_user nuevoAlumno);

        void UpdateUser(tbl_user actualizarAlumno);

        void DeleteUser(tbl_user eliminarUser);

        string Login(string usuario, string password);
    }
}
