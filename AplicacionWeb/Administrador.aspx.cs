
using AplicacionWeb.Servicios.Colegio;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeb
{
    public partial class Index : System.Web.UI.Page
    {

        Servicios.Colegio.Service1Client servicio = new Servicios.Colegio.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridEstudiantes();
            GridDocentes();
            GridNotas();
            GridQuimestres();
            GridAsistencia();
            GridAulas();
            GridMaterias();
            GridClases();
            //GridVistaClases();
            GridUser();
        }

        protected void GridUser()
        {
            store_Usuarios.DataSource = servicio.GetUser();
            store_Usuarios.DataBind();
        }

        protected void InsertUsuarios()
        {
            //int iduser = this.idUsuario.Text;
            string contraseña = this.contrasenias.Text;
            string nombreCuenta = this.nombrePersonas.Text;
            string nombrePerson = this.nombresCuentas.Text;
            string tipoUsuario = this.tipoUsuario.Text;

            Servicios.Colegio.tbl_user usuario = new Servicios.Colegio.tbl_user
            {
                nombreCuenta = nombreCuenta,
                contraseña = contraseña,
                tipoUsuario= tipoUsuario,                
                nombrePersona = nombrePerson
            };
            servicio.InsertUser(usuario);

        }

        [DirectMethod]
        protected void InsertarUser(Object sender, EventArgs e)
        {
            InsertUsuarios();
            gridPanelUsuarios.Reload();
        }

        protected void UpdateUsuario()
        {
            int iduser = int.Parse(this.idUsuarios.Text);
            string contraseña = this.contrasenias.Text;
            string nombreCuenta = this.nombrePersonas.Text;
            string nombrePerson = this.nombresCuentas.Text;
            string tipoUsuario = this.tipoUsuario.Text;

            Servicios.Colegio.tbl_user usuario = new Servicios.Colegio.tbl_user
            {
                nombreCuenta = nombreCuenta,
                contraseña = contraseña,
                tipoUsuario = tipoUsuario,
                nombrePersona = nombrePerson
            };
            servicio.UpdateUser(usuario);
        }

        [DirectMethod]
        protected void ActualizarUsuario(Object sender, EventArgs e)
        {
            UpdateUsuario();
            gridPanelUsuarios.Reload();
        }


        protected void EliminarUsuario()
        {
            int iduser = int.Parse(this.idUsuarios.Text);
            string contraseña = contrasenias.Text;
            string nombreCuenta = nombrePersonas.Text;
            string nombrePerson = nombresCuentas.Text;

            Servicios.Colegio.tbl_user usuario = new Servicios.Colegio.tbl_user
            {
                id = iduser,
                contraseña = contraseña,
                nombreCuenta = nombreCuenta,
                nombrePersona = nombrePerson
            };
            servicio.DeleteUser(usuario);
        }

        [DirectMethod]
        protected void EliminarUsuario(object sender, EventArgs e)
        {
            EliminarUsuario();
            gridPanelUsuarios.Reload();
        }


        [DirectMethod]
        protected void LimpiarCampos(object sender, EventArgs e)
        {
            formPanelUsuarios.Reset();
        }


        //ESTUDIANTES
        /*Listar todos los alumnos*/
        protected void GridEstudiantes()
        {
            store_alumnos.DataSource = servicio.GetAlumnos();
            store_alumnos.DataBind();
        }

        /*Crear un alumno*/
        protected void InsertAlumno()
        {
            string cedula = cedulaEstudiante.Text;
            string nombre = nombresEstudiante.Text;
            string apellido = apellidosEstudiante.Text;
            string telefono = telefonoEstudiante.Text;

            tbl_Estudiante estudiante = new tbl_Estudiante
            {
                est_cedula = cedula,
                est_nombres = nombre,
                est_apellidos = apellido,
                est_telefono = telefono
            };

            servicio.InsertAlumno(estudiante);

        }

        /*Crear un alumno*/
        [DirectMethod]
        protected void InsertarEstudiante(Object sender, EventArgs e)
        {
            InsertAlumno();
            gridPanelAlumnos.Reload();
        }

        /*Actualizar un alumno*/
        protected void UpdateAlumno()
        {
            int id = int.Parse(idEstudiante.Text);
            string cedula = cedulaEstudiante.Text;
            string nombre = nombresEstudiante.Text;
            string apellido = apellidosEstudiante.Text;
            string telefono = telefonoEstudiante.Text;

            tbl_Estudiante estudiante = new tbl_Estudiante
            {
                est_id_estudiante = id,
                est_cedula = cedula,
                est_nombres = nombre,
                est_apellidos = apellido,
                est_telefono = telefono
            };
            servicio.UpdateAlumno(estudiante);
        }

        /*Actualizar un alumno*/
        [DirectMethod]
        protected void ActualizarEstudiante(Object sender, EventArgs e)
        {
            UpdateAlumno();
            gridPanelAlumnos.Reload();
        }

        //DOCENTES
        /*Listar todos los docentes*/
        protected void GridDocentes()
        {
            store_docentes.DataSource = servicio.GetDocentes();
            store_docentes.DataBind();
        }

        /*Crear un docente*/
        protected void InsertDocente()
        {
            string cedula = cedulaDocente.Text;
            string nombre = nombresDocente.Text;
            string apellido = apellidosDocente.Text;
            string telefono = telefonoDocente.Text;

            tbl_Docente docente = new tbl_Docente
            {
                doc_cedula = cedula,
                doc_nombres = nombre,
                doc_apellidos = apellido,
                doc_telefono = telefono
            };

            servicio.InsertDocente(docente);
        }

        /*Crear un docente*/
        [DirectMethod]
        protected void InsertarDocente(Object sender, EventArgs e)
        {
            InsertDocente();
            gridPanelDocentes.Reload();
        }

        /*Actualizar un docente*/
        protected void UpdateDocente()
        {
            int id = int.Parse(idDocente.Text);
            string cedula = cedulaDocente.Text;
            string nombre = nombresDocente.Text;
            string apellido = apellidosDocente.Text;
            string telefono = telefonoDocente.Text;

            tbl_Docente docente = new tbl_Docente
            {
                doc_id_docente = id,
                doc_cedula = cedula,
                doc_nombres = nombre,
                doc_apellidos = apellido,
                doc_telefono = telefono
            };

            servicio.UpdateDocente(docente);
        }

        /*Actualizar un docente*/
        [DirectMethod]
        protected void ActualizarDocente(Object sender, EventArgs e)
        {
            UpdateDocente();
            gridPanelDocentes.Reload();
        }


        //NOTAS
        /*Listar todas las notas*/
        protected void GridNotas()
        {
            store_notas.DataSource = servicio.GetNotas();
            store_notas.DataBind();
        }

        /*Crear una nota*/
        protected void InsertNota()
        {
            int estudiante = int.Parse(idNotaEstudiante.Text);
            int quimestre = int.Parse(idNotaQuimestre.Text);
            int clase = int.Parse(idNotaClase.Text);

            decimal nota1 = decimal.Parse(idNota1.Text);
            decimal nota2 = decimal.Parse(idNota2.Text);
            decimal nota3 = decimal.Parse(idNota3.Text);
            decimal nota4 = decimal.Parse(idNota4.Text);

            tbl_Nota nota = new tbl_Nota
            {
                est_id_estudiante = estudiante,
                qui_id_quimestre = quimestre,
                cla_id_clase = clase,
                not_nota1 = nota1,
                not_nota2 = nota2,
                not_nota3 = nota3,
                not_nota4 = nota4
            };
            servicio.InsertNota(nota);
        }

        /*Crear una nota*/
        [DirectMethod]
        protected void InsertarNotas(Object sender, EventArgs e)
        {
            InsertNota();
            gridPanelNotas.Reload();
        }

        /*Actualizar una nota*/
        protected void UpdateNota()
        {
            int id = int.Parse(idNota.Text);
            int estudiante = int.Parse(idNotaEstudiante.Text);
            int quimestre = int.Parse(idNotaQuimestre.Text);
            int clase = int.Parse(idNotaClase.Text);
            decimal nota1 = decimal.Parse(idNota1.Text);
            decimal nota2 = decimal.Parse(idNota2.Text);
            decimal nota3 = decimal.Parse(idNota3.Text);
            decimal nota4 = decimal.Parse(idNota4.Text);

            tbl_Nota nota = new tbl_Nota
            {
                not_id_nota = id,
                est_id_estudiante = estudiante,
                qui_id_quimestre = quimestre,
                cla_id_clase = clase,
                not_nota1 = nota1,
                not_nota2 = nota2,
                not_nota3 = nota3,
                not_nota4 = nota4
            };

            servicio.UpdateNota(nota);
        }

        /*Actualizar una nota*/
        [DirectMethod]
        protected void ActualizarNotas(Object sender, EventArgs e)
        {
            UpdateNota();
            gridPanelNotas.Reload();
        }

        //QUIMESTRES
        /*Listar todos los quimestres*/
        protected void GridQuimestres()
        {
            store_quimestre.DataSource = servicio.GetQuimestres();
            store_quimestre.DataBind();
        }

        /*Crear un quimestre*/
        protected void InsertQuimestre()
        {
            string fechaI = fechaInicio.Text;
            string fechaF = fechaInicio.Text;

            DateTime inicio = DateTime.Parse(fechaI);
            DateTime fin = DateTime.Parse(fechaF);

            string numero = numeroQuimestre.Text;

            tbl_Quimestre quimestre = new tbl_Quimestre
            {
                qui_fecha_inicio = inicio,
                qui_fecha_fin = fin,
                qui_numero_quimestre = numero
            };

            servicio.InsertQuimestre(quimestre);
        }

        /*Insertar un quimestre*/
        [DirectMethod]
        protected void InsertarQuimestre(Object sender, EventArgs e)
        {
            InsertQuimestre();
            gridPanelQuimestres.Reload();
        }

        /*Actualizar un quimestre*/
        protected void UpdateQuimestre()
        {
            int id = int.Parse(idQuimestre.Text);

            string fechaI = fechaInicio.Text;
            string fechaF = fechaInicio.Text;

            DateTime inicio = DateTime.Parse(fechaI);
            DateTime fin = DateTime.Parse(fechaF);

            string numero = numeroQuimestre.Text;

            tbl_Quimestre quimestre = new tbl_Quimestre
            {
                qui_id_quimestre = id,
                qui_fecha_inicio = inicio,
                qui_fecha_fin = fin,
                qui_numero_quimestre = numero
            };
            servicio.UpdateQuimestre(quimestre);
        }

        /*Actualizar un quimestre*/
        [DirectMethod]
        protected void UpdateQuimestre(Object sender, EventArgs e)
        {
            UpdateQuimestre();
            gridPanelQuimestres.Reload();
        }


        //ASISTENCIA
        /*Listar todas las asistencias*/
        protected void GridAsistencia()
        {
            store_asistencia.DataSource = servicio.GetAsistencias();
            store_asistencia.DataBind();
        }

        /*Crear un quimestre*/
        protected void InsertAsistencia()
        {

            int estudiante = int.Parse(idAsistenciaEstudiante.Text);
            int clase = int.Parse(idAsistenciaClase.Text);

            string fechaA = fechaAsistencia.Text;
            DateTime fecha = DateTime.Parse(fechaA);

            Boolean tomar = Boolean.Parse(tomarAsistencia.Text);

            tbl_Asistencia asistencia = new tbl_Asistencia
            {
                est_id_estudiante = estudiante,
                cla_id_clase = clase,
                asi_fecha_asistencia = fecha,
                asi_tomar_asistencia = tomar
            };

            servicio.InsertAsistencia(asistencia);
        }

        /*Insertar un quimestre*/
        [DirectMethod]
        protected void InsertarAsistencia(Object sender, EventArgs e)
        {
            InsertAsistencia();
            gridPanelAsistencia.Reload();
        }

        /*Actualizar un quimestre*/
        protected void UpdateAsistencia()
        {
            int id = int.Parse(idAsistencia.Text);
            int estudiante = int.Parse(idAsistenciaEstudiante.Text);
            int clase = int.Parse(idAsistenciaClase.Text);

            string fechaA = fechaAsistencia.Text;
            DateTime fecha = DateTime.Parse(fechaA);

            Boolean tomar = Boolean.Parse(tomarAsistencia.Text);

            tbl_Asistencia asistencia = new tbl_Asistencia
            {
                asi_id_asistencia = id,
                est_id_estudiante = estudiante,
                cla_id_clase = clase,
                asi_fecha_asistencia = fecha,
                asi_tomar_asistencia = tomar
            };

            servicio.UpdateAsistencia(asistencia);
        }

        /*Actualizar un quimestre*/
        [DirectMethod]
        protected void ActualizarAsistencia(Object sender, EventArgs e)
        {
            UpdateAsistencia();
            gridPanelAsistencia.Reload();
        }

        //AULAS
        /*Listar todas las aulas*/
        protected void GridAulas()
        {
            store_aula.DataSource = servicio.GetAulas();
            store_aula.DataBind();
        }

        /*Crear un aula*/
        protected void InsertAula()
        {
            string nombre = nombreAula.Text;

            tbl_Aula aula = new tbl_Aula
            {
                au_nombre_aula = nombre
            };

            servicio.InsertAula(aula);
        }

        /*Crear un aula*/
        [DirectMethod]
        protected void InsertarAula(Object sender, EventArgs e)
        {
            InsertAula();
            gridPanelAula.Reload();
        }

        /*Actualizar un aula*/
        protected void UpdatetAula()
        {
            int id = int.Parse(idAula.Text);
            string nombre = nombreAula.Text;

            tbl_Aula aula = new tbl_Aula
            {
                au_id_aula = id,
                au_nombre_aula = nombre
            };

            servicio.UpdateAula(aula);
        }

        /*Actualizar un aula*/
        [DirectMethod]
        protected void ActualizarAula(Object sender, EventArgs e)
        {
            UpdatetAula();
            gridPanelAula.Reload();
        }

        //MATERIAS
        /*Listar todas las materias*/
        protected void GridMaterias()
        {
            store_materias.DataSource = servicio.GetMaterias();
            store_materias.DataBind();
        }

        /*Crear una materia*/
        protected void InsertMateria()
        {
            string codigo = codigoMateria.Text;
            string nombre = nombreMateria.Text;

            tbl_Materia materia = new tbl_Materia
            {
                mat_cod_materia = codigo,
                mat_nombre_materia = nombre
            };

            servicio.InsertMateria(materia);
        }

        /*Crear una materia*/
        [DirectMethod]
        protected void InsertarMateria(Object sender, EventArgs e)
        {
            InsertMateria();
            gridPanelMaterias.Reload();
        }

        /*Actualizar una materia*/
        protected void UpdateMateria()
        {
            int id = int.Parse(idMateria.Text);
            string codigo = codigoMateria.Text;
            string nombre = nombreMateria.Text;

            tbl_Materia materia = new tbl_Materia
            {
                mat_id_materia = id,
                mat_cod_materia = codigo,
                mat_nombre_materia = nombre
            };
            servicio.UpdateMateria(materia);
        }

        /*Actualizar una materia*/
        [DirectMethod]
        protected void ActualizarMateria(Object sender, EventArgs e)
        {
            UpdateMateria();
            gridPanelMaterias.Reload();
        }

        //CLASES
        /*Listar todas las clases*/
        protected void GridClases()
        {
            store_clases.DataSource = servicio.GetClases();
            store_clases.DataBind();
        }

        /*Crear una clase*/
        protected void InsertClase()
        {
            int idMateria = int.Parse(idClaseMateria.Text);
            int idDocente = int.Parse(idClaseDocente.Text);
            int idAula = int.Parse(idClaseAula.Text);

            tbl_Clase clase = new tbl_Clase
            {
                mat_id_materia = idMateria,
                doc_id_docente = idDocente,
                au_id_aula = idAula
            };

            servicio.InsertClase(clase);
        }

        /*Crear una clase*/
        [DirectMethod]
        protected void InsertarClase(Object sender, EventArgs e)
        {
            InsertClase();
            gridPanelClase.Reload();
        }

        /*Actualizar una clase*/
        protected void UpdateClase()
        {
            int id = int.Parse(idClase.Text);
            int idMateria = int.Parse(idClaseMateria.Text);
            int idDocente = int.Parse(idClaseDocente.Text);
            int idAula = int.Parse(idClaseAula.Text);

            tbl_Clase clase = new tbl_Clase
            {
                cla_id_clase = id,
                mat_id_materia = idMateria,
                doc_id_docente = idDocente,
                au_id_aula = idAula
            };

            servicio.UpdateClase(clase);
        }

        /*Actualizar una clase*/
        [DirectMethod]
        protected void ActualizarClase(Object sender, EventArgs e)
        {
            UpdateClase();
            gridPanelClase.Reload();
        }

        ////VISTAS
        ///*Listar Vista Clase*/
        //private void GridVistaClases()
        //{
        //    store_vistaClases.DataSource = servicio.GetVistaClases();
        //    store_vistaClases.DataBind();
        //}

        ///*Insertar Vista Clase*/
        //protected void InsertVistaClase()
        //{
        //    int idMateria = int.Parse(idClaseVistaMateria.Text);
        //    int idDocente = int.Parse(idClaseVistaDocente.Text);
        //    int idAula = int.Parse(idClaseVistaAula.Text);

        //    tbl_Clase clase = new tbl_Clase
        //    {
        //        mat_id_materia = idMateria,
        //        doc_id_docente = idDocente,
        //        au_id_aula = idAula
        //    };

        //    servicio.InsertClase(clase);
        //}

        ///*Insertar Vista Clase*/
        //[DirectMethod]
        //protected void InsertarVistaClase(Object sender, EventArgs e)
        //{
        //    InsertVistaClase();
        //    gridPanelVistaClase.Reload();
        //}

        ///*Actualizar una clase*/
        //protected void UpdateClaseVista()
        //{
        //    int id = int.Parse(idClaseVista.Text);
        //    int idMateria = int.Parse(idClaseVistaMateria.Text);
        //    int idDocente = int.Parse(idClaseVistaDocente.Text);
        //    int idAula = int.Parse(idClaseVistaAula.Text);

        //    tbl_Clase clase = new tbl_Clase
        //    {
        //        cla_id_clase = id,
        //        mat_id_materia = idMateria,
        //        doc_id_docente = idDocente,
        //        au_id_aula = idAula
        //    };

        //    servicio.UpdateClase(clase);
        //}

        ///*Actualizar una clase*/
        //[DirectMethod]
        //protected void ActualizarClaseVista(Object sender, EventArgs e)
        //{
        //    UpdateClaseVista();
        //    gridPanelVistaClase.Reload();
        //}

        //Verificar que haya datos ingresados
        protected void CheckField(object sender, RemoteValidationEventArgs e)
        {
            TextField field = (TextField)sender;

            if (field.Text != null)
            {
                e.Success = true;
            }
            else
            {
                e.Success = false;
                e.ErrorMessage = "No ingreso algún campo.";
            }
            System.Threading.Thread.Sleep(1000);
        }

        protected void CheckCombo(object sender, RemoteValidationEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.SelectedItem.Value != null)
            {
                e.Success = true;
            }
            else
            {
                e.Success = false;
                e.ErrorMessage = "No ingreso algún campo.";
            }
            System.Threading.Thread.Sleep(1000);
        }

        
        //LIMPIAR CAMPOS
        [DirectMethod]
        protected void CleanTextFieldEstudiante(object sender, EventArgs e)
        {
            formPanelEstudiantes.Reset();
        }

        [DirectMethod]
        protected void CleanTextFieldDocente(object sender, EventArgs e)
        {
            formPanelDocentes.Reset();
        }

        [DirectMethod]
        protected void CleanTextFieldMateria(object sender, EventArgs e)
        {
            formPanelMaterias.Reset();
        }

        [DirectMethod]
        protected void CleanTextFieldNota(object sender, EventArgs e)
        {
            formPanelNotas.Reset();
        }

        [DirectMethod]
        protected void CleanTextFieldQuimestre(object sender, EventArgs e)
        {
            formPanelQuimestres.Reset();
        }

        [DirectMethod]
        protected void CleanTextFieldAsistencia(object sender, EventArgs e)
        {
            formPanelAsistencias.Reset();
        }

        [DirectMethod]
        protected void CleanTextFieldAula(object sender, EventArgs e)
        {
            formPanelAulas.Reset();
        }

        [DirectMethod]
        protected void CleanTextFieldClase(object sender, EventArgs e)
        {
            formPanelClases.Reset();
        }

        //[DirectMethod]
        //protected void CleanTextFieldVistaClase(object sender, EventArgs e)
        //{
        //    formPanelVistaClases.Reset();
        //}
    }
}