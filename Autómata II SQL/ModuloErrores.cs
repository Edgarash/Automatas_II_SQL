using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autómata_II_SQL
{
    static class ModuloErrores
    {
        public enum Error { Léxico, Sintáctico }

        static string[][,] Errores = new string[][,]
        {
            new string [,] { { "1", "101", "Simbolo Desconocido" } },
            new string [,] 
            {
                { "2", "200", "Sin Error."},
                { "2", "201", "Falta Delimitador."},
                { "2", "202", "Falta Identificador."},
                { "2", "203", "Falta Operador."},
                { "2", "204", "Error Sintáctico, cerca de "}
            }
        };

        public static string MensajeErrorLéxico(Error Tipo, int Linea)
        {
            return MensajeError(Tipo, -1, Linea, ' ');
        }

        public static string MensajeError(Error Tipo, int Numero_Error, int Linea, char Caracter)
        {
            string Cadena = "";
            switch (Tipo)
            {
                case Error.Léxico:
                    Cadena = "1:" + Errores[0][0, 1] + " Error en Línea " + Linea + ": "+ Errores[0][0, 2];
                    break;
                case Error.Sintáctico:
                    Cadena = "2:" + Errores[1][0, 1];
                    Cadena+= (Numero_Error == 0 ? " " : " Error en Línea " + Linea + ": ") + Errores[1][Numero_Error, 2] + (Numero_Error == 4 ? Caracter.ToString() : "");
                    break;
            }
            return Cadena;
        }
    }
}
