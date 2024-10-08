using Examen02.Clases;
using Examen02.Interfaces;

void ExamenSinMenu()
{
    List<EmpleadoBase> empleados = new List<EmpleadoBase>();
    Gerente gerente = new Gerente { IdEmpleado = 1, Nombre = "Santos Pairazamán", Puesto = "Gerente" };
    Desarrollador desarrollador = new Desarrollador { IdEmpleado = 2, Nombre = "André Gámez", Puesto = "Desarrollador" };
    GerenteRRHH gerenteRRHH = new GerenteRRHH { IdEmpleado = 3, Nombre = "Willy Flores", Puesto = "Gerente RRHH" };
    ConsultorExterno consultorExterno = new ConsultorExterno { IdEmpleado = 4, Nombre = "Jhonny Cruz", Puesto = "Consultor" };

    empleados.Add(gerente);
    empleados.Add(desarrollador);
    empleados.Add(gerenteRRHH);
    empleados.Add(consultorExterno);

    foreach (var empleado in empleados)
    {

        empleado.MostrarDetalles();

        if (empleado is ISueldoBonificable empleadoBonificable)
        {
            Console.WriteLine($"Bonificacion: {empleadoBonificable.CalcularBonificacion()}");
        }
        if (empleado is IDescuentoImpuesto empleadoDescuento)
        {
            Console.WriteLine($"Descuento: {empleadoDescuento.DescontarSueldo()}");
        }
        Console.WriteLine($"Sueldo neto:{empleado.CalcularSueldo()}");
    }
    //Console.Read();
}


void ExamenConMenu()
{
    List<EmpleadoBase> empleados = new List<EmpleadoBase>();
    string opcion = "";
    int contador = 0;

;    do
    {
        Console.WriteLine("===============================");
        Console.WriteLine("A - Ingrese Empleado");
        Console.WriteLine("B - Mostrar Listado de empleados");
        Console.WriteLine("S - Salir");

        opcion = Console.ReadLine().ToUpper();

        switch (opcion)
        {
            case "A":
                Console.WriteLine("Ingrese Tipo Empleado(GER/AUD/DEV)");
                string tipo = Console.ReadLine().ToUpper();
                Console.WriteLine("Ingrese Nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Puesto");
                string puesto = Console.ReadLine();
                contador += 1;
                empleados = IngresarEmpleados(empleados, tipo, contador, nombre, puesto);
                break;
            case "B":
                MostrarListado(empleados);
                break;
            default:
                break;
        }

    } while (opcion != "S");

    List<EmpleadoBase> IngresarEmpleados(List<EmpleadoBase> empleados, string tipo, int contador, string nombre, string puesto)
    {
        if (tipo == "GER") empleados.Add(new Gerente { IdEmpleado = contador, Nombre = nombre, Puesto = puesto });
        if (tipo == "AUD") empleados.Add(new ConsultorExterno { IdEmpleado = contador, Nombre = nombre, Puesto = puesto });
        if (tipo == "DEV") empleados.Add(new Desarrollador { IdEmpleado = contador, Nombre = nombre, Puesto = puesto });
        return empleados;
    }


   void MostrarListado(List<EmpleadoBase> empleados)
    {
        decimal totalDeSueldos = 0m;
        foreach (var empleado in empleados)
        {
            empleado.MostrarDetalles();
            if (empleado is ISueldoBonificable empleadoBonificable)
            {
                Console.WriteLine($"Bonificacion: {empleadoBonificable.CalcularBonificacion()}");
            }
            if (empleado is IDescuentoImpuesto empleadoDescuento)
            {
                Console.WriteLine($"Descuento: {empleadoDescuento.DescontarSueldo()}");
            }
            Console.WriteLine($"Sueldo neto:{empleado.CalcularSueldo()}");
            totalDeSueldos += empleado.CalcularSueldo();
        }
        Console.WriteLine($"La cantidad de empleados es: {contador}");
        Console.WriteLine($"El total de sueldos es: {totalDeSueldos}");

        Console.Read();
    }
   
}

//ExamenSinMenu();
ExamenConMenu();

