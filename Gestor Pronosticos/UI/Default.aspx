<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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

b,
strong {
  font-weight: bolder;
}

        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style3 {
            font-size: x-large;
            color: #009999;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1"><strong class="auto-style2" style="color: #009999; font-style: inherit; font-variant: normal; text-transform: inherit;"><span class="auto-style1">Pronósticos del tiempo</span></strong></h1>
            <div class="auto-style2">
                <asp:Menu ID="Menu1" runat="server" BackColor="#33CCCC" DynamicHorizontalOffset="2" Font-Bold="True" Font-Names="Georgia" Font-Size="Large" Font-Strikeout="False" ForeColor="Black" Orientation="Horizontal" StaticSubMenuIndent="10px">
                    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#E3EAEB" />
                    <DynamicSelectedStyle BackColor="#1C5E55" />
                    <Items>
                        <asp:MenuItem Text="Iniciar Sesión" Value="Iniciar Sesión" NavigateUrl="~/Login.aspx"></asp:MenuItem>
                    </Items>

                    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#1C5E55" />

                </asp:Menu>
            </div>
        </div>
        <p class="auto-style1">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Logos/Gestor de Pron¢sticos3.png" />
            </p>
    <p class="auto-style3">
        Pronósticos para el día de hoy:</p>
        <p>
            <asp:GridView ID="gdvPronostico" runat="server">
            </asp:GridView>
        </p>
        <p>
            <asp:Label ID="lblDefault" runat="server"></asp:Label>
        </p>
    </form>
    </body>
</html>
