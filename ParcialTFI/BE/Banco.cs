using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Banco
    {

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }



        private string _Bco;

        public string Bco
        {
            get { return _Bco; }
            set { _Bco = value; }
        }

        public override string ToString()
        {
            return Bco;
        }

    }
}
