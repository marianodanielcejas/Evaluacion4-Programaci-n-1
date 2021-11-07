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
                    
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(DT.Rows[i]["Id"]) == anatomia.Id)
                        {
                            DT.Rows[i]["Musculos"] = anatomia.Musculos;
                            DT.Rows[i]["AlumnoSeleccionadoLista"] = anatomia.AlumnoSeleccionadoLista.ToString();
                            DT.WriteXml("Lista.xml");
                            break;
                        }
                        
                    }
                }
            }
            return resp;
        }
        
        

        public Anatomia BuscarCodigo(int id)
        {
            Anatomia res = new Anatomia();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (Convert.ToInt32(DT.Rows[i]["Id"]) == id)
                {
                    res.Id = Convert.ToInt32(DT.Rows[i]["Id"]);
                    res.Musculos = (DT.Rows[i]["Musculos"].ToString());
                    res.AlumnoSeleccionadoLista = Convert.ToInt32(DT.Rows[i]["AlumnoSeleccionadoLista"]);
                    break;
                }

            }
            return res;
        }
        
        
        public bool DeleteMuscle(Anatomia anatomia)
        {
            bool resp = false;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (Convert.ToInt32(DT.Rows[i]["Id"]) == anatomia.Id)
                {
                    DT.Rows[i].Delete();
                    DT.WriteXml("Lista.xml");
                    resp = true;
                    break;
                }

            }
            //for (int i = 0; i < Muscles.Length; i++)
            //{
            //   if (Muscles[i].Id == anatomia.Id)
            //    {
            //      EliminarRegistro(i);
            //      break;
            //  }
            //}
            return resp;
        }
    }
}   
