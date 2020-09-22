using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoConcepto
    {
        DAL.MP_TipoConcepto GestorTipoC = new DAL.MP_TipoConcepto();
        public List<BE.TipoConcepto> ListaTipoConceptos()
        {

            List<BE.TipoConcepto> Listaconc = GestorTipoC.ListarConceptos();
            return Listaconc;
        }


    }
}
