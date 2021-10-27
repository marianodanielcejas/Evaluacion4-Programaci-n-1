using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion4_Programación_1
{
    public class Anatomia
    {
        //Se usa cada ves que adicionamos una persona.
        public int Id { get; set; }
        public string Musculos { get; set; }
        public int AlumnoSeleccionadoLista { get; set;}
        public bool Validar()
        {
            bool resp = false;
            if (AlumnoSeleccionadoLista >= 1 && AlumnoSeleccionadoLista <= 60)
            {
                resp = true;
            }
            return resp;
        }
    }
}
