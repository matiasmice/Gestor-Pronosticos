using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

public partial class EditUsr : System.Web.UI.Page
{
    private LogCiudad logCiudad = new LogCiudad();
    private LogPais logpais = new LogPais();
    protected void Page_Load(object sender, EventArgs e)
    {        
        txtCodPais.Focus();
        txtcodCiudad.Focus();
        txtNombre.Enabled = false;
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {

        try
        {
            string nom = txtNombre.Text;
            string codCiudad = txtcodCiudad.Text;
            string codPais = txtCodPais.Text;
            Pais pais = logpais.Buscar(codPais);
            Ciudad ciudad = new Ciudad(nom, codCiudad, pais);    
            logCiudad.Editar(ciudad);
        }
        catch (Exception ex)
        {
            lblCiudad.Text = ex.Message;
        }
        finally
        {
            LimpiarControles();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            string nom = txtNombre.Text;
            string codCiudad = txtcodCiudad.Text;
            string codPais = txtCodPais.Text;
            Pais pais = logpais.Buscar(codPais);
            Ciudad ciudad = new Ciudad(nom, codCiudad, pais);
            logCiudad.Eliminar(ciudad);
        }
        catch (Exception ex)
        {
            lblCiudad.Text = ex.Message;
        }
        finally
        {
            LimpiarControles();
        }
    }

    protected void BtnCrear_Click(object sender, EventArgs e)
    {
        try
        {
            string nom = txtNombre.Text;
            string codCiudad = txtcodCiudad.Text;
            string codPais = txtCodPais.Text;
            Pais pais = logpais.Buscar(codPais);
            Ciudad ciudad = new Ciudad(nom, codCiudad, pais);
            logCiudad.Crear(ciudad);
        }
        catch (Exception ex)
        {
            lblCiudad.Text = ex.Message;
        }
        finally
        {
            LimpiarControles();
        }
    }
    private void LimpiarControles()
    {

        txtCodPais.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtcodCiudad.Text = string.Empty;
        btnCrear.Enabled = false;
        btnEditar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;


    }

    protected void txtBuscar_Click(object sender, EventArgs e)
    {
        lblCiudad.Text = string.Empty;
        if (txtCodPais.Text == string.Empty)
            lblCiudad.Text = "Indique el código del país";
        else if (txtcodCiudad.Text == string.Empty)
            lblCiudad.Text = "Indique el código de ciudad";
        else
        {
            try
            {

                string codpais = txtCodPais.Text;
                string codciudad = txtcodCiudad.Text;
                Ciudad ciudad = logCiudad.Buscar(codciudad, codpais);


                if (ciudad != null)
                {
                    txtCodPais.Text = ciudad.Pais.CodPais;
                    txtNombre.Text = ciudad.Nombre;
                    txtcodCiudad.Text = ciudad.CodCiudad;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    txtNombre.Enabled = true;
                    btnBuscar.Enabled = false;

                }
                else
                {
                    lblCiudad.ForeColor = System.Drawing.Color.Red;
                    lblCiudad.Text = "No existe la ciudad buscada";
                    btnCrear.Enabled = true;
                    txtNombre.Enabled = true;


                }

            }
            catch (Exception ex)
            {
                lblCiudad.ForeColor = System.Drawing.Color.Red;
                lblCiudad.Text = ex.Message;
                btnCrear.Enabled = true;
            } 
        }

    }
}

    
