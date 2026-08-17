using System;
using System.Web.UI;
using WebApplicationFinal.Services;

namespace WebApplicationFinal.Views.CapacidadPago
{
    public partial class Index : Page
    {
        private readonly ICapacidadPagoService _service =
            new CapacidadPagoService();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var datos = await _service.ObtenerCapacidadesAsync();

                gvCapacidadPago.DataSource = datos;
                gvCapacidadPago.DataBind();
            }
        }
    }
}