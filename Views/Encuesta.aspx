<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Encuesta.aspx.cs"
    Inherits="WebApplicationFinal.Views.Encuesta" %>
 
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
            margin-top: 70px;
            padding: 30px;
        }
 
        .card {
            border: white;
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
 
        <div class="card">
 
            <h3>Encuesta de Solicitud de Préstamo</h3>
 
            <div class="mb-3">
<label>Fecha de la encuesta</label>
<asp:TextBox ID="txtFechaEncuesta"
                    runat="server"
                    CssClass="form-control"
                    TextMode="Date">
</asp:TextBox>
</div>
 
            <div class="mb-3">
<label>Género</label>
<asp:DropDownList ID="ddlGenero"
                    runat="server"
                    CssClass="form-control">
</asp:DropDownList>
</div>
 
            <div class="mb-3">
<label>Rango de Edad</label>
<asp:DropDownList ID="ddlRangoEdad"
                    runat="server"
                    CssClass="form-control">
</asp:DropDownList>
</div>
 
            <div class="mb-3">
<label>Nivel Educativo</label>
<asp:DropDownList ID="ddlNivelEducativo"
                    runat="server"
                    CssClass="form-control">
</asp:DropDownList>
</div>
 
            <div class="mb-3">
<label>Ingresos Mensuales</label>
<asp:DropDownList ID="ddlRangoIngresos"
                    runat="server"
                    CssClass="form-control">
</asp:DropDownList>
</div>
 
            <div class="mb-3">
<label>Tipo de préstamo</label>
<asp:DropDownList ID="ddlTipoPrestamo"
                    runat="server"
                    CssClass="form-control">
</asp:DropDownList>
</div>
 
            <div class="mb-3">
<label>Monto deseado</label>
<asp:TextBox ID="txtMontoDeseado"
                    runat="server"
                    CssClass="form-control">
</asp:TextBox>
</div>
 
            <div class="mb-3">
<label>Plazo</label>
<asp:DropDownList ID="ddlPlazo"
                    runat="server"
                    CssClass="form-control">
</asp:DropDownList>
</div>
 
            <div class="mb-3">
<label>Tasa de interés</label>
<asp:DropDownList ID="ddlTasaInteres"
                    runat="server"
                    CssClass="form-control">
</asp:DropDownList>
</div>
 
            <div class="mb-3">
<label>Capacidad de pago</label>
<asp:DropDownList ID="ddlCapacidadPago"
                    runat="server"
                    CssClass="form-control">
</asp:DropDownList>
</div>
 
            <div class="mb-3">
<label>Historial crediticio</label>
<asp:RadioButtonList ID="rblHistorial"
                    runat="server">
<asp:ListItem>Si</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:RadioButtonList>
</div>
 
            <div class="mb-3">
<label>¿Ha estado en mora?</label>
<asp:RadioButtonList ID="rblMora"
                    runat="server">
<asp:ListItem>Si</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:RadioButtonList>
</div>
 
            <div class="mb-3">
<label>Medio de contratación</label>
<asp:CheckBoxList ID="cblMedio"
                    runat="server">
<asp:ListItem>Web</asp:ListItem>
<asp:ListItem>App</asp:ListItem>
<asp:ListItem>Sucursal</asp:ListItem>
</asp:CheckBoxList>
</div>
 <div class="mb-3">
<label>¿Tiene empleo fijo?</label>
<asp:RadioButtonList ID="rblEmpleoFijo" runat="server">
<asp:ListItem Value="Si">Sí</asp:ListItem>
<asp:ListItem Value="No">No</asp:ListItem>
</asp:RadioButtonList>
</div>
 
<div class="mb-3">
<label>¿Cuánto tiempo tiene de laborar?</label>
<asp:TextBox ID="txtTiempoLaborar" runat="server" CssClass="form-control"></asp:TextBox>
</div>
 
<div class="mb-3">
<label>¿Posee vivienda propia?</label>
<asp:RadioButtonList ID="rblVivienda" runat="server">
<asp:ListItem>Si</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:RadioButtonList>
</div>
 
<div class="mb-3">
<label>¿Tiene otras deudas?</label>
<asp:RadioButtonList ID="rblDeudas" runat="server">
<asp:ListItem>Si</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:RadioButtonList>
</div>
 
<div class="mb-3">
<label>Personas que dependen de usted</label>
<asp:TextBox ID="txtDependientes" runat="server" CssClass="form-control"></asp:TextBox>
</div>
 
<div class="mb-3">
<label>¿Cuenta con fiador?</label>
<asp:RadioButtonList ID="rblFiador" runat="server">
<asp:ListItem>Si</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:RadioButtonList>
</div>
 
<div class="mb-3">
<label>¿Acepta promociones?</label>
<asp:RadioButtonList ID="rblPromociones" runat="server">
<asp:ListItem>Si</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:RadioButtonList>
</div>
 
<div class="mb-3">
<label>¿Desea recibir futuras ofertas?</label>
<asp:RadioButtonList ID="rblOfertas" runat="server">
<asp:ListItem>Si</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:RadioButtonList>
</div>

            <asp:Button
                ID="btnEnviar"
                runat="server"
                Text="Enviar"
                CssClass="btn btn-success"
                OnClick="btnEnviar_Click" />
 
        </div>
 
    </div>
 
</form>
 
</body>
</html>
