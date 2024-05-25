using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;

public partial class Login : System.Web.UI.Page
{
    LogUsuario logUsuario = new LogUsuario();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAcceder_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario usuario = logUsuario.Logueo(txtUsuario.Text, txtContrasenia.Text);
            if (usuario != null)
            {
                //Si los datos son correctos
                Session["Usuario"] = usuario;
                Response.Redirect("BienvenidaUsr.aspx");
            }
            else
            {
                lblLogin.Text = "Usuario y contraseña incorrectas";
            }
        }
        catch (Exception ex)
        {
            lblLogin.Text = ex.Message;
        }
    }
}