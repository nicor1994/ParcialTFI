using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Recibo
    {

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private List<BE.Concepto> _ListaConceptos;

        public List<BE.Concepto> ListaConceptos
        {
            get { return _ListaConceptos; }
            set { _ListaConceptos = value; }
        }

        private DateTime _fechadepago;

        public DateTime FechaDePago
        {
            get { return _fechadepago; }
            set { _fechadepago = value; }
        }

        private float _SubtotalConRet;

        public float SubtotalConRet
        {
            get { return _SubtotalConRet; }
            set { _SubtotalConRet = value; }
        }

        private float _SubtotalExentas;

        public float SubtotalExentas
        {
            get { return _SubtotalExentas; }
            set { _SubtotalExentas = value; }
        }

        private float _SubtotalDeducciones;

        public float SubtotalDeducciones
        {
            get { return _SubtotalDeducciones; }
            set { _SubtotalDeducciones = value; }
        }

        private float _Total;

        public float Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _periodo;

        public string Periodo
        {
            get { return _periodo; }
            set { _periodo = value; }
        }

        private List<BE.Renglon> _renglones;

        public List<BE.Renglon> Renglones
        {
            get { return _renglones; }
            set { _renglones = value; }
        }


        private BE.Empleado _emp;

        public BE.Empleado Emp
        {
            get { return _emp; }
            set { _emp = value; }
        }

        private string _tipoLiquidacion;

        public string TipoLiquidacion
        {
            get { return _tipoLiquidacion; }
            set { _tipoLiquidacion = value; }
        }

        public override string ToString()
        {
            return Periodo + " - " + TipoLiquidacion + " - " + FechaDePago.ToShortDateString();
        }

    }
}
