using System;
using WebApplicationFinal.Services;

namespace WebApplicationFinal.Views
{
    public partial class MisEncuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarEncuestas();
            }
        }

        private void CargarEncuestas()
        {
            int idUsuario = Convert.ToInt32(Session["IdUsuario"]);

            CrudService servicio = new CrudService();

            gvEncuestas.DataSource = servicio.ObtenerMisEncuestas(idUsuario);
            gvEncuestas.DataBind();
        }
    }
}