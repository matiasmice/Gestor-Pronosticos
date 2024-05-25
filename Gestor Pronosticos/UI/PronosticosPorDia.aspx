<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PronosticosPorDia.aspx.cs" Inherits="PronosticosPorDia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style2 {
        font-size: x-large;
    }
    .auto-style3 {
        font-size: x-large;
        color: #009999;
    }
    .auto-style4 {
        color: #009999;
    }
        .auto-style6 {
            width: 440px;
            text-align: right;
        }
        .auto-style7 {
            width: 277px;
        }
    .auto-style8 {
        margin-left: 80;
    }
    .auto-style9 {
        width: 440px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span class="auto-style3">Pronósticos por fecha:</span><br class="auto-style4" />
<div>
    <table style="width:100%;">
        <tr>
            <td class="auto-style6">Ingrese una fecha:</td>
            <td class="auto-style7">
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="auto-style8" Width="255px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">
                <asp:GridView ID="grvPronPorFecha" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="Usuario" DataField="usuario.user" HeaderText="Usuario" />
                        <asp:BoundField AccessibleHeaderText="Ciudad" DataField="ciudad.nombre" HeaderText="Ciudad" />
                        <asp:BoundField DataField="ciudad.pais.nombre" HeaderText="Pais" SortExpression="ciudad.pais.nombre" />
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
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
</asp:Content>

