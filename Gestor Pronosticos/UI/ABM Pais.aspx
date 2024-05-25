<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM Pais.aspx.cs" Inherits="EditUsr" %>

<script runat="server">

</script>


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
        .auto-style11 {
            text-align: right;
            font-size: large;
            color: #000000;
            height: 28px;
        }
        .auto-style12 {
            text-align: left;
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style6">
    <tr>
        <td class="auto-style3" colspan="3">Edición de País</td>
    </tr>
    <tr>
        <td class="auto-style11"></td>
        <td colspan="2" class="auto-style12">
            </td>
    </tr>
    <tr>
        <td class="auto-style9">Código País:</td>
        <td colspan="2" class="text-start">
            <asp:TextBox ID="txtCodPais" runat="server" Width="249px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodPais" EnableClientScript="False" ErrorMessage="Debe ingresar un código"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style9">Nombre:</td>
        <td colspan="2" class="text-start">
            <asp:TextBox ID="txtNombre" runat="server" Width="250px" Enabled="False"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" EnableClientScript="False" ErrorMessage="Debe ingresar un nombre"></asp:RequiredFieldValidator>
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        </td>
    </tr>
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style8">
            &nbsp;</td>
        <td class="text-end">
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" Enabled="False" />
            <span class="auto-style7">&nbsp;&nbsp;</span><asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Enabled="False" />
            <span class="auto-style7">&nbsp;<asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="BtnCrear_Click" Enabled="False" />
            &nbsp;</span></td>
    </tr>
    <tr>
        <td class="auto-style10" colspan="3">
            <asp:Label ID="lblPais" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

