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

                    pnlUsuario.Visible = false;
                    pnlCliente.Visible = false;
                    pnlGenero.Visible = false;

                    gvDatos.Visible = true;
                    gvClientes.Visible = false;
                    gvGenero.Visible = false;

                    CargarUsuarios();

                    break;

                case "Clientes":

                    pnlUsuario.Visible = false;
                    pnlCliente.Visible = false;
                    pnlGenero.Visible = false;

                    gvDatos.Visible = false;
                    gvClientes.Visible = true;
                    gvGenero.Visible = false;

                    CargarClientes();

                    break;

                case "Genero":

                    pnlUsuario.Visible = false;
                    pnlCliente.Visible = false;
                    pnlGenero.Visible = false;

                    gvDatos.Visible = false;
                    gvClientes.Visible = false;
                    gvGenero.Visible = true;

                    CargarGeneros();

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
            gvDatos.Visible = true;
            gvClientes.Visible = false;

            gvDatos.DataSource = servicio.ObtenerUsuarios();
            gvDatos.DataBind();
        }
        private void CargarClientes()
        {
            CrudService servicio = new CrudService();

            gvClientes.DataSource = servicio.ObtenerClientes();
            gvClientes.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            // Ocultar todos los formularios
            pnlUsuario.Visible = false;
            pnlCliente.Visible = false;
            pnlGenero.Visible = false;

            if (ddlTablas.SelectedValue == "Usuarios")
            {
                LimpiarFormulario();
                btnGuardar.Text = "Guardar";
                pnlUsuario.Visible = true;
            }
            else if (ddlTablas.SelectedValue == "Clientes")
            {
                LimpiarFormularioCliente();
                btnGuardarCliente.Text = "Guardar";
                pnlCliente.Visible = true;
            }
            else if (ddlTablas.SelectedValue == "Genero")
            {
                LimpiarFormularioGenero();
                btnGuardarGenero.Text = "Guardar";
                pnlGenero.Visible = true;
            }
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
                    pnlUsuario.Visible = false;
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

                    pnlUsuario.Visible = false;
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
            pnlUsuario.Visible = false;

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

                pnlUsuario.Visible = true;
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

                    pnlUsuario.Visible = false;
                    btnGuardar.Text = "Guardar";
                }
            }
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //========================
            // EDITAR
            //========================
            if (e.CommandName == "Editar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                // Obtener el Id del cliente seleccionado
                int idCliente = Convert.ToInt32(gvClientes.DataKeys[fila].Value);

                // Solo para comprobar
                Response.Write("<script>alert('Id Cliente = " + idCliente + "');</script>");

                // Guardar el Id para usarlo al actualizar
                ViewState["IdClienteEditar"] = idCliente;

                GridViewRow row = gvClientes.Rows[fila];

                txtNombreCliente.Text = Server.HtmlDecode(row.Cells[3].Text);
                txtApellidoCliente.Text = Server.HtmlDecode(row.Cells[4].Text);
                txtCorreoCliente.Text = Server.HtmlDecode(row.Cells[5].Text);
                txtTelefonoCliente.Text = Server.HtmlDecode(row.Cells[6].Text);

                // Mostrar únicamente el formulario de clientes
                pnlUsuario.Visible = false;
                pnlGenero.Visible = false;
                pnlCliente.Visible = true;

                btnGuardarCliente.Text = "Actualizar";
            }

            //========================
            // ELIMINAR
            //========================
            if (e.CommandName == "Eliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                int idCliente = Convert.ToInt32(gvClientes.DataKeys[fila].Value);

                if (servicio.EliminarCliente(idCliente, Session["Nombre"].ToString()))
                {
                    CargarClientes();
                }
            }
        }
        protected void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            CrudService servicio = new CrudService();

            Cliente cliente = new Cliente();

            cliente.Nombre = txtNombreCliente.Text;
            cliente.Apellido = txtApellidoCliente.Text;
            cliente.Correo = txtCorreoCliente.Text;
            cliente.Telefono = txtTelefonoCliente.Text;

            // Valores por defecto
            cliente.IdGenero = 1;
            cliente.IdNivelEducativo = 1;
            cliente.IdRangoEdad = 1;
            cliente.IdRangoIngresos = 1;

            cliente.Activo = true;

            if (btnGuardarCliente.Text == "Guardar")
            {
                cliente.UsuarioCreacion = Session["Nombre"].ToString();

                if (servicio.CrearCliente(cliente))
                {
                    CargarClientes();
                    LimpiarFormularioCliente();
                }
            }
            else
            {
                cliente.IdCliente = Convert.ToInt32(ViewState["IdClienteEditar"]);
                cliente.UsuarioModificacion = Session["Nombre"].ToString();

                if (servicio.ModificarCliente(cliente))
                {
                    CargarClientes();
                    LimpiarFormularioCliente();
                    btnGuardarCliente.Text = "Guardar";
                }
            }
        }

        private void LimpiarFormularioCliente()
        {
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            txtCorreoCliente.Text = "";
            txtTelefonoCliente.Text = "";

            pnlCliente.Visible = false;
        }
        private void CargarGeneros()
        {
            CrudService servicio = new CrudService();

            gvGenero.DataSource = servicio.ObtenerGeneros();
            gvGenero.DataBind();
        }

        private void LimpiarFormularioGenero()
        {
            txtNombreGenero.Text = "";
            chkActivoGenero.Checked = true;

            pnlGenero.Visible = false;
        }

        protected void btnGuardarGenero_Click(object sender, EventArgs e)
        {
            CrudService servicio = new CrudService();

            Genero genero = new Genero();

            genero.Nombre = txtNombreGenero.Text;
            genero.Activo = chkActivoGenero.Checked;

            if (btnGuardarGenero.Text == "Guardar")
            {
                genero.UsuarioCreacion = Session["Nombre"].ToString();

                if (servicio.CrearGenero(genero))
                {
                    CargarGeneros();
                    LimpiarFormularioGenero();
                    pnlGenero.Visible = false;
                }
            }
            else
            {
                genero.IdGenero = Convert.ToInt32(ViewState["IdGeneroEditar"]);
                genero.UsuarioModificacion = Session["Nombre"].ToString();

                if (servicio.ModificarGenero(genero))
                {
                    CargarGeneros();
                    LimpiarFormularioGenero();
                    pnlGenero.Visible = false;
                    btnGuardarGenero.Text = "Guardar";
                }
            }
        }

        protected void gvGenero_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CrudService servicio = new CrudService();

            // ============================
            // EDITAR
            // ============================
            if (e.CommandName == "Editar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                int idGenero = Convert.ToInt32(gvGenero.DataKeys[fila].Value);

                GridViewRow row = gvGenero.Rows[fila];

                ViewState["IdGeneroEditar"] = idGenero;

                txtNombreGenero.Text = row.Cells[3].Text;
                chkActivoGenero.Checked =
                    ((CheckBox)row.Cells[4].Controls[0]).Checked;

                pnlGenero.Visible = true;

                btnGuardarGenero.Text = "Actualizar";
            }

            // ============================
            // ELIMINAR
            // ============================
            if (e.CommandName == "Eliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                int idGenero = Convert.ToInt32(gvGenero.DataKeys[fila].Value);

                if (servicio.EliminarGenero(idGenero, Session["Nombre"].ToString()))
                {
                    CargarGeneros();

                    LimpiarFormularioGenero();

                    btnGuardarGenero.Text = "Guardar";
                }
            }
        }
    }
}