using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   
    public class MP_ValorConcepto
    {
        Acceso Acc = new Acceso();
        public List<BE.ValorConcepto> ListarConceptos()
        {
            List<BE.ValorConcepto> ListaConc = new List<BE.ValorConcepto>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = Acc.ArmarParametro("tabla", "Valor_Concepto", SqlDbType.VarChar);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ListarEntidad", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.ValorConcepto val = new BE.ValorConcepto();

                val.ID = (int)linea["ID"];
                val.TipoValor = (string)linea["TipoValor"];

                ListaConc.Add(val);

            }

            return ListaConc;
        }

        public BE.ValorConcepto ListarConceptos(int id)
        {
            BE.ValorConcepto val = new BE.ValorConcepto();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = Acc.ArmarParametro("tabla", "Valor_Concepto", SqlDbType.VarChar);
            parametros[1] = Acc.ArmarParametro("id", id, SqlDbType.Int);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ObtenerEntidadID", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                

                val.ID = (int)linea["ID"];
                val.TipoValor = (string)linea["TipoValor"];

                

            }

            return val;
        }

    }
}
