using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Conceptos : System.Web.UI.Page
    {
        BLL.ValorConcepto GestorV = new BLL.ValorConcepto();
        List<BE.ValorConcepto> ListaV = new List<BE.ValorConcepto>();

        BLL.TipoConcepto GestorT = new BLL.TipoConcepto();
        List<BE.TipoConcepto> ListaT = new List<BE.TipoConcepto>();

        BLL.Concepto GestorConcepto = new BLL.Concepto();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                ListaV = GestorV.ListarValorConceptos();
                Session["ListaV"] = ListaV;
                ListaT = GestorT.ListaTipoConceptos();
                Session["ListaT"] = ListaT;



                Enlazar();


            }

            ListaV = (List<BE.ValorConcepto>)Session["ListaV"];
            ListaT = (List<BE.TipoConcepto>)Session["ListaT"];
        }

        public void Enlazar()
        {
            dropdownValor.DataSource = null;
            dropdownValor.DataSource = ListaV;
            dropdownValor.DataBind();
            
            dropdownConcepto.DataSource = null;
            dropdownConcepto.DataSource = ListaT;
            dropdownConcepto.DataBind();

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtValor.Text))
            {
                BE.Concepto conc = new BE.Concepto();

                conc.Nombre = txtNombre.Text;
                conc.Valor = float.Parse(txtValor.Text);
                conc.TConcepto = ListaT[dropdownConcepto.SelectedIndex];
                conc.VConcepto = ListaV[dropdownValor.SelectedIndex];

                int fa = GestorConcepto.AgregarConcepto(conc);

                if (fa != -1)
                {

                    lblSuccess.Text = "El concepto fue agregado!";
                    lblSuccess.CssClass = "aler alert-success";
                    lblSuccess.Visible = true;

                }
                else
                {
                    lblSuccess.Text = "Hubo un problema al guardar";
                    lblSuccess.CssClass = "aler alert-danger";
                    lblSuccess.Visible = true;
                }
            }
            else
            {
                lblSuccess.Text = "Complete los campos!";
                lblSuccess.CssClass = "aler alert-danger";
                lblSuccess.Visible = true;
            }
        }
    }
}