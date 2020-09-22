using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {

        SqlConnection Conexion = new SqlConnection();
        private SqlTransaction tx;

        public void AbrirConexion()
        {
            Conexion.ConnectionString = @"Data Source=DESKTOP-UGU0FER;Initial Catalog=ParcialTFI;Integrated Security= True";
            Conexion.Open();
        }

        public void CerrarConexion()
        {
            Conexion.Close();
        }

        public void IniciarTx()
        {
            tx = Conexion.BeginTransaction();
        }

        public void Confirmar()
        {
            tx.Commit();
            tx = null;
        }

        private SqlCommand CrearComando(string sp, SqlParameter[] parametros)
        {
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (tx != null)
            {
                cmd.Transaction = tx;
            }
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros);
            }
            return cmd;
        }
        private SqlCommand CrearComando(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Conexion);
            cmd.CommandType = CommandType.Text;
            if (tx != null)
            {
                cmd.Transaction = tx;
            }
            return cmd;
        }

        public SqlParameter ArmarParametro(string nombre, object valor, SqlDbType tipo)
        {
            var prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = string.Concat("@", nombre);
            prm.Value = valor;
            prm.SqlDbType = tipo;
            return prm;
        }

        public DataTable Leer(string sp, SqlParameter[] parametros = null)
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = CrearComando(sp, parametros);
            adaptador.Fill(Tabla);
            adaptador.Dispose();
            return Tabla;
        }

        public int Escribir(string sp, SqlParameter[] parametros)
        {
            SqlCommand cmd = CrearComando(sp, parametros);
            int fa = 0;
            try
            {
                fa = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            { fa = -1; }

            return fa;
        }

        public int Escribir(string query)
        {
            SqlCommand cmd = CrearComando(query);
            int fa = 0;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            { fa = -1; }

            return fa;
        }


    }
}
