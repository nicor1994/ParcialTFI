using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Recibo
    {

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

        private BE.TipoLiquidacion _TipoLiquidacion;

        public BE.TipoLiquidacion TipoLiq
        {
            get { return _TipoLiquidacion; }
            set { _TipoLiquidacion = value; }
        }



    }
}
