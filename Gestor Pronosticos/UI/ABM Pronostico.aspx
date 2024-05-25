<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM Pronostico.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            text-align: left;
            width: 315px;
        }
        .auto-style3 {
            font-size: x-large;
            color: #009999;
            text-align: center;
            background-color: #FFFFFF;
        }
        .auto-style4 {
            font-size: large;
        }
        .auto-style6 {
            width: 413px;
            margin-left: 80px;
        }
        .auto-style7 {
            width: 140px;
            margin-left: 160px;
        }
        .auto-style8 {
            height: 30px;
            width: 413px;
            margin-left: 120px;
        }
        .auto-style9 {
            height: 30px;
        }
        .auto-style10 {
            width: 413px;
            margin-left: 200px;
        }
        .auto-style11 {
            height: 30px;
            text-align: right;
            width: 270px;
        }
        .auto-style12 {
            width: 270px;
        }
        .auto-style13 {
            text-align: right;
            width: 270px;
        }
        .auto-style14 {
            width: 413px;
        }
        .auto-style15 {
            font-size: large;
            color: #000000;
            width: 159px;
            background-color: #FFFFFF;
        }
        .auto-style16 {
            width: 413px;
            margin-left: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="auto-style3">
        &nbsp;
        Agregar un pronóstico</p>

<table style="width:100%;">
        <tr>
            <td class="auto-style15">Escoja un país:</td>
            <td class="auto-style7">
                <asp:DropDownList ID="ddlPais" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" Text="Listar Ciudades" OnClick="btnListar_Click" />
            </td>
        </tr>
    </table>
    <p>
        <span class="auto-style4">&nbsp;Seleccione una ciudad:</span><asp:GridView ID="grvCiudades" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="grvCiudades_RowCommand" OnSelectedIndexChanged="grvCiudades_SelectedIndexChanged1">
            <Columns>
                <asp:ButtonField Text="Seleccionar" />
                <asp:BoundField />
                <asp:BoundField />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style14">&nbsp;
        I<span class="auto-style4">ngrese los datos del prónostico</span></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">Fecha (mm/dd/aaaa hh:mm):
    </td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtFecha" runat="server" Enabled="False" TextMode="DateTimeLocal"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha" EnableClientScript="False" ErrorMessage="Ingrese una fecha"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Tipo de Cielo:
        </td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlTipoCielo" runat="server" Enabled="False" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="nuboso">Nuboso</asp:ListItem>
                        <asp:ListItem Value="parcialmente nuboso">Parcialmente nuboso</asp:ListItem>
                        <asp:ListItem Value="despejado">Despejado</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">Temperatura máxima (°C) :</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtTempMax" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTempMax" EnableClientScript="False" ErrorMessage="Ingrese un valor de Temperatura máxima"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Temperatura mínima (°C):</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtTempMin" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTempMin" EnableClientScript="False" ErrorMessage="Ingrese un valor de Temperatura minima"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtTempMax" ControlToValidate="txtTempMin" EnableClientScript="False" ErrorMessage="Temp. Máx no puede ser menor que Temp.Min" Operator="LessThanEqual" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">Probabilidad de lluvia (%):</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtProbLluvia" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProbLluvia" EnableClientScript="False" ErrorMessage="Ingrese una Probabilidad de lluvias"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Probabilidad de tormentas (%):</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtProbTornenta" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProbTornenta" EnableClientScript="False" ErrorMessage="Ingrese una Probabilidad de Tormentas"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Velocidad del viento (km/h):</td>
                <td class="auto-style10">
                    <asp:TextBox ID="txtVelviento" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtVelviento" EnableClientScript="False" ErrorMessage="Ingrese una Velocidad de viento"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" Enabled="False" OnClick="btnAgregar_Click" Text="Agregar" />
                </td>
            </tr>
        </table>
    </p>
    <p>
    </p>
</asp:Content>

