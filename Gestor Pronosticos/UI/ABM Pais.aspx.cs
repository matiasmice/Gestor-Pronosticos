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
    private LogPais logpais = new LogPais();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCodPais.Focus();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {

            string codpais = txtCodPais.Text;
            Pais pais = logpais.Buscar(codpais);
            btnBuscar.Enabled = false;

            if (pais != null)
            {
                txtCodPais.Text = pais.CodPais;
                txtNombre.Text = pais.Nombre;

                txtCodPais.Enabled = false;
                txtNombre.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

            }
            else
            {
                lblPais.ForeColor = System.Drawing.Color.Red;
                lblPais.Text = "No existe el país buscado";
                txtNombre.Enabled = true;
                btnCrear.Enabled = true;

            }

        }
        catch (Exception ex)
        {
            lblPais.Text = ex.Message;
        }

    
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
     
        try
        {
            string nom = txtNombre.Text;
            string codPais = txtCodPais.Text;
            Pais pais = new Pais(nom,codPais);
            logpais.Editar(pais);
        }
        catch (Exception ex)
        {
            lblPais.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            
            lblPais.Text = string.Empty;
            txtNombre.Enabled = false;
            string codpais = txtCodPais.Text;
            Pais pais = logpais.Buscar(codpais);
            logpais.Eliminar(pais);           

        }
        catch (Exception ex)
        {
            
            lblPais.Text = ex.Message;
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
            string codPais = txtCodPais.Text;
            Pais pais = new Pais(nom, codPais);
            logpais.Crear(pais);
        }
        catch (Exception ex)
        {
            lblPais.Text = ex.Message;
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
        txtCodPais.Enabled = true;

        btnCrear.Enabled = false;
        btnEditar.Enabled = false;
        btnEliminar.Enabled = false;
    }    
}
