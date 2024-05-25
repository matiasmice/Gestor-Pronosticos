using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;

public partial class _Default : System.Web.UI.Page
{
    LogPronostico logPronostico = new LogPronostico();
    List<Pronostico> pronosticos = new List<Pronostico>();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Cada vez q vuelvo o paso por la defaul realizo un Deslogueo
        Session["Usuario"] = null;

        try
        {
            pronosticos = logPronostico.PorFecha(Convert.ToDateTime(DateTime.Now));
            gdvPronostico.DataSource = pronosticos;
            gdvPronostico.DataBind();
        }
        catch (Exception ex)
        {
            lblDefault.Text = ex.Message;
        } 
    }
}