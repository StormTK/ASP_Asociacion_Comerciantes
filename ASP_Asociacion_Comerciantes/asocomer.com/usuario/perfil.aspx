<%@ Page Title="" Language="C#" MasterPageFile="~/asocomer.com/usuario/usuario.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.asocomer.com.usuario.perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Informacion del Usuario</h2>
    <div class="dato">
        <p class="tipo">Nombre:</p>
        <p class="valor">
            <%
                if (Request.QueryString.Get("id") != null)
                {
                    int idPerfil = Convert.ToInt32(Request.QueryString.Get("id"));
                    Response.Write(getNombreUsuario(idPerfil));
                }
            %>
        </p>
    </div>
    <div class="dato">
        <p class="tipo">E-mail:</p>
        <p class="valor">
            <%
                if (Request.QueryString.Get("id") != null)
                {
                    int idPerfil = Convert.ToInt32(Request.QueryString.Get("id"));
                    Response.Write(getEmail(idPerfil));
                }
            %>
        </p>
    </div>
    <div class="dato">
        <p class="tipo">Sexo:</p>
        <p class="valor">
            <%
                if (Request.QueryString.Get("id") != null)
                {
                    int idPerfil = Convert.ToInt32(Request.QueryString.Get("id"));
                    Response.Write(getSexoUsuario(idPerfil));
                }
            %>
        </p>
    </div>
    <div class="dato">
        <p class="tipo">Telefono:</p>
        <p class="valor">
            <%
                if (Request.QueryString.Get("id") != null)
                {
                    int idPerfil = Convert.ToInt32(Request.QueryString.Get("id"));
                    Response.Write(getTelefono(idPerfil));
                }
            %>
        </p>
    </div>
</asp:Content>
