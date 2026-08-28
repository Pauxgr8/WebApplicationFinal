<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Usuarios.aspx.cs"
    Inherits="WebApplicationFinal.Views.Usuarios" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
<title>FinanCR - Usuarios</title>
 
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"/>
 
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
    color:#333;
    text-decoration:none;
    font-size:17px;
 
}
 
.sidebar a:hover{
 
    background:#b60d4b;
    color:white;
 
}
 
.content{
 
    margin-left:250px;
    padding:40px;
 
}
 
.card{
 
    border:none;
    border-radius:12px;
    box-shadow:0 5px 15px rgba(0,0,0,.15);
    padding:25px;
 
}
 
</style>
 
</head>
 
<body>
 
<div class="header">
    FinanCR
</div>
 
<div class="sidebar">
 
<a href="GestionCRUD.aspx">
Dashboard
</a>
 
<a href="Usuarios.aspx">
Usuarios
</a>
 
<a href="Reportes.aspx">
Reportes
</a>
 
<a href="Default.aspx">
Cerrar sesión
</a>
 
</div>
 
<form id="form1" runat="server">
 
<div class="content">
 
<h2>Administración de Usuarios</h2>
 
<p>
Aquí podrá administrar los usuarios registrados en el sistema.
</p>
 
<br />
 
<asp:Button
ID="btnNuevo"
runat="server"
Text="Nuevo Usuario"
CssClass="btn btn-primary"
OnClick="btnNuevo_Click"/>
 
<br />
<br />
 
<asp:Panel
ID="pnlUsuario"
runat="server"
Visible="false"
CssClass="card">
 
<table class="table">
 
<tr>
 
<td>Rol</td>
 
<td>
 
<asp:DropDownList
ID="ddlRol"
runat="server"
CssClass="form-select">
 
<asp:ListItem Value="1">Administrador</asp:ListItem>
 
<asp:ListItem Value="2">Consultor</asp:ListItem>
    <asp:ListItem Value="1002">Encuestador</asp:ListItem>
 
</asp:DropDownList>
 
</td>
 
</tr>
 
<tr>
 
<td>Nombre</td>
 
<td>
 
<asp:TextBox
ID="txtNombre"
runat="server"
CssClass="form-control"/>
 
</td>
 
</tr>
 
<tr>
 
<td>Correo</td>
 
<td>
 
<asp:TextBox
ID="txtCorreo"
runat="server"
CssClass="form-control"/>
 
</td>
 
</tr>
 
<tr>
 
<td>Usuario</td>
 
<td>
 
<asp:TextBox
ID="txtUsuario"
runat="server"
CssClass="form-control"/>
 
</td>
 
</tr>
 
<tr>
 
<td>Contraseña</td>
 
<td>
 
<asp:TextBox
ID="txtPassword"
runat="server"
CssClass="form-control"/>
 
</td>
 
</tr>
 
<tr>
 
<td></td>
 
<td>
 
<asp:Button
ID="btnGuardar"
runat="server"
Text="Guardar"
CssClass="btn btn-success"
OnClick="btnGuardar_Click"/>
 
</td>
 
</tr>
 
</table>
 
</asp:Panel>
 
<br />
 
<asp:GridView
 
ID="gvDatos"
 
runat="server"
 
CssClass="table table-bordered table-hover"
 
AutoGenerateColumns="False"
 
DataKeyNames="IdUsuario, idRol"
 
OnRowCommand="gvDatos_RowCommand">
 
<Columns>
 
<asp:TemplateField>
 
<ItemTemplate>
 
<asp:Button
 
ID="btnEditar"
 
runat="server"
 
Text="Editar"
 
CssClass="btn btn-warning btn-sm"
 
CommandName="Editar"
 
CommandArgument="<%# Container.DataItemIndex %>"/>
 
</ItemTemplate>
 
</asp:TemplateField>
 
<asp:TemplateField>
 
<ItemTemplate>
 
<asp:Button
 
ID="btnEliminar"
 
runat="server"
 
Text="Eliminar"
 
CssClass="btn btn-danger btn-sm"
 
CommandName="Eliminar"
 
CommandArgument="<%# Container.DataItemIndex %>"/>
 
</ItemTemplate>
 
</asp:TemplateField>
 
<asp:BoundField DataField="IdUsuario" HeaderText="ID"/>
 
<asp:BoundField DataField="NombreRol" HeaderText="Rol"/>
 
<asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
 
<asp:BoundField DataField="Correo" HeaderText="Correo"/>
 
<asp:BoundField DataField="UsuarioLogin" HeaderText="Usuario"/>
 
<asp:BoundField DataField="Contrasena" HeaderText="Contraseña"/>
 
<asp:CheckBoxField DataField="Activo" HeaderText="Activo"/>
 
<asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación"/>
 
<asp:BoundField DataField="UsuarioCreacion" HeaderText="Usuario Creación"/>
 
</Columns>
 
</asp:GridView>
 
</div>
 
</form>
 
</body>
 
</html>