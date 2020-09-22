using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ValorConcepto
    {

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TipoValor;

        public string TipoValor
        {
            get { return _TipoValor; }
            set { _TipoValor = value; }
        }

        public override string ToString()
        {
            return TipoValor;
        }
    }
}
