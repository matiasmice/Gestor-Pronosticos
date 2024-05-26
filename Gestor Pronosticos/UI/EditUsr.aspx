<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUsr.aspx.cs" Inherits="EditUsr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style2 {
        text-align: center;
        font-size: x-large;
    }
    .auto-style3 {
        text-align: center;
        font-size: x-large;
        color: #0099CC;
            height: 36px;
        }
    .auto-style5 {
        text-align: center;
        font-size: medium;
        color: #000000;
    }
        .auto-style6 {
            margin-left: 448px;
        }
        .auto-style7 {
            font-size: medium;
        }
        .auto-style8 {
            font-size: medium;
            text-align: right;
        }
        .auto-style9 {
            text-align: right;
            font-size: large;
            color: #000000;
        }
        .auto-style10 {
            text-align: center;
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style6">
    <tr>
        <td class="auto-style3" colspan="3">Edición de Usuario</td>
    </tr>
    <tr>
        <td class="auto-style9">Usuario:</td>
        <td colspan="2" class="text-start">
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="auto-style5" Width="250px"></asp:TextBox>
        &nbsp;<asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        </td>
    </tr>
    <tr>
        <td class="auto-style9">Nombre:</td>
        <td colspan="2" class="text-start">
            <asp:TextBox ID="txtNombre" runat="server" Width="250px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style9">Apellido:</td>
        <td colspan="2" class="text-start">
            <asp:TextBox ID="txtApellido" runat="server" Width="249px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style9">Contraseña:</td>
        <td class="auto-style8">
            <asp:TextBox ID="txtContrasenia" runat="server" Width="248px" CssClass="auto-style7" TextMode="Password" Enabled="False"></asp:TextBox>
        </td>
        <td class="text-start">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style8">
            &nbsp;</td>
        <td class="text-end">
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" Enabled="False" />
            &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="auto-style7" OnClick="btnEliminar_Click" Enabled="False" />
            <span class="auto-style7">&nbsp;<asp:Button ID="btnCrearUsr" runat="server" Text="Crear" OnClick="BtnCrearUsr_Click" Enabled="False" />
            </span></td>
    </tr>
    <tr>
        <td class="auto-style10" colspan="3">
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

