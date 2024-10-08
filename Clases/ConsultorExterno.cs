using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen02.Clases
{
    public class ConsultorExterno : EmpleadoBase
    {
        public override decimal SueldoBase => 5000m;

        public override decimal CalcularSueldo()
        {
           return SueldoBase;
        }
    }
}
