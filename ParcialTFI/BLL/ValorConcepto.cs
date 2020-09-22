using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ValorConcepto
    {
        DAL.MP_ValorConcepto GestorValorC = new DAL.MP_ValorConcepto();
        public List<BE.ValorConcepto> ListarValorConceptos()
        {

            List<BE.ValorConcepto> Listaconc = GestorValorC.ListarConceptos();
            return Listaconc;
        }

    }
}
