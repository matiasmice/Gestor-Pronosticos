<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM Ciudad.aspx.cs" Inherits="EditUsr" %>

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
        <td class="auto-style3" colspan="3">Edición de Ciudades</td>
    </tr>
    <tr>
        <td class="auto-style9">Código de Ciudad:</td>
        <td colspan="2" class="text-start">
            <asp:TextBox ID="txtcodCiudad" runat="server" CssClass="auto-style5" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcodCiudad" EnableClientScript="False" ErrorMessage="Debe ingresar un código"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style9">Código País:</td>
        <td colspan="2" class="text-start">
            <asp:TextBox ID="txtCodPais" runat="server" Width="249px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCodPais" EnableClientScript="False" ErrorMessage="Debe ingresar un código"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style9">Nombre:</td>
        <td colspan="2" class="text-start">
            <asp:TextBox ID="txtNombre" runat="server" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre" EnableClientScript="False" ErrorMessage="Debe ingresar un nombre"></asp:RequiredFieldValidator>
            <asp:Button ID="btnBuscar" runat="server" OnClick="txtBuscar_Click" Text="Buscar" />
        </td>
    </tr>
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style8">
            &nbsp;</td>
        <td class="text-end"><span class="auto-style7">&nbsp;&nbsp;&nbsp;
                </span>
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" Enabled="False" />
            <span class="auto-style7">&nbsp;&nbsp;</span><asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="auto-style7" OnClick="btnEliminar_Click" Enabled="False" />
            <span class="auto-style7">&nbsp;<asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="BtnCrear_Click" Enabled="False" />
            &nbsp;</span></td>
    </tr>
    <tr>
        <td class="auto-style10" colspan="3">
            <asp:Label ID="lblCiudad" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

