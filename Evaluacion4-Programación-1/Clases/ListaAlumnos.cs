using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Evaluacion4_Programación_1
{
    public class ListaAlumnos
    {
        //Lista Musculos.
        public Anatomia[] Muscles { get; set; }
        //Metodo: Último codigo que voy a dar cuando quiera generar un nuevo músculo.

        public DataTable DT { get; set; } = new DataTable();
        public int UltimoCodigo { get; set; } = 0;

        public ListaAlumnos()
        {
            DT.TableName = "ListaAlumnos";
            DT.Columns.Add("id");
            DT.Columns.Add("Musculos");
            DT.Columns.Add("AlumnoSeleccionadoLista");

            LeerDT_DeArchivo();
        }
        public void LeerDT_DeArchivo()
        {
            if (System.IO.File.Exists("Lista.xml"))
            {
                DT.Clear();
                DT.ReadXml("Lista.xml");
                UltimoCodigo = 0;

                for(int i = 0; i < DT.Rows.Count; i++)
                {
                    if(Convert.ToInt32(DT.Rows[i]["Id"])> UltimoCodigo)
                    {
                        UltimoCodigo = Convert.ToInt32(DT.Rows[i]["Id"]);
                    }
                }
            }
        }


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

                    DT.Rows.Add();
                    int NumeroRegistroNuevo = DT.Rows.Count - 1;
                    DT.Rows[NumeroRegistroNuevo]["Id"] = anatomia.Id.ToString();
                    DT.Rows[NumeroRegistroNuevo]["Musculos"] = anatomia.Musculos.ToString();
                    DT.Rows[NumeroRegistroNuevo]["AlumnoSeleccionadoLista"] = anatomia.AlumnoSeleccionadoLista.ToString();

                    DT.WriteXml("Lista.xml");
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
        //Metodo para convertir a string.
        public void EliminarRegistro(int posicion)
        {
            for (int i = posicion; i < Muscles.Length - 1; i++)
            {
                Muscles[i] = Muscles[i + 1];
            }
            Anatomia[] Arraux = new Anatomia[Muscles.Length - 1];
            for (int i = 0; i < Muscles.Length - 1; i++)
            {
                Arraux[i] = Muscles[i];
            }
            Muscles = Arraux;
        }
        public override string ToString()
        {
            string Resp = "Lista:\r\n"; ;
            //foreach (Anatomia item in Muscles)
            //{
            //  Resp = Resp
            //    + item.Id.ToString() + " - "
            //  + item.AlumnoSeleccionadoLista.ToString()
            //+ " - " + item.Musculos + "\r\n";
            //}
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
            bool resp = false;
            for (int i = 0; i < Muscles.Length; i++)
            {
                if (Muscles[i].Id == anatomia.Id)
                {
                    EliminarRegistro(i);
                    break;
                }
            }
            return resp;
        }
    }
}   
