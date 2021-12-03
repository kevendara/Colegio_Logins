using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfColegio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);
        
        [OperationContract]
        List<tbl_Estudiante> GetAlumnos();

        [OperationContract]
        List<tbl_Docente> GetDocentes();

        [OperationContract]
        List<tbl_Quimestre> GetQuimestres();

        [OperationContract]
        List<tbl_Aula> GetAulas();

        [OperationContract]
        List<tbl_Materia> GetMaterias();

        [OperationContract]
        List<tbl_Clase> GetClases();

        [OperationContract]
        List<tbl_Asistencia> GetAsistencias();

        [OperationContract]
        List<tbl_Nota> GetNotas();

        [OperationContract]
        List<vta_Clase> GetVistaClases();

        [OperationContract]
        void InsertAlumno(tbl_Estudiante nuevoAlumno);

        [OperationContract]
        void InsertDocente(tbl_Docente nuevoDocente);

        [OperationContract]
        void InsertMateria(tbl_Materia nuevaMateria);

        [OperationContract]
        void InsertAula(tbl_Aula nuevaAula);

        [OperationContract]
        void InsertQuimestre(tbl_Quimestre nuevoQuimestre);

        [OperationContract]
        void InsertClase(tbl_Clase nuevaClase);

        [OperationContract]
        void InsertNota(tbl_Nota nuevaNota);

        [OperationContract]
        void InsertAsistencia(tbl_Asistencia nuevaAsitencia);

        [OperationContract]
        void UpdateAlumno(tbl_Estudiante actualizarAlumno);

        [OperationContract]
        void UpdateDocente(tbl_Docente actualizarDocente);

        [OperationContract]
        void UpdateMateria(tbl_Materia actualizarMateria);

        [OperationContract]
        void UpdateAula(tbl_Aula actualizarAula);

        [OperationContract]
        void UpdateQuimestre(tbl_Quimestre actualizarQuimestre);

        [OperationContract]
        void UpdateClase(tbl_Clase actualizarClase);

        [OperationContract]
        void UpdateNota(tbl_Nota actualizarNota);

        [OperationContract]
        void UpdateAsistencia(tbl_Asistencia actualizarAsitencia);



        [OperationContract]
        List<tbl_user> GetUser();

        [OperationContract]
        void InsertUser(tbl_user nuevoAlumno);

        [OperationContract]
        void UpdateUser(tbl_user actualizarAlumno);

        [OperationContract]
        void DeleteUser(tbl_user eliminarUser);

        [OperationContract]
        string Login(string usuario, string password);


        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
