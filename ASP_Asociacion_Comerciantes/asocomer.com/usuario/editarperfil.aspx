<%@ Page Title="" Language="C#" MasterPageFile="~/asocomer.com/usuario/usuario.Master" AutoEventWireup="true" CodeBehind="editarperfil.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.asocomer.com.usuario.editarperfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar Perfil</h2>
    <div class="formulario">
        

        
        <%
            if (Session["Usuario"] != null)
            {

                String[] usuario = (String[])Session["Usuario"];
                int idPerfil = Convert.ToInt32(usuario[0]);
                Response.Write("<p>Su E-mail:</p><input maxlength=\"60\" id=\"txt_correo\" class=\"txt_formulario\" value=\"" + Email(idPerfil) + "\" type=\"text\">");
                Response.Write("<p>Su Contraseña:</p><input maxlength=\"18\" id=\"txt_contraseña\" class=\"txt_formulario\" value=\"" + Password(idPerfil) + "\" type=\"text\">");
                Response.Write("<p>Su Nombre:</p><input maxlength=\"30\" id=\"txt_nombre\" class=\"txt_formulario\" value=\"" + Nombre(idPerfil) + "\" type=\"text\">");
                Response.Write("<p>Su Apellido:</p><input maxlength=\"30\" id=\"txt_apellido\" class=\"txt_formulario\" value=\"" + Apellido(idPerfil) + "\" type=\"text\">");
            }
        %>




        <asp:Button ID="btn_Enviar" Class="boton icon-usuario" runat="server" Text=" Registrarse" />
    </div>
</asp:Content>
