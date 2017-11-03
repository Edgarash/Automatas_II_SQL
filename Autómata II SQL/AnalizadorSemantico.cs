using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autómata_II_SQL
{
    public static class AnalizadorSemantico
    {

        public static List<string[]> Tablas { get; set; }
        public static List<string[]> Atributos { get; set; }
        public static List<string[]> Restricciones { get; set; }
        private static int NoTabla { get; set; }
        private static int NoAtributos { get; set; }
        private static int NoRestricciones { get; set; }
        private static int AtributosActuales { get; set; }
        private static int RestriccionesActuales { get; set; }
        private static int TablaActual { get; set; }
        private static string NombreTablaActual { get; set; }
        private static bool Cadena { get; set; }
        private static int Inserting { get; set; }

        public static void InicializarSemantico()
        {
            Tablas = new List<string[]>();
            Atributos = new List<string[]>();
            Restricciones = new List<string[]>();
            RestriccionesActuales = AtributosActuales = NoTabla = NoAtributos = NoRestricciones = 1;
            Inserting = 0;
        }

        public static void Metodos700(int Regla, string Identificador)
        {
            switch (Regla)
            {
                case 700:
                    if (!TablaEnTablas(Identificador))
                        AgregarTabla(Identificador);
                    else
                        SetError(5, Identificador);
                    break;
                case 701:
                    if (!AtributoEnTabla(Identificador))
                        AgregarAtributo(Identificador);
                    else
                        SetError(1, Identificador);
                    break;
                case 702:
                    if (Identificador == "CHAR" || Identificador == "NUMERIC")
                        Atributos[NoAtributos - 2][3] = Identificador;
                    break;
                case 703:
                    Atributos[NoAtributos - 2][4] = Identificador;
                    break;
                case 704:
                    Atributos[NoAtributos - 2][5] = Identificador == "NULL" ? "1" : "0";
                    break;
                case 705:
                    if (!RestriccionEnTabla(Identificador))
                        AgregarRestriccion(Identificador);
                    else
                        SetError(3, Identificador);
                    break;
                case 706:
                    Restricciones[NoRestricciones - 2][2] = Identificador == "PRIMARY" ? "1" : "2";
                    break;
                case 707:
                    int Indice;
                    if (AtributoEnTabla(Identificador, NoTabla, out Indice))
                        Restricciones[NoRestricciones - 2][4] = (Indice + 1).ToString();
                    else
                        SetError(2, Identificador, NombreTablaActual);
                    break;
                case 708:
                    int Tabla;
                    if (TablaEnTablas(Identificador, out Tabla))
                    {
                        Restricciones[NoRestricciones - 2][5] = (Tabla + 1).ToString();
                        TablaActual = Tabla;
                        Inserting = 0;
                    }
                    else
                        SetError(4, Identificador);
                    break;
                case 709:
                    int Atributo;
                    if (AtributoEnTabla(Identificador, TablaActual + 2, out Atributo))
                        Restricciones[NoRestricciones - 2][6] = (Atributo + 1).ToString();
                    else
                        SetError(2, Identificador, NombreTablaActual);
                    break;
                case 710:
                    Cadena = true;
                    break;
                case 711:
                    string NombreCampo;
                    string Tipo;
                    int Longitud;
                    BuscarAtributoEnTabla(out NombreCampo, out Tipo, out Longitud);
                    if ((Tipo == "CHAR" && Cadena) || (Tipo == "NUMERIC" && !Cadena))
                    {
                        if (Longitud < Identificador.Length)
                            SetError(7, Identificador);
                    }
                    else
                    {
                        string Cadenita = "No se puede asignarle el valor " + (Cadena? "'" : "") + Identificador + (Cadena ? "'" : "") + " al campo " + NombreCampo;
                        SetError(6, Cadenita);
                    }
                    Inserting++;
                    Cadena = false;
                    break;
                case 714:
                    if (!TablaEnTablas(Identificador, out Tabla))
                        SetError(11, Identificador);
                    break;
            }
        }

        private static void SetError(int NoError, string PalabraError)
        {
            SetError(NoError, PalabraError, "");
        }

        private static void SetError(int NoError, string PalabraError, string PalabraError2)
        {
            ModuloErrores.TipoError = ModuloErrores.TipoDeError.Semántico;
            ModuloErrores.Error = true;
            ModuloErrores.NoError = NoError;
            ModuloErrores.PalabraError = PalabraError;
            ModuloErrores.PalabraError2 = PalabraError2;
        }

        private static void AgregarTabla(string Identificador)
        {
            Tablas.Add(new string[] { (NoTabla++).ToString(), Identificador, "", "" });
            AtributosActuales = RestriccionesActuales = 1;
        }

        private static bool TablaEnTablas(string Identificador)
        {
            int x;
            return TablaEnTablas(Identificador, out x);
        }

        private static bool TablaEnTablas(string Identificador, out int NoTabla)
        {
            NoTabla = -1;
            for (int i = 0; i < Tablas.Count && NoTabla == -1; i++)
                if (Tablas[i][1] == Identificador)
                    NoTabla = i;
            NombreTablaActual = Identificador;
            return NoTabla != -1;
        }

        private static void AgregarAtributo(string Identificador)
        {
            Tablas[NoTabla - 2][2] = (AtributosActuales++).ToString();
            Atributos.Add(new string[] { (NoTabla - 1).ToString(), (NoAtributos++).ToString(), Identificador, "", "", "" });
        }

        private static bool AtributoEnTabla(string Identificador)
        {
            int x;
            return AtributoEnTabla(Identificador, NoTabla, out x);
        }

        private static bool AtributoEnTabla(string Identificador, int Tabla, out int Indice)
        {
            Indice = -1;
            string Tablita = (Tabla - 1).ToString();
            for (int i = 0; i < Atributos.Count && Indice == -1; i++)
                if (Atributos[i][0] == Tablita)
                    if (Atributos[i][2] == Identificador)
                        Indice = i;
            return Indice != -1;
        }

        private static void AgregarRestriccion(string Identificador)
        {
            Tablas[NoTabla - 2][3] = (RestriccionesActuales++).ToString();
            if (Restricciones.Count> 0)
            {
                if (string.IsNullOrWhiteSpace(Restricciones[NoRestricciones - 2][5])) Restricciones[NoRestricciones - 2][5] = "-";
                if (string.IsNullOrWhiteSpace(Restricciones[NoRestricciones - 2][6])) Restricciones[NoRestricciones - 2][6] = "-";
            }
            Restricciones.Add(new string[] { (NoTabla - 1).ToString(), (NoRestricciones++).ToString(), "", Identificador, "", "", "" });
        }

        private static bool RestriccionEnTabla(string Identificador)
        {
            bool Encontrado = false;
            string Tablita = (NoTabla - 1).ToString();
            for (int i = 0; i < Restricciones.Count && !Encontrado; i++)
                if (Restricciones[i][0] == Tablita)
                    if (Restricciones[i][3] == Identificador)
                        Encontrado = true;
            return Encontrado;
        }

        private static bool BuscarAtributoEnTabla(out string Atributo, out string Tipo, out int Longitud)
        {
            bool Encontrado = false;
            Atributo = Tipo = "";
            Longitud = 0;
            for (int i = 0; i < Atributos.Count && !Encontrado; i++)
                if (Atributos[i][0] == (TablaActual + 1).ToString())
                {
                    Atributo = Atributos[i + Inserting][2];
                    Tipo = Atributos[i + Inserting][3];
                    Longitud = Convert.ToInt32(Atributos[i + Inserting][4]);
                    Encontrado = true;
                }
            return Encontrado;
        }

        public static void GuardarTablas()
        {
            string ArchivoTablas = @"Tablas.XML";
            DataTable Tablitas = new DataTable("Tabla");
            Tablitas.Columns.Add("Numero");
            Tablitas.Columns.Add("Nombre");
            Tablitas.Columns.Add("Atributos");
            Tablitas.Columns.Add("Restricciones");
            for (int i = 0; i < AnalizadorSemantico.Tablas?.Count; i++)
            {
                string[] temp = AnalizadorSemantico.Tablas[i];
                Tablitas.Rows.Add(temp[0], temp[1], temp[2], temp[3]);
            }
            File.Delete(ArchivoTablas);
            FileStream t = new FileStream(ArchivoTablas, FileMode.OpenOrCreate);
            Tablitas.WriteXml(t);
            t.Close();
            string ArchivoAtributos = @"Atributos.XML";
            DataTable Atributitos = new DataTable("Atributos");
            Atributitos.Columns.Add("Tabla");
            Atributitos.Columns.Add("Numero");
            Atributitos.Columns.Add("Nombre");
            Atributitos.Columns.Add("Tipo");
            Atributitos.Columns.Add("Longitud");
            Atributitos.Columns.Add("Null");
            for (int i = 0; i < AnalizadorSemantico.Atributos?.Count; i++)
            {
                string[] temp = AnalizadorSemantico.Atributos[i];
                Atributitos.Rows.Add(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
            }
            File.Delete(ArchivoAtributos);
            t = new FileStream(ArchivoAtributos, FileMode.OpenOrCreate);
            Atributitos.WriteXml(t);
            t.Close();
            string ArchivoRestricciones = @"Restricciones.XML";
            DataTable Restriccioncitas = new DataTable("Restricciones");
            Restriccioncitas.Columns.Add("Tabla");
            Restriccioncitas.Columns.Add("Numero");
            Restriccioncitas.Columns.Add("Tipo");
            Restriccioncitas.Columns.Add("Nombre");
            Restriccioncitas.Columns.Add("AtributoReferenciado");
            Restriccioncitas.Columns.Add("TablaReferenciada");
            Restriccioncitas.Columns.Add("CampoReferenciado");
            for (int i = 0; i < AnalizadorSemantico.Restricciones?.Count; i++)
            {
                string[] temp = AnalizadorSemantico.Restricciones[i];
                Restriccioncitas.Rows.Add(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
            }
            File.Delete(ArchivoRestricciones);
            t = new FileStream(ArchivoRestricciones, FileMode.OpenOrCreate);
            Restriccioncitas.WriteXml(t);
            t.Close();
        }

        public static void Cargar()
        {
            string ArchivoTablas = @"Tablas.XML";
            string ArchivoAtributos = @"Atributos.XML";
            string ArchivoRestricciones = @"Restricciones.XML";
            FileStream temp = new FileStream(ArchivoTablas, FileMode.Open);
            DataTable x1 = new DataTable();
            x1.ReadXmlSchema(temp);
            temp.Close();
            temp = new FileStream(ArchivoAtributos, FileMode.Open);
            DataTable x2 = new DataTable();
            x2.ReadXmlSchema(temp);
            temp.Close();
            temp = new FileStream(ArchivoRestricciones, FileMode.Open);
            DataTable x3 = new DataTable();
            x3.ReadXmlSchema(temp);
            temp.Close();
            Tablas = new List<string[]>();
            for (int i = 0; i < x1.Rows.Count; i++)
            {
                DataRow x = x1.Rows[i];
                Tablas.Add(new string[] { x[0].ToString(), x[1].ToString(), x[2].ToString(), x[3].ToString() });
            }
        }
    }
}