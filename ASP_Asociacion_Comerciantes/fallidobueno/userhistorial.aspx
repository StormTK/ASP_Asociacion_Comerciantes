<%@ Page Title="" Language="C#" MasterPageFile="~/AsociacionComerciantes.com/AsociacionComerciantes.Master" AutoEventWireup="true" CodeBehind="userhistorial.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.userhistorial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/perfil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <%
            if (Session["Usuario"] != null)
            {
                String[] variablesesion = (String[])Session["Usuario"];
                int idvisitante = Convert.ToInt32(variablesesion[0]);
                Response.Write(MostrarHistorialHTML(idvisitante));
            }
            else
            {
                Response.Redirect("login.aspx?msg=3");
            }

        %>
    </section>
</asp:Content>
