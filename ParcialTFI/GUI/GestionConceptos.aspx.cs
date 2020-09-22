using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class GestionConceptos : System.Web.UI.Page
    {
        BLL.ValorConcepto GestorV = new BLL.ValorConcepto();
        List<BE.ValorConcepto> ListaV = new List<BE.ValorConcepto>();

        BLL.TipoConcepto GestorT = new BLL.TipoConcepto();
        List<BE.TipoConcepto> ListaT = new List<BE.TipoConcepto>();

        BLL.Concepto GestorConcepto = new BLL.Concepto();
        List<BE.Concepto> ListaConc = new List<BE.Concepto>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                ListaV = GestorV.ListarValorConceptos();
                Session["ListaV"] = ListaV;
                ListaT = GestorT.ListaTipoConceptos();
                Session["ListaT"] = ListaT;
                ListaConc = GestorConcepto.ListarConceptos();
                Session["ListaConceptos"] = ListaConc;


                Enlazar();


            }

            ListaV = (List<BE.ValorConcepto>)Session["ListaV"];
            ListaT = (List<BE.TipoConcepto>)Session["ListaT"];
            ListaConc = (List<BE.Concepto>)Session["ListaConceptos"];
        }

        public void Enlazar()
        {
            dropdownValor.DataSource = null;
            dropdownValor.DataSource = ListaV;
            dropdownValor.DataBind();

            dropdownConcepto.DataSource = null;
            dropdownConcepto.DataSource = ListaT;
            dropdownConcepto.DataBind();

            dropdownConc.DataSource = null;
            dropdownConc.DataSource = ListaConc;
            dropdownConc.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            BE.Concepto c = new BE.Concepto();
            c = ListaConc[dropdownConc.SelectedIndex];

            if (c.ID != 5)
            {
                txtNombre.Visible = true;
                txtValor.Visible = true;
                dropdownConc.Visible = true;
                dropdownConcepto.Visible = true;
                dropdownValor.Visible = true;
                btnAlta.Visible = true;
                btnModificar.Visible = false;
                btnBaja.Visible = false;
                dropdownConc.Enabled = false;

                BE.Concepto conce = ListaConc[dropdownConc.SelectedIndex];

                txtValor.Text = conce.Valor.ToString();
                txtNombre.Text = conce.Nombre;
                dropdownConcepto.SelectedValue = conce.TConcepto.Tipo;
                dropdownValor.SelectedValue = conce.VConcepto.TipoValor;
            }
            else
            {
                lblSuccess.Text = "No se puede modificar el Sueldo!";
                lblSuccess.CssClass = "alert alert-danger";
                lblSuccess.Visible = true;
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtValor.Text))
            {
                ListaV = (List<BE.ValorConcepto>)Session["ListaV"];
                ListaT = (List<BE.TipoConcepto>)Session["ListaT"];

                BE.Concepto conc = new BE.Concepto();

                conc.ID = ListaConc[dropdownConc.SelectedIndex].ID;
                conc.Nombre = txtNombre.Text;
                conc.Valor = float.Parse(txtValor.Text);
                conc.TConcepto = ListaT[dropdownConcepto.SelectedIndex];
                conc.VConcepto = ListaV[dropdownValor.SelectedIndex];
                int fa = GestorConcepto.ModificarConcepto(conc);
                if (fa == -1)
                {
                    lblSuccess.Text = "Ocurrio un error en la Base de Datos";
                    lblSuccess.CssClass = "alert alert-danger";
                    lblSuccess.Visible = true;
                }
                else
                {
                    lblSuccess.Text = "Empleado guardado!!";
                    lblSuccess.CssClass = "alert alert-success";
                    lblSuccess.Visible = true;

                   
                    btnAlta.Visible = false;
                    dropdownConcepto.Visible = false;
                    dropdownValor.Visible = false;
                    txtNombre.Visible = false;
                    txtValor.Visible = false;
                    btnModificar.Visible = true;
                    btnBaja.Visible = true;
                    dropdownConc.Enabled = true;

                    ListaConc = GestorConcepto.ListarConceptos();
                    Session["ListaConceptos"] = ListaConc;
                    Enlazar();

                }

            }
            else
            {
                lblSuccess.Text = "Complete los datos!!";
                lblSuccess.CssClass = "alert alert-success";
                lblSuccess.Visible = true;
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            BE.Concepto c = new BE.Concepto();
            c = ListaConc[dropdownConc.SelectedIndex];

            if (c.ID != 5)
            {
                int fa = GestorConcepto.BajaConcepto(c);
                if (fa != -1)
                {
                    lblSuccess.Text = "Concepto dado de baja!";
                    lblSuccess.CssClass = "alert alert-success";
                    lblSuccess.Visible = true;

                    ListaConc = GestorConcepto.ListarConceptos();
                    Session["ListaConceptos"] = ListaConc;
                    Enlazar();
                }
                else
                {
                    lblSuccess.Text = "Ocurrio un error!";
                    lblSuccess.CssClass = "alert alert-danger";
                    lblSuccess.Visible = true;
                }
            }
            else
            {
                lblSuccess.Text = "No se puede borrar el Sueldo!";
                lblSuccess.CssClass = "alert alert-danger";
                lblSuccess.Visible = true;
            }
        }
    }
}