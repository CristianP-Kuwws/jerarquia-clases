using System;
using Excepcion.CM;

namespace Excepcion
{
    public class ExcepcionComunidad : Exception
    {
        public ExcepcionComunidad(string mensaje) : base(mensaje) { }

        public class ExcepcionNula : ExcepcionComunidad
        {
            public ExcepcionNula(string mensaje) : base(mensaje) { }
        }
    }
}

namespace ComunidadOBJ
{
    public abstract class MiembroDeLaComunidad
    {
        private string _nombre;
        private string _apellido;
        private int _edad;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ExcepcionComunidad("El nombre es requerido.");
                }
                if (value.Length > 20)
                {
                    throw new ExcepcionComunidad("El nombre no puede exceder los 20 caracteres.");
                }
                _nombre = value;
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ExcepcionComunidad("El apellido es requerido.");
                }
                if (value.Length > 20)
                {
                    throw new ExcepcionComunidad("El apellido no puede exceder los 20 caracteres.");
                }
                _apellido = value;
            }
        }

        public int Edad
        {
            get { return _edad; }
            set
            {
                if (value < 18 || value > 70)
                {
                    throw new ExcepcionComunidad("La edad debe ser mayor a 18 y menor a 70.");
                }
                _edad = value;
            }
        }

        public MiembroDeLaComunidad(string nombre, string apellido, int edad)
        {
            Nombre = nombre ?? throw new ExcepcionComunidad.ExcepcionNula($"{nameof(nombre)} no puede ser nulo.");
            Apellido = apellido ?? throw new ExcepcionComunidad.ExcepcionNula($"{nameof(apellido)} no puede ser nulo.");
            Edad = edad;
        }

        public abstract void MostrarInformacion();

        public class Empleado : MiembroDeLaComunidad
        {
            public string Puesto { get; set; }

            public Empleado(string nombre, string apellido, int edad, string puesto)
                : base(nombre, apellido, edad)
            {
                Puesto = puesto ?? throw new ExcepcionComunidad.ExcepcionNula($"{nameof(puesto)} no puede ser nulo.");
            }

            public override void MostrarInformacion()
            {
                Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, Edad: {Edad}");
                Console.WriteLine($"Puesto del Empleado: {Puesto}");
            }
        }

        public class Estudiante : MiembroDeLaComunidad
        {
            public int Matricula { get; set; }

            public Estudiante(string nombre, string apellido, int edad, int matricula)
                : base(nombre, apellido, edad)
            {
                Matricula = matricula;
            }

            public override void MostrarInformacion()
            {
                Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, Edad: {Edad}");
                Console.WriteLine($"Matricula: {Matricula}");
            }
        }

        public class ExAlumno : MiembroDeLaComunidad
        {
            public int AnioGraduacion { get; set; }

            public ExAlumno(string nombre, string apellido, int edad, int anioGraduacion)
                : base(nombre, apellido, edad)
            {
                AnioGraduacion = anioGraduacion;
            }

            public override void MostrarInformacion()
            {
                Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, Edad: {Edad}");
                Console.WriteLine($"Año de graduación: {AnioGraduacion}");
            }
        }

        public class Docente : Empleado
        {
            public string Especialidad { get; set; }

            public Docente(string nombre, string apellido, int edad, string puesto, string especialidad)
                : base(nombre, apellido, edad, puesto)
            {
                Especialidad = especialidad ?? throw new ExcepcionComunidad.ExcepcionNula($"{nameof(especialidad)} no puede ser nulo.");
            }

            public override void MostrarInformacion()
            {
                base.MostrarInformacion();
                Console.WriteLine($"Especialidad: {Especialidad}");
            }
        }

        public class Administrativo : Empleado
        {
            public string Departamento { get; set; }

            public Administrativo(string nombre, string apellido, int edad, string puesto, string departamento)
                : base(nombre, apellido, edad, puesto)
            {
                Departamento = departamento ?? throw new ExcepcionComunidad.ExcepcionNula($"{nameof(departamento)} no puede ser nulo.");
            }

            public override void MostrarInformacion()
            {
                base.MostrarInformacion();
                Console.WriteLine($"Departamento: {Departamento}");
            }
        }

        public class Administrador : Docente
        {
            public string AreaAdmin { get; set; }

            public Administrador(string nombre, string apellido, int edad, string puesto, string especialidad, string areaAdmin)
                : base(nombre, apellido, edad, puesto, especialidad)
            {
                AreaAdmin = areaAdmin ?? throw new ExcepcionComunidad.ExcepcionNula($"{nameof(areaAdmin)} no puede ser nulo.");
            }

            public override void MostrarInformacion()
            {
                base.MostrarInformacion();
                Console.WriteLine($"Área de Administración: {AreaAdmin}");
            }
        }

        public class Maestro : Docente
        {
            public string Asignatura { get; set; }

            public Maestro(string nombre, string apellido, int edad, string puesto, string especialidad, string asignatura)
                : base(nombre, apellido, edad, puesto, especialidad)
            {
                Asignatura = asignatura ?? throw new ExcepcionComunidad.ExcepcionNula($"{nameof(asignatura)} no puede ser nulo.");
            }

            public override void MostrarInformacion()
            {
                base.MostrarInformacion();
                Console.WriteLine($"Asignatura: {Asignatura}");
            }
        }
    }

    public class Inicio
    {
        public void Ejecutar()
        {
            MiembroDeLaComunidad.Empleado empleado = new MiembroDeLaComunidad.Empleado("Ana", "Lopez", 25, "Secretaria");
            Console.WriteLine("Información del Empleado:");
            empleado.MostrarInformacion();
            Console.WriteLine();

            MiembroDeLaComunidad.Estudiante estudiante = new MiembroDeLaComunidad.Estudiante("Juan", "Perez", 22, 12345);
            Console.WriteLine("Información del Estudiante:");
            estudiante.MostrarInformacion();
            Console.WriteLine();

            MiembroDeLaComunidad.ExAlumno exAlumno = new MiembroDeLaComunidad.ExAlumno("Maria", "Gonzalez", 28, 2015);
            Console.WriteLine("Información del ExAlumno:");
            exAlumno.MostrarInformacion();
            Console.WriteLine();

            MiembroDeLaComunidad.Docente docente = new MiembroDeLaComunidad.Docente("Luis", "Fernandez", 40, "Profesor", "Matemáticas");
            Console.WriteLine("Información del Docente:");
            docente.MostrarInformacion();
            Console.WriteLine();

            MiembroDeLaComunidad.Administrativo administrativo = new MiembroDeLaComunidad.Administrativo("Laura", "Ramirez", 35, "Administrativa", "Finanzas");
            Console.WriteLine("Información del Administrativo:");
            administrativo.MostrarInformacion();
            Console.WriteLine();

            MiembroDeLaComunidad.Administrador administrador = new MiembroDeLaComunidad.Administrador("Pedro", "Gomez", 45, "Director", "Gestión", "Recursos Humanos");
            Console.WriteLine("Información del Administrador:");
            administrador.MostrarInformacion();
            Console.WriteLine();

            MiembroDeLaComunidad.Maestro maestro = new MiembroDeLaComunidad.Maestro("Sofia", "Herrera", 50, "Maestra", "Educación", "Historia");
            Console.WriteLine("Información del Maestro:");
            maestro.MostrarInformacion();
            Console.WriteLine();
        }
    }
}
