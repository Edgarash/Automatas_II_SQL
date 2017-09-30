using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autómata_II_SQL
{
    static class AnalizadorSintactico
    {
        static string[,] TablaSintactica = new string[,]
        {
            {"4",       "8",        "10",                   "11",       "12",       "13",           "14",       "15",       "50",       "51",       "53",       "54",           "61",       "62",       "72",       "199"},

            {"",        "",         "10 301 11 306 310",    "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"302",     "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "72",       ""},
            {"304 303", "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"",        "",         "",                     "99",       "",         "",             "",         "",         "50 302",   "",         "",         "",             "",         "",         "",         "99"},
            {"4 305",   "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"",        "99",       "",                     "99",       "",         "99",           "99",       "99",       "99",       "51 4",     "99",       "",             "",         "",         "",         "99"},
            {"308 307", "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"",        "",         "",                     "",         "99",       "",             "",         "",         "50 306",   "",         "99",       "",             "",         "",         "",         "99"},
            {"4 309",   "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"4",       "",         "",                     "",         "99",       "",             "",         "",         "99",       "",         "99",       "",             "",         "",         "",         "99"},
            {"",        "",         "",                     "",         "12 311",   "",             "",         "",         "",         "",         "99",       "",             "",         "",         "",         "99"},
            {"313 312", "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"",        "",         "",                     "",         "",         "",             "317 311",  "317 311",  "",         "",         "99",       "",             "",         "",         "",         "99"},
            {"304 314", "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"",        "315 316",  "",                     "",         "",         "13 52 300 53", "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"",        "8",        "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "",         "",         ""},
            {"304",     "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "54 318 54",    "319",      "",         "",         ""},
            {"",        "",         "",                     "",         "",         "",             "14",       "15",       "",         "",         "",         "",             "",         "",         "",         ""},
            {"",        "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "",         "62",       "",         ""},
            {"",        "",         "",                     "",         "",         "",             "",         "",         "",         "",         "",         "",             "61",       "",         "",         ""}
        };

        static string[] PrimerosSiguientes = new string[]
        {
            "\"SELECT\"",
            "Identificador o Operador",
            "Identificador",
            "Delimitador o Palabra Reservada",
            "Identificador",
            "Delimitador o  Operador Relacional o Palabra Reservada",
            "Identificador",
            "Palabra Reservada o Delimitador",
            "Identificador",
            "Delimitador o Palabra Reservada",
            "Delimitador o Palabra Reservada",
            "Identificador",
            "Delimitador o Palabra Reservada",
            "Identificador",
            "Operador o Palabra Reservada",
            "Operador",
            "Delimitador o Constante o Identificador",
            "Palabra Reservada",
            "Constante",
            "Constante"
        };

        public static string Pila { get; set; }
        public static string X { get; set; }
        public static string K { get; set; }
        public static int Apuntador { get; set; }
        public static bool Error { get; set; }
        public static int NumError { get; set; }
        public static string Cadena { get; set; }
        public static string SeEsperaba { get; set; }
        public static List<string[]> Arbol { get; set; }
        public static string[][] ArbolSintactico { get { return Arbol.ToArray(); } }

        private static int ObtenerIndiceK()
        {
            int temp = 0;
            switch (K)
            {
                case "4":
                    temp = 0;
                    break;
                case "8":
                    temp = 1;
                    break;
                case "10":
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                    temp = byte.Parse(K) - 8;
                    break;
                case "50":
                case "51":
                    temp = byte.Parse(K) - 42;
                    break;
                case "53":
                case "54":
                    temp = byte.Parse(K) - 43;
                    break;
                case "61":
                case "62":
                    temp = byte.Parse(K) - 49;
                    break;
                case "72":
                    temp = 14;
                    break;
                case "199":
                    temp = 15;
                    break;
            }
            return temp;
        }

        private static void InsertarPila(string Caracter)
        {
                Pila = Caracter.ToString() + ' ' + Pila;
        }

        private static string ExtraerPila()
        {
            string[] t = Pila.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string temp = "";
            if (t.Length > 0)
            {
                temp = t[0];
                Pila = "";
                for (int i = 1; i < t.Length; i++)
                {
                    Pila += " " + t[i];
                }
            }
            return temp;
        }

        public static void Analizar()
        {
            SeEsperaba = "";
            int Xx;
            Arbol = new List<string[]>();
            Error = false;
            Pila = "";
            InsertarPila("199");
            InsertarPila("300"); //Insertar Q
            Cadena = AnalizadorLexico.CadenaLexica + " 199";
            Apuntador = 0;
            AgregarRegistro(Pila, RestanteCadena, "", "");
            do
            {
                X = ExtraerPila();
                K = Cadena.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[Apuntador];
                AgregarRegistro();
                Xx = int.Parse(X);
                if ((Xx >= 4 && Xx <= 90) || (Xx == 199)) //Como saber si x es un terminal porque todos son números :B Debe estar bien hasta aquí
                {
                    if (X == K)
                    {
                        Apuntador++;
                    }
                    else
                    {
                        Error = true;
                        NumError = TablaDeSimbolos.BuscarBuscando(X);
                    }
                }
                else
                {
                    int t = Convert.ToInt32(X.ToString()) - 299;
                    int p = ObtenerIndiceK();   //
                    string temp = TablaSintactica[t, p];
                    if (temp != "")
                    {
                        if (temp != "99")
                        {
                            string[] split = temp.Split(' ');
                            for (int i = split.Length - 1; i >= 0; i--)
                                InsertarPila(split[i]);
                            AgregarRegistro(Pila, "", X, K);
                        }
                    }
                    else
                    {
                        Error = true;
                        NumError = 7;
                        SeEsperaba = PrimerosSiguientes[Convert.ToInt32(X) - 300];
                    }
                }
            } while (X != "199" && !Error);
        }

        private static void AgregarRegistro()
        {
            AgregarRegistro
                (
                Pila,
                RestanteCadena,
                X.ToString(),
                K.ToString()
                );
        }

        private static string RestanteCadena
        {
            get
            {

                string temp = "";
                string[] t = Cadena.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = Apuntador; i < t.Length; i++)
                    temp += " " + t[i];
                return temp;
            }
        }

        private static void AgregarRegistro(string Cad1, string Cad2, object Cad3, object Cad4)
        {
            Arbol.Add(new string[]
            {
                Cad1,
                Cad2,
                Cad3.ToString(),
                Cad4.ToString()
            });
        }
    }
}
