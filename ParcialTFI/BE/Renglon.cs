using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Renglon
    {

        private BE.Concepto _conc;

        public BE.Concepto Conc
        {
            get { return _conc; }
            set { _conc = value; }
        }

        private float _valor;

        public float Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }



    }
}
