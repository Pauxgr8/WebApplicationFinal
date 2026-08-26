<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="GestionCRUD.aspx.cs"
    Inherits="WebApplicationFinal.Views.GestionCRUD" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
<title>FinanCR - Gestión General</title>
 
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
 
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" rel="stylesheet"/>
 
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
 
            <h2>Administración General</h2>
 
            <asp:Label
                ID="lblNombre"
                runat="server"
                CssClass="text-secondary">
</asp:Label>
 
        </div>
 
       <asp:Button

    ID="btnNuevo"

    runat="server"

    Text="Nuevo Registro"

    CssClass="btn btn-primary"

    OnClick="btnNuevo_Click" />
 
 
    </div>
 
    <div class="card">
 
        <div class="card-body">
 
            <div class="row">
 
                <div class="col-md-4">
 
                    <label class="form-label">
 
                        Tabla
 
                    </label>
<asp:DropDownList
    ID="ddlTablas"
    runat="server"
    CssClass="form-select"
    AutoPostBack="true"
    OnSelectedIndexChanged="ddlTablas_SelectedIndexChanged">
 
    <asp:ListItem>Usuarios</asp:ListItem>
<asp:ListItem>Clientes</asp:ListItem>
<asp:ListItem>Genero</asp:ListItem>
<asp:ListItem>Encuestas</asp:ListItem>
 
    <asp:ListItem>NivelEducativo</asp:ListItem>
<asp:ListItem>RangoEdad</asp:ListItem>
<asp:ListItem>RangoIngresos</asp:ListItem>
<asp:ListItem>TipoPrestamo</asp:ListItem>
<asp:ListItem>Plazo</asp:ListItem>
<asp:ListItem>TasaInteres</asp:ListItem>
<asp:ListItem>CapacidadPago</asp:ListItem>
<asp:ListItem>MedioContratacion</asp:ListItem>
 
</asp:DropDownList>
 
                </div>
 
            </div>
 
           <asp:GridView
    ID="gvDatos"
    runat="server"
    CssClass="table table-bordered table-hover"
    AutoGenerateColumns="False"
    GridLines="None"
    DataKeyNames="IdUsuario"
    OnRowCommand="gvDatos_RowCommand">
 
    <Columns>

<asp:TemplateField HeaderText="">
<ItemTemplate>
<asp:Button
                    ID="btnEditar"
                    runat="server"
                    Text="Editar"
                    CssClass="btn btn-warning btn-sm"
                    CommandName="Editar"
                    CommandArgument="<%# Container.DataItemIndex %>" />
</ItemTemplate>
</asp:TemplateField>
 
   
<asp:TemplateField HeaderText="">
<ItemTemplate>
<asp:Button
                    ID="btnEliminar"
                    runat="server"
                    Text="Eliminar"
                    CssClass="btn btn-danger btn-sm"
                    CommandName="Eliminar"
                    CommandArgument="<%# Container.DataItemIndex %>" />
</ItemTemplate>
</asp:TemplateField>
 
        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
<asp:BoundField DataField="IdRol" HeaderText="Rol" />
<asp:BoundField DataField="Nombre" HeaderText="Nombre" />
<asp:BoundField DataField="Correo" HeaderText="Correo" />
<asp:BoundField DataField="UsuarioLogin" HeaderText="Usuario" />
<asp:BoundField DataField="Contrasena" HeaderText="Contraseña" />
<asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
<asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación" />
<asp:BoundField DataField="UsuarioCreacion" HeaderText="Usuario Creación" />
 
    </Columns>
 
</asp:GridView>
<asp:GridView
    ID="gvClientes"
    runat="server"
    CssClass="table table-bordered table-hover"
    AutoGenerateColumns="False"
    GridLines="None"
    DataKeyNames="IdCliente"
    OnRowCommand="gvClientes_RowCommand">
 
    <Columns>
 
        <asp:TemplateField>
<ItemTemplate>
<asp:Button
                    ID="btnEditarCliente"
                    runat="server"
                    Text="Editar"
                    CssClass="btn btn-warning btn-sm"
                    CommandName="Editar"
                    CommandArgument="<%# Container.DataItemIndex %>" />
</ItemTemplate>
</asp:TemplateField>
 
        <asp:TemplateField>
<ItemTemplate>
<asp:Button
                    ID="btnEliminarCliente"
                    runat="server"
                    Text="Eliminar"
                    CssClass="btn btn-danger btn-sm"
                    CommandName="Eliminar"
                    CommandArgument="<%# Container.DataItemIndex %>" />
