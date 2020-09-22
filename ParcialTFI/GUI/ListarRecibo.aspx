<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarRecibo.aspx.cs" Inherits="GUI.ListarRecibo" %>

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
         <div class="container">
         <h1 class="font-weight-bold mb-0">Recibos</h1>
         <br />

         <div class="row">
             <div class="col-md-12 border shadow rounded">
                 <br />
             <h4 class="font-weight-bold mb-0">Listar Recibo</h4>

             <br />

                 <br />
                  <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping">Empleado</span>
                  </div>
                    <asp:DropDownList ID="dropdownEmpleado" runat="server"></asp:DropDownList>
                       <asp:Button ID="btnSeleccionar" style="margin-left:10px" CssClass="btn btn-info" runat="server" Text="Seleccionar" OnClick="btnSeleccionar_Click"/>               
                </div>
                 <br />
           
               
                   
          
            <div class="input-group flex-nowrap">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="addon-wrapping2">Recibos</span>
                        <asp:ListBox ID="listRecibos" runat="server" Visible ="false"></asp:ListBox>
                      <asp:Button ID="btnCargar" style="margin-left:10px" CssClass="btn btn-warning" runat="server" Text="Cargar Recibo" OnClick="btnCargar_Click" Visible ="false"/>
                      <asp:Label ID="lblError" runat="server" Text="" Visible ="false"></asp:Label>
                  </div>
                 
                </div>
                
          
                 <br />

                 <div class="container">
                 <div class="row">
                     <div class="col-sm border font-weight-bold ">
                         Nombre y Apellido
                     </div>
                     <div class="col-sm border font-weight-bold">
                         Legajo
                     </div>
                     <div class="col-sm border font-weight-bold">
                         CUIL
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-sm border">
                         <asp:Label ID="lblNombre"  runat="server" Text=""></asp:Label> 
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblLegajo" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblCUIL" runat="server" Text=""></asp:Label>
                     </div>
                 </div>
                       <div class="row">
                     <div class="col-sm border font-weight-bold">
                         Categoria
                     </div>
                     <div class="col-sm border font-weight-bold">
                         Division
                     </div>
                     <div class="col-sm border font-weight-bold">
                         Departamento
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-sm border">
                         <asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label> 
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblDivision" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblDepartamento" runat="server" Text=""></asp:Label>
                     </div>
                 </div>
                      <div class="row">
                     <div class="col-sm border font-weight-bold">
                         Fecha Ingreso
                     </div>
                     <div class="col-sm border font-weight-bold">
                         Sueldo
                     </div>
                     <div class="col-sm border font-weight-bold">
                         Liquidacion Tipo
                     </div>
                           <div class="col-sm border font-weight-bold">
                         Periodo
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-sm border">
                         <asp:Label ID="lblFechaIngreso" runat="server" Text=""></asp:Label> 
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblSueldo" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblTipoL" runat="server" Text=""></asp:Label>
                     </div>
                       <div class="col-sm border">
                          <asp:Label ID="lblPeriodo" runat="server" Text=""></asp:Label>
                     </div>
                 </div>
                     <div class="row">
                         <div class="col-sm border font-weight-bold">
                             Codigo
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Detalle
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Con Ret
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Exentas
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Deducciones
                         </div>
                     </div>
                     <div class="row">
                     <div class="col-sm border">
                         <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label> 
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblDetalle" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="col-sm border">
                         <asp:Label ID="lblConRet" runat="server" Text=""></asp:Label>
                     </div>
                         <div class="col-sm border">
                             <asp:Label ID="lblExentas" runat="server" Text=""></asp:Label>
                         </div>
                         <div class="col-sm border">
                             <asp:Label ID="lblDeducciones" runat="server" Text=""></asp:Label>
                         </div>
                     </div>
                      <div class="row">
                         <div class="col-sm border font-weight-bold">
                             Lugar
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Fecha de Pago
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Subtotal
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Subtotal
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Subtotal
                         </div>
                     </div>
                      <div class="row">
                     <div class="col-sm border">
                         <asp:Label ID="lbllugar" runat="server" Text=""></asp:Label> 
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblfecha" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="col-sm border">
                         <asp:Label ID="lblsubconret" runat="server" Text=""></asp:Label>
                     </div>
                         <div class="col-sm border">
                             <asp:Label ID="lblsubexentas" runat="server" Text=""></asp:Label>
                         </div>
                         <div class="col-sm border">
                             <asp:Label ID="lblsubded" runat="server" Text=""></asp:Label>
                         </div>
                     </div>
                      <div class="row">
                         <div class="col-sm border font-weight-bold">
                             Banco Acreditacion
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Cuenta
                         </div>
                         <div class="col-sm border font-weight-bold">
                            Total Neto
                         </div>
                        
                     </div>
                      <div class="row">
                     <div class="col-sm border">
                         <asp:Label ID="lblbanco" runat="server" Text=""></asp:Label> 
                     </div>
                     <div class="col-sm border">
                          <asp:Label ID="lblcuenta" runat="server" Text=""></asp:Label>
                     </div>
                     <div class="col-sm border">
                         <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                     </div>
                       
             </div>
                       <div class="row">
                         <div class="col-sm border">
                             El presente es duplicado del recibo original que obra en nuestro poder firmado por el empleado.
                             <br />
                         </div>
                         <div class="col-sm border font-weight-bold">
                             Firma del Empleador
                             <br />
                             <br />
                         </div>
                       
                     </div>

                     <br />
                     <br />
             </div>

         </div>
             
             <br />           
          </div>
    </form>
     <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/ionicons@5.1.2/dist/ionicons.js"></script>
</body>
</html>
