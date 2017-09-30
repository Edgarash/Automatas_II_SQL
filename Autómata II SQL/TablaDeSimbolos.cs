using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autómata_II_SQL
{
    static class TablaDeSimbolos
    {
        private static int ValorIdentificador = 400;
        private static int ValorConstante = 600;

        public static string[,] Operadores = new string[,]
        {
            { "+", "70" },
            { "-", "71" },
            { "*", "72" },
            { "/", "73" }
        };

        public static string[,] Delimitadores = new string[,]
        {
            { ",", "50" },
            { ".", "51" },
            { "(" ,"52" },
            { ")", "53" },
            { "'", "54" },
            { ";", "55" }
        };

        public static string[,] Relacionales = new string[,]
        {
            { ">", "81", ">" },
            { "<", "82", "<" },
            { "=", "83", "=" },
            { "≥", "84", ">=" },
            { "≤", "85", "<=" },
            { "≠", "86", "<>" }
        };

        public static string[,] PalabrasReservadas = new string[,]
        {
            { "s", "10", "SELECT" },
            { "f", "11", "FROM" },
            { "w", "12", "WHERE" },
            { "n", "13", "IN" },
            { "y", "14", "AND" },
            { "o", "15", "OR" },
            { "c", "16", "CREATE" },
            { "t", "17", "TABLE" },
            { "h", "18", "CHAR" },
            { "u", "19", "NUMERIC" },
            { "e", "20", "NOT" },
            { "g", "21", "NULL" },
            { "b", "22", "CONSTRAINT" },
            { "k", "23", "KEY" },
            { "p", "24", "PRIMARY" },
            { "j", "25", "FOREIGN" },
            { "l", "26", "REFERENCES" },
            { "m", "27", "INSERT" },
            { "q", "28", "INTO" },
            { "v", "29", "VALUES" }
        };

        public static List<string[]> IdentificadoresL = new List<string[]>();

        public static List<string[]> ConstantesL = new List<string[]>();

        public static string[][] Identificadores { get { return IdentificadoresL.ToArray(); } }
        
        public static string[][] Constantes { get { return ConstantesL.ToArray(); } }

        public static bool Buscar(string[,] Tabla, char Caracter, out int Ind)
        {
            bool Encontrado = false;
            int Length = Tabla.GetLength(0);
            string temp = Caracter.ToString();
            Ind = -1;
            for (int i = 0; i < Length && !Encontrado; i++)
                if (Tabla[i,0] == temp)
                {
                    Encontrado = true;
                    Ind = i;
                }
            return Encontrado;
        }

        public static bool Buscar(List<string[]> Tabla, string Caracter, out int Ind, bool Id)
        {
            bool Encontrado = false;
            int Length = Tabla.Count;
            string temp = Caracter;
            for (Ind = 0; Ind < Length && !Encontrado; Ind++)
                if (Tabla[Ind][Id ? 0 : 1] == temp)
                {
                    Encontrado = true;
                    Ind--;
                }
            return Encontrado;
        }

        public static bool EsIdentificador(string Caracter, out int Indice)
        {
            return Buscar(IdentificadoresL, Caracter, out Indice, true);
        }

        public static bool EsIdentificador(string Caracter)
        {
            int x;
            return EsIdentificador(Caracter, out x);
        }

        public static bool EsOperador(char Caracter, out int Indice)
        {
            return Buscar(Operadores, Caracter, out Indice);
        }

        public static bool EsOperador(char Caracter)
        {
            int x;
            return EsOperador(Caracter, out x);
        }

        public static bool EsDelimitador(char Caracter, out int Indice)
        {
            return Buscar(Delimitadores, Caracter, out Indice);
        }

        public static bool EsDelimitador(char Caracter)
        {
            int x;
            return Buscar(Delimitadores, Caracter, out x);
        }

        public static bool EsRelacional(string Palabra, out int Indice)
        {
            bool Encontrado = false;
            int Length = Relacionales.GetLength(0);
            string temp = Palabra;
            Indice = -1;
            for (int i = 0; i < Length && !Encontrado; i++)
                if (Relacionales[i, 2] == temp)
                {
                    Encontrado = true;
                    Indice = i;
                }
            return Encontrado;
        }

        public static bool EsRelacional(string Caracter)
        {
            int x;
            return EsRelacional(Caracter, out x);
        }

        public static bool EsConstante(string Caracter, out int Indice)
        {
            return Buscar(ConstantesL, Caracter, out Indice, false);
        }

        public static bool EsConstante(string Caracter)
        {
            int x;
            return EsConstante(Caracter, out x);
        }

        public static bool EsPalabraReservada(string Palabra, out int Indice)
        {
            bool Encontrado = false;
            int Length = PalabrasReservadas.GetLength(0);
            string temp = Palabra;
            Indice = -1;
            for (int i = 0; i < Length && !Encontrado; i++)
                if (PalabrasReservadas[i, 2] == temp)
                {
                    Encontrado = true;
                    Indice = i;
                }
            return Encontrado;
        }

        public static bool EsPalabrareservada(string Palabra)
        {
            int x;
            return EsPalabraReservada(Palabra, out x);
        }

        private static void Agregar(List<string[]> Lista, params string[] Caracteres)
        {
            Lista.Add(Caracteres);
        }

        public static int AgregarIdentificador(string Cadena, int NumeroLinea)
        {
            int x = ValorIdentificador - 400; //Obtener el índice en la lista
            Agregar(IdentificadoresL, Cadena, (++ValorIdentificador).ToString(), NumeroLinea.ToString());
            return x;
        }

        public static int AgregarConstante(int Numero, string Constante)
        {
            int x = ValorConstante - 600; //Obtener el índice en la lista
            Agregar(ConstantesL, Numero.ToString(), Constante, (++ValorConstante).ToString());
            return x;
        }

        public static string BuscarConstante(string Valor)
        {
            string temp = "";
            for (int i = 0; i < ConstantesL.Count; i++)
                if (ConstantesL[i][2] == Valor)
                {
                    temp = ConstantesL[i][1];
                    break;
                }
            return temp;
        }

        public static int BuscarBuscando(string Valor)
        {
            int temp = 0;
            bool Encontrado = false;
            for (int i = 0; i < PalabrasReservadas.GetLength(0); i++)
                if (PalabrasReservadas[i, 1] == Valor)
                {
                    temp = 1;
                    Encontrado = true;
                    break;
                }
            for (int i = 0; i < Operadores.GetLength(0) && !Encontrado; i++)
                if (Operadores[i, 1] == Valor)
                {
                    temp = 5;
                    Encontrado = true;
                }
            for (int i = 0; i < Delimitadores.GetLength(0) && !Encontrado; i++)
                if (Delimitadores[i, 1] == Valor)
                {
                    temp = 3;
                    Encontrado = true;
                }
            for (int i = 0; i < Relacionales.GetLength(0) && !Encontrado; i++)
                if (Relacionales[i,1] == Valor)
                {
                    temp = 6;
                    Encontrado = true;
                }
            if (Valor == "4")
                temp = 2;
            if (Valor == "62" || "61" == Valor)
                temp = 4;
            return temp;
        }

        public static void Reset()
        {
            ValorIdentificador = 400;
            ValorConstante = 600;
            IdentificadoresL.Clear();
            ConstantesL.Clear();
        }
    }
}
