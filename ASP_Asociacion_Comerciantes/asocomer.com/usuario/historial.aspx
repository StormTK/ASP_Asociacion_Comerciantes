<%@ Page Title="" Language="C#" MasterPageFile="~/asocomer.com/usuario/usuario.Master" AutoEventWireup="true" CodeBehind="historial.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.asocomer.com.usuario.historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Historial de Acciones del Usuario</h2>
    <%

        if (Session["Usuario"] != null)
        {
            String[] usuario = (String[])Session["Usuario"];
            int idUsuarioHistorial = Convert.ToInt32(usuario[0]);
            Response.Write(MostrarHTMLHistorial(idUsuarioHistorial));
        }
    %>
</asp:Content>
