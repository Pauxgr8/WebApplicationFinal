<%@ Page Language="C#" AutoEventWireup="true"
    Async="true"
    CodeBehind="Index.aspx.cs"
    Inherits="WebApplicationFinal.Views.CapacidadPago.Index" %>
 
<!DOCTYPE html>
<html> 
<head runat="server">
 
    <title>Sistema de Cotización de Préstamos</title>
 
    <link href="~/Content/site.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" runat="server">
<div class="wrapper">
 
    <div class="topbar">
        <h2>Sistema de Cotización de Préstamos</h2>
    </div>
    <div class="sidebar">
 
        <a href="#">Dashboard</a>
 
        <a href="#">Clientes</a>
 
        <a href="#">Capacidad de Pago</a>
 
        <a href="#">Tipo de Préstamo</a>
 
        <a href="#">Plazos</a>
 
        <a href="#">Tasas</a>
 
        <a href="#">Encuestas</a>
 
        <a href="#">Usuarios</a>
    </div>
    <div class="content">
        <h1>Capacidad de Pago</h1>
        <hr />
        <asp:GridView
            ID="gvCapacidadPago"
            runat="server"
            AutoGenerateColumns="true">
</asp:GridView>
    </div>
</div>
</form>
</body>
</html>