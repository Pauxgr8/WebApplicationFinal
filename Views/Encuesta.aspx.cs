using System;
using System.Linq;
using System.Web.UI;
using WebApplicationFinal.Models;
using WebApplicationFinal.Services;

namespace WebApplicationFinal.Views
{
    public partial class Encuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
            }
        }

        private void CargarCombos()
        {
            CrudService servicio = new CrudService();

            // Género
            ddlGenero.DataSource = servicio.ObtenerGeneros();
            ddlGenero.DataTextField = "Nombre";
            ddlGenero.DataValueField = "IdGenero";
            ddlGenero.DataBind();

            // Rango Edad
            ddlRangoEdad.DataSource = servicio.ObtenerRangoEdad();
            ddlRangoEdad.DataTextField = "Descripcion";
            ddlRangoEdad.DataValueField = "IdRangoEdad";
            ddlRangoEdad.DataBind();

            // Nivel Educativo
            ddlNivelEducativo.DataSource = servicio.ObtenerNivelEducativo();
            ddlNivelEducativo.DataTextField = "Nombre";
            ddlNivelEducativo.DataValueField = "IdNivelEducativo";
            ddlNivelEducativo.DataBind();

            // Rango Ingresos
            ddlRangoIngresos.DataSource = servicio.ObtenerRangoIngresos();
            ddlRangoIngresos.DataTextField = "Descripcion";
            ddlRangoIngresos.DataValueField = "IdRangoIngresos";
            ddlRangoIngresos.DataBind();

            // Tipo Préstamo
            ddlTipoPrestamo.DataSource = servicio.ObtenerTipoPrestamos();
            ddlTipoPrestamo.DataTextField = "Nombre";
            ddlTipoPrestamo.DataValueField = "IdTipoPrestamo";
            ddlTipoPrestamo.DataBind();

            // Plazo
            ddlPlazo.DataSource = servicio.ObtenerPlazos();
            ddlPlazo.DataTextField = "Descripcion";
            ddlPlazo.DataValueField = "IdPlazo";
            ddlPlazo.DataBind();

            // Tasa Interés
            ddlTasaInteres.DataSource = servicio.ObtenerTasasInteres();
            ddlTasaInteres.DataTextField = "Descripcion";
            ddlTasaInteres.DataValueField = "IdTasaInteres";
            ddlTasaInteres.DataBind();

            // Capacidad de Pago
            ddlCapacidadPago.DataSource = servicio.ObtenerCapacidadesPago();
            ddlCapacidadPago.DataTextField = "Descripcion";
            ddlCapacidadPago.DataValueField = "IdCapacidadPago";
            ddlCapacidadPago.DataBind();
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            CrudService servicio = new CrudService();

            Models.Encuesta encuesta =
                new Models.Encuesta();

            // Datos principales de la encuesta
            encuesta.FechaEncuesta = Convert.ToDateTime(txtFechaEncuesta.Text);

            // Ajusta estos dos según tu login
            encuesta.IdCliente = 1;
            encuesta.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);

            encuesta.IdTipoPrestamo = Convert.ToInt32(ddlTipoPrestamo.SelectedValue);
            encuesta.IdPlazo = Convert.ToInt32(ddlPlazo.SelectedValue);
            encuesta.IdTasaInteres = Convert.ToInt32(ddlTasaInteres.SelectedValue);
            encuesta.IdCapacidadPago = Convert.ToInt32(ddlCapacidadPago.SelectedValue);

            // Medio de contratación
            foreach (System.Web.UI.WebControls.ListItem item in cblMedio.Items)
            {
                if (item.Selected)
                {
                    encuesta.IdMedioContratacion = 1;
                    break;
                }
            }

            encuesta.UsuarioCreacion = Session["IdUsuario"].ToString();
            encuesta.Activo = true;

            bool resultado = servicio.CrearEncuesta(encuesta);

            if (!resultado)
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "msg",
                    "alert('No fue posible guardar la encuesta');",
                    true);

                return;
            }

            // Obtener la última encuesta creada
            var listaEncuestas = servicio.ObtenerEncuestas();

            WebApplicationFinal.Models.Encuesta ultimaEncuesta =
    listaEncuestas
        .OrderByDescending(x => x.IdEncuesta)
        .FirstOrDefault();

            if (ultimaEncuesta == null)
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "msg",
                    "alert('No se pudo recuperar la encuesta creada');",
                    true);

                return;
            }

            int idEncuesta = ultimaEncuesta.IdEncuesta;

            // AQUÍ empezaremos a guardar las respuestas

            void GuardarRespuesta(int idPregunta, string valor)
            {
                Respuesta respuesta = new Respuesta();

                respuesta.IdEncuesta = idEncuesta;
                respuesta.IdPregunta = idPregunta;
                respuesta.Valor = valor;
                respuesta.Activo = true;
                respuesta.UsuarioCreacion = "Administrador";

                servicio.CrearRespuesta(respuesta);
            }
            GuardarRespuesta(1, ddlGenero.SelectedValue);
            GuardarRespuesta(2, ddlRangoEdad.SelectedValue);
            GuardarRespuesta(3, ddlNivelEducativo.SelectedValue);
            GuardarRespuesta(4, ddlRangoIngresos.SelectedValue);
            GuardarRespuesta(5, ddlTipoPrestamo.SelectedValue);
            GuardarRespuesta(6, txtMontoDeseado.Text);
            GuardarRespuesta(7, ddlPlazo.SelectedValue);
            GuardarRespuesta(8, ddlTasaInteres.SelectedValue);
            GuardarRespuesta(9, ddlCapacidadPago.SelectedValue);
            GuardarRespuesta(10, rblHistorial.SelectedValue);
            GuardarRespuesta(11, rblMora.SelectedValue);
            GuardarRespuesta(12, ObtenerMedioSeleccionado());
            GuardarRespuesta(13, rblEmpleoFijo.SelectedValue);
            GuardarRespuesta(14, txtTiempoLaborar.Text);
            GuardarRespuesta(15, rblVivienda.SelectedValue);
            GuardarRespuesta(16, rblDeudas.SelectedValue);
            GuardarRespuesta(17, txtDependientes.Text);
            GuardarRespuesta(18, rblFiador.SelectedValue);
            GuardarRespuesta(19, rblPromociones.SelectedValue);
            GuardarRespuesta(20, rblOfertas.SelectedValue);
            ClientScript.RegisterStartupScript(

    GetType(),

    "ok",

    "alert('Encuesta enviada correctamente');window.location='Encuesta.aspx';",

    true);


        }

        private string ObtenerMedioSeleccionado()
        {
            foreach (System.Web.UI.WebControls.ListItem item in cblMedio.Items)
            {
                if (item.Selected)
                    return item.Value;
            }

            return "";
        }
    }
}