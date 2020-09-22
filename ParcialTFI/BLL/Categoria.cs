using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Categoria
    {

        DAL.MP_Categoria MpCat = new DAL.MP_Categoria();
        public List<BE.Categoria> ListarCat(int id)
        {

            List<BE.Categoria> listacat = MpCat.ListarCategorias(id);
            return listacat;
        }

    }
}
