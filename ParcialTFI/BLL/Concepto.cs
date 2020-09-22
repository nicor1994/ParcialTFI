using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Concepto
    {
        DAL.MP_Concepto MpCon = new DAL.MP_Concepto();
        public int AgregarConcepto(BE.Concepto conc)
        {

            int fa = MpCon.AgregarConcepto(conc);
            return fa;
        }

        public List<BE.Concepto> ListarConceptos()
        {

            List<BE.Concepto> ListaConc = MpCon.ListarConceptos();

            return ListaConc;
        }

        public int ModificarConcepto(BE.Concepto conc)
        {

            int fa = MpCon.ModificarConcepto(conc);
            return fa;
        }

        public int BajaConcepto(BE.Concepto conc)
        {
            int fa = MpCon.BajaConcepto(conc);

                return fa;
        }

    }
}
