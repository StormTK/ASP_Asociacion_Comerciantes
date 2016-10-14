<%@ Page Title="" Language="C#" MasterPageFile="~/asocomer.com/asocomer.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.asocomer.com.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login_register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="presentacion"></div>
        <div class="formulario">
            <h2>Login</h2>
            <%
                              
                if (Request.QueryString.Get("msg") != null)
                {
                    int msg = Int32.Parse(Request.QueryString.Get("msg"));
                    switch (msg)
                    {
                        case 1:
                            Response.Write("<div class=\"error\" > <p class=\"icon-error\"> </p><p class=\"mensaje\"> Email/Password Incorrecto</p></div>");
                            break;
                        case 2:
                            Response.Write("<div class=\"login\" > <p class=\"icon-check-mark\"> </p><p class=\"mensaje\"> Se ha Registrado con Exito <br /> Inicie Sesion para Comenzar</p></div>");
                            break;
                        case 3:
                           Response.Write("<div class=\"advertencia\" > <p class=\"icon-peligo\"></p><p class=\"mensaje\">  Para acceder a esta pagina necesita Iniciar Sesión</p></div>");
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
