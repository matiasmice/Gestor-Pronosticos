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
        if (!IsPostBack)
        {
            LogPais logPais = new LogPais();
            ddlPais.DataSource = logPais.Listar();
            ddlPais.DataValueField = "CodPais";
            ddlPais.DataTextField = "Dato";
            ddlPais.DataBind();

        }

    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        Pais pais = logPais.Buscar(ddlPais.SelectedValue);
        grvCiudades.DataSource = logCiudad.CiudadesPorPais(pais);
        grvCiudades.DataBind();

        


    }

    protected void grvCiudades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int fila = Convert.ToInt32(e.CommandArgument);
        string codCiud = grvCiudades.Rows[fila].Cells[2].Text;

        LogPronostico logPronostico = new LogPronostico();
        Ciudad ciudad = logCiudad.Buscar(codCiud, ddlPais.SelectedValue);
        List<Pronostico> pronosticos = logPronostico.PorCiudad(ciudad);

        grvPronosticosCiudad.DataSource = pronosticos;
        grvPronosticosCiudad.DataBind();
    }
}