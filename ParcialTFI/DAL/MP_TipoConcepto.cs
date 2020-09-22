using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class MP_TipoConcepto
    {

        Acceso Acc = new Acceso();
        public List<BE.TipoConcepto> ListarConceptos()
        {
            List<BE.TipoConcepto> ListaConc = new List<BE.TipoConcepto>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = Acc.ArmarParametro("tabla", "Tipo_Concepto", SqlDbType.VarChar);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ListarEntidad", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.TipoConcepto val = new BE.TipoConcepto();

                val.ID = (int)linea["ID"];
                val.Tipo = (string)linea["Tipo"];

                ListaConc.Add(val);

            }

            return ListaConc;
        }

        public BE.TipoConcepto ListarConceptos(int id)
        {
            BE.TipoConcepto val = new BE.TipoConcepto();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = Acc.ArmarParametro("tabla", "Tipo_Concepto", SqlDbType.VarChar);
            parametros[1] = Acc.ArmarParametro("id", id, SqlDbType.Int);

            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ObtenerEntidadID", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
               

                val.ID = (int)linea["ID"];
                val.Tipo = (string)linea["Tipo"];

                

            }

            return val;
        }


    }
}