</ItemTemplate>
</asp:TemplateField>
 
        <asp:BoundField DataField="IdCliente" HeaderText="Id" />
<asp:BoundField DataField="Nombre" HeaderText="Nombre" />
<asp:BoundField DataField="Apellido" HeaderText="Apellido" />
<asp:BoundField DataField="Correo" HeaderText="Correo" />
<asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
 
    </Columns>
 
</asp:GridView>
<asp:GridView
    ID="gvGenero"
    runat="server"
    CssClass="table table-bordered table-hover"
    AutoGenerateColumns="False"
    GridLines="None"
    DataKeyNames="IdGenero"
    Visible="false"
    OnRowCommand="gvGenero_RowCommand">
 
    <Columns>
 
        <asp:TemplateField>
<ItemTemplate>
<asp:Button
                    ID="btnEditarGenero"
                    runat="server"
                    Text="Editar"
                    CssClass="btn btn-warning btn-sm"
                    CommandName="Editar"
                    CommandArgument="<%# Container.DataItemIndex %>" />
</ItemTemplate>
</asp:TemplateField>
 
        <asp:TemplateField>
<ItemTemplate>
<asp:Button
                    ID="btnEliminarGenero"
                    runat="server"
                    Text="Eliminar"
                    CssClass="btn btn-danger btn-sm"
                    CommandName="Eliminar"
                    CommandArgument="<%# Container.DataItemIndex %>" />
</ItemTemplate>
</asp:TemplateField>
 
        <asp:BoundField DataField="IdGenero" HeaderText="ID" />
<asp:BoundField DataField="Nombre" HeaderText="Descripción" />
<asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
 
    </Columns>
 
</asp:GridView>

<asp:GridView
    ID="gvEncuestas"
    runat="server"
    CssClass="table table-bordered table-hover"
    AutoGenerateColumns="False"
    GridLines="None"
    DataKeyNames="IdEncuesta"
    Visible="false"
    OnRowCommand="gvEncuestas_RowCommand">
 
    <Columns>
 
        <asp:ButtonField
            Text="Editar"
            CommandName="Editar"
            ButtonType="Button"
            ControlStyle-CssClass="btn btn-warning" />
 
        <asp:ButtonField
            Text="Eliminar"
            CommandName="Eliminar"
            ButtonType="Button"
            ControlStyle-CssClass="btn btn-danger" />
 
        <asp:BoundField
            DataField="IdEncuesta"
            HeaderText="Id" />
 
        <asp:BoundField
            DataField="FechaEncuesta"
            HeaderText="Fecha" />
 
        <asp:BoundField
            DataField="IdCliente"
            HeaderText="Cliente" />
 
        <asp:BoundField
            DataField="IdUsuario"
            HeaderText="Usuario" />
 
        <asp:BoundField
            DataField="IdTipoPrestamo"
            HeaderText="Tipo Prestamo" />
 
        <asp:BoundField
            DataField="IdPlazo"
            HeaderText="Plazo" />
        <asp:BoundField
        DataField="IdTasaInteres"
        HeaderText="Tasa Interés" />
 
    <asp:BoundField
        DataField="IdCapacidadPago"
        HeaderText="Capacidad Pago" />
 
    <asp:BoundField
        DataField="IdMedioContratacion"
        HeaderText="Medio Contratación" />
 
    </Columns>
 
</asp:GridView>
 <asp:Panel ID="pnlUsuario" runat="server" Visible="false">
 
    <h4>Nuevo Usuario</h4>
 
    <table class="table">
 
        <tr>
<td>Rol</td>
<td>
<asp:DropDownList
        ID="ddlRol"
        runat="server"
        CssClass="form-control">
 
        <asp:ListItem Text="Seleccione un rol" Value=""></asp:ListItem>
<asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
<asp:ListItem Text="Consultor" Value="2"></asp:ListItem>
 
    </asp:DropDownList>
</td>
</tr>
 
        <tr>
<td>Nombre</td>
<td>
<asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"/>
</td>
</tr>
 
        <tr>
<td>Correo</td>
<td>
<asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"/>
</td>
</tr>
 
        <tr>
<td>Usuario</td>
<td>
<asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"/>
</td>
</tr>
 
        <tr>
<td>Contraseña</td>
<td>
<asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"/>
</td>
</tr>
 
    </table>
 
    <asp:Button
        ID="btnGuardar"
        runat="server"
        Text="Guardar"
        CssClass="btn btn-success"
        OnClick="btnGuardar_Click"/>
 
