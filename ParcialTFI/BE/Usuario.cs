using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuarios
    {

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private int _Legajo;

        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }

        private int _Cuil;

        public int Cuil
        {
            get { return _Cuil; }
            set { _Cuil = value; }
        }

        private BE.Categoria categoria;

        public BE.Categoria Cat
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private BE.Division _div;

        public BE.Division Div
        {
            get { return _div; }
            set { _div = value; }
        }

        private BE.Departamento _Depto;

        public BE.Departamento Depto
        {
            get { return _Depto; }
            set { _Depto = value; }
        }

        private DateTime _FechaIngreso;

        public DateTime FechaIngreso
        {
            get { return _FechaIngreso; }
            set { _FechaIngreso = value; }
        }

        private float _sueldo;

        public float Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }

        private string _Cuenta;

        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private BE.Banco _bco;

        public BE.Banco Bco
        {
            get { return _bco; }
            set { _bco = value; }
        }


    }
}
