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
        enum Parte { Select, From, Where }
        private static Parte ParteDelSelect { get; set; }
        public static List<string[]> Tablas { get; set; }
        public static List<string[]> Atributos { get; set; }
        public static List<string[]> Restricciones { get; set; }
        public static List<string[]> SelectCampos { get; set; }
        public static List<string[]> FromTablas { get; set; }
        public static List<string[]> WhereCampos { get; set; }
        private static int SelectIndice { get; set; }
        private static int NoTabla { get; set; }
        private static int NoAtributos { get; set; }
        private static int NoRestricciones { get; set; }
        private static int AtributosActuales { get; set; }
        private static int RestriccionesActuales { get; set; }
        private static int TablaActual { get; set; }
        private static string NombreTablaActual { get; set; }
        private static bool Cadena { get; set; }
        private static bool VamoAComparar { get; set; }
        private static int Inserting { get; set; }

        public static void InicializarSemantico()
        {
            Tablas = new List<string[]>();
            Atributos = new List<string[]>();
            Restricciones = new List<string[]>();
            SelectCampos = new List<string[]>();
            FromTablas = new List<string[]>();
            WhereCampos = new List<string[]>();
            RestriccionesActuales = AtributosActuales = NoTabla = NoAtributos = NoRestricciones = 1;
            SelectIndice = Inserting = 0;
            VamoAComparar = false;
        }

        public static void Metodos700(int Regla, string Identificador, int IndiceTabla)
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
                    int Tabla = 0;
                    if (TablaEnTablas(Identificador, out Tabla))
                    {
                        if (NoRestricciones > 1)
                        {
                            Restricciones[NoRestricciones - 2][5] = (Tabla + 1).ToString();
                            TablaActual = Tabla;
                            Inserting = 0;
                        }
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
                        string Cadenita = "No se puede asignarle el valor " + (Cadena ? "'" : "") + Identificador + (Cadena ? "'" : "") + " al campo " + NombreCampo;
                        SetError(6, Cadenita);
                    }
                    Inserting++;
                    Cadena = false;
                    break;
                case 712:
                    if (!TablaEnTablas(Identificador, out Tabla))
                        SetError(11, Identificador);
                    break;
                case 713:
                    if (ParteDelSelect == Parte.Select)
                        //IndiceTablaLéxica, Tabla, Atributo
                        SelectCampos.Add(new string[] { IndiceTabla.ToString(), "", Identificador, "", SelectIndice.ToString() });
                    else
                    {
                        if (ParteDelSelect == Parte.Where)
                        {
                            WhereCampos.Add(new string[] { IndiceTabla.ToString(), "", Identificador, "", "", "", "", VamoAComparar.ToString(), "", SelectIndice.ToString() });
                            VamoAComparar = false;
                        }
                    }
                    break;
                case 714:
                    ParteDelSelect = Parte.Select;
                    break;
                case 715:
                    ParteDelSelect = Parte.From;
                    break;
                case 716:
                    ParteDelSelect = Parte.Where;
                    break;
                case 717:
                    if (ParteDelSelect == Parte.From)
                    {
                        TablaEnTablas(Identificador, out Tabla);
                        FromTablas.Add(new string[] { IndiceTabla.ToString(), (Tabla + 1).ToString(), Identificador, "", "", SelectIndice.ToString() });
                    }
                    break;
                case 718:
                    if (ParteDelSelect == Parte.Select)
                    {
                        int Campo = SelectCampos.Count - 1;
                        SelectCampos[Campo][1] = SelectCampos[Campo][2];
                        SelectCampos[Campo][2] = Identificador;
                        SelectCampos[Campo][3] = IndiceTabla.ToString();
                    }
                    else
                    {
                        if (ParteDelSelect == Parte.Where)
                        {
                            int Campo = WhereCampos.Count - 1;
                            WhereCampos[Campo][1] = WhereCampos[Campo][2];
                            WhereCampos[Campo][2] = Identificador;
                            WhereCampos[Campo][3] = IndiceTabla.ToString();
                        }
                    }
                    break;
                case 719:
                    if (ParteDelSelect == Parte.From)
                    {
                        bool Encontrado = false;
                        for (int i = 0; i < FromTablas.Count && !Encontrado; i++)
                            if (FromTablas[i][5] == SelectIndice.ToString())
                                if (FromTablas[i][3] == Identificador)
                                    Encontrado = true;
                        if (!Encontrado)
                        {
                            FromTablas[FromTablas.Count - 1][3] = Identificador;
                            FromTablas[FromTablas.Count - 1][4] = IndiceTabla.ToString();
                        }
                        else
                            SetError(5, Identificador, IndiceTabla);
                    }
                    break;
                case 720:
                    VamoAComparar = true;
                    break;
                case 721:
                    WhereCampos[WhereCampos.Count - 1][7] = Cadena ? "CADENA" : "NUMERIC";
                    WhereCampos[WhereCampos.Count - 1][8] = Identificador;
                    VamoAComparar = false;
                    Cadena = false;
                    break;
                case 722:
                    SelectIndice++;
                    break;
                case 723:
                    for (int i = 0; i < SelectCampos.Count; i++)
                        if (SelectCampos[i][4] == SelectIndice.ToString())
                        {
                            SelectCampos.RemoveAt(i);
                            i--;
                        }
                    for (int i = 0; i < FromTablas.Count; i++)
                        if (FromTablas[i][5] == SelectIndice.ToString())
                        {
                            FromTablas.RemoveAt(i);
                            i--;
                        }
                    for (int i = 0; i < WhereCampos.Count; i++)
                        if (WhereCampos[i][9] == SelectIndice.ToString())
                        {
                            WhereCampos.RemoveAt(i);
                            i--;
                        }
                    SelectIndice--;
                    break;
                case 799:
                    SelectBuscarAtributoEnTablas();
                    if (!ModuloErrores.Error)
                        WhereBuscarAtributoEnTablas();
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

        private static void SetError(int NoError, string PalabraError, int IndiceTabla)
        {
            SetError(NoError, PalabraError);
            ModuloErrores.IndiceTablaLexica = IndiceTabla;
            ModuloErrores.Linea = Convert.ToInt32(AnalizadorLexico.TablaLexica[ModuloErrores.IndiceTablaLexica][1]);
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
            if (Restricciones.Count > 0)
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

        private static void SelectBuscarAtributoEnTablas()
        {
            bool Error = false;
            for (int i = 0; i < SelectCampos.Count && !Error; i++)
            {
                string Tabla = SelectCampos[i][1];
                string Campo = SelectCampos[i][2];
                bool Encontrado = false;
                int Veces = 0;
                if (SelectCampos[i][4] == SelectIndice.ToString())
                {
                    if (Tabla == "")
                    {
                        for (int j = 0; j < Atributos.Count && Veces < 2; j++)
                        {
                            if (Campo == Atributos[j][2])
                                if (AtributoEnTablasSelect(Atributos[j][0], SelectCampos[i][4]))
                                { Encontrado = true; Veces++; }
                        }
                    }
                    else
                    {
                        string TablaDeVerdad = "";
                        if (BuscarTablaEnFrom(Tabla, out TablaDeVerdad))
                        {
                            int t;
                            TablaEnTablas(TablaDeVerdad, out t);
                            if (AtributoEnTabla(Campo, t + 2, out t))
                            { Encontrado = true; Veces++; }
                            else
                            { Encontrado = true; SetError(8, Campo, Convert.ToInt32(SelectCampos[i][3])); }
                        }
                        else
                        {
                            SetError(13, Tabla, Convert.ToInt32(SelectCampos[i][0]));
                            Encontrado = true;
                        }
                    }
                    if (!Encontrado)
                    {
                        SetError(8, Campo, Convert.ToInt32(SelectCampos[i][0]));
                        Error = true;
                    }
                    if (Veces > 1)
                    {
                        SetError(9, Campo, Convert.ToInt32(SelectCampos[i][0]));
                        Error = true;
                    }
                }
            }
        }

        private static void WhereBuscarAtributoEnTablas()
        {
            bool Error = false;
            for (int i = 0; i < WhereCampos.Count && !Error; i++)
            {
                string Tabla = WhereCampos[i][1];
                string Campo = WhereCampos[i][2];
                bool Encontrado = false;
                int Veces = 0;
                if (WhereCampos[i][9] == SelectIndice.ToString())
                {
                    if (Tabla == "")
                    {
                        for (int j = 0; j < Atributos.Count && Veces < 2; j++)
                        {
                            if (Campo == Atributos[j][2])
                                if (AtributoEnTablasSelect(Atributos[j][0], WhereCampos[i][9]))
                                { Encontrado = true; Veces++; Tabla = Atributos[j][1]; }
                        }
                        if (Veces < 2 && Veces > 0)
                        {
                            int t = Convert.ToInt32(Tabla) - 1;
                            WhereCampos[i][4] = Atributos[t][3];
                            WhereCampos[i][5] = Atributos[t][4];
                            WhereCampos[i][6] = Atributos[t][5];
                            if (WhereCampos[i][7] == "True")
                            {
                                if (WhereCampos[i][4] != WhereCampos[i - 1][4])
                                {
                                    SetError(10, WhereCampos[i - 1][2], WhereCampos[i - 1][4] + "\" a tipo de dato \"" + WhereCampos[i][4]);
                                    ModuloErrores.IndiceTablaLexica = Convert.ToInt32(WhereCampos[i - 1][3]);
                                    ModuloErrores.Linea = Convert.ToInt32(AnalizadorLexico.TablaLexica[ModuloErrores.IndiceTablaLexica][1]);
                                    Error = Encontrado = true;
                                }
                            }
                            else
                            {
                                if (WhereCampos[i][7] != "False")
                                {
                                    WhereCampos[i][7] = WhereCampos[i][7] == "CADENA" ? "CHAR" : "NUMERIC";
                                    if (WhereCampos[i][4] != WhereCampos[i][7])
                                    {
                                        SetError(10, WhereCampos[i][2], WhereCampos[i][4] + "\" a tipo de dato \"" + WhereCampos[i][7]);
                                        ModuloErrores.IndiceTablaLexica = Convert.ToInt32(WhereCampos[i][0]);
                                        ModuloErrores.Linea = Convert.ToInt32(AnalizadorLexico.TablaLexica[ModuloErrores.IndiceTablaLexica][1]);
                                        Error = Encontrado = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string TablaDeVerdad = "";
                        if (BuscarTablaEnFrom(Tabla, out TablaDeVerdad))
                        {
                            int t;
                            TablaEnTablas(TablaDeVerdad, out t);
                            if (AtributoEnTabla(Campo, t + 2, out t))
                            {
                                Encontrado = true;
                                Veces++;
                                WhereCampos[i][4] = Atributos[t][3];
                                WhereCampos[i][5] = Atributos[t][4];
                                WhereCampos[i][6] = Atributos[t][5];
                                if (WhereCampos[i][7] == "True")
                                {
                                    if (WhereCampos[i][4] != WhereCampos[i - 1][4])
                                    {
                                        SetError(10, WhereCampos[i - 1][2], WhereCampos[i - 1][4] + "\" a tipo de dato \"" + WhereCampos[i][4]);
                                        ModuloErrores.IndiceTablaLexica = Convert.ToInt32(WhereCampos[i - 1][3]);
                                        ModuloErrores.Linea = Convert.ToInt32(AnalizadorLexico.TablaLexica[ModuloErrores.IndiceTablaLexica][1]);
                                        Error = Encontrado = true;
                                    }
                                }
                                else
                                {
                                    if (WhereCampos[i][7] != "False")
                                    {
                                        WhereCampos[i][7] = WhereCampos[i][7] == "CADENA" ? "CHAR" : "NUMERIC";
                                        if (WhereCampos[i][4] != WhereCampos[i][7])
                                        {
                                            SetError(10, WhereCampos[i][2], WhereCampos[i][4] + "\" a tipo de dato \"" + WhereCampos[i][7]);
                                            ModuloErrores.IndiceTablaLexica = Convert.ToInt32(WhereCampos[i][3]);
                                            ModuloErrores.Linea = Convert.ToInt32(AnalizadorLexico.TablaLexica[ModuloErrores.IndiceTablaLexica][1]);
                                            Error = Encontrado = true;
                                        }
                                    }
                                }
                            }
                            else
                            { Encontrado = true; SetError(8, Campo, Convert.ToInt32(WhereCampos[i][3]));
                                Error = true;
                            }
                        }
                        else
                        {
                            SetError(13, Tabla, Convert.ToInt32(WhereCampos[i][0]));
                            Encontrado = true;
                            Error = true;
                        }
                    }
                    if (!Encontrado)
                    {
                        SetError(8, Campo, Convert.ToInt32(WhereCampos[i][0]));
                        Error = true;
                    }
                    if (Veces > 1)
                    {
                        SetError(9, Campo, Convert.ToInt32(WhereCampos[i][0]));
                        Error = true;
                    }
                }
            }
        }

        private static bool AtributoEnTablasSelect(string NoTablaDeAtributo, string Select)
        {
            bool Encontrado = false;
            for (int i = 0; i < FromTablas.Count && !Encontrado; i++)
                if (FromTablas[i][5] == Select)
                    if (FromTablas[i][1] == NoTablaDeAtributo)
                        Encontrado = true;
            return Encontrado;
        }

        private static bool BuscarTablaEnFrom(string Tabla, out string VerdaderoNombreTabla)
        {
            VerdaderoNombreTabla = "";
            bool Encontrado = false;
            for (int i = 0; i < FromTablas.Count && !Encontrado; i++)
                if ((FromTablas[i][2] == Tabla || FromTablas[i][3] == Tabla) && FromTablas[i][5] == SelectIndice.ToString())
                {
                    Encontrado = true;
                    VerdaderoNombreTabla = FromTablas[i][2];
                }
            return Encontrado;
        }

        #region Cosas XML

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

        public static void CargarTablas()
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

        #endregion
    }
}