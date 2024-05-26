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
    private LogUsuario logUsr = new LogUsuario();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsuario.Focus();
        if (IsPostBack)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Black;
            lblMensaje.Text = string.Empty;
        }
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        try
        {
            string usr = txtUsuario.Text;
            string nom = txtNombre.Text;
            string ape = txtApellido.Text;
            string ctr = txtContrasenia.Text;
            Usuario usuario = new Usuario(nom, ape, usr, ctr);


            if (logUsr.Editar(usuario))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Usuario editado con éxito";
            }
        }
        catch (Exception ex)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = ex.Message;
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
            string usr = txtUsuario.Text;
            string nom = txtNombre.Text;
            string ape = txtApellido.Text;
            string ctr = txtContrasenia.Text;
            Usuario usuario = new Usuario(nom, ape, usr, ctr);


            if (logUsr.Eliminar(usuario))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Usuario eliminado con éxito";
            }
        }
        catch (Exception ex)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = ex.Message;
        }
        finally
        {
            LimpiarControles();
        }
    }

    protected void BtnCrearUsr_Click(object sender, EventArgs e)
    {
        try
        {
            string usr = txtUsuario.Text;
            string nom = txtNombre.Text;
            string ape = txtApellido.Text;
            string ctr = txtContrasenia.Text;
            Usuario usuario = new Usuario(nom, ape, usr, ctr);


            if (logUsr.Crear(usuario))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Usuario creado con éxito";
            }
        }
        catch (Exception ex)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = ex.Message;
        }
        finally
        {
            LimpiarControles();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtUsuario.Text != String.Empty)
        {
            Usuario usuario = logUsr.Buscar(txtUsuario.Text);
            btnBuscar.Enabled = false;

            if (usuario != null)
            {
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtContrasenia.Text = usuario.Contrasenia;

                txtUsuario.Enabled = false;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtContrasenia.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "No existe el usuario buscado. Complete los datos para crearlo";
                txtUsuario.Enabled = false;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtContrasenia.Enabled = true;
                btnCrearUsr.Enabled = true;
            }
        }
        else 
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = "Debe ingresar un nómbre de usuario"; 
        }
    }
    private void LimpiarControles()
    {
        //Vacía todas las TxtBox
        txtApellido.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtUsuario.Text = string.Empty;
        txtContrasenia.Text = string.Empty;

        //Habilita solamente la txtBox Usuario y el boton buscar
        txtUsuario.Enabled = true;
        
        btnBuscar.Enabled = true;
        btnCrearUsr.Enabled = false;
        btnEditar.Enabled = false;
        btnEliminar.Enabled = false;

        txtNombre.Enabled = false;
        txtApellido.Enabled = false;
        txtContrasenia.Enabled = false;
    }
}