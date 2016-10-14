<%@ Page Title="" Language="C#" MasterPageFile="~/AsociacionComerciantes.com/AsociacionComerciantes.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login_register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="formulario">
            <h2>Login</h2>
            <%
                              
                if (Request.QueryString.Get("msg") != null)
                {
                    int msg = Int32.Parse(Request.QueryString.Get("msg"));
                    switch (msg)
                    {
                        case 1:
                            Response.Write("<p class=\"error\" > <span class=\"icon-error\"> </span> Email/Password Incorrecto</p>");
                            break;
                        case 2:
                            Response.Write("<p class=\"login\" > <span class=\"icon-check-mark\"> </span>Se ha Registrado en la Aplicacion Web <br /> Inicie Sesion para Comenzar</p>");
                            break;
                        case 3:
                           Response.Write("<p class=\"advertencia\" > <span class=\"icon-peligo\"> </span>Para acceder a esta pagina necesita <br />Iniciar Sesión</p>");
                            break;
                    }
                }
            %>
            <p>Ingrese su E-mail:</p>
            <asp:TextBox runat="server" ID="txt_correo" CssClass="txt_formulario" value="@"></asp:TextBox>

            <p>Ingrese su Contraseña:</p>
            <asp:TextBox runat="server" ID="txt_contraseña" type="Password" CssClass="txt_formulario"></asp:TextBox>

            <asp:Button ID="btn_Enviar" Class="boton icon-key" runat="server" Text=" Entrar" OnClick="btn_Login_Click" />
        </div>
    </section>
</asp:Content>
