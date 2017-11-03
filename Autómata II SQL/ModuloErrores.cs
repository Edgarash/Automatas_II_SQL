using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autómata_II_SQL
{
    static class ModuloErrores
    {
        public enum TipoDeError { Léxico, Sintáctico, Semántico }

        public static bool Error { get; set; }
        public static TipoDeError TipoError { get; set; }
        public static int NoError { get; set; }
        public static int Linea { get; set; }

        public static string PalabraError { get; set; }
        public static string PalabraError2 { get; set; }

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
            },
            new string[,]
            {
                {"3", "301", "", "" },
                {"3", "302", "El nombre de atributo ", " se especifica más de una vez" },
                {"3", "303", "El nombre de atributo ", " no existe en la tabla" },
                {"3", "304", "El nombre de restricción ", " está duplicado" },
                {"3", "305", "Se hace referencia a ", " un atributo no válido" },
                {"3", "306", "El nombre de atributo ", " está duplicado" },
                {"3", "307", "Los valores especificados no corresponden ", "" },
                {"3", "308", "Los datos de cadena o binarios se truncarían ", "" },
                {"3", "311", "El nombre de atributo ", " no es válido" },
                {"3", "312", "El nombre de atributo ", " es ambigüo" },
                {"3", "313", "Conversión de tipo de dato", "" },
                {"3", "314", "Nombre de la tabla ", "no es válido"},
                {"3", "315", "Identificador inválido", ""},
            }
        };

        public static string MensajeErrorLéxico(TipoDeError Tipo, int Linea)
        {
            return MensajeError(Tipo, -1, Linea);
        }

        public static string MensajeError(TipoDeError Tipo, int Numero_Error, int Linea)
        {
            string Cadena = "";
            switch (Tipo)
            {
                case TipoDeError.Léxico:
                    Cadena = "1:" + Errores[0][0, 1] + " Error en Línea " + Linea + ": "+ Errores[0][0, 2];
                    break;
                case TipoDeError.Sintáctico:
                    Cadena = "2:" + Errores[1][0, 1];
                    Cadena+= (Numero_Error == 0 ? " " : " Error en Línea " + Linea + ": ") + Errores[1][Numero_Error, 2] + (Numero_Error == 7 ? PalabraError : "");
                    break;
                case TipoDeError.Semántico:
                    Cadena = "3:" + Errores[2][NoError, 1];
                    Cadena += " Error en Línea " + Linea + ": " + Errores[2][Numero_Error, 2] + "\"" + PalabraError + "\"" + Errores[2][Numero_Error, 3] + (PalabraError2 == "" ? "" : " \"" + PalabraError2 + "\"");
                    break;
            }
            return Cadena;
        }

        public static string MensajeError()
        {
            return MensajeError(TipoError, NoError, Linea);
        }
    }
}

