<%@ Page Title="" Language="C#" MasterPageFile="~/AsociacionComerciantes.com/AsociacionComerciantes.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.AsociacionComerciantes.com.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login_register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="formulario">
            <h2>Login</h2>
            <%
                if(Request.QueryString.Get("verif") != null)
                {
                    String verif = Request.QueryString.Get("verif");
                    switch (verif)
                    {
                        case "si":
                            Response.Write("<p class=\"login\" > <span class=\"icon-error\"> </span>Se ha Registrado en la Aplicacion</p>");
                            break;
                    }
                }
                if (Request.QueryString.Get("Error") != null)
                {
                    int Error = Int32.Parse(Request.QueryString.Get("Error"));
                    switch (Error)
                    {
                        case 1:
                            Response.Write("<p class=\"error\" > <span class=\"icon-error\"> </span> Email/Password Incorrecto</p>");
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
