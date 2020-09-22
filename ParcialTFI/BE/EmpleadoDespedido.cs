using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class EmpleadoDespedido : BE.Empleado
    {
        private DateTime _FechaDespedido;

        public DateTime FechaDespido
        {
            get { return _FechaDespedido; }
            set { _FechaDespedido = value; }
        }


    }
}
