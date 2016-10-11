<%@ Page Title="" Language="C#" MasterPageFile="~/AsociacionComerciantes.com/AsociacionComerciantes.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login_register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="formulario">
            <h2>Crear Usuario</h2>
            <%
                if (Request.QueryString.Get("Error") != null)
                {
                    int Error = Int32.Parse(Request.QueryString.Get("Error"));
                    switch (Error)
                    {
                        case 1:
                            Response.Write("<p class=\"error\" > <span class=\"icon-error\"> </span> No se ha Aceptado los Terminos y Condiciones</p>");
                            break;
                        case 2:
                            Response.Write("<p class=\"error\" > <span class=\"icon-error\"> </span> El E-mail ingresado es invalido</p>");
                            break;
                        case 3:
                            Response.Write("<p class=\"error\" ><span class=\"icon-error\"> </span> Algunos campos estan vacios</p>");
                            break;
                        case 4:
                            Response.Write("<p class=\"error\" ><span class=\"icon-error\"> </span> La Contraseña es muy corta, debe tener al menos 8 Caracteres</p>");
                            break;
                        case 5:
                            Response.Write("<p class=\"error\" ><span class=\"icon-error\"> </span> La Contraseña debe tener al menos una Minuscula, una Mayuscula y un Numero</p>");
                            break;
                        case 6:
                            Response.Write("<p class=\"error\" ><span class=\"icon-error\"> </span> Este E-mail ya esta registrado en la Aplicación Web</p>");
                            break;
                        case 7:
                            Response.Write("<p class=\"error\" ><span class=\"icon-error\"> </span> No se Pudo Registrar el Usuario, Intentelo Nuevamente mas tarde.</p>");
                            break;
                    }
                }
            %>
            <p>Ingrese su E-mail:</p>
            <asp:TextBox runat="server" ID="txt_correo" CssClass="txt_formulario" value="@"></asp:TextBox>
            
            <p>Ingrese su Contraseña:</p>
            <asp:TextBox runat="server" ID="txt_contraseña" type="Password" CssClass="txt_formulario"></asp:TextBox>
            
            <p>Ingrese su Nombre:</p>
            <asp:TextBox runat="server" ID="txt_nombre" CssClass="txt_formulario"></asp:TextBox>
            
            <p>Ingrese su Apellido:</p>
            <asp:TextBox runat="server" ID="txt_apellido" CssClass="txt_formulario"></asp:TextBox>
            
            <p>Seleccione su Sexo:</p>
            <asp:RadioButtonList runat="server" ID="OpcionSexo">
                <asp:ListItem Text="Hombre" Value="True"></asp:ListItem>
                <asp:ListItem Text="Mujer" Value="False"></asp:ListItem>
            </asp:RadioButtonList>
            
            <p>Lee y Acepte nuestros terminos y Condiciones:</p>
            <asp:CheckBox runat="server" ID="aceptar_terminos"/><a href="#" target="_blank"> Terminos y Condiciones</a>
            <br />
            <asp:Button ID="btn_Enviar" Class="boton" runat="server" Text="Enviar" OnClick="btn_Enviar_Click" />
        </div>
    </section>
</asp:Content>
