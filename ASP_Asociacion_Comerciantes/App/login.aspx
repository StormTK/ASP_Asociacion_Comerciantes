<%@ Page Title="" Language="C#" MasterPageFile="~/App/AsociacionComerciantes.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.App.js.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section>
        <form class="formulario" runat="server">
            <h1>Crear Usuario</h1>
            <%
                    if ( Request.QueryString.Get("Error") != null){
                        int Error = Int32.Parse(Request.QueryString.Get("Error"));
                        switch(Error){
                            case 1:
                                Response.Write("<p class=\"error\" >El E-mail ingresado es invalido</p>");
                                break;
                            case 2:
                                Response.Write("<p class=\"error\" >Algunos campos estan vacios</p>");
                                break;
                            case 3:
                                Response.Write("<p class=\"error\" >La Contraseña es muy corta, debe tener al menos 8 Caracteres</p>");
                                break;
                            case 4:
                                Response.Write("<p class=\"error\" >La Contraseña debe tener al menos una Minuscula, una Mayuscula y un Numero</p>");
                                break;
                        }
                    }
                    
                     %>
            <p>Ingrese su e-mail</p>
            <asp:TextBox runat="server" ID="txt_correo" CssClass="txt_formulario" value="@"></asp:TextBox>
            <p>Ingrese su Contraseña</p>
            <asp:TextBox runat="server" ID="txt_contraseña" type="Password" CssClass ="txt_formulario" placeholder="Ingrese su contra--seña..."></asp:TextBox>
            <asp:Button ID="btn_Enviar" Class="boton" runat="server" Text="Ingresar" />
            <p><a>Olvide mi Contraseña</a>|<a>Registrarse</a></p>
        </form>
    </section>
</asp:Content>
