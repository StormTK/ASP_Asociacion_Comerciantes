<%@ Page Title="" Language="C#" MasterPageFile="~/asocomer.com/administracion/administracion.Master" AutoEventWireup="true" CodeBehind="agregar.aspx.cs" Inherits="ASP_Asociacion_Comerciantes.asocomer.com.administracion.Zona.agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/zona.css" rel="stylesheet" />
    <script type="text/javascript">
        function ActiveFileUpload() {
            var filehide = document.getElementById('Fileupload');
            if (filehide.value.length > 0) {
                 document.getElementById('lbruta').innerHTML = filehide.value.toString();               
            }
        }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registrar Zonas y Zonas Vecinas</h2>
    <p>Suba un Archivo .xml para registar las zonas o zonas vecinas en la aplicacion Web</p>
    <asp:FileUpload CssClass="ArchivoZona" ID="ArchivoZona" runat="server"  />
    <br />
    <asp:Button CssClass="RegistrarZona" Text="Registrar Archivo" ID="RegistrarZona" runat="server" OnClick="RegistrarZona_Click"  />
</asp:Content>
