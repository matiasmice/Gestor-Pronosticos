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


            logUsr.Editar(usuario);
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
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


            logUsr.Eliminar(usuario);
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
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


            logUsr.Crear(usuario);
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Usuario usuario = logUsr.Buscar(txtUsuario.Text);
        btnBuscar.Enabled = false;

        if (usuario !=null)
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
            lblMensaje.Text = "No existe el usuario buscado";
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtContrasenia.Enabled = true;
            BtnCrearUsr.Enabled = true;
        }
    }
}