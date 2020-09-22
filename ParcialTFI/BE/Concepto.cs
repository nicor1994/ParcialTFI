using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Concepto
    {

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private TipoConcepto _tipoConcepto;

        public TipoConcepto TConcepto
        {
            get { return _tipoConcepto; }
            set { _tipoConcepto = value; }
        }

        private ValorConcepto valorConcepto;

        public ValorConcepto VConcepto
        {
            get { return valorConcepto; }
            set { valorConcepto = value; }
        }

        private float _Valor;

        public float Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }




        public override string ToString()
        {
            return Nombre + " - " + Valor;
        }

    }
}
