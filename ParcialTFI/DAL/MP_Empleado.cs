using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class MP_Empleado
    {
        Acceso acc = new Acceso();
        DAL.MP_Categoria MPCat = new MP_Categoria();
        MP_Banco MPBco = new MP_Banco();
        public int AgregarUsuario(BE.Empleado emp)
        {
            int fa = 0;
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = acc.ArmarParametro("nombre", emp.Nombre, System.Data.SqlDbType.VarChar);
            parametros[1] = acc.ArmarParametro("apellido", emp.Apellido, System.Data.SqlDbType.VarChar);
            parametros[2] = acc.ArmarParametro("legajo", emp.Legajo, System.Data.SqlDbType.Int);
            parametros[3] = acc.ArmarParametro("cuil", emp.Cuil, System.Data.SqlDbType.VarChar);
            parametros[4] = acc.ArmarParametro("cuenta", emp.Cuenta, System.Data.SqlDbType.Int);
            parametros[5] = acc.ArmarParametro("idbanco", emp.Bco.ID, System.Data.SqlDbType.VarChar);
            parametros[6] = acc.ArmarParametro("ingreso", emp.FechaIngreso, System.Data.SqlDbType.Date);
            parametros[7] = acc.ArmarParametro("idcat", emp.Cat.ID, System.Data.SqlDbType.VarChar);
        

            fa = acc.Escribir("Empleado_Agregar", parametros);
            acc.CerrarConexion();
            GC.Collect();
            return fa;
        }

        public int ModificarUsuario(BE.Empleado emp)
        {
            int fa = 0;
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = acc.ArmarParametro("nombre", emp.Nombre, System.Data.SqlDbType.VarChar);
            parametros[1] = acc.ArmarParametro("apellido", emp.Apellido, System.Data.SqlDbType.VarChar);
            parametros[2] = acc.ArmarParametro("legajo", emp.Legajo, System.Data.SqlDbType.Int);
            parametros[3] = acc.ArmarParametro("cuil", emp.Cuil, System.Data.SqlDbType.VarChar);
            parametros[4] = acc.ArmarParametro("cuenta", emp.Cuenta, System.Data.SqlDbType.Int);
            parametros[5] = acc.ArmarParametro("idbanco", emp.Bco.ID, System.Data.SqlDbType.VarChar);
            parametros[6] = acc.ArmarParametro("id", emp.ID, System.Data.SqlDbType.Int);
            parametros[7] = acc.ArmarParametro("idcat", emp.Cat.ID, System.Data.SqlDbType.VarChar);
            

            fa = acc.Escribir("Empleado_Modificar", parametros);
            acc.CerrarConexion();
            GC.Collect();
            return fa;
        }

        public int BajaUsuario(BE.Empleado emp)
        {
            int fa = 0;
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = acc.ArmarParametro("id", emp.ID, System.Data.SqlDbType.Int);
            parametros[1] = acc.ArmarParametro("fecha", DateTime.Now, System.Data.SqlDbType.VarChar);
            fa = acc.Escribir("Empleado_Baja", parametros);
            acc.CerrarConexion();
            GC.Collect();
            return fa;
        }

        public List<BE.Empleado> ListarEmpleados()
        {

            List<BE.Empleado> ListaEmpleados = new List<BE.Empleado>();
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acc.ArmarParametro("tabla", "Empleado", System.Data.SqlDbType.VarChar);

            DataTable Tabla = acc.Leer("ListarEntidad", parametros);
            acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in Tabla.Rows)
            {
                BE.Empleado emp = new BE.Empleado();

                if (VerificarDespedido((int)linea["ID"]) == false)
                {
                    emp.ID = (int)linea["ID"];
                    emp.Nombre = (string)linea["Nombre"];
                    emp.Apellido = (string)linea["Apellido"];
                    emp.Legajo = (int)linea["Legajo"];
                    emp.Cuil = (int)linea["Cuil"];
                    MPCat.ListarCategoria(emp, (int)linea["ID_Categoria"]);
                    emp.FechaIngreso = (DateTime)linea["FechaIngreso"];
                    emp.Cuenta = float.Parse(linea["Cuenta"].ToString());
                    emp.Bco = MPBco.ListarBco((int)linea["ID_Banco"]);
                    emp.Sueldo = emp.Cat.Sueldo;

                    ListaEmpleados.Add(emp);
                }          
            }
            return ListaEmpleados;

        }

        public List<BE.Empleado> ListarEmpleadosTodos()
        {

            List<BE.Empleado> ListaEmpleados = new List<BE.Empleado>();
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acc.ArmarParametro("tabla", "Empleado", System.Data.SqlDbType.VarChar);

            DataTable Tabla = acc.Leer("ListarEntidad", parametros);
            acc.CerrarConexion();
            GC.Collect();
            foreach (DataRow linea in Tabla.Rows)
            {
                BE.Empleado emp = new BE.Empleado();

               
                    emp.ID = (int)linea["ID"];
                    emp.Nombre = (string)linea["Nombre"];
                    emp.Apellido = (string)linea["Apellido"];
                    emp.Legajo = (int)linea["Legajo"];
                    emp.Cuil = (int)linea["Cuil"];
                    MPCat.ListarCategoria(emp, (int)linea["ID_Categoria"]);
                    emp.FechaIngreso = (DateTime)linea["FechaIngreso"];
                    emp.Cuenta = float.Parse(linea["Cuenta"].ToString());
                    emp.Bco = MPBco.ListarBco((int)linea["ID_Banco"]);
                    emp.Sueldo = emp.Cat.Sueldo;

                    ListaEmpleados.Add(emp);
                
            }
            return ListaEmpleados;

        }

        public bool VerificarDespedido(int id)
        {

            
            acc.AbrirConexion();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = acc.ArmarParametro("tabla", "EmpleadoDespedido", System.Data.SqlDbType.VarChar);
            parametros[1] = acc.ArmarParametro("id", id, System.Data.SqlDbType.Int);
            DataTable Tabla = acc.Leer("ObtenerEntidadID", parametros);
            acc.CerrarConexion();
            GC.Collect();
            
            if (Tabla.Rows.Count == 0)
            {
                return false;
            }
            else { return true; }
            }
            
        }

    }

