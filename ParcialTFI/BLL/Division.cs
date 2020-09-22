using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Division
    {

        DAL.MP_Division MpDiv = new DAL.MP_Division();
        BLL.Categoria GestorCategoria = new Categoria();
        
        public List<BE.Division> ListarDivs(int id)
        {

            List<BE.Division> listadiv = MpDiv.ListarDivisiones(id);

            foreach(BE.Division div in listadiv)
            {

                div.ListaCat = GestorCategoria.ListarCat(div.ID);

            }

            return listadiv;
        }

       

    }
}
