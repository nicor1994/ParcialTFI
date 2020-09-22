using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Departamento
    {
        DAL.MP_Departamento MpDepto = new DAL.MP_Departamento();
        BLL.Division GestorDivision = new BLL.Division();
        public List<BE.Departamento> ListarDeptos()
        {

            List<BE.Departamento> listadept = MpDepto.ListarDeptos();

            foreach (BE.Departamento dep in listadept)
            {
                dep.ListaDiv = GestorDivision.ListarDivs(dep.ID);
            }

            return listadept;
        }

    }
}
