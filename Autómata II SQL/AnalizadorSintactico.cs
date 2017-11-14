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
            /**/{"*", "4","8","10","11","12","13","14","15","16","18","19","20","22","24","25","26","27","50","51","53","54","61","62","72","199","55"},
            /*200*/{"200", "","","","","","","","","16 17 4 700 52 202 53 55 201","","","","","","","","","","","","","","","","",""},
            /*201*/{"201", "","","722 300 723 55 201","","","","","","200","","","","","","","","211","","","","","","","","99",""},
            /*202*/{"202", "4 701 203 702 52 61 703 53 204 704 205","","","","","","","","","","","","","","","","","","","","","","","","",""},
            /*203*/{"203","","","","","","","","","","18","19","","","","","","","","","","","","","","",""},
            /*204*/{"204","","","","","","","","","","","","20 21","","","","","","99","","99","","","","","",""},
            /*205*/{"205","","","","","","","","","","","",""," ","","","","","50 206","","99","","","","","",""},
            /*206*/{"206","202","","","","","","","","","","","","207","","","","","","","","","","","","",""},
            /*207*/{"207","","","","","","","","","","","","","22 4 705 208 52 4 707 53 209","","","","","","","","","","","","",""},
            /*208*/{"208","","","","","","","","","","","","","","24 706 23","25 706 23 ","","","","","","","","","","",""},
            /*209*/{"209","","","","","","","","","","","","","","","","26 4 708 52 4 709 53 210","","50 207","","99","","","","","",""},
            /*210*/{"210","","","","","","","","","","","","","","","","","","50 207","","99","","","","","",""},
            /*211*/{"211","","","","","","","","","","","","","","","","","27 28 4 708 29 52 212 53 55 215","","","","","","","","",""},
            /*212*/{"212","","","","","","","","","","","","","","","","","","","","","213 214","213 214","","","",""},
            /*213*/{"213","","","","","","","","","","","","","","","","","","","","","54 710 62 711 54 ","61 711","","","",""},
            /*214*/{"214","","","","","","","","","","","","","","","","","","50  212","","99","","","","","",""},
            /*215*/{"215","","","201","","","","","","201","","","","","","","","211","","","","","","","","99","99"},
            /*300*/{"300","","","10 714 301 11 715 306 310 799","","","","","","","","","","","","","","","","","","","","","","",""},
            /*301*/{"301","302","","","","","","","","","","","","","","","","","","","","","","","72","",""},
            /*302*/{"302","304 303","","","","","","","","","","","","","","","","","","","","","","","","",""},
            /*303*/{"303","","","","99","","","","","","","","","","","","","","50 302","","","","","","","99",""},
            /*304*/{"304","4 713 305","","","","","","","","","","","","","","","","","","","","","","","","",""},
            /*305*/{"305","","99","","99","","99","99","99","","","","","","","","","","99","51 4 718","99","","","","","99",""},
            /*306*/{"306","308 307","","","","","","","","","","","","","","","","","","","","","","","","",""},
            /*307*/{"307","","","","","99","","","","","","","","","","","","","50 306","","99","","","","","99","99"},
            /*308*/{"308","4 712 717 309","","","","","","","","","","","","","","","","","","","","","","","","",""},
            /*309*/{"309","4 719","","","","99","","","","","","","","","","","","","99","","99","","","","","99","99"},
            /*310*/{"310","","","","","12 716 311","","","","","","","","","","","","","","","99","","","","","99","99"},
            /*311*/{"311","313 312","","","","","","","","","","","","","","","","","","","","","","","","",""},
            /*312*/{"312","","","","","","","317 311","317 311","","","","","","","","","","","","99","","","","","99","99"},
            /*313*/{"313","304 314","","","","","","","","","","","","","","","","","","","","","","","","",""},
            /*314*/{"314","","315  316","","","","13 52 722 300 723 53","","","","","","","","","","","","","","","","","","","",""},
            /*315*/{"315","","8 720","","","","","","","","","","","","","","","","","","","","","","","",""},
            /*316*/{"316","304","","","","","","","","","","","","","","","","","","","","54 710 318 54","319","","","",""},
            /*317*/{"317","","","","","","","14","15","","","","","","","","","","","","","","","","","",""},
            /*318*/{"318","","","","","","","","","","","","","","","","","","","","","","","62 721","","",""},
            /*319*/{"319","","","","","","","","","","","","","","","","","","","","","","61 721","","","",""},

        };

        static string[,] PrimerosSiguientes = new string[,]
        {
            {"200", "Palabra Reservada" },
            {"201", "Palabra Reservada" },
            {"202", "Identificador" },
            {"203", "Palabra Reservada" },
            {"204", "Palabra Reservada o Delimitador" },
            {"205", "Delimitador" },
            {"206", "Identificador o Palabra Reservada" },
            {"207", "Palabra Reservada" },
            {"208", "Palabra Reservada" },
            {"209", "Delimitador o Palabra Reservada" },
            {"210", "Delimitador" },
            {"211", "Palabra Reservada" },
            {"212", "Delimitador o Constante" },
            {"213", "Delimitador o Constante" },
            {"214", "Delimitador" },
            {"215", "Palabra Reservada" },
            {"300", "Palabra Reservada" },
            {"301", "Identificador o Operador" },
            {"302", "Identificador" },
            {"303", "Delimitador o Palabra Reservada" },
            {"304", "Identificador" },
            {"305", "Delimitador o  Operador Relacional o Palabra Reservada" },
            {"306", "Identificador" },
            {"307", "Palabra Reservada o Delimitador" },
            {"308", "Identificador" },
            {"309", "Delimitador o Palabra Reservada" },
            {"310", "Delimitador o Palabra Reservada" },
            {"311", "Identificador" },
            {"312", "Delimitador o Palabra Reservada" },
            {"313", "Identificador" },
            {"314", "Operador o Palabra Reservada" },
            {"315", "Operador" },
            {"316", "Delimitador o Constante o Identificador" },
            {"317", "Palabra Reservada" },
            {"318", "Constante" },
            {"319", "Constante" },
        };

        public static string Pila { get; set; }
        public static string X { get; set; }
        public static string K { get; set; }
        public static int Apuntador { get; set; }
        public static string Cadena { get; set; }
        public static List<string[]> Arbol { get; set; }
        public static string[][] ArbolSintactico { get { return Arbol.ToArray(); } }

        private static int ObtenerIndiceK()
        {
            int temp = -1;
            int x = TablaSintactica.GetLength(1);
            for (int i = 0; i < x && temp == -1; i++)
                if (TablaSintactica[0, i] == K)
                    temp = i;
            return temp;
        }

        private static int ObtenerIndiceX()
        {
            int temp = -1;
            int x = TablaSintactica.GetLength(0);
            for (int i = 0; i < x && temp == -1; i++)
                if (TablaSintactica[i, 0] == X)
                    temp = i;
            return temp;
        }

        private static string ObtenerPrimerosOSiguientes()
        {
            string temp = "";
            int x = PrimerosSiguientes.GetLength(0);
            for (int i = 0; i < x && temp == ""; i++)
                if (PrimerosSiguientes[i, 0] == X)
                    temp = PrimerosSiguientes[i, 1];
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
            ModuloErrores.PalabraError = "";
            int Xx;
            Arbol = new List<string[]>();
            ModuloErrores.Error = false;
            Pila = "";
            InsertarPila("199");
            InsertarPila("201"); //Insertar Q
            Cadena = AnalizadorLexico.CadenaLexica + " 199";
            Apuntador = 0;
            AgregarRegistro(Pila, RestanteCadena, "", "");
            do
            {
                X = ExtraerPila();
                K = Cadena.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[Apuntador];
                AgregarRegistro();
                Xx = int.Parse(X);
                if (Xx >= 700)
                {
                    string Identificador = "";
                    if (Xx != 722 && Xx != 723)
                        Identificador = AnalizadorLexico.TablaLexica[Apuntador - 1][2];
                    if (Identificador == "CONSTANTE")
                        Identificador = TablaDeSimbolos.BuscarConstante(AnalizadorLexico.TablaLexica[Apuntador - 1][4]);
                    AnalizadorSemantico.Metodos700(Xx, Identificador, Apuntador - 1);
                    if (ModuloErrores.Error)
                    {
                        if (Xx != 799)
                        {
                            ModuloErrores.IndiceTablaLexica = Apuntador - 1;
                            ModuloErrores.Linea = Convert.ToInt32(AnalizadorLexico.TablaLexica[Apuntador - 1][1]);
                        }
                    }
                }
                else
                {
                    if ((Xx >= 4 && Xx <= 90) || (Xx == 199)) //Como saber si x es un terminal porque todos son números :B Debe estar bien hasta aquí
                    {
                        if (X == K)
                        {
                            Apuntador++;
                        }
                        else
                        {
                            ModuloErrores.Error = true;
                            ModuloErrores.NoError = TablaDeSimbolos.BuscarBuscando(X);
                            ModuloErrores.TipoError = ModuloErrores.TipoDeError.Sintáctico;
                            ModuloErrores.Linea = Convert.ToInt32(AnalizadorLexico.TablaLexica[Apuntador - 1][1]);
                        }
                    }
                    else
                    {
                        int t = ObtenerIndiceX();
                        int p = ObtenerIndiceK();
                        string temp = t == -1 || p == -1 ? "" : TablaSintactica[t, p];
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
                            ModuloErrores.TipoError = ModuloErrores.TipoDeError.Sintáctico;
                            ModuloErrores.Error = true;
                            ModuloErrores.NoError = 7;
                            int Indice = Apuntador - 1 < 0 ? 0 : Apuntador - 1;
                            ModuloErrores.Linea = Convert.ToInt32(AnalizadorLexico.TablaLexica[Indice][1]);
                            ModuloErrores.PalabraError = ObtenerPrimerosOSiguientes();
                        }
                    }
                }
            }while (X != "199" && !ModuloErrores.Error);
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
