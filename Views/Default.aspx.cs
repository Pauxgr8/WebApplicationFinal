using System;
using System.Web.UI;
using WebApplicationFinal.Models;
using WebApplicationFinal.Services;

namespace WebApplicationFinal.Views
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                LoginService service = new LoginService();

                LoginRequest request = new LoginRequest
                {
                    Usuario = txtUsuario.Text.Trim(),
                    Contrasena = txtPassword.Text.Trim()
                };

                LoginResponse usuario = service.Login(request);

                if (usuario == null)
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                Session["IdUsuario"] = usuario.IdUsuario;
                Session["Nombre"] = usuario.Nombre;
                Session["Usuario"] = usuario.Usuario;
                Session["Rol"] = usuario.Rol;
                Session["IdRol"] = usuario.IdRol;

                if (usuario.Rol == "Administrador")
                {
                    Response.Redirect("GestionCRUD.aspx");
                }
                else if (usuario.Rol == "Consultor")
                {
                    Response.Redirect("Reportes.aspx");
                }
                else if (usuario.Rol == "Encuestador")
                {
                    Response.Redirect("Encuesta.aspx");
                }
                else
                {
                    lblMensaje.Text = "Rol no reconocido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}