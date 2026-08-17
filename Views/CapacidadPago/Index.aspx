<%@ Page Language="C#" AutoEventWireup="true"
    Async="true"
    CodeBehind="Index.aspx.cs"
    Inherits="WebApplicationFinal.Views.CapacidadPago.Index" %>
 
<!DOCTYPE html>
 
<html>
<head runat="server">
 
    <meta charset="utf-8" />
 
    <title>Sistema de Cotización de Préstamos</title>
 
    <link href="~/Content/site.css" rel="stylesheet" />
 
    <!-- Bootstrap -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
 
    <!-- Bootstrap Icons -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css" rel="stylesheet"/>
 
</head>
 
<body>
 
<form id="form1" runat="server">
 
<div class="wrapper">
 
    <!-- Barra Superior -->
 
    <div class="topbar">
 
        <h2>
<i class="bi bi-bank2"></i>
            Sistema de Cotización de Préstamos
</h2>
 
    </div>
 
    <!-- Menú -->
 
    <div class="sidebar">
 
        <h4 class="text-center text-white mt-4 mb-4">
 
            <i class="bi bi-bank"></i>
 
            Sistema
 
        </h4>
 
        <a href="#">
<i class="bi bi-speedometer2"></i>
            Dashboard
</a>
 
        <a href="#">
<i class="bi bi-people-fill"></i>
            Clientes
</a>
 
        <a href="#" class="active">
        <a href="#" class="active">
<i class="bi bi-cash-stack"></i>
            Capacidad de Pago
</a>
 
        <a href="#">
<i class="bi bi-credit-card"></i>
            Tipo de Préstamo
</a>
 
        <a href="#">
<i class="bi bi-calendar-week"></i>
            Plazos
</a>
 
        <a href="#">
<i class="bi bi-percent"></i>
            Tasas
</a>
 
        <a href="#">
<i class="bi bi-ui-checks-grid"></i>
            Encuestas
</a>
 
        <a href="#">
<i class="bi bi-person-circle"></i>
            Usuarios
</a>
 
    </div>
 
    <!-- Contenido -->
 
    <div class="content">
 
        <div class="d-flex justify-content-between align-items-center mb-4">
 
            <div>
 
                <h2 class="fw-bold">
 
                    <i class="bi bi-cash-stack text-success"></i>
 
                    Capacidad de Pago
 
                </h2>
 
                <p class="text-muted">
 
                    Administración de rangos de capacidad de pago.
 
                </p>
 
            </div>
 
            <asp:Button
                ID="btnNuevo"
                runat="server"
                Text="Nueva Capacidad"
                CssClass="btn btn-nuevo" />
 
        </div>
 
        <div class="card shadow">
 
            <div class="card-header bg-dark text-white">
 
                <i class="bi bi-table"></i>
 
                Listado de Capacidades
 
            </div>
 
            <div class="card-body">
 
                <asp:GridView
                    ID="gvCapacidadPago"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-striped table-hover table-bordered align-middle">
 
                    <Columns>
 
                        <asp:BoundField DataField="IdCapacidadPago" HeaderText="ID" />
 
                        <asp:BoundField DataField="PagoMinimo" HeaderText="Pago Mínimo" DataFormatString="{0:C}" />
 
                        <asp:BoundField DataField="PagoMaximo" HeaderText="Pago Máximo" DataFormatString="{0:C}" />
 
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
 
                        <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
 
                        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
 
                        <asp:BoundField DataField="UsuarioCreacion" HeaderText="Usuario Creación" />
 
                        <asp:BoundField DataField="FechaModificacion" HeaderText="Fecha Modificación" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
 
                        <asp:BoundField DataField="UsuarioModificacion" HeaderText="Usuario Modificación" />
 
                    </Columns>
 
                </asp:GridView>
 
            </div>
 
        </div>
 
    </div>
 
</div>
 
</form>
 
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
 
</body>
 
</html>