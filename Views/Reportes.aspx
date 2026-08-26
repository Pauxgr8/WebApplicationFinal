<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Reportes.aspx.cs"
    Inherits="WebApplicationFinal.Views.Reportes" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
 
<head runat="server">
 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
    <title>FinanCR - Reportes</title>
 
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" rel="stylesheet"/>
 
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
 
    <style>
 
        body{
            margin:0;
            background:#f5f6fa;
            font-family:'Segoe UI';
        }
 
        .header{
            height:70px;
            background:#3d2620;
            color:white;
            display:flex;
            align-items:center;
            padding-left:30px;
            font-size:30px;
            font-weight:bold;
        }
 
        .sidebar{
            position:fixed;
            top:70px;
            left:0;
            width:230px;
            height:100%;
            background:#dbe9d4;
            padding-top:20px;
        }
 
        .sidebar a{
            display:block;
            padding:15px 25px;
            text-decoration:none;
            color:#333;
            font-size:17px;
        }
 
        .sidebar a:hover{
            background:#b60d4b;
            color:white;
        }
 
        .content{
            margin-left:250px;
            padding:30px;
        }
 
        .card{
            border:none;
            border-radius:12px;
            box-shadow:0px 5px 15px rgba(0,0,0,.15);
        }
 
        .table{
            margin-top:20px;
        }
 
        .btn-primary{
            background:#b60d4b;
            border:none;
        }
 
        .btn-primary:hover{
            background:#92103f;
        }
 
    </style>
 
</head>
 
<body>
 
<form id="form1" runat="server">
 
<div class="header">
 
    FinanCR
 
</div>
 
<div class="sidebar">
 
<a href="GestionCRUD.aspx">
<i class="fa fa-chart-line"></i>
Dashboard
</a>
 
<a href="GestionCRUD.aspx">
<i class="fa fa-users"></i>
Clientes
</a>
 
<a href="GestionCRUD.aspx">
<i class="fa fa-user"></i>
Usuarios
</a>
 
<a href="Encuesta.aspx">
<i class="fa fa-file"></i>
Encuestas
</a>
 
<a href="Reportes.aspx">
<i class="fa fa-chart-bar"></i>
Reportes
</a>
 
<hr />
 
<a href="Default.aspx">
<i class="fa fa-right-from-bracket"></i>
Cerrar sesión
</a>
 
</div>
 
<div class="content">
<div class="d-flex justify-content-between align-items-center mb-4">
 
    <div>
 
        <h2>Reportes Estadísticos</h2>
 
        <asp:Label
            ID="lblDescripcion"
            runat="server"
            CssClass="text-secondary"
            Text="Visualización de resultados de las encuestas">
</asp:Label>
 
    </div>
 
</div>
 
<div class="card">
 
<div class="card-body">
 
<div class="row">
 
<div class="col-md-8">
 
<label class="form-label">
 
Seleccione el reporte
 
</label>
 
<asp:DropDownList
    ID="ddlReportes"
    runat="server"
    CssClass="form-select">
 
    <asp:ListItem Value="1">
        Reporte 1 - Tipo de préstamo por rango de edad
</asp:ListItem>
 
    <asp:ListItem Value="2">
        Reporte 2 - Plazo de préstamo
</asp:ListItem>
 
    <asp:ListItem Value="3">
        Reporte 3 - Plazo mayores a 36 meses
</asp:ListItem>
 
    <asp:ListItem Value="4">
        Reporte 4 - Monto Promedio por tipo de préstamo
</asp:ListItem>
 
    <asp:ListItem Value="5">
        Reporte 5 - Ingresos bajos con tasa alta
</asp:ListItem>
 
    <asp:ListItem Value="6">
        Reporte 6 - Nivel educativo
</asp:ListItem>
 
    <asp:ListItem Value="7">
        Reporte 7 - Medio de contratación
</asp:ListItem>
 
    <asp:ListItem Value="8">
        Reporte 8 - Clientes inactivos
</asp:ListItem>
 
    <asp:ListItem Value="9">
        Reporte 9 - Capacidad de pago por edad
</asp:ListItem>
 
    <asp:ListItem Value="10">
        Reporte 10 - Préstamos por plazo
</asp:ListItem>
 
    <asp:ListItem Value="11">
       Reporte 11 - Tasa promedio por ingreso
</asp:ListItem>
        <asp:ListItem Value="12">
       Reporte 12 - Préstamos universitarios
</asp:ListItem>
        <asp:ListItem Value="13">
       Reporte 13 - Capacidad de pago baja
