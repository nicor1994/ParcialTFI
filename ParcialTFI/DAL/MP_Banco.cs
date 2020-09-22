using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class MP_Banco
    {

        Acceso Acc = new Acceso();
        public List<BE.Banco> ListarBancos()
        {
            List<BE.Banco> ListaBank = new List<BE.Banco>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = Acc.ArmarParametro("tabla", "Banco", SqlDbType.VarChar);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ListarEntidad", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.Banco bco = new BE.Banco();

                bco.ID = (int)linea["ID"];
                bco.Bco = (string)linea["Banco"];

                ListaBank.Add(bco);

            }

            return ListaBank;
        }

        public BE.Banco ListarBco(int id)
        {
            BE.Banco bco = new BE.Banco();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = Acc.ArmarParametro("tabla", "Banco", SqlDbType.VarChar);
            parametros[1] = Acc.ArmarParametro("id", id, SqlDbType.VarChar);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ObtenerEntidadID", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                

                bco.ID = (int)linea["ID"];
                bco.Bco = (string)linea["Banco"];

              

            }

            return bco;
        }

    }
}
