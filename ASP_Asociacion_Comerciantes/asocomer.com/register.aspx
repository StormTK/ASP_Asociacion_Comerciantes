<%@ Page Title="" Language="C#" MasterPageFile="~/asocomer.com/asocomer.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.asocomer.com.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login_register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="registro">
        <div class="presentacion"></div>
        <div class="formulario">
            <h2>Crear Usuario</h2>
            <%
                if (Request.QueryString.Get("error") != null)
                {
                    int Error = Int32.Parse(Request.QueryString.Get("error"));
                    switch (Error)
                    {
                        case 1:
                            Response.Write("<div class=\"error\" > <p class=\"icon-error\"> </p><p class=\"mensaje\"> Algunos campos estan vacios.</p></div>");
                            break;
                        case 2:
                            Response.Write("<div class=\"error\" > <p class=\"icon-error\"> </p><p class=\"mensaje\"> El E-mail ingresado ya esta registrado en la Aplicacion Web.</p></div>  ");
                            break;
                        case 3:
                            Response.Write("<div class=\"error\" > <p class=\"icon-error\"> </p><p class=\"mensaje\"> La Contraseña es muy corta, debe tener al menos 8 Caracteres</p></div>");
                            break;
                        case 4:
                            Response.Write("<div class=\"error\" > <p class=\"icon-error\"> </p><p class=\"mensaje\"> La Contraseña debe tener al menos una Minuscula, una Mayuscula y un Numero</p></div>");
                            break;
                        case 5:
                            Response.Write("<div class=\"error\" > <p class=\"icon-error\"> </p><p class=\"mensaje\"> No se Pudo Registrar el Usuario, Intentelo Nuevamente mas tarde.</p></div>");
                            break;
                        case 6:
                            Response.Write("<div class=\"error\" > <p class=\"icon-error\"> </p><p class=\"mensaje\"> No ingreso el registro.</p></div>");
                            break;
                    }
                }
            %>

            <p>Ingrese su E-mail:</p>
            <asp:TextBox runat="server" ID="txt_correo" CssClass="txt_formulario" value="@" MaxLength="60"></asp:TextBox>

            <p>Ingrese su Contraseña:</p>
            <asp:TextBox runat="server" ID="txt_contraseña" type="Password" CssClass="txt_formulario" MaxLength="18"></asp:TextBox>

            <p>Ingrese su Nombre:</p>
            <asp:TextBox runat="server" ID="txt_nombre" CssClass="txt_formulario" MaxLength="30"></asp:TextBox>

            <p>Ingrese su Apellido:</p>
            <asp:TextBox runat="server" ID="txt_apellido" CssClass="txt_formulario" MaxLength="30"></asp:TextBox>

            <p>Seleccione su Sexo:</p>
            <asp:RadioButtonList runat="server" ID="OpcionSexo">
                <asp:ListItem Text="Hombre" Value="true"></asp:ListItem>
                <asp:ListItem Text="Mujer" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

            <asp:Button ID="btn_Enviar" Class="boton icon-usuario" runat="server" Text=" Registrarse" OnClick="btn_Enviar_Click" />
        </div>
    </section>
</asp:Content>
