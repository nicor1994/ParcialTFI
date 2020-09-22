using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Empleados : System.Web.UI.Page
    {
        BLL.Banco GestorBanco = new BLL.Banco();
        BLL.Categoria GestorCategoria = new BLL.Categoria();
        BLL.Departamento GestorDepto = new BLL.Departamento();
        BLL.Division GestorDiv = new BLL.Division();
        BLL.Empleado GestorEmpleado = new BLL.Empleado();
        BLL.Banco GestorBlanco = new BLL.Banco();
       
        List<BE.Departamento> ListaDto = new List<BE.Departamento>();
        List<BE.Banco> ListaBco = new List<BE.Banco>();
        List<BE.Empleado> ListaEmp = new List<BE.Empleado>();
         protected void Page_Load(object sender, EventArgs e)
        {

           

            if (!IsPostBack)
            {

             
                ListaDto = GestorDepto.ListarDeptos();
                Session["ListaDto"] = ListaDto;
                ListaBco = GestorBanco.ListarBco();
                Session["ListaBco"] = ListaBco;
                ListaEmp = GestorEmpleado.ListarEmpleados();
                Session["Empleados"] = ListaEmp;
                Enlazar();

                
            }

            ListaBco = (List<BE.Banco>)Session["ListaBco"];
            ListaDto = (List<BE.Departamento>)Session["ListaDto"];
            ListaEmp = (List<BE.Empleado>)Session["Empleados"];
        }

        public void Enlazar()
        {
           
            dropdownDepartamento.DataSource = null;
            dropdownDepartamento.DataSource = ListaDto;
            dropdownDepartamento.DataBind();
          

            dropdownBancos.DataSource = null;
            dropdownBancos.DataSource = ListaBco;
            dropdownBancos.DataBind();


            dropdownDivision.DataSource = null;
            dropdownDivision.DataSource = ListaDto[dropdownDepartamento.SelectedIndex].ListaDiv;
            dropdownDivision.DataBind();

            dropdownCategorias.DataSource = null;
            dropdownCategorias.DataSource = ListaDto[dropdownDepartamento.SelectedIndex].ListaDiv[dropdownDivision.SelectedIndex].ListaCat;
            dropdownCategorias.DataBind();

           


        }

        protected void dropdownDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            ListaDto = (List<BE.Departamento>)Session["ListaDto"];

            dropdownDivision.DataSource = null;
            dropdownDivision.DataSource = ListaDto[dropdownDepartamento.SelectedIndex].ListaDiv;
            dropdownDivision.DataBind();
            dropdownCategorias.DataSource = null;
            dropdownCategorias.DataSource = ListaDto[dropdownDepartamento.SelectedIndex].ListaDiv[dropdownDivision.SelectedIndex].ListaCat;
            dropdownCategorias.DataBind();
        }

        protected void dropdownDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaDto = (List<BE.Departamento>)Session["ListaDto"];

            dropdownCategorias.DataSource = null;
            dropdownCategorias.DataSource = ListaDto[dropdownDepartamento.SelectedIndex].ListaDiv[dropdownDivision.SelectedIndex].ListaCat;
            dropdownCategorias.DataBind();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtCuenta.Text) && !string.IsNullOrWhiteSpace(txtCuil.Text) && !string.IsNullOrWhiteSpace(txtLegajo.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text))
            {

                ListaDto = (List<BE.Departamento>)Session["ListaDto"];
                ListaBco = (List<BE.Banco>)Session["ListaBco"];
                BE.Empleado emp = new BE.Empleado();

                emp.Nombre = txtNombre.Text;
                emp.Apellido = txtApellido.Text;
                emp.Legajo = int.Parse(txtLegajo.Text);
                emp.Cuil = int.Parse(txtCuil.Text);
                emp.Depto = ListaDto[dropdownDepartamento.SelectedIndex];
                emp.Div = ListaDto[dropdownDepartamento.SelectedIndex].ListaDiv[dropdownDivision.SelectedIndex];
                emp.Cat = ListaDto[dropdownDepartamento.SelectedIndex].ListaDiv[dropdownDivision.SelectedIndex].ListaCat[dropdownCategorias.SelectedIndex];
                emp.Cuenta = int.Parse(txtCuenta.Text);
                emp.Bco = ListaBco[dropdownBancos.SelectedIndex];
                emp.FechaIngreso = DateTime.Now;
               int fa = GestorEmpleado.AgregarEmpleado(emp);
                if (fa == -1){
                    lblSuccess.Text = "Ocurrio un error en la Base de Datos";
                    lblSuccess.CssClass = "alert alert-danger";
                    lblSuccess.Visible = true;
                }
                else
                {
                    lblSuccess.Text = "Empleado guardado!!";
                    lblSuccess.CssClass = "alert alert-success";
                    lblSuccess.Visible = true;
                }
            }
            else
            {
                lblSuccess.Text = "Complete los campos!";
                lblSuccess.CssClass = "alert alert-danger";
                lblSuccess.Visible = true;
            }

        }
    }
}