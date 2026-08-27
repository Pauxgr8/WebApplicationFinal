using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationFinal.Models;
using WebApplicationFinal.Services;

namespace WebApplicationFinal.Views
{
    public partial class Usuarios : Page
    {
        private CrudService servicio = new CrudService();

        private int IdUsuarioEditar
        {
            get
            {
                if (ViewState["IdUsuarioEditar"] == null)
                    return 0;

                return Convert.ToInt32(ViewState["IdUsuarioEditar"]);
            }
            set
            {
                ViewState["IdUsuarioEditar"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar que exista una sesión
            if (Session["Rol"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            // Solo Administradores
            if (Session["Rol"].ToString() != "Administrador")
            {
                Response.Redirect("Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }
        private void CargarUsuarios()
        {
            gvDatos.DataSource = servicio.ObtenerUsuarios();
            gvDatos.DataBind();
        }
        private void LimpiarFormulario()
        {
            ddlRol.SelectedIndex = 0;

            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";

            btnGuardar.Text = "Guardar";

            pnlUsuario.Visible = false;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            btnGuardar.Text = "Guardar";

            pnlUsuario.Visible = true;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlRol.SelectedValue))
                return;

            Usuario usuario = new Usuario();

            usuario.IdRol = Convert.ToInt32(ddlRol.SelectedValue);
            usuario.Nombre = txtNombre.Text;
            usuario.Correo = txtCorreo.Text;
            usuario.UsuarioLogin = txtUsuario.Text;
            usuario.Contrasena = txtPassword.Text;
            usuario.Activo = true;

            if (btnGuardar.Text == "Guardar")
            {
                usuario.UsuarioCreacion = Session["Nombre"].ToString();

                if (servicio.CrearUsuario(usuario))
                {
                    LimpiarFormulario();
                    CargarUsuarios();
                }
                else
                {
                    ClientScript.RegisterStartupScript(
                        GetType(),
                        "msg",
                        "alert('No fue posible crear el usuario');",
                        true);
                }
            }
            else
            {
                usuario.IdUsuario = IdUsuarioEditar;

                usuario.UsuarioCreacion = Session["Nombre"].ToString();
                usuario.UsuarioModificacion = Session["Nombre"].ToString();

                if (servicio.ModificarUsuario(usuario))
                {
                    LimpiarFormulario();
                    CargarUsuarios();

                    btnGuardar.Text = "Guardar";
                }
                else
                {
                    ClientScript.RegisterStartupScript(
                        GetType(),
                        "msg",
                        "alert('No fue posible actualizar el usuario');",
                        true);
                }
            }
        }

        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // ==========================
            // EDITAR
            // ==========================
            if (e.CommandName == "Editar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                IdUsuarioEditar =
                    Convert.ToInt32(gvDatos.DataKeys[fila].Value);

                GridViewRow row = gvDatos.Rows[fila];

                ddlRol.SelectedValue = row.Cells[3].Text;
                txtNombre.Text = Server.HtmlDecode(row.Cells[4].Text);
                txtCorreo.Text = Server.HtmlDecode(row.Cells[5].Text);
                txtUsuario.Text = Server.HtmlDecode(row.Cells[6].Text);
                txtPassword.Text = Server.HtmlDecode(row.Cells[7].Text);

                pnlUsuario.Visible = true;

                btnGuardar.Text = "Actualizar";
            }

            // ==========================
            // ELIMINAR
            // ==========================
            if (e.CommandName == "Eliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                int id =
                    Convert.ToInt32(gvDatos.DataKeys[fila].Value);

                bool eliminado =
                    servicio.EliminarUsuario(
                        id,
                        Session["Nombre"].ToString());

                if (eliminado)
                {
                    ClientScript.RegisterStartupScript(
                        GetType(),
                        "ok",
                        "alert('Usuario eliminado correctamente');",
                        true);

                    CargarUsuarios();

                    LimpiarFormulario();
                }
                else
                {
                    ClientScript.RegisterStartupScript(
                        GetType(),
                        "err",
                        "alert('No fue posible eliminar el usuario');",
                        true);
                }
            }
        }
    }
}