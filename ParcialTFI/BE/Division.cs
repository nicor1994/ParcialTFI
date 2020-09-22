using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Division
    {

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _Div;

        public string Div
        {
            get { return _Div; }
            set { _Div = value; }
        }

        private List<BE.Categoria> _listaCat;

        public List<BE.Categoria> ListaCat
        {
            get { return _listaCat; }
            set { _listaCat = value; }
        }



        public override string ToString()
        {
            return Div;
        }

    }
}
