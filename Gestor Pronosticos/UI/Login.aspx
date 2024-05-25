<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

  h1, .h1 {
    font-size: 2.5rem;
  }

h1, .h1 {
  font-size: calc(1.375rem + 1.5vw);
}

h6, .h6, h5, .h5, h4, .h4, h3, .h3, h2, .h2, h1, .h1 {
  margin-top: 0;
  margin-bottom: 0.5rem;
  font-weight: 500;
  line-height: 1.2;
}

*,
*::before,
*::after {
  box-sizing: border-box;
}

        .auto-style2 {
            font-size: xx-large;
        }
    
b,
strong {
  font-weight: bolder;
}

        .auto-style1 {
            background-color: #fff;
            font-family: "Britannic Bold";
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            margin-left: 0px;
        }
        .auto-style5 {
            width: 15px;
            text-align: center;
        }
        .auto-style6 {
            width: 48%;
            margin-left: 455px;
        }
        .auto-style7 {
            width: 328px;
        }
        .auto-style9 {
            text-align: left;
            font-size: xx-large;
            color: #0099CC;
        }
        .auto-style10 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style3"><strong class="auto-style2" style="color: #009999; font-style: inherit; font-variant: normal; text-transform: inherit;"><span class="auto-style1">Pronósticos del tiempo</span></strong></h1>
                <asp:Menu ID="Menu1" runat="server" BackColor="#33CCCC" DynamicHorizontalOffset="2" Font-Bold="True" Font-Names="Georgia" Font-Size="Large" Font-Strikeout="False" ForeColor="Black" Orientation="Horizontal" StaticSubMenuIndent="10px">
                    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#E3EAEB" />
                    <DynamicSelectedStyle BackColor="#1C5E55" />
                    <Items>
                        <asp:MenuItem Text="Inicio" Value="Inicio" NavigateUrl="~/Default.aspx"></asp:MenuItem>
                    </Items>

                    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#1C5E55" />

                </asp:Menu>
        </div>
        <div class="auto-style3">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Logos/Gestor de Pron¢sticos3.png" />
            </div>
        <div>
            <h2>
                <table class="auto-style6">
                    <tr>
                        <td class="auto-style9" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Iniciar sesión</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Usuario:</td>
                        <td colspan="2" class="auto-style10">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="auto-style4" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Contraseña:</td>
                        <td class="auto-style7">
                            <asp:TextBox ID="txtContrasenia" runat="server" Width="248px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnAcceder" runat="server" CssClass="auto-style4" Text="Acceder" OnClick="btnAcceder_Click" />
&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3" colspan="3">
                            <asp:Label ID="lblLogin" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </h2>
        </div>
    </form>
</body>
</html>
