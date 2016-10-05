<%@ Page Title="" Language="C#" MasterPageFile="~/App/AsociacionComerciantes.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.App.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section>
        <div class="contenido">
            <form class="formulario" runat="server">
                <h2>Crear Usuario</h2>
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
                <asp:TextBox runat="server" ID="txt_contraseña" type="Password" CssClass ="txt_formulario" placeholder="Ingrese su contraseña..."></asp:TextBox>
                <p>Ingrese su Nombre</p>
                <asp:TextBox runat="server" ID="txt_nombre" CssClass="txt_formulario" placeholder="Ingrese su Nombre..."></asp:TextBox>
                <p>Ingrese su Apellido</p>
                <asp:TextBox runat="server" ID="txt_apellido" CssClass="txt_formulario" placeholder="Ingrese su Apellido..."></asp:TextBox>
                <asp:Button ID="btn_Enviar" Class="boton" runat="server" Text="Enviar" OnClick="btn_Enviar_Click" />
            </form>
        </div>
    </section>
</asp:Content>
