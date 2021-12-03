using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeb
{
    public partial class Login : System.Web.UI.Page
    {

        Servicios.Colegio.Service1Client servicio = new Servicios.Colegio.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        protected void btnLogin_Click(Object sender, EventArgs e)
        {
            string usuario = this.UserName.Text;
            string contraseña = this.Password.Text;
            if (servicio.Login(usuario, contraseña) == "administrador")
            {
                Response.Redirect("Administrador.aspx", true);
            }
            else
            {
                if (servicio.Login(usuario, contraseña) == "docente")
                {
                    Response.Redirect("Docente.aspx", true);
                }
                else
                {
                    if (servicio.Login(usuario, contraseña) == "estudiante")
                    {
                        Response.Redirect("Estudiante.aspx", true);
                    }
                    else
                    {
                        if (servicio.Login(usuario, contraseña) == null)
                        {
                            MensajeEmergente("El usuario no existe.", "LOGIN", MessageBox.Icon.ERROR);
                        }
                    }
                }
            }
        }

        public void MensajeEmergente(string mensaje, string titulo, MessageBox.Icon icono)

        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = titulo,
                Message = mensaje,
                Buttons = MessageBox.Button.OK,
                Icon = icono
            });
        }
    }
}