</asp:Panel>
            <asp:Panel ID="pnlCliente"
    runat="server"
    Visible="false">
 
    <h4>Nuevo Cliente</h4>
 
    <table class="table">
 
        <tr>
<td>Nombre</td>
<td>
<asp:TextBox ID="txtNombreCliente"
                    runat="server"
                    CssClass="form-control" />
</td>
</tr>
 
        <tr>
<td>Apellido</td>
<td>
<asp:TextBox ID="txtApellidoCliente"
                    runat="server"
                    CssClass="form-control" />
</td>
</tr>
 
        <tr>
<td>Correo</td>
<td>
<asp:TextBox ID="txtCorreoCliente"
                    runat="server"
                    CssClass="form-control" />
</td>
</tr>
 
        <tr>
<td>Teléfono</td>
<td>
<asp:TextBox ID="txtTelefonoCliente"
                    runat="server"
                    CssClass="form-control" />
</td>
</tr>
        <tr>
<td colspan="2" style="text-align:center">

</td>
</tr>
 
    </table>
 
    <asp:Button
        ID="btnGuardarCliente"
        runat="server"
        Text="Guardar Cliente"
        CssClass="btn btn-success"
        OnClick="btnGuardarCliente_Click" />
 
</asp:Panel>

<asp:Panel ID="pnlGenero" runat="server" Visible="false">
 
    <h4>Nuevo Género</h4>
 
    <table class="table">
 
        <tr>
<td>Descripción</td>
<td>
<asp:TextBox
                    ID="txtNombreGenero"
                    runat="server"
                    CssClass="form-control">
</asp:TextBox>
</td>
</tr>
 
        <tr>
<td>Activo</td>
<td>
<asp:CheckBox
                    ID="chkActivoGenero"
                    runat="server"
                    Checked="true" />
</td>
</tr>
 
        <tr>
<td colspan="2" style="text-align:center">
<asp:Button
                    ID="btnGuardarGenero"
                    runat="server"
                    Text="Guardar"
                    CssClass="btn btn-primary"
                    OnClick="btnGuardarGenero_Click" />
</td>
</tr>
 
    </table>
 
</asp:Panel>

            <asp:Panel ID="pnlEncuesta"

    runat="server"

    Visible="false">
 
    <h4>Nueva Encuesta</h4>
 
<table class="table">
 
<tr>
<td>Fecha Encuesta</td>
<td>
<asp:TextBox
            ID="txtFechaEncuesta"
            runat="server"
            TextMode="Date"
            CssClass="form-control" />
</td>
</tr>
 
<tr>
<td>Cliente</td>
<td>
<asp:TextBox
            ID="txtIdCliente"
            runat="server"
            CssClass="form-control" />
</td>
</tr>
 
<tr>
<td>Usuario</td>
<td>
<asp:TextBox
            ID="txtIdUsuario"
            runat="server"
            CssClass="form-control" />
</td>
</tr>
 
<tr>
<td>Tipo Préstamo</td>
<td>
<asp:TextBox
            ID="txtIdTipoPrestamo"
            runat="server"
            CssClass="form-control" />
</td>
</tr>
 
<tr>
<td>Plazo</td>
<td>
<asp:TextBox
            ID="txtIdPlazo"
            runat="server"
            CssClass="form-control" />
</td>
</tr>
 
<tr>
<td>Tasa Interés</td>
<td>
<asp:TextBox
            ID="txtIdTasaInteres"
            runat="server"
            CssClass="form-control" />
</td>
</tr>
 
<tr>
<td>Capacidad Pago</td>
<td>
<asp:TextBox
            ID="txtIdCapacidadPago"
            runat="server"
            CssClass="form-control" />
</td>
</tr>
 
<tr>
<td>Medio Contratación</td>
<td>
<asp:TextBox
            ID="txtIdMedioContratacion"
            runat="server"
            CssClass="form-control" />
</td>
</tr>
 
<tr>
<td colspan="2" style="text-align:center">
 
        <asp:Button
            ID="btnGuardarEncuesta"
            runat="server"
            Text="Guardar Encuesta"
            CssClass="btn btn-success"
            OnClick="btnGuardarEncuesta_Click"/>
 
    </td>
</tr>
 
</table>
 
</asp:Panel>
 

        </div>
 
    </div>
 
</div>
 
</form>
 
</body>
 
</html>