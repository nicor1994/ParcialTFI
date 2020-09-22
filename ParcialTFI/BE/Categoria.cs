using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Categoria
    {

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _Cat;

        public string Cat
        {
            get { return _Cat; }
            set { _Cat = value; }
        }

        private float _sueldo;

        public float Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }


        public override string ToString()
        {
            return Cat + "  - $"+ Sueldo;
        }
    }
}
