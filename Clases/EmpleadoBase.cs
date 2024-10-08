using Examen02.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen02.Clases
{
    public abstract class EmpleadoBase:IEmpleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } 
        public string Puesto { get; set; }
        public abstract decimal SueldoBase { get; }

        public abstract decimal CalcularSueldo();
    
        public void MostrarDetalles()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Id: {IdEmpleado}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Puesto: {Puesto}");
            Console.WriteLine($"Sueldo Base: {SueldoBase}");

        }
    }
}
