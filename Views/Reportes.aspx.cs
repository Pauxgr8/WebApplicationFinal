using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationFinal.Models;
using WebApplicationFinal.Services;

namespace WebApplicationFinal.Views
{
    public partial class Reportes : System.Web.UI.Page
    {
        private readonly ReporteService servicio = new ReporteService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Si no ha iniciado sesión
            if (Session["Rol"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            // El Encuestador no puede entrar a Reportes
            if (Session["Rol"].ToString() == "Encuestador")
            {
                Response.Redirect("Encuesta.aspx");
                return;
            }

            if (!IsPostBack)
            {
                // aquí queda todo tu código actual
            }
        }
        

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            switch (ddlReportes.SelectedValue)
            {
                case "1":
                    CargarReporte1ConFiltro();
                    break;
                case "2":
                    CargarReporte2();
                    break;
                case "3":
                    CargarReporte3();
                    break;
                case "4":
                    CargarReporte4();
                    break;
                case "5":
                    CargarReporte5();
                    break;
                case "6":
                    CargarReporte6();
                    break;
                case "7":
                    CargarReporte7();
                    break;
                case "8":
                    CargarReporte8();
                    break;
                case "9":
                    CargarReporte9();
                    break;
                case "10":
                    CargarReporte10();
                    break;
                case "11":
                    CargarReporte11();
                    break;
                case "12":
                    CargarReporte12();
                    break;
                case "13":
                    CargarReporte13();
                    break;
                case "14":
                    CargarReporte14();
                    break;
                case "15":
                    CargarReporte15();
                    break;
                case "31":
                    CargarReporte31(1);
                    break;
            }
        }

        private void CargarReporte1()
        {
            List<ReportePregunta1> datos = servicio.ObtenerReporte1();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.RangoEdad + " - " + x.TipoPrestamo)
                .ToList();

            var valores = datos
                .Select(x => x.Cantidad)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'bar');";

            ClientScript.RegisterStartupScript(
                this.GetType(),
                "grafico",
                script,
                true
            );
        }

        private void CargarReporte2()
        {
            List<ReportePlazo> datos = servicio.ObtenerReporte2();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.Plazo)
                .ToList();

            var valores = datos
                .Select(x => x.Cantidad)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'doughnut');";

            ClientScript.RegisterStartupScript(
                GetType(),
                "grafico",
                script,
                true);
        }
        private void CargarReporte3()
        {
            List<ReportePlazosMayores36> datos = servicio.ObtenerReporte3();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.Etiqueta)
                .ToList();

            var valores = datos
                .Select(x => x.Valor)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'pie');";

            ClientScript.RegisterStartupScript(
                GetType(),
                "grafico",
                script,
                true);
        }
        private void CargarReporte4()
        {
            List<ReporteMontoPromedio> datos = servicio.ObtenerReporte4();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.Etiqueta)
                .ToList();

            var valores = datos
                .Select(x => (double)x.Valor)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}],'bar');";

            ClientScript.RegisterStartupScript(
                GetType(),
                "grafico",
                script,
                true);
        }
        private void CargarReporte5()
        {
            List<ReporteIngresosBajos> datos = servicio.ObtenerReporte5();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.Etiqueta)
                .ToList();

            var valores = datos
                .Select(x => x.Valor)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'pie');";

            ClientScript.RegisterStartupScript(
                GetType(),
                "grafico5",
                script,
                true);
        }
        private void CargarReporte6()
        {
            List<ReporteNivelEducativo> datos = servicio.ObtenerReporte6();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.NivelEducativo)
                .ToList();

            var valores = datos
                .Select(x => x.Cantidad)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'bar');";

            ClientScript.RegisterStartupScript(
                GetType(),
                "grafico",
                script,
                true);
        }

        private void CargarReporte7()
        {
            List<ReporteMedioContratacion> datos = servicio.ObtenerReporte7();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos.Select(x => x.MedioContratacion).ToList();
            var valores = datos.Select(x => x.Cantidad).ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'pie');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }

        private void CargarReporte8()
        {
            List<ReporteCantidad> datos = servicio.ObtenerReporte8();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = new List<string> { "Clientes inactivos" };
            var valores = datos.Select(x => x.Cantidad).ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'doughnut');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }
        private void CargarReporte9()
        {
            List<ReportePromedioPago> datos = servicio.ObtenerReporte9();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos.Select(x => x.RangoEdad).ToList();
            var valores = datos.Select(x => (double)x.PromedioPago).ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'bar');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }

        private void CargarReporte10()
        {
            List<ReportePrestamoPlazo> datos = servicio.ObtenerReporte10();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.TipoPrestamo + " - " + x.Plazo)
                .ToList();

            var valores = datos
                .Select(x => x.Cantidad)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'bar');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }
        private void CargarReporte11()
        {
            List<ReporteTasaPromedio> datos = servicio.ObtenerReporte11();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos.Select(x => x.RangoIngresos).ToList();
            var valores = datos.Select(x => (double)x.PromedioTasa).ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'bar');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }
        private void CargarReporte12()
        {
            List<ReportePrestamoUniversitario> datos = servicio.ObtenerReporte12();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos.Select(x => x.TipoPrestamo).ToList();
            var valores = datos.Select(x => x.Cantidad).ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'pie');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }

        private void CargarReporte13()
        {
            List<ReporteDescripcion> datos = servicio.ObtenerReporte13();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos.Select(x => x.Descripcion).ToList();
            var valores = datos.Select(x => x.Cantidad).ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'doughnut');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }
        private void CargarReporte14()
        {
            List<ReporteEdadPrestamo> datos = servicio.ObtenerReporte14();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.Edad + " - " + x.Prestamo)
                .ToList();

            var valores = datos
                .Select(x => x.Cantidad)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'bar');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }
        private void CargarReporte15()
        {
            List<ReporteDescripcion> datos = servicio.ObtenerReporte15();

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos.Select(x => x.Descripcion).ToList();
            var valores = datos.Select(x => x.Cantidad).ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'doughnut');";

            ClientScript.RegisterStartupScript(GetType(), "grafico", script, true);
        }
        private void CargarReporte31(int idEdad)
        {
            List<ReportePregunta1> datos = servicio.ObtenerReporte31(idEdad);

            gvReporte.DataSource = datos;
            gvReporte.DataBind();

            var etiquetas = datos
                .Select(x => x.RangoEdad + " - " + x.TipoPrestamo)
                .ToList();

            var valores = datos
                .Select(x => x.Cantidad)
                .ToList();

            string labels = "'" + string.Join("','", etiquetas) + "'";
            string data = string.Join(",", valores);

            string script = $"cargarGrafico([{labels}], [{data}], 'bar');";

            ClientScript.RegisterStartupScript(
                GetType(),
                "grafico31",
                script,
                true);
        }
        private void CargarReporte1ConFiltro()
        {
            if (ddlFiltroEdad.SelectedValue == "0")
            {
                // Todos
                CargarReporte1();
            }
            else
            {
                int idEdad = Convert.ToInt32(ddlFiltroEdad.SelectedValue);
                CargarReporte31(idEdad);
            }
        }
    }
}