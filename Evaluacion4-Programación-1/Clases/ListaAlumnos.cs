using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion4_Programación_1
{
    public class ListaAlumnos
    {
        //Lista Musculos.
        public Anatomia[] Muscles { get; set; }
        //Metodo: Último codigo que voy a dar cuando quiera generar un nuevo músculo.
        public int UltimoCodigo { get; set; } = 0;
        //Redimencionar el arreglo Muscles.
        public void Redimencionar()
        {
            if (Muscles == null)
            {
                Muscles = new Anatomia[1];
            }
            else
            {
                Anatomia[] Arraux = new Anatomia[Muscles.Length + 1];
                for (int i = 0; i < Muscles.Length; i++)
                {
                    Arraux[i] = Muscles[i];
                }
                Muscles = Arraux;
            }
        }
        //Metodo para añadir un músculo.
        //public bool AddPersona(string Musculo, string NL)
        //{
          //  Anatomia anatomia = new Anatomia();
            //anatomia.Musculos = Musculo;
            //anatomia.AlumnoSeleccionadoLista = Convert.ToInt32(NL);
            //bool resp = anatomia.Validar();
           
            //pos = pos + 1;
            //if (resp)
            //{
              //  UltimoCodigo = UltimoCodigo + 1;
                //anatomia.Id = UltimoCodigo;
                //Redimencionar();
                //Muscles[Muscles.Length - 1] = anatomia;
            //}
            //return resp;
        //}
        //Metodo que recibe el objeto anatomia;
        public bool UpdatePersona(Anatomia anatomia)
        {
            bool resp = anatomia.Validar();

            //pos = pos + 1;
            if (resp)
            {
                //significa que nunca lo cargue.
                if(anatomia.Id == 0)
                {
                    UltimoCodigo = UltimoCodigo + 1;
                    anatomia.Id = UltimoCodigo;
                    Redimencionar();
                    Muscles[Muscles.Length - 1] = anatomia;
                }
                else
                {
                    for (int i = 0; i < Muscles.Length; i++)
                    {
                        if (Muscles[i].Id == anatomia.Id)
                        {
                            Muscles[i] = anatomia;
                            break;
                        }
                    }
                }
            }
            return resp;
        }
        //Metodo para convertir a string.
        public override string ToString()
        {
            string Resp = "Lista:\r\n"; ;
            foreach (Anatomia item in Muscles)
            {
                Resp = Resp
                    + item.Id.ToString() + " - "
                    + item.AlumnoSeleccionadoLista.ToString()
                    + " - " + item.Musculos + "\r\n";
            }
            return Resp;
        }
        //Metodo para filtrar por año minimo.
        public string ToStringFiltrado(int NMinimo)
        {
            string Resp = "Lista:\r\n";
            foreach (Anatomia item in Muscles)
            {
                if (item.AlumnoSeleccionadoLista >= NMinimo)
                {
                    Resp = Resp
                   + item.Id.ToString() + " - "
                   + item.AlumnoSeleccionadoLista.ToString()
                   + " - " + item.Musculos + "\r\n";
                }
            }
            return Resp;
        }

        public Anatomia BuscarCodigo(int Id)
        {
            Anatomia res = new Anatomia();
            foreach (Anatomia item in Muscles)
            {
                if(item.Id == Id)
                {
                    res = item;
                    break;
                }
            }

            return res;
        }
        
        //seria el Método para borrar
        public bool DeleteMuscle(Anatomia anatomia)
        {
            return false;
        }
    }
}   
