using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationFinal.Models;
using WebApplicationFinal.Services;

namespace WebApplicationFinal.Views
{
    public partial class GestionCRUD : Page
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
            // Validar sesión
            if (Session["Nombre"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            // Mostrar nombre del usuario
            lblNombre.Text = "Bienvenido, " + Session["Nombre"].ToString();

            // Cargar información únicamente la primera vez
            if (!IsPostBack)
            {
                ddlTablas.SelectedValue = "Usuarios";
                CargarTabla();
            }
        }

        private void CargarTabla()
        {
            switch (ddlTablas.SelectedValue)
            {
                case "Usuarios":
                    CargarUsuarios();
                    break;

                case "Clientes":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "Genero":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "NivelEducativo":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "RangoEdad":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "RangoIngresos":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "TipoPrestamo":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "Plazo":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "TasaInteres":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "CapacidadPago":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                case "MedioContratacion":
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;

                default:
                    gvDatos.DataSource = null;
                    gvDatos.DataBind();
                    break;
            }
        }

        protected void ddlTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private  void CargarUsuarios()

        {
            var datos = servicio.ObtenerUsuarios();

            gvDatos.DataSource = datos;
            gvDatos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlFormulario.Visible = true;
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
                    pnlFormulario.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('No se pudo crear el usuario');</script>");
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

                    pnlFormulario.Visible = false;
                    btnGuardar.Text = "Guardar";
                }
                else
                {
                    Response.Write("<script>alert('No se pudo actualizar el usuario');</script>");
                }
            }
        }
        private void LimpiarFormulario()
        {
            pnlFormulario.Visible = false;

            ddlRol.SelectedIndex = 0;

            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";

            btnGuardar.Text = "Guardar";

            CargarUsuarios();
        }
        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // ==========================
            // EDITAR
            // ==========================
            if (e.CommandName == "Editar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                IdUsuarioEditar = Convert.ToInt32(gvDatos.DataKeys[fila].Value);

                GridViewRow row = gvDatos.Rows[fila];

                ddlRol.SelectedValue = row.Cells[3].Text;
                txtNombre.Text = row.Cells[4].Text;
                txtCorreo.Text = row.Cells[5].Text;
                txtUsuario.Text = row.Cells[6].Text;
                txtPassword.Text = row.Cells[7].Text;

                pnlFormulario.Visible = true;
                btnGuardar.Text = "Actualizar";
            }

            // ==========================
            // ELIMINAR
            // ==========================
            if (e.CommandName == "Eliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                int id = Convert.ToInt32(gvDatos.DataKeys[fila].Value);

                if (servicio.EliminarUsuario(id, Session["Nombre"].ToString()))
                {
                    CargarUsuarios();

                    pnlFormulario.Visible = false;
                    btnGuardar.Text = "Guardar";
                }
            }
        }
    }
}