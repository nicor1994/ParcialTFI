using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Recibo
    {
        DAL.MP_Recibo MpRecibo = new DAL.MP_Recibo();
        public float ObtenerSubtotalConRet(List<BE.Renglon> lista)
        {

            float subt = new float();

            foreach (BE.Renglon ren in lista)
            {

                if (ren.Conc.TConcepto.ID == 1)
                {
                    subt = subt + ren.Valor;
                }
                


            }

            return subt;
        }

        public float ObtenerSubtotalExentas(List<BE.Renglon> lista)
        {

            float subt = new float();

            foreach (BE.Renglon ren in lista)
            {

                if (ren.Conc.TConcepto.ID == 2)
                {
                    subt = subt + ren.Valor;
                }



            }

            return subt;
        }

        public float ObtenerSubtotalDeducciones(List<BE.Renglon> lista)
        {

            float subt = new float();

            foreach (BE.Renglon ren in lista)
            {

                if (ren.Conc.TConcepto.ID == 3)
                {
                    subt = subt + ren.Valor;
                }



            }

            return subt;
        }

        public List<BE.Renglon> ObtenerRenglonesRemunerativo(List<BE.Concepto> lista, BE.Empleado emp)
        {
            List<BE.Renglon> Renglones = new List<BE.Renglon>();

            foreach (BE.Concepto con in lista)
            {
                if (con.TConcepto.ID != 3)
                {
                    BE.Renglon ren = new BE.Renglon();

                    ren.Conc = con;

                    if (ren.Conc.ID == 5)
                    {
                        ren.Valor = emp.Sueldo;
                    }
                    else
                    {
                        if (ren.Conc.VConcepto.ID == 1)
                        {
                            ren.Valor = con.Valor;
                        }
                        else if (ren.Conc.VConcepto.ID == 2)
                        {
                            ren.Valor = (con.Valor * emp.Sueldo) / 100;
                        }
                    }

                    Renglones.Add(ren);
                }
            }

            return Renglones;
        }

        public List<BE.Renglon> ObtenerRenglonesDeduciones(List<BE.Concepto> lista, BE.Empleado emp, List<BE.Renglon> reng)
        {
            

            foreach (BE.Concepto con in lista)
            {
                if (con.TConcepto.ID == 3)
                {
                    BE.Renglon ren = new BE.Renglon();

                    ren.Conc = con;                  
                   
                        if (ren.Conc.VConcepto.ID == 1)
                        {
                            ren.Valor = con.Valor;
                        }
                        else if (ren.Conc.VConcepto.ID == 2)
                        {
                        float total = new float();
                        foreach(BE.Renglon r in reng)
                        {
                            if (r.Conc.TConcepto.ID == 1){
                                total = total + r.Valor;
                            }
                        }

                            ren.Valor = (con.Valor * total) / 100;
                        }
                    reng.Add(ren);
                }
            }

            return reng;
        }

        public float ObtenerTotal(float subRet, float subEx, float subDeducc)
        {

            float total = new float();

            total = (subRet + subEx) - subDeducc;

            return total;
        }

        public int GuardarRecibo(BE.Recibo Rec)
        {
            int fa = MpRecibo.AgregarRecibo(Rec);
            if (fa != -1)
            {
                fa = MpRecibo.AgregarConceptos(Rec);
            }
                
            

            return fa;
        }

        public List<BE.Recibo> ListarRecibos(BE.Empleado emp)
        {

            List<BE.Recibo> listaRec =MpRecibo.ListarRecibos(emp);
            return listaRec;
        }

        public List<BE.Renglon> ListarRenglones(BE.Recibo rec)
        {

            List<BE.Renglon> listareng = MpRecibo.ListarRenglones(rec);
            return listareng;
        }
    }
}
