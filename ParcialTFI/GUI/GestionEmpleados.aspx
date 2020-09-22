<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionEmpleados.aspx.cs" Inherits="GUI.GestionEmpleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Parcial TFI - Nicolas Rubino</title>

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="/Content/global.css" />
    <link href="https://unpkg.com/ionicons@4.5.10-0/dist/css/ionicons.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
          <div>
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <a class="navbar-brand" href="#">Parcial</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                  <ul class="navbar-nav mr-auto">                       
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Empleados
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="Empleados.aspx">Alta de Empleado</a>
                                <a class="dropdown-item" href="GestionEmpleados.aspx">Gestion de Empleados</a>                             
                            </div>
                        </li>
                       <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Recibos
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="Conceptos.aspx">Alta de Conceptos</a>
                                <a class="dropdown-item" href="GestionConceptos.aspx">Gestion de Conceptos</a>
                              <a class="dropdown-item" href="Recibos.aspx">Alta de Recibos</a>
                                 <a class="dropdown-item" href="ListarRecibo.aspx">Listar Recibos</a>                                 
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
        
        
        
       
      <%--  <asp:DropDownList ID="dropdownDepartamento" runat="server" OnSelectedIndexChanged="dropdownDepartamento_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>--%>
   

         <div class="container">
         <h1 class="font-weight-bold mb-0">Empleados</h1>
         <br />

         <div class="row">
             
             <div class="col-md-12 border shadow rounded ">
                
                 <br />
                  <h4 class="font-weight-bold mb-0">Gestion de Empleado</h4>
                 <br />
                 <br />
            
                 
                  <br />
            <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping10">Empleado</span>
                  </div>
                <asp:DropDownList ID="dropdownEmpleado" runat="server"></asp:DropDownList>
                <asp:Button ID="btnModificar" style="margin-left:10px" CssClass="btn btn-warning" runat="server" Text="Modificar" OnClick="btnModificar_Click"   />
                <asp:Button ID="btnBaja" style="margin-left:10px" CssClass="btn btn-danger" runat="server" Text="Despedir" OnClick="btnBaja_Click" />
                </div>
                 <br />
                  <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping">Nombre/s</span>
                  </div>
                   <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" Visible ="false"></asp:TextBox>
                </div>
                
                 <br />
            <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping2">Apellido/s</span>
                  </div>
                  <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" Visible ="false"></asp:TextBox>
                </div>
                
                   <br />
            <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping3">Legajo</span>
                  </div>
                    <asp:TextBox textmode="Number" ID="txtLegajo" CssClass="form-control" runat="server" Visible ="false"></asp:TextBox>
                </div>
                   <br />
            <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping4">CUIL</span>
                  </div>                 
                <asp:TextBox textmode="Number" ID="txtCuil" CssClass="form-control" runat="server" Visible ="false"></asp:TextBox>
            </div>
                 <br />
                 <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping5">Departamento</span>
                  </div>                 
                <asp:DropDownList ID="dropdownDepartamento" runat="server" OnSelectedIndexChanged="dropdownDepartamento_SelectedIndexChanged" AutoPostBack="True" Visible ="false"></asp:DropDownList>
            </div>
                   <br />
                 <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping6">Division</span>
                  </div>                 
                <asp:DropDownList ID="dropdownDivision" Visible ="false" runat="server" OnSelectedIndexChanged="dropdownDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
                   <br />
                 <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping7">Categoria</span>
                  </div>                 
                <asp:DropDownList ID="dropdownCategorias" runat="server" Visible ="false"></asp:DropDownList>
            </div>
                           <br />
            <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping9">Cuenta</span>
                  </div>
                   <asp:TextBox TextMode="Number" ID="txtCuenta" CssClass="form-control" runat="server" Visible ="false"></asp:TextBox>
                </div>
                       <br />
            <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping8">Banco</span>
                  </div>
                <asp:DropDownList ID="dropdownBancos" runat="server" Visible ="false"></asp:DropDownList>
                </div>
                   <br />
                 <asp:Label ID="lblSuccess" runat="server" CssClass="alert alert-success" Text="Empleado agregado!" Visible="true"></asp:Label>
                 <asp:Button ID="btnAlta" class="btn btn-info" runat="server" Text="Modificar Empleado" OnClick="btnAlta_Click" Visible ="false " />
                 <br />
                 <br />
             </div>

                   <br />


             </div>
          </div>
    

    
    </form>

      <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/ionicons@5.1.2/dist/ionicons.js"></script>

</body>
</html>
