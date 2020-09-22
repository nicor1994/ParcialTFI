using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ListarRecibo : System.Web.UI.Page
    {
        BLL.Empleado GestorEmpleado = new BLL.Empleado();
        List<BE.Empleado> ListaEmp = new List<BE.Empleado>();

        BLL.Recibo GestorRecibo = new BLL.Recibo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListaEmp = GestorEmpleado.ListarEmpleadosTodos();
                Session["Empleados"] = ListaEmp;              
                Enlazar();
              

            }

            ListaEmp = (List<BE.Empleado>)Session["Empleados"];
        }

        public void Enlazar()
        {
            dropdownEmpleado.DataSource = null;
            dropdownEmpleado.DataSource = ListaEmp;
            dropdownEmpleado.DataBind();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            BE.Empleado emp = ListaEmp[dropdownEmpleado.SelectedIndex];

            emp.ListaRecibo = GestorRecibo.ListarRecibos(emp);
            Session["RecibosEmpleado"] = emp.ListaRecibo;
            listRecibos.DataSource = null;
            listRecibos.DataSource = emp.ListaRecibo;
            listRecibos.DataBind();
            listRecibos.Visible = true;
            btnCargar.Visible = true;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {

            List<BE.Recibo> lista = (List<BE.Recibo>)Session["RecibosEmpleado"];
            if (lista.Count != 0)
            {
                lblError.Visible = false;
                BE.Recibo rec = lista[listRecibos.SelectedIndex];
                BE.Empleado emp = ListaEmp[dropdownEmpleado.SelectedIndex];

                rec.Renglones = GestorRecibo.ListarRenglones(rec);

                lblNombre.Text = emp.Apellido + " " + emp.Nombre;
                lblLegajo.Text = emp.Legajo.ToString();
                lblCUIL.Text = emp.Cuil.ToString();
                lblDepartamento.Text = emp.Depto.Depto;
                lblDivision.Text = emp.Div.Div;
                lblCategoria.Text = emp.Cat.Cat;
                lblFechaIngreso.Text = emp.FechaIngreso.ToShortDateString();
                lblSueldo.Text = "$" + emp.Cat.Sueldo.ToString();
                lblTipoL.Text = rec.TipoLiquidacion;
                lblPeriodo.Text = rec.Periodo;

                string strcodigo = "";
                string strdetalle = "";
                string strconret = "";
                string strexentas = "";
                string strdeduc = "";

                foreach (BE.Renglon r in rec.Renglones)
                {
                    strcodigo = strcodigo + r.Conc.ID + "<br/>";
                    strdetalle = strdetalle + r.Conc.Nombre + "<br/>";

                    if (r.Conc.TConcepto.ID == 1)
                    {
                        strconret = strconret + r.Valor + "<br/>";
                        strdeduc = strdeduc + "<br/>";
                        strexentas = strexentas + "<br/>";
                    }
                    if (r.Conc.TConcepto.ID == 2)
                    {
                        strconret = strconret + "<br/>";
                        strdeduc = strdeduc + "<br/>";

                        strexentas = strexentas + r.Valor + "<br/>";
                    }
                    if (r.Conc.TConcepto.ID == 3)
                    {
                        strconret = strconret + "<br/>";

                        strexentas = strexentas + "<br/>";
                        strdeduc = strdeduc + r.Valor + "<br/>";
                    }
                }

                lblcodigo.Text = strcodigo;
                lblDetalle.Text = strdetalle;
                lblConRet.Text = strconret;
                lblExentas.Text = strexentas;
                lblDeducciones.Text = strdeduc;

                lblfecha.Text = rec.FechaDePago.ToShortDateString();
                lblsubconret.Text = rec.SubtotalConRet.ToString();
                lblsubexentas.Text = rec.SubtotalExentas.ToString();
                lblsubded.Text = rec.SubtotalDeducciones.ToString();
                lblbanco.Text = emp.Bco.Bco;
                lblcuenta.Text = emp.Cuenta.ToString();
                lblTotal.Text = rec.Total.ToString();
                lbllugar.Text = "CABA";
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "El empleado no tiene recibos creados!";
                lblError.CssClass = "Alert alert-danger";
            }
        }
    }
}