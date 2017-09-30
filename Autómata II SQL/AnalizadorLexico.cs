using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autómata_II_SQL
{
    static class AnalizadorLexico
    {
        private static List<string[]> TL { get; set; }
        private enum TipoDeSimbolo { Identificador, Delimitador, Operador, Constante, PalabraReservada, Relacional } //NO SE USA
        private static int Indice;
        private static string Acumulador;
        private static int Caracter { get; set; }
        private static int Contador { get; set; }
        private static int Estado { get; set; }
        private static char Token { get; set; }
        private static int Ultimo { get; set; }

        public static int NoLinea { get; set; }
        public static string[][] TablaLexica { get { return TL.ToArray(); } }

        public static string CadenaLexica
        {
            get
            {
                string temp = "";
                string[][] TLL = TablaLexica;
                for (int i = 0; i < TL.Count; i++)
                {
                    if (TLL[i][3] == "6")
                    {
                        bool Alfa = false;
                        if (TLL[i - 1 < 0 ? 0 : i - 1][4] == "54")
                            Alfa = true;
                        temp += " " + (Alfa ? 62 : 61);
                    }
                    else
                    {
                        if (TLL[i][3] == "4" || TLL[i][3] == "8")
                            temp += " " + TLL[i][3];
                        else
                            temp += " " + TLL[i][4];
                    }
                }
                return temp;
            }
        }

        public static int[,] MT = new int[,]
        {
            /*
              E: Espacio/Enter
              O: Operador
              D: Delimitador Excepto '
              L: Letra
              N: Número
              X: Diferente De Los Anteriores
           
              E  O  <  =  >  '  D  L  N  #  X
             */
            //??
            { 0, 2, 3, 4, 5, 6, 1, 7, 8, 9, 9 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 9 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 9 },
            { 0, 0, 0, 4, 4, 0, 0, 0, 0, 9, 9 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 9 },
            { 0, 0, 0, 4, 0, 0, 0, 0, 0, 9, 9 },
            { 6, 6, 6, 6, 6, 0, 6, 6, 6, 6, 6 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 7, 0, 9 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 8, 9, 9 },
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }
        };


        public static bool Analizar(string Cadena)
        {
            TL = new List<string[]>();
            TablaDeSimbolos.Reset();
            Acumulador = "";
            Caracter = NoLinea = 1;
            Contador = Estado = 0;
            int Ultimo = Cadena.Length;
            bool Error = false;
            while (Contador < Ultimo && !Error)
            {
                Token = Cadena[Contador];
                switch (Estado)
                {
                    case 0:
                        if (Token == 13)
                        {
                            NoLinea++;
                            Contador++;
                        }
                        else
                        {
                            if (Token == 10 || Token == 32)
                                Contador++;
                            else
                            {
                                if (TablaDeSimbolos.EsOperador(Token, out Indice))
                                    Estado = MT[0, 1];
                                else
                                {
                                    if (Token == '<')
                                    {
                                        Acumulador += Token;
                                        Estado = MT[0, 2];
                                        Contador++;
                                    }
                                    else
                                    {
                                        if (Token == '=')
                                        {
                                            Acumulador += Token;
                                            Estado = MT[0, 3];
                                        }
                                        else
                                        {
                                            if (Token == '>')
                                            {
                                                Acumulador += Token;
                                                Estado = MT[0, 4];
                                                Contador++;
                                            }
                                            else
                                            {
                                                if (Token == '\'')
                                                {
                                                    TablaDeSimbolos.EsDelimitador(Token, out Indice);
                                                    AgregarDelimitadorTL();
                                                    Estado = MT[0, 5];
                                                    Contador++;
                                                }
                                                else
                                                {
                                                    if (TablaDeSimbolos.EsDelimitador(Token, out Indice))
                                                        Estado = MT[0, 6];
                                                    else
                                                    {
                                                        if (char.IsLetter(Token))
                                                        {
                                                            Acumulador += Token;
                                                            Estado = MT[0, 7];
                                                            Contador++;
                                                        }
                                                        else
                                                        {
                                                            if (char.IsDigit(Token))
                                                            {
                                                                Acumulador += Token;
                                                                Estado = MT[0, 8];
                                                                Contador++;
                                                            }
                                                            else
                                                                Estado = MT[0, 9];
                                                        }//No Es Letra
                                                    }//No Es Delimitador
                                                }//No Es Apóstrofe
                                            }//No Es >
                                        }//No Es =
                                    }//No Es <
                                }//No Es Operador
                            }//No Es Espacio O \r
                        }//No Es Enter
                        break;
                    case 1:
                        AgregarDelimitadorTL();
                        Contador++;
                        Estado = 0;
                        break;
                    case 2:
                        AgregarOperadorTL();
                        Contador++;
                        Estado = 0;
                        break;
                    case 3:
                        if ("=>".Contains(Token))
                        {
                            Acumulador += Token;
                            Estado = 4;
                        }
                        else
                        {
                            TablaDeSimbolos.EsRelacional(Acumulador, out Indice);
                            AgregarRelacionalTL();
                            Estado = 0;
                        }
                        break;
                    case 4:
                        TablaDeSimbolos.EsRelacional(Acumulador, out Indice);
                        AgregarRelacionalTL();
                        Contador++;
                        Estado = 0;
                        break;
                    case 5:
                        if (Token == '=')
                        {
                            Acumulador += Token;
                            Estado = 4;
                        }
                        else
                        {
                            TablaDeSimbolos.EsRelacional(Acumulador, out Indice);
                            AgregarRelacionalTL();
                            Estado = 0;
                        }
                        break;
                    case 6:
                        if (Token == '\'')
                        {
                            if (Acumulador != "")
                            {
                                Indice = TablaDeSimbolos.AgregarConstante(Caracter - 1, Acumulador);
                                AgregarConstanteTL();
                            }
                            TablaDeSimbolos.EsDelimitador(Token, out Indice);
                            AgregarDelimitadorTL();
                            Contador++;
                            Estado = 0;
                        }
                        else
                        {
                            Acumulador += Token;
                            Contador++;
                        }
                        break;
                    case 7:
                        if (Token == '#')
                        {
                            Acumulador += Token;
                            if (!TablaDeSimbolos.EsIdentificador(Acumulador, out Indice))
                                Indice = TablaDeSimbolos.AgregarIdentificador(Acumulador, NoLinea);
                            AgregarIdentificadorTL();
                            Contador++;
                            Estado = 0;
                        }
                        else
                        {
                            if (char.IsLetterOrDigit(Token) || Token == '_')
                            {
                                Acumulador += Token;
                                Contador++;
                            }
                            else
                            {
                                if (TablaDeSimbolos.EsPalabraReservada(Acumulador, out Indice))
                                    AgregarPalabraTL();
                                else
                                {
                                    if (!TablaDeSimbolos.EsIdentificador(Acumulador, out Indice))
                                        Indice = TablaDeSimbolos.AgregarIdentificador(Acumulador, NoLinea);
                                    AgregarIdentificadorTL();
                                }
                                Estado = 0;
                            }
                        }
                        break;
                    case 8:
                        if (char.IsDigit(Token))
                        {
                            Acumulador += Token;
                            Contador++;
                        }
                        else
                        {
                            Indice = TablaDeSimbolos.AgregarConstante(Caracter, Acumulador);
                            AgregarConstanteTL();
                            Estado = 0;
                        }
                        break;
                    case 9:
                        Error = true;
                        break;
                }
            }
            if (Acumulador != "")
            {
                if (TablaDeSimbolos.EsRelacional(Acumulador, out Indice))
                    AgregarRelacionalTL();
                else
                {
                    if (TablaDeSimbolos.EsPalabraReservada(Acumulador, out Indice))
                        AgregarPalabraTL();
                    else
                    {
                        if (Estado == 8 || Estado == 6)
                        {
                            Indice = TablaDeSimbolos.AgregarConstante(Caracter - 1, Acumulador);
                            AgregarConstanteTL();
                        }
                        else
                        {
                            if (Estado == 7)
                            {
                                if (!TablaDeSimbolos.EsIdentificador(Acumulador, out Indice))
                                    Indice = TablaDeSimbolos.AgregarIdentificador(Acumulador, NoLinea);
                                AgregarIdentificadorTL();
                            }
                        }
                    }
                }
            }
            return Error;
        }

        private static void AgregarTL(string No, string Linea, string Token, string Tipo, string Codigo)
        {
            TL.Add(new string[] { No, Linea, Token, Tipo, Codigo });
            Acumulador = "";
            Caracter++;
        }

        private static void AgregarPalabraTL()
        {
            AgregarTL(Caracter.ToString(), NoLinea.ToString(), Acumulador, "1", TablaDeSimbolos.PalabrasReservadas[Indice, 1]);
        }

        private static void AgregarDelimitadorTL()
        {
            AgregarTL(Caracter.ToString(), NoLinea.ToString(), Token.ToString(), "5", TablaDeSimbolos.Delimitadores[Indice, 1]);
        }

        private static void AgregarOperadorTL()
        {
            AgregarTL(Caracter.ToString(), NoLinea.ToString(), Token.ToString(), "7", TablaDeSimbolos.Operadores[Indice, 1]);
        }

        private static void AgregarConstanteTL()
        {
            AgregarTL(Caracter.ToString(), NoLinea.ToString(), "CONSTANTE", "6", TablaDeSimbolos.ConstantesL[Indice][2]);
        }

        private static void AgregarRelacionalTL()
        {
            AgregarTL(Caracter.ToString(), NoLinea.ToString(), Acumulador, "8", TablaDeSimbolos.Relacionales[Indice, 1]);
        }

        private static void AgregarIdentificadorTL()
        {
            AgregarTL(Caracter.ToString(), NoLinea.ToString(), Acumulador, "4", TablaDeSimbolos.IdentificadoresL[Indice][1]);
            string temp = TablaDeSimbolos.Identificadores[Indice][2];
            if (!temp.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Contains(NoLinea.ToString()))
                TablaDeSimbolos.Identificadores[Indice][2] += ", " + NoLinea;
        }

        //private static bool EsUltimo { get { return Contador == Ultimo - 1; } }
    }
}
