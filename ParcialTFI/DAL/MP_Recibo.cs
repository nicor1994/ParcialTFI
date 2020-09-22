using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class MP_Recibo
    {
        Acceso acc = new Acceso();
        MP_Concepto MpConc = new MP_Concepto();
        public int AgregarRecibo(BE.Recibo rec)
        {
            int fa = 0;
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = acc.ArmarParametro("idemp", rec.Emp.ID, System.Data.SqlDbType.VarChar);
            parametros[1] = acc.ArmarParametro("fechapago", rec.FechaDePago, System.Data.SqlDbType.Date);
            parametros[2] = acc.ArmarParametro("periodo", rec.Periodo, System.Data.SqlDbType.VarChar);
            parametros[3] = acc.ArmarParametro("subtExe", rec.SubtotalExentas, System.Data.SqlDbType.Float);
            parametros[4] = acc.ArmarParametro("subConRet", rec.SubtotalConRet, System.Data.SqlDbType.Float);
            parametros[5] = acc.ArmarParametro("subDeduc", rec.SubtotalDeducciones, System.Data.SqlDbType.Float);
            parametros[6] = acc.ArmarParametro("total", rec.Total, System.Data.SqlDbType.Float);
            parametros[7] = acc.ArmarParametro("tipo", rec.TipoLiquidacion, System.Data.SqlDbType.VarChar);
            fa = acc.Escribir("Recibo_Agregar", parametros);
            acc.CerrarConexion();
            GC.Collect();
            return fa;
        }

        public int AgregarConceptos(BE.Recibo rec)
        {
            int fa = 0;
            foreach (BE.Renglon ren in rec.Renglones) {
                acc.AbrirConexion();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = acc.ArmarParametro("idconc", ren.Conc.ID, System.Data.SqlDbType.Int);
                parametros[1] = acc.ArmarParametro("valor", ren.Valor, System.Data.SqlDbType.Float);
                
                fa = acc.Escribir("Renglon_Agregar", parametros);
                acc.CerrarConexion();
                GC.Collect();
            }
            
            return fa;
        }


        public List<BE.Recibo> ListarRecibos(BE.Empleado emp)
        {

            List<BE.Recibo> ListaRecibos = new List<BE.Recibo>();
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acc.ArmarParametro("idemp", emp.ID, System.Data.SqlDbType.Int);

            DataTable Tabla = acc.Leer("Recibo_Listar", parametros);
            acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in Tabla.Rows)
            {
                BE.Recibo rec = new BE.Recibo();

                rec.ID = (int)linea["ID"];
                rec.Emp = emp;
                rec.FechaDePago = (DateTime)linea["Fecha"];
                rec.Periodo = (string)linea["Periodo"];
                rec.SubtotalConRet = float.Parse(linea["Subtotal_ConRet"].ToString());
                rec.SubtotalDeducciones = float.Parse(linea["Subtotal_Deducciones"].ToString());
                rec.SubtotalExentas = float.Parse(linea["Subtotal_Exentas"].ToString()); ;
                rec.TipoLiquidacion = (string)linea["TipoLiquidacion"];
                rec.Total = float.Parse(linea["Total"].ToString()); ;

                ListaRecibos.Add(rec);
            }
            return ListaRecibos;

        }

        public List<BE.Renglon> ListarRenglones(BE.Recibo rec)
        {

            List<BE.Renglon> ListaRenglones = new List<BE.Renglon>();
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acc.ArmarParametro("idrec", rec.ID, System.Data.SqlDbType.Int);

            DataTable Tabla = acc.Leer("Recibo_ListarRenglones", parametros);
            acc.CerrarConexion();
            GC.Collect();

            List<BE.Concepto> ListaConceptos = MpConc.ListarConceptos();
            foreach (DataRow linea in Tabla.Rows)
            {
                BE.Renglon ren = new BE.Renglon();

                ren.Valor = float.Parse(linea["Valor"].ToString()); ;
                foreach(BE.Concepto c in ListaConceptos)
                {
                    if (c.ID == (int)linea["ID_Concepto"])
                    {
                        ren.Conc = c;
                    }
                }

                ListaRenglones.Add(ren);
            }
            return ListaRenglones;

        }

    }
}
