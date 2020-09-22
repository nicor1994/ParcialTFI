using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public class MP_Division
    {
        MP_Departamento GestorDto = new MP_Departamento();
        Acceso Acc = new Acceso();
        public List<BE.Division> ListarDivisiones(int id)
        {
            List<BE.Division> Listadiv = new List<BE.Division>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = Acc.ArmarParametro("id", id, SqlDbType.Int);
           
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ListarDivisiones", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.Division div = new BE.Division();
                div.ID = (int)linea["ID"];
                div.Div = (string)linea["Division"];
                Listadiv.Add(div);
            }
            return Listadiv;
        }

        public BE.Empleado ListarDivision(BE.Empleado emp, int id)
        {
            
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = Acc.ArmarParametro("tabla", "Division", SqlDbType.VarChar);
            parametros[1] = Acc.ArmarParametro("id", id, SqlDbType.Int);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ObtenerEntidadID", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.Division divi = new BE.Division();
                divi.ID = (int)linea["ID"];
                divi.Div = (string)linea["Division"];
                emp.Div = divi;
                GestorDto.ListarDto(emp, (int)linea["ID_Departamento"]);
            }
            return emp;
        }


    }
}
