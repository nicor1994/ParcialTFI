using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class MP_Categoria
    {
        
        Acceso Acc = new Acceso();
        MP_Division GestorDiv = new MP_Division();
        public List<BE.Categoria> ListarCategorias(int id)
        {
            List<BE.Categoria> ListaCat = new List<BE.Categoria>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = Acc.ArmarParametro("id", id, SqlDbType.Int);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ListarCategorias", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.Categoria cat = new BE.Categoria();

                cat.ID = (int)linea["ID"];
                cat.Cat = (string)linea["Categoria"];
                cat.Sueldo = float.Parse(linea["Sueldo"].ToString());
                ListaCat.Add(cat);

            }

            return ListaCat;
        }

        public BE.Empleado ListarCategoria(BE.Empleado emp, int id)
        {
            
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = Acc.ArmarParametro("tabla", "Categoria", SqlDbType.VarChar);
            parametros[1] = Acc.ArmarParametro("id", id, SqlDbType.Int);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ObtenerEntidadID", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.Categoria cate = new BE.Categoria();

                cate.ID = (int)linea["ID"];
                cate.Cat = (string)linea["Categoria"];
                cate.Sueldo = float.Parse(linea["Sueldo"].ToString());
                emp.Cat = cate;
                GestorDiv.ListarDivision(emp, (int)linea["ID_Division"]);

            }

            return emp;
        }

    }
}
