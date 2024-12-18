using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace generador_contrasenias
{
    internal class GeneradorDeContras
    {
        const string LetrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
        const string LetrasMayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string Numeros = "0123456789";
        const string CaracteresEspeciales = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        private int Longitud { get; set; }
        private bool IncluirMayusculas { get; set; }
        private bool IncluirNumeros { get; set; }
        private bool IncluirEspeciales { get; set; }

        public GeneradorDeContras(int longitud, bool mayusculas, bool numeros, bool especiales)
        {
            Longitud = longitud;
            IncluirMayusculas = mayusculas;
            IncluirNumeros = numeros;
            IncluirEspeciales = especiales;
        }

        public string Generar()
        {
            // Construir el conjunto de caracteres disponibles
            string caracteresDisponibles = LetrasMinusculas;

            if (IncluirMayusculas) caracteresDisponibles += LetrasMayusculas;
            if (IncluirNumeros) caracteresDisponibles += Numeros;
            if (IncluirEspeciales) caracteresDisponibles += CaracteresEspeciales;

            if (string.IsNullOrEmpty(caracteresDisponibles))
                throw new InvalidOperationException("Debe incluir al menos un tipo de caracteres para generar la contraseña.");

            // Crear la contraseña
            Random random = new Random();
            char[] contrasena = new char[Longitud];

            for (int i = 0; i < Longitud; i++)
            {
                contrasena[i] = caracteresDisponibles[random.Next(caracteresDisponibles.Length)];
            }

            return new string(contrasena);
        }
    }
}
