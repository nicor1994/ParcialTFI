using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MP_Departamento
    {
        Acceso Acc = new Acceso();
        public List<BE.Departamento> ListarDeptos()
        {
            List<BE.Departamento> ListaDeptos = new List<BE.Departamento>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = Acc.ArmarParametro("tabla", "Departamento", SqlDbType.VarChar);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ListarEntidad", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.Departamento dpto = new BE.Departamento();

                dpto.ID = (int)linea["ID"];
                dpto.Depto = (string)linea["Departamento"];

                ListaDeptos.Add(dpto);

            }

            return ListaDeptos;
        }

        public BE.Empleado ListarDto(BE.Empleado emp, int id)
        {
            
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = Acc.ArmarParametro("tabla", "Departamento", SqlDbType.VarChar);
            parametros[1] = Acc.ArmarParametro("id", id, SqlDbType.Int);
            Acc.AbrirConexion();
            DataTable tabla = Acc.Leer("ObtenerEntidadID", parametros);
            Acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in tabla.Rows)
            {
                BE.Departamento depa = new BE.Departamento();

                depa.ID = (int)linea["ID"];
                depa.Depto = (string)linea["Departamento"];
                emp.Depto = depa;

            }

            return emp;
        }

    }
}
