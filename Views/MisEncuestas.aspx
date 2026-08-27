<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="MisEncuestas.aspx.cs"
    Inherits="WebApplicationFinal.Views.MisEncuestas" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>FinanCR - Encuesta</title>
 
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" rel="stylesheet" />
 
    <style>
        body {
            margin: 0;
            background: #f5f6fa;
            font-family: 'Segoe UI';
        }
 
        .header {
            height: 70px;
            background: #3d2620;
            color: white;
            display: flex;
            align-items: center;
            padding-left: 30px;
            font-size: 30px;
            font-weight: bold;
        }
 
        .sidebar {
            position: fixed;
            top: 70px;
            left: 0;
            width: 230px;
            height: 100%;
            background: #dbe9d4;
            padding-top: 20px;
        }
 
        .sidebar a {
            display: block;
            padding: 15px 25px;
            text-decoration: none;
            color: #333;
            font-size: 17px;
        }
 
        .sidebar a:hover {
            background: #b60d4b;
            color: white;
        }
 
        .content {
            margin-left: 250px;
            padding: 30px;
        }
 
        .card {
            border: none;
            border-radius: 12px;
            box-shadow: 0 5px 15px rgba(0,0,0,.15);
            padding: 25px;
        }
</style>
 
</head>
 
<body>
 
<form id="form1" runat="server">
 
    <div class="header">
        FinanCR
</div>
 
    <div class="sidebar">
 
      <% if (Session["Rol"].ToString() == "Administrador") { %>
 
<a href="GestionCRUD.aspx">
<i class="fa fa-chart-line"></i> Dashboard
</a>
 
<a href="GestionCRUD.aspx">
<i class="fa fa-users"></i> Clientes
</a>
 
<a href="GestionCRUD.aspx">
<i class="fa fa-user"></i> Usuarios
</a>
 
<a href="Encuesta.aspx">
<i class="fa fa-file"></i> Encuestas
</a>
 
<a href="Reportes.aspx">
<i class="fa fa-chart-bar"></i> Reportes
</a>
 
<% } %>
 
<% if (Session["Rol"].ToString() == "Consultor") { %>
 
<a href="Reportes.aspx">
<i class="fa fa-chart-bar"></i> Reportes
</a>
 
<% } %>
 
<% if (Session["Rol"].ToString() == "Encuestador") { %>
 
<a href="Encuesta.aspx">
<i class="fa fa-file"></i>
    Nueva Encuesta
</a>
 
<a href="MisEncuestas.aspx">
<i class="fa fa-list"></i>
    Mis Encuestas
</a>
 
<% } %>
 
        <hr />
 
        <a href="Default.aspx">
<i class="fa fa-right-from-bracket"></i> Cerrar sesión
</a>
 
    </div>

 
    <div class="content">
 
       <h2 style="margin-top:10px; color:#3d2620;">
           Mis Encuentas
           </h2 >
 
        <p style="margin-bottom:25px;">    Aquí podrá visualizar todas las encuestas que usted ha realizado.</p>
 
        <br />
 
        <asp:GridView
    ID="gvEncuestas"
    runat="server"
    AutoGenerateColumns="False"
    CssClass="table">
 
    <Columns>
 
        <asp:BoundField
            DataField="IdEncuesta"
            HeaderText="Encuesta" />
 
        <asp:BoundField
            DataField="FechaEncuesta"
            HeaderText="Fecha" />
 
        <asp:BoundField
            DataField="Cliente"
            HeaderText="Cliente" />
 
        <asp:BoundField
            DataField="TipoPrestamo"
            HeaderText="Tipo de préstamo" />
 
        <asp:BoundField
            DataField="Plazo"
            HeaderText="Plazo" />
 
        <asp:BoundField
            DataField="Tasa"
            HeaderText="Tasa de interés" />
 
        <asp:BoundField
            DataField="CapacidadPago"
            HeaderText="Capacidad de pago" />
 
        <asp:BoundField
            DataField="MedioContratacion"
            HeaderText="Medio de contratación" />
 
    </Columns>
 
</asp:GridView>
 
    </div>
 
</form>
 
</body>
 
</html>