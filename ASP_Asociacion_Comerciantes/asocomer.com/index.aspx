<%@ Page Title="" Language="C#" MasterPageFile="~/asocomer.com/asocomer.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.asocomer.com.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/index.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="slides_contenedor">
        <div class="slides">
            <img src="imagenes/imagen1.png" />
            <img src="imagenes/imagen2.png" />
        </div>
    </section>

    <script src="js/jquery-1.9.1.min.js"></script>
    <script src="js/jquery.slides.js"></script>
    <script>

        $(function () {
            $('.slides').slidesjs({
                play: {
                    active: true,
                    auto: true,
                    interval: 15000,
                    swap: false
                }
            });
        });

    </script>
</asp:Content>
