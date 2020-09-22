using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Recibos : System.Web.UI.Page
    {
        BLL.Empleado GestorEmpleado = new BLL.Empleado();
        List<BE.Empleado> ListaEmp = new List<BE.Empleado>();

        BLL.Concepto GestorConcepto = new BLL.Concepto();
        List<BE.Concepto> ListaConc = new List<BE.Concepto>();

        BLL.Recibo GestorRecibo = new BLL.Recibo();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ListaEmp = GestorEmpleado.ListarEmpleados();
                Session["Empleados"] = ListaEmp;
                ListaConc = GestorConcepto.ListarConceptos();
                Session["ListaConceptos"] = ListaConc;
                Enlazar();
                lblSuccess.Visible = false;
               
            }

            ListaEmp = (List<BE.Empleado>)Session["Empleados"];
            ListaConc = (List<BE.Concepto>)Session["ListaConceptos"];
            
        }
        public void Enlazar()
        {
            dropdownEmpleado.DataSource = null;
            dropdownEmpleado.DataSource = ListaEmp;
            dropdownEmpleado.DataBind();

            dropdownConcepto.DataSource = null;
            dropdownConcepto.DataSource = ListaConc;
            dropdownConcepto.DataBind();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            dropdownEmpleado.Enabled = false;
            btnSeleccionar.Visible = false;
            dropdownConcepto.Visible = true;
            txtFecha.Visible = true;
            txtPeriodo.Visible = true;
            txtTipoLiquidacion.Visible = true;
            btnAlta.Visible = true;
            listConceptos.Visible = true;
            btnAgregarConcepto.Visible = true;
        }

        protected void btnAgregarConcepto_Click(object sender, EventArgs e)
        {
            if (ListaConc.Count != 0)
            {
                List<BE.Concepto> ListaTemp = new List<BE.Concepto>();

                List<BE.Concepto> Lista = (List<BE.Concepto>)Session["ListaTemp"];
                if (Lista != null)
                {
                    ListaTemp = (List<BE.Concepto>)Session["ListaTemp"];
                }


                ListaTemp.Add(ListaConc[dropdownConcepto.SelectedIndex]);
                Session["ListaTemp"] = ListaTemp;

                ListaConc = (List<BE.Concepto>)Session["ListaConceptos"];
                ListaConc.RemoveAt(dropdownConcepto.SelectedIndex);
                Session["ListaConceptos"] = ListaConc;

                listConceptos.DataSource = null;
                listConceptos.DataSource = ListaTemp;
                listConceptos.DataBind();

                dropdownConcepto.DataSource = null;
                dropdownConcepto.DataSource = ListaConc;
                dropdownConcepto.DataBind();
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            BE.Recibo Rec = new BE.Recibo();

            List<BE.Concepto> listaconcepto = new List<BE.Concepto>();
            listaconcepto = (List<BE.Concepto>)Session["ListaTemp"];

            if (listaconcepto != null)
            {
                if (!string.IsNullOrWhiteSpace(txtPeriodo.Text) && !string.IsNullOrWhiteSpace(txtTipoLiquidacion.Text) && !string.IsNullOrWhiteSpace(txtFecha.Text))
                {
                    Rec.Emp = ListaEmp[dropdownEmpleado.SelectedIndex];
                    Rec.FechaDePago = DateTime.Parse(txtFecha.Text);
                    Rec.Periodo = txtPeriodo.Text;
                    Rec.TipoLiquidacion = txtTipoLiquidacion.Text;
                    Rec.ListaConceptos = (List<BE.Concepto>)Session["ListaTemp"];
                    Rec.Renglones = GestorRecibo.ObtenerRenglonesRemunerativo(Rec.ListaConceptos, Rec.Emp);
                    Rec.Renglones = GestorRecibo.ObtenerRenglonesDeduciones(Rec.ListaConceptos, Rec.Emp, Rec.Renglones);
                    Rec.SubtotalConRet = GestorRecibo.ObtenerSubtotalConRet(Rec.Renglones);
                    Rec.SubtotalExentas = GestorRecibo.ObtenerSubtotalExentas(Rec.Renglones);
                    Rec.SubtotalDeducciones = GestorRecibo.ObtenerSubtotalDeducciones(Rec.Renglones);
                    Rec.Total = GestorRecibo.ObtenerTotal(Rec.SubtotalConRet, Rec.SubtotalExentas, Rec.SubtotalDeducciones);

                    int fa = GestorRecibo.GuardarRecibo(Rec);
                    if (fa != -1)
                    {
                        lblSuccess.Text = "Recibo generado!";
                        lblSuccess.Visible = true;
                        lblSuccess.CssClass = "alert alert-success";

                        txtFecha.Text = "";
                        txtFecha.Visible = false;
                        txtPeriodo.Text = "";
                        txtPeriodo.Visible = false;
                        txtTipoLiquidacion.Text = "";
                        txtTipoLiquidacion.Visible = false;
                        btnAlta.Visible = false;
                        btnSeleccionar.Visible = true;
                        btnAgregarConcepto.Visible = false;
                        dropdownEmpleado.Enabled = true;
                        ListaConc = GestorConcepto.ListarConceptos();
                        Session["ListaConceptos"] = ListaConc;
                        Session["ListaTemp"] = null;
                        listConceptos.DataSource = null;
                        listConceptos.Items.Clear();
                        listConceptos.DataBind();
                        Enlazar();
                    }
                }
                else
                {
                    lblSuccess.Text = "Complete los campos!";
                    lblSuccess.Visible = true;
                    lblSuccess.CssClass = "alert alert-danger";
                }

            }
            else
            {
                lblSuccess.Text = "Debe seleccionar al menos un concepto!";
                lblSuccess.Visible = true;
                lblSuccess.CssClass = "alert alert-warning";
            }
        }
    }
}