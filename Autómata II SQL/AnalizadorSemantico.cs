using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autómata_II_SQL
{
    public static class AnalizadorSemantico
    {

        public static List<string[]> Tablas { get; set; }
        private static int NoTabla { get; set; }

        private static bool Create { get; set; }
        private static bool Table { get; set; }

        public static void InicializarSemantico()
        {
            Tablas = new List<string[]>();
            NoTabla = 1;
            Create = Table = false;
        }

        private static bool TablaEnTablas(string Identificador)
        {
            bool Encontrado = false;
            for (int i = 0; i < Tablas.Count && !Encontrado; i++)
                if (Tablas[i][1] == Identificador)
                    Encontrado = true;
            return Encontrado;
        }

        public static bool TablaRepetida(string Identificador)
        {
            bool Repetido = false;
            if (Identificador == "CREATE")
                Create = true;
            else
            {
                if (Create && Identificador == "TABLE")
                    Table = true;
                else
                {
                    if (Create && Table)
                    {
                        if (TablaEnTablas(Identificador))
                            Repetido = true;
                        else
                            Tablas.Add(new string[] { "" + NoTabla++, Identificador, "", "" });
                    }
                    Create = Table = false;
                }
            }
            return Repetido;
        }
    }
}
