using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

public partial class Default2 : System.Web.UI.Page
{
    LogCiudad logCiudad = new LogCiudad();
    LogPais logPais = new LogPais();
    static Ciudad ciudad = null;

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

    protected void grvCiudades_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void grvCiudades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int fila = Convert.ToInt32(e.CommandArgument);


            string codCiud = grvCiudades.Rows[fila].Cells[2].Text;
            codCiud = grvCiudades.Rows[fila].Cells[4].Text; //El codigo cuidad me figura en la columna 4 no se por qué
            ciudad = logCiudad.Buscar(codCiud, ddlPais.SelectedValue);

            txtFecha.Enabled = true;
            txtProbLluvia.Enabled = true;
            txtProbTornenta.Enabled = true;
            txtTempMax.Enabled = true;
            txtTempMin.Enabled = true;
            ddlTipoCielo.Enabled = true;
            txtVelviento.Enabled = true;
            btnAgregar.Enabled = true;
            txtFecha.Focus();


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
            grvCiudades.DataSource = null;
            grvCiudades.DataBind();
            Pais pais = logPais.Buscar(ddlPais.SelectedValue);
            if (logCiudad.CiudadesPorPais(pais).Count == 0)
            {
                lblMensaje.Text = "No hay cuidades ingresadas para el país seleccionado";
            }
            else
            {
                lblMensaje.Text = string.Empty;
                grvCiudades.DataSource = logCiudad.CiudadesPorPais(pais);
                grvCiudades.DataBind();
                grvCiudades.Focus();
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            int probLlvia = Convert.ToInt32(txtProbLluvia.Text);
            int probTorm = Convert.ToInt32(txtProbTornenta.Text);
            int tempMax = Convert.ToInt32(txtTempMax.Text);
            int tempMin = Convert.ToInt32(txtTempMin.Text);
            string tipoCielo = ddlTipoCielo.SelectedValue;
            int velViento = Convert.ToInt32(txtVelviento.Text);

            LogPronostico logPronostico = new LogPronostico();
            Pronostico pronostico = new Pronostico(tipoCielo, (Usuario)Session["usuario"], ciudad, tempMax, tempMin,
                                                    probLlvia, probTorm, velViento, fecha);
            if (logPronostico.Agregar(pronostico))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Pronóstico agregado con éxito";
            }
            
        }
        catch (Exception ex)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = ex.Message;
        }
    }

    protected void grvCiudades_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTipoCielo.AutoPostBack = true;
    }
}