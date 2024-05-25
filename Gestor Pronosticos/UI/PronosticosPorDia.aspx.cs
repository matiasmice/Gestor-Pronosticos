using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;

public partial class PronosticosPorDia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMensaje.Text = string.Empty;
        txtFecha.Focus();
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        LogPronostico logPronostico = new LogPronostico();
        List<Pronostico> pronosticos = new List<Pronostico>();
        try
        {
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            pronosticos = logPronostico.PorFecha(fecha);
            grvPronPorFecha.DataSource = pronosticos;
            grvPronPorFecha.DataBind();
            if (pronosticos.Count ==0)
            {
                lblMensaje.Text=("No hay pronósticos para la fecha ingresada");
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }

    }
}