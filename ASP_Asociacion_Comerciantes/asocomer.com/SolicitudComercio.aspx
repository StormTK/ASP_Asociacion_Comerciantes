<%@ Page Title="" Language="C#" MasterPageFile="~/asocomer.com/asocomer.Master" AutoEventWireup="true" CodeBehind="solicitudcomercio.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.asocomer.com.SolicitudComercio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login_register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["Usuario"] == null)
        {
            Response.Redirect("login.aspx?msg=3", false);
        }
    %>
    <section id="solicitud">
        <div class="presentacion"></div>
        <div class="formulario formulario2">
            <h2>Enviar Solicitud de Comercio</h2>
            <p>Nombre del Comercio:</p>
            <asp:TextBox runat="server" ID="txt_nombre" CssClass="txt_formulario" value="" MaxLength="60"></asp:TextBox>

            <p>Ingrese las Siglas del Comercio:</p>
            <asp:TextBox runat="server" ID="txt_siglas" CssClass="txt_formulario" MaxLength="10"></asp:TextBox>

            <p>Ingrese su Direccion Fisica:</p>
            <asp:TextBox runat="server" ID="txt_direccion" CssClass="txt_formulario" MaxLength="30"></asp:TextBox>

            <p>Ingrese el E-mail del Comercio:</p>
            <asp:TextBox runat="server" ID="txt_apellido" CssClass="txt_formulario" MaxLength="30"></asp:TextBox>

            <p>Ingrese su Fax:</p>
            <asp:TextBox runat="server" ID="txt_fax" CssClass="txt_formulario" MaxLength="30"></asp:TextBox>

            <p>Ingrese su Telefono:</p>
            <asp:TextBox runat="server" ID="txt_telefono" CssClass="txt_formulario" MaxLength="8"></asp:TextBox>

            <asp:Button ID="btn_Enviar" Class="boton icon-register" runat="server" Text="\&xe907 Enviar Solicitud" />
        </div>
    </section>
</asp:Content>
