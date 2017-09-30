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
                { "2", "201", "Se Esperaba Palabra Reservada."},
                { "2", "204", "Se Esperaba Identificador."},
                { "2", "205", "Se Esperaba Delimitador."},
                { "2", "206", "Se Esperaba Constante."},
                { "2", "207", "Se Esperaba Operador."},
                { "2", "208", "Se Esperaba Operador Relacional."},
                { "2", "209", "Se Esperaba "},
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
                    Cadena+= (Numero_Error == 0 ? " " : " Error en Línea " + Linea + ": ") + Errores[1][Numero_Error, 2] + (Numero_Error == 7 ? AnalizadorSintactico.SeEsperaba : "");
                    break;
            }
            return Cadena;
        }
    }
}
