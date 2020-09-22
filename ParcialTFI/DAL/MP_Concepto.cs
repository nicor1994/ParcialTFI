using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class MP_Concepto
    {
        Acceso acc = new Acceso();
        MP_TipoConcepto MpTConcepto = new MP_TipoConcepto();
        MP_ValorConcepto MpVConcepto = new MP_ValorConcepto();
        public int AgregarConcepto(BE.Concepto conc)
        {
            int fa = 0;
            acc .AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = acc.ArmarParametro("IDTipo", conc.TConcepto.ID, System.Data.SqlDbType.Int);
            parametros[1] = acc.ArmarParametro("Valor", conc.Valor, System.Data.SqlDbType.Float);
            parametros[2] = acc.ArmarParametro("IDValor", conc.VConcepto.ID, System.Data.SqlDbType.Int);
            parametros[3] = acc.ArmarParametro("Nombre", conc.Nombre, System.Data.SqlDbType.VarChar);
            


            fa = acc.Escribir("Concepto_Agregar", parametros);
            acc.CerrarConexion();
            GC.Collect();
            return fa;
        }

        public List<BE.Concepto> ListarConceptos()
        {

            List<BE.Concepto> ListaConcepto = new List<BE.Concepto>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acc.ArmarParametro("tabla", "Concepto", SqlDbType.VarChar);
            acc.AbrirConexion();
            DataTable tabla = acc.Leer("ListarEntidad", parametros);
            acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {

                if ((int)linea["Borrado"] == 0)
                {
                    BE.Concepto conc = new BE.Concepto();

                    conc.ID = (int)linea["ID"];
                    conc.Nombre = (string)linea["Nombre"];
                    conc.Valor = float.Parse(linea["Valor"].ToString());
                    conc.TConcepto = MpTConcepto.ListarConceptos((int)linea["ID_Tipo"]);
                    conc.VConcepto = MpVConcepto.ListarConceptos((int)linea["ID_Valor"]);

                    ListaConcepto.Add(conc);
                }
            }

            return ListaConcepto;


        }

        public int ModificarConcepto(BE.Concepto conc)
        {
            int fa = 0;
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = acc.ArmarParametro("IDTipo", conc.TConcepto.ID, System.Data.SqlDbType.Int);
            parametros[1] = acc.ArmarParametro("Valor", conc.Valor, System.Data.SqlDbType.Float);
            parametros[2] = acc.ArmarParametro("IDValor", conc.VConcepto.ID, System.Data.SqlDbType.Int);
            parametros[3] = acc.ArmarParametro("Nombre", conc.Nombre, System.Data.SqlDbType.VarChar);
            parametros[4] = acc.ArmarParametro("id", conc.ID, System.Data.SqlDbType.Int);


            fa = acc.Escribir("Concepto_Modificar", parametros);
            acc.CerrarConexion();
            GC.Collect();
            return fa;
        }

        public int BajaConcepto(BE.Concepto conc)
        {
            int fa = 0;
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acc.ArmarParametro("ID", conc.ID, System.Data.SqlDbType.Int);
           


            fa = acc.Escribir("Concepto_Baja", parametros);
            acc.CerrarConexion();
            GC.Collect();
            return fa;
        }

    }
}
