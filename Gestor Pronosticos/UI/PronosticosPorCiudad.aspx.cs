using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;
public partial class PronosticosPorCiudad : System.Web.UI.Page
{
    LogCiudad logCiudad = new LogCiudad();
    LogPais logPais = new LogPais();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                LogPais logPais = new LogPais();
                ddlPais.DataSource = logPais.Listar();
                ddlPais.DataValueField = "CodPais";
                ddlPais.DataTextField = "Dato";
                ddlPais.DataBind();
            }


        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }

    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text= string.Empty;
            grvCiudades.DataSource=null;
            grvCiudades.DataBind();
            grvPronosticosCiudad.Visible = false;
            Pais pais = logPais.Buscar(ddlPais.SelectedValue);
            if (logCiudad.CiudadesPorPais(pais).Count == 0)
            {
                lblMensaje.Text = "No hay cuidades ingresadas para el país seleccionado";
            }
            else
            {
                grvCiudades.DataSource = logCiudad.CiudadesPorPais(pais);
                grvCiudades.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }

    }

    protected void grvCiudades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            grvPronosticosCiudad.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            string codCiud = grvCiudades.Rows[fila].Cells[2].Text;
            lblMensaje.Text = string.Empty;
            LogPronostico logPronostico = new LogPronostico();
            Ciudad ciudad = logCiudad.Buscar(codCiud, ddlPais.SelectedValue);
            List<Pronostico> pronosticos = logPronostico.PorCiudad(ciudad);
            if (pronosticos.Count == 0)
            {
                lblMensaje.Text = "No hay pronósticos asociados para la cuidad seleccionada";
            }
            else
            {
                grvPronosticosCiudad.Visible = true;
                grvPronosticosCiudad.DataSource = pronosticos;
                grvPronosticosCiudad.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }

    }

    protected void grvCiudades_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}