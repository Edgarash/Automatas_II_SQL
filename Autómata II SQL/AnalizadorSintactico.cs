using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autómata_II_SQL
{
    static class AnalizadorSintactico
    {
        //Comentario 2
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

        public static string Pila { get; set; }
        public static string X { get; set; }
        public static string K { get; set; }
        public static int Apuntador { get; set; }
        public static bool Error { get; set; }
        public static int NumError { get; set; }
        public static string Cadena { get; set; }
        public static List<string[]> Arbol { get; set; }
        public static string[][] ArbolSintactico { get { return Arbol.ToArray(); } }

        private static int ObtenerIndiceK()
        {
            int Index = 0;

            return Index;
        }

        private static void InsertarPila(string Caracter)
        {
            if (Caracter == "8" || Caracter == "9")
                Pila = K.ToString() + Pila;
            else
                Pila = Caracter.ToString() + ' ' + Pila;
        }

        private static string ExtraerPila()
        {
            string temp = Pila.Split(new string[] { "" }, StringSplitOptions.RemoveEmptyEntries)[0];
            Pila = Pila.Substring(1);
            return temp;
        }

        public static void Analizar()
        {
            int Xx;
            Arbol = new List<string[]>();
            Error = false;
            Pila = "";
            InsertarPila("$");
            InsertarPila("1"); //Insertar Q
            Cadena = AnalizadorLexico.CadenaLexica + "$";
            Apuntador = 0;
            AgregarRegistro(Pila, Cadena, "", "");
            do
            {
                X = ExtraerPila();
                K = Cadena.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[Apuntador];
                AgregarRegistro();
                if (int.TryParse(X, out Xx) || X == "$")
                {
                    if (X == K)
                    {
                        Apuntador++;
                        //AgregarRegistro();
                    }
                    else
                    {
                        Error = true;
                        if (TablaDeSimbolos.EsDelimitador(X[0]))
                            NumError = 1;
                        else
                        {
                            if (TablaDeSimbolos.EsOperador(X[0]))
                                NumError = 3;
                            else
                            {
                                if (TablaDeSimbolos.EsIdentificador(X))
                                    NumError = 2;
                            }
                        }
                    }
                }
                else
                {
                    int t = Convert.ToInt32(X.ToString());
                    int p = ObtenerIndiceK();
                    string temp = TablaSintactica[t, p];
                    if (temp != "")
                    {
                        if (temp != "0")
                        {
                            for (int i = temp.Length - 1; i >= 0; i--)
                                InsertarPila(temp.Split(' ')[i]);
                            AgregarRegistro(Pila, "", X, K);
                        }
                    }
                    else
                    {
                        Error = true;
                        NumError = 4;
                    }
                }
            } while (X != "$" && !Error);
        }

        private static void AgregarRegistro()
        {
            AgregarRegistro
                (
                Pila,
                Cadena.Substring(Apuntador),
                X.ToString(),
                K.ToString()
                );
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
