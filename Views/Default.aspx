<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="WebApplicationFinal.Views.Default" %>
 
<!DOCTYPE html>
 
<html>
<head runat="server">
 
    <meta charset="utf-8" />
 
    <title>FinanCR</title>
 
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"/>
 
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css" rel="stylesheet"/>
 
    <link href="Content/site.css" rel="stylesheet"/>
 
    <style>
 
        body{
            background:#F8F7F3;
            height:100vh;
            display:flex;
            justify-content:center;
            align-items:center;
        }
 
        .login-card{
 
            width:430px;
 
            border:none;
 
            border-radius:20px;
 
            box-shadow:0 10px 30px rgba(0,0,0,.15);
 
            overflow:hidden;
 
        }
 
        .login-header{
 
            background:#33211C;
 
            color:white;
 
            text-align:center;
 
            padding:35px;
 
        }
 
        .login-header img{
 
            width:90px;
 
            margin-bottom:15px;
 
        }
 
        .login-header h2{
 
            margin:0;
 
            font-weight:bold;
 
        }
 
        .login-header p{
 
            color:#F5EEC3;
 
            margin-top:10px;
 
        }
 
        .login-body{
 
            padding:35px;
 
            background:white;
 
        }
 
        .btn-login{
 
            width:100%;
 
            background:#AE0C3E;
 
            color:white;
 
            border:none;
 
            padding:12px;
 
            border-radius:10px;
 
            font-weight:bold;
 
        }
 
        .btn-login:hover{
 
            background:#880A32;
 
        }
 
    </style>
 
</head>
 
<body>
 
<form id="form1" runat="server">
 
<div class="login-card">
 
<div class="login-header">
 
    <img src="../Images/logo.png"/>
 
    <h2>FinanCR</h2>
 
    <p>Soluciones que impulsan tu futuro</p>
 
</div>
 
<div class="login-body">
 
    <div class="mb-3">
 
        <label>Usuario</label>
 
        <asp:TextBox
            ID="txtUsuario"
            CssClass="form-control"
            runat="server"/>
 
    </div>
 
    <div class="mb-3">
 
        <label>Contraseña</label>
 
        <asp:TextBox
            ID="txtPassword"
            TextMode="Password"
            CssClass="form-control"
            runat="server"/>
 
    </div>
 
    <div class="mb-3">
 
        <asp:Label
            ID="lblMensaje"
            ForeColor="Red"
            runat="server"/>
 
    </div>
 
    <asp:Button
 
        ID="btnIngresar"
 
        runat="server"
 
        Text="Iniciar Sesión"
 
        CssClass="btn-login"
 
        OnClick="btnIngresar_Click"/>
 
</div>
 
</div>
 
</form>
 
</body>
 
</html>