</asp:ListItem>
        <asp:ListItem Value="14">
       Reporte 14 - Préstamo por edad
</asp:ListItem>
        <asp:ListItem Value="15">
       Reporte 15 - Solicitudes por rango de ingresos
</asp:ListItem>
        <asp:ListItem Value="16">
       Reporte 16 - Medio de contratación por tipo de préstamo
</asp:ListItem>
        <asp:ListItem Value="17">
       Reporte 17 - Mujeres con préstamo personal
</asp:ListItem>
        <asp:ListItem Value="18">
       Reporte 18 - Préstamos a 24 meses
</asp:ListItem>
        <asp:ListItem Value="19">
       Reporte 19 - Distribuición de préstamos
</asp:ListItem>
        <asp:ListItem Value="20">
       Reporte 20  - Solicitudes por nivel educativo

</asp:ListItem>    
    <asp:ListItem Value="21">
       Reporte 21 - Tasa alta con plazo largo
</asp:ListItem>
        <asp:ListItem Value="22">
       Reporte 22 - Préstamos de 36 a 45 años
</asp:ListItem>
        <asp:ListItem Value="23">
       Reporte 23 - Capacidad de pago por nivel educativo
</asp:ListItem>
        <asp:ListItem Value="24">
       Reporte 24 - Plazo para ingresos altos
</asp:ListItem>
        <asp:ListItem Value="25">
       Reporte 25 - Préstamo vehicular con ingresos altos
</asp:ListItem>
        <asp:ListItem Value="26">
       Reporte 26 - Préstamos por plazo (resumen)
</asp:ListItem>
        <asp:ListItem Value="27">
       Reporte 27 - Tasa de interés por capacidad de pago
</asp:ListItem>
        <asp:ListItem Value="28">
       Reporte 28 - Medio de contratación
</asp:ListItem>
        <asp:ListItem Value="29">
       Reporte 29 - Préstamos a 12 meses
</asp:ListItem>
        <asp:ListItem Value="30">
       Reporte 30 - Pérfil común del solicitante
</asp:ListItem>   
 
</asp:DropDownList>
 
</div>
    <div class="row mt-3">
 
    <div class="col-md-4">
 
        <label>Filtrar por rango de edad</label>
 
        <asp:DropDownList
            ID="ddlFiltroEdad"
            runat="server"
            CssClass="form-control">

            
            <asp:ListItem Value="0">Todos</asp:ListItem>
 
            <asp:ListItem Value="1">18 a 25 años</asp:ListItem>
<asp:ListItem Value="2">26 a 35 años</asp:ListItem>
<asp:ListItem Value="3">36 a 45 años</asp:ListItem>
 
        </asp:DropDownList>
 
    </div>
 
</div>
 
<div class="col-md-4 d-flex align-items-end">
 
<asp:Button
    ID="btnConsultar"
    runat="server"
    Text="Consultar"
    CssClass="btn btn-primary"
    OnClick="btnConsultar_Click"/>
 
</div>
 
</div>
 
<hr />
 
<div class="row">
 
<div class="col-md-12">
 
<canvas
    id="graficoReporte"
    height="300">
</canvas>
 
</div>
 
</div>
 
<asp:GridView
 
    ID="gvReporte"
 
    runat="server"
 
    CssClass="table table-bordered table-hover"
 
    AutoGenerateColumns="true"
 
    GridLines="None">
 
</asp:GridView>
 
</div>
 
</div>

    <script>
 
    let grafico = null;
 
function cargarGrafico(labels, valores, tipo) {

    const ctx = document.getElementById('graficoReporte');

    if (grafico != null) {
        grafico.destroy();
    }

    grafico = new Chart(ctx, {

        type: tipo,

        data: {
            labels: labels,

            datasets: [{
                label: 'Cantidad',
                data: valores,

                backgroundColor: [
                    '#AE0C3E',
                    '#3D2620',
                    '#DBE9D4',
                    '#7A9E7E',
                    '#D4AF37',
                    '#8B5E3C',
                    '#5F8575',
                    '#C97C5D'
                ],

                borderColor: '#3D2620',
                borderWidth: 1
            }]
        },

        options: {
            responsive: true,
            maintainAspectRatio: false,

            plugins: {
                legend: {
                    display: true
                }
            },

            scales: tipo == 'bar' ? {
                y: {
                    beginAtZero: true
                }
            } : {}
        }
            });
        }
 
</script>
 
</div>
 
</form>
 
</body>
 
</html>