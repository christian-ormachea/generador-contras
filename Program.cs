using System.Text.Json;
using generador_contrasenias;

namespace generadorcontrasenias
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int opcion = 0;
            string contraGenerada = "";
            do
            {   
                Console.WriteLine("Hola que tal, bienvenido al generador de contraseñas de Ormachea Christian");
                Console.WriteLine("1. Crear contraseña.");
                Console.WriteLine("2. Guardar la contraseña en un archivo?");
                Console.WriteLine("3. Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        contraGenerada = CreadorDeContras();
                        if (!string.IsNullOrEmpty(contraGenerada))
                        {
                            Console.WriteLine($"la contraseña generada es: {contraGenerada}");
                        }
                        break;
                    case 2: 
                        if(contraGenerada == "")
                        {
                            Console.WriteLine("Error, primero debes haber generado una contraseña!");
                        } 
                        else if(contraGenerada == "error")
                        {
                            Console.WriteLine("Ocurrio un error al generar la contraseña");
                        }
                        else
                        {
                            GuardarEnArchivo(contraGenerada);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Gracias vuelva prontos!");
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida!");
                        break;
                }
                
            } while (opcion != 3);
            
        }

        static string CreadorDeContras()
        {
            Console.WriteLine("Seleccione con Y o N (Si o No) las características que prefiera para la contraseña.");

            // Solicitar la longitud
            Console.WriteLine("Seleccione la longitud de la contraseña: ");
            int longitud = int.Parse(Console.ReadLine());

            // Crear un diccionario para almacenar las preferencias del usuario
            var preferencias = new Dictionary<string, bool>
            {
                { "mayusculas", false },
                { "numeros", false },
                { "caracteresEspeciales", false }
            };

            // Solicitar al usuario sus preferencias
            foreach (var key in preferencias.Keys.ToList())
            {
                Console.WriteLine($"{key}? (Y/N): ");
                string respuesta = Console.ReadLine()?.Trim().ToUpper();
                preferencias[key] = respuesta == "Y";
            }

            // Validar entradas
            bool entradasInvalidas = preferencias.Values.Any(value => value == null);
            if (entradasInvalidas)
            {
                Console.WriteLine("Error: Una de las entradas no es válida.");
                return "error";
            }

            // Mostrar las opciones seleccionadas
            Console.WriteLine("\nResumen de opciones:");
            foreach (var opcion in preferencias)
            {
                Console.WriteLine($"{opcion.Key}: {(opcion.Value ? "Sí" : "No")}");
            }

            bool mayusculas = preferencias["mayusculas"];
            bool numeros = preferencias["numeros"];
            bool especiales = preferencias["caracteresEspeciales"];
            GeneradorDeContras contraGenerada = new GeneradorDeContras(longitud, mayusculas, numeros, especiales);
            string contrasenia = contraGenerada.Generar();

            return contrasenia;
        }

        static void GuardarEnArchivo(string contraGenerada) {
            var contraSerializada = JsonSerializer.Serialize(contraGenerada);
            File.WriteAllText("contraGenerada.json", contraSerializada);
        }
    }
};


