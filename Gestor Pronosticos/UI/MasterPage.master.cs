using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Session["usuario"] is Entidades.Usuario))
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                lblUsuarios.Text = "¡Hola: " + usuario.Nombre+"!";
            }
        }
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["usuario"] = null;
        lblUsuarios.Text = string.Empty;
        Response.Redirect("Default.aspx");
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
}