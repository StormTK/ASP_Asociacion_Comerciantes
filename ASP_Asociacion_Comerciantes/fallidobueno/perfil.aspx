<%@ Page Title="" Language="C#" MasterPageFile="~/AsociacionComerciantes.com/AsociacionComerciantes.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.usuario.perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/perfil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <%
            if (Session["Usuario"] != null)
            {
                if (Request.QueryString.Get("id") != null)
                {
                    String stgid = Request.QueryString.Get("id");
                    int id = Convert.ToInt32(stgid);
                    String[] variablesesion = (String[])Session["Usuario"];
                    int idvisitante = Convert.ToInt32(variablesesion[0]);
                    Response.Write(MostrarPerfil(id,idvisitante));
                }
                else
                {
                    Response.Write("<p class=\"invalido\">:c <br />Error 404<br />Usuario No Encontrado</p>");
                }
            }
            else
            {
                Response.Redirect("login.aspx?msg=3");
            }
        %>

    </section>
</asp:Content>
