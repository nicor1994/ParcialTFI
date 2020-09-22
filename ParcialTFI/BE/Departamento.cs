using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Departamento
    {

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _depto;

        public string Depto
        {
            get { return _depto; }
            set { _depto = value; }
        }

        private List<BE.Division> _listaDiv;

        public List<BE.Division> ListaDiv
        {
            get { return _listaDiv; }
            set { _listaDiv = value; }
        }



        public override string ToString()
        {
            return Depto;
        }

    }
}
