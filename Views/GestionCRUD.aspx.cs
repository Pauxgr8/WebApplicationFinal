using System;

namespace WebApplicationFinal.Views
{
    public partial class GestionCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            lblNombre.Text = Session["Nombre"].ToString();
        }
    }
}