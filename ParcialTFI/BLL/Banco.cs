using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Banco
    {


        DAL.MP_Banco MpBan = new DAL.MP_Banco();
        public List<BE.Banco> ListarBco()
        {

            List<BE.Banco> lista = MpBan.ListarBancos();
            return lista;
        }


    }
}
