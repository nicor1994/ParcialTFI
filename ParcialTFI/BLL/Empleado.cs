using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{


    public class Empleado
    {
        DAL.MP_Empleado MpEmpleado = new DAL.MP_Empleado();
        public int AgregarEmpleado(BE.Empleado emp)
        {

            int fa = MpEmpleado.AgregarUsuario(emp);
            return fa;
        }

        public int ModificarEmpleado(BE.Empleado emp)
        {

            int fa = MpEmpleado.ModificarUsuario(emp);
            return fa;
        }

        public List<BE.Empleado> ListarEmpleados()
        {
           
            List<BE.Empleado> ListaEmp = MpEmpleado.ListarEmpleados();

            return ListaEmp;
        }

        public List<BE.Empleado> ListarEmpleadosTodos()
        {

            List<BE.Empleado> ListaEmp = MpEmpleado.ListarEmpleadosTodos();

            return ListaEmp;
        }

        public int BajaEmpleado(BE.Empleado emp)
        {

            int fa = MpEmpleado.BajaUsuario(emp);
            return fa;
        }

    }
}
