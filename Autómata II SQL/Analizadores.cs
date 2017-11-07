using System;
using System.Drawing;
using ScintillaNET;
using System.Windows.Forms;
using System.Data;

namespace Autómata_II_SQL
{
    public partial class Analizadores : Form
    {
        static Timer Retraso { get; set; }
        static DateTime HoraInicial { get; set; }
        static DateTime HoraFinal { get; set; }
        static string TiempoTardado
        {
            get
            {
                TimeSpan x = HoraFinal - HoraInicial;
                return x.ToString();
            }
        }

        public Analizadores()
        {
            InitializeComponent();
            InitialiseScintilla();
            Retraso = new Timer();
            Retraso.Tick += Retraso_Tick;
            Retraso.Interval = 1000;
            Diseñando = false;
        }

        private void Retraso_Tick(object sender, EventArgs e)
        {
            Analizar(SourceCode.Text);
            Retraso.Stop();
        }

        private void Analizar(string Cadena)
        {
            //Limpiando Parámetros
            dgvLexico.Rows.Clear();
            dgvIdentificadores.Rows.Clear();
            dgvArbol.Rows.Clear();
            dgvTablaTablas.Rows.Clear();
            dgvAtributos.Rows.Clear();
            dgvRestricciones.Rows.Clear();
            AnalizadorSemantico.InicializarSemantico();
            ModuloErrores.Error = false;
            //Verificando Cadena Vacía
            if (!string.IsNullOrWhiteSpace(Cadena))
            {
                //Empieza Conteo Tiempo
                HoraInicial = DateTime.Now;
                //Análisis Léxico
                ModuloErrores.Error = AnalizadorLexico.Analizar(Cadena.ToUpper());
                //Analizador Sintactico
                if (!ModuloErrores.Error)
                    AnalizadorSintactico.Analizar();
                HoraFinal = DateTime.Now;
                //Tabla Léxica
                string[][] TablaLexica = AnalizadorLexico.TablaLexica;
                dgvLexico.RowCount = TablaLexica.Length;
                for (int i = 0; i < TablaLexica.Length; i++)
                    for (int j = 0; j < TablaLexica[i].Length - 2; j++)
                        dgvLexico[j, i].Value = TablaLexica[i][j];
                //Tabla Identificadores
                string[][] Identificadores = TablaDeSimbolos.Identificadores;
                dgvIdentificadores.RowCount = Identificadores.Length;
                for (int i = 0; i < Identificadores.Length; i++)
                    for (int j = 0; j < Identificadores[i].Length; j++)
                        dgvIdentificadores[j, i].Value = Identificadores[i][j];
                //Tabla Constantes
                string[][] Constantes = TablaDeSimbolos.Constantes;
                dgvConstantes.RowCount = Constantes.Length;
                for (int i = 0; i < Constantes.Length; i++)
                    for (int j = 0; j < Constantes[0].Length; j++)
                        dgvConstantes[j, i].Value = Constantes[i][j];
                //Tabla Arbol Sintactico
                if (AnalizadorSintactico.Arbol?.Count > 0)
                {
                    string[][] Arbol = AnalizadorSintactico.ArbolSintactico;
                    dgvArbol.RowCount = Arbol.Length;
                    for (int i = 0; i < Arbol.Length; i++)
                        for (int j = 0; j < Arbol[i].Length; j++)
                            dgvArbol[j, i].Value = Arbol[i][j];
                }
                //Tabla Tablas
                string[][] Tablas = AnalizadorSemantico.Tablas.ToArray();
                dgvTablaTablas.RowCount = Tablas.Length;
                for (int i = 0; i < Tablas.Length; i++)
                    for (int j = 0; j < Tablas[i].Length; j++)
                        dgvTablaTablas[j, i].Value = Tablas[i][j];
                //Tabla Atributos
                string[][] Atributos = AnalizadorSemantico.Atributos.ToArray();
                dgvAtributos.RowCount = Atributos.Length;
                for (int i = 0; i < Atributos.Length; i++)
                    for (int j = 0; j < Atributos[i].Length; j++)
                        dgvAtributos[j, i].Value = Atributos[i][j];
                //Tabla Restricciones
                string[][] Restricciones = AnalizadorSemantico.Restricciones.ToArray();
                dgvRestricciones.RowCount = Restricciones.Length;
                for (int i = 0; i < Restricciones.Length; i++)
                    for (int j = 0; j < Restricciones[i].Length; j++)
                        dgvRestricciones[j, i].Value = Restricciones[i][j];
                //Mensaje Error
                if (ModuloErrores.Error)
                {
                    setError();
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = ModuloErrores.MensajeError();
                    if (ModuloErrores.TipoError == ModuloErrores.TipoDeError.Sintáctico && ModuloErrores.NoError == 0)
                    {
                        lblMensaje.ForeColor = Color.Green;
                        lblMensaje.Text = ModuloErrores.MensajeError(ModuloErrores.TipoDeError.Sintáctico, 0, 0);
                    }
                }
                else
                {
                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = ModuloErrores.MensajeError(ModuloErrores.TipoDeError.Sintáctico, 0, 0);
                }
                lblTiempo.Text = TiempoTardado;
            }
            else
            {
                lblMensaje.Text = "";
                lblTiempo.Text = "";
            }
        }

        private void SourceCode_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.ForeColor = Color.Black;
            lblMensaje.Text = "Analizando...";
            Retraso.Stop();
            Retraso.Start();
        }

        private void SourceCode_Delete(object sender, ModificationEventArgs e)
        {
            // Only update line numbers if the number of lines changed
            if (e.LinesAdded != 0)
                UpdateLineNumbers(SourceCode.LineFromPosition(e.Position));
        }

        private void UpdateLineNumbers(int startingAtLine)
        {
            // Starting at the specified line index, update each
            // subsequent line margin text with a hex line number.
            for (int i = startingAtLine; i < SourceCode.Lines.Count; i++)
            {
                SourceCode.Lines[i].MarginStyle = Style.LineNumber;
                SourceCode.Lines[i].MarginText = "0x" + i.ToString("X2");
            }
        }

        private void SourceCode_Insert(object sender, ModificationEventArgs e)
        {
            // Only update line numbers if the number of lines changed
            if (e.LinesAdded != 0)
                UpdateLineNumbers(SourceCode.LineFromPosition(e.Position));
        }

        private void InitialiseScintilla()
        {
            //Set the line numbers 
            SourceCode.Margins[0].Width = 50;

            SourceCode.StyleResetDefault();
            SourceCode.Styles[Style.Default].Font = "Consolas";
            SourceCode.Styles[Style.Default].Size = 10;
            SourceCode.StyleClearAll();

            SourceCode.Styles[Style.Sql.Character].ForeColor = Color.Black;

            // surrounded by /* */
            SourceCode.Styles[Style.Sql.Comment].ForeColor = Color.Green;

            // begins with --
            SourceCode.Styles[Style.Sql.CommentLine].ForeColor = Color.Green;

            //scintilla1.Styles[Style.Sql.CommentDoc].ForeColor = Color.Black;
            //scintilla1.Styles[Style.Sql.CommentDocKeyword].ForeColor = Color.Black;
            //scintilla1.Styles[Style.Sql.CommentDocKeywordError].ForeColor = Color.Black;
            //scintilla1.Styles[Style.Sql.CommentLineDoc].ForeColor = Color.Black;

            // Any text?
            SourceCode.Styles[Style.Sql.Identifier].ForeColor = Color.Black;

            // just a number
            SourceCode.Styles[Style.Sql.Number].ForeColor = Color.Orange;

            //+ = <> - etc
            SourceCode.Styles[Style.Sql.Operator].ForeColor = Color.Goldenrod;

            //think it's supposed to be the keywords, but doesn't change them!
            SourceCode.Styles[Style.Sql.Word].ForeColor = Color.Blue;
            SourceCode.Styles[Style.Sql.Word2].ForeColor = Color.DeepPink;

            // in double quotes
            SourceCode.Styles[Style.Sql.Character].ForeColor = Color.Red;

            SourceCode.Styles[Style.BraceLight].BackColor = Color.LightGray;
            SourceCode.Styles[Style.BraceLight].ForeColor = Color.BlueViolet;
            SourceCode.Styles[Style.BraceBad].ForeColor = Color.Red;

            SourceCode.Lexer = Lexer.Sql;

            SourceCode.SetKeywords(0, "select from where create table char numeric constraint key primary foreign references insert into values");
            SourceCode.SetKeywords(1, "in and or not null");
        }

        private void SourceCode_UpdateUI(object sender, UpdateUIEventArgs e)
        {
            int lastCaretPos = 0;

            // Has the caret changed position?
            var caretPos = SourceCode.CurrentPosition;
            if (lastCaretPos != caretPos)
            {
                lastCaretPos = caretPos;
                var bracePos1 = -1;
                var bracePos2 = -1;

                // Is there a brace to the left or right?
                if (caretPos > 0 && IsBrace(SourceCode.GetCharAt(caretPos - 1)))
                    bracePos1 = (caretPos - 1);
                else if (IsBrace(SourceCode.GetCharAt(caretPos)))
                    bracePos1 = caretPos;

                if (bracePos1 >= 0)
                {
                    // Find the matching brace
                    bracePos2 = SourceCode.BraceMatch(bracePos1);
                    if (bracePos2 == Scintilla.InvalidPosition)
                        SourceCode.BraceBadLight(bracePos1);
                    else
                        SourceCode.BraceHighlight(bracePos1, bracePos2);
                }
                else
                {
                    // Turn off brace matching
                    SourceCode.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                }
            }
            SourceCode.Focus();
        }

        private static bool IsBrace(int c)
        {
            switch (c)
            {
                case '(':
                case ')':
                    return true;
            }
            return false;
        }

        private void SourceCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            SourceCode.IndicatorCurrent = 0;
            SourceCode.IndicatorClearRange(0, SourceCode.Text.Length);
            SourceCode.IndicatorCurrent = 1;
            SourceCode.IndicatorClearRange(0, SourceCode.Text.Length);
        }


        #region Columna Movible

        static bool Diseñando { get; set; }
        static bool Entro { get; set; }
        static float XXX { get; set; }
        private void tlpDiseño_MouseMove(object sender, MouseEventArgs e)
        {
            int Pos1 = SourceCode.Location.X + SourceCode.Width;
            int Pos2 = Tablas.Location.X;
            if (Pos1 <= e.X && Pos2 > e.X)
            {
                Entro = true;
                tlpDiseño.Cursor = Cursors.VSplit;
            }
            else
            {
                if (!Diseñando)
                {
                    Entro = false;
                    tlpDiseño.Cursor = Cursors.Default;
                }
            }
            if (Diseñando)
            {
                XXX = (e.X / (float)Width) * 100f;
                tlpDiseño.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, XXX);
                tlpDiseño.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 100 - XXX);
            }
        }

        private void tlpDiseño_MouseClick(object sender, MouseEventArgs e)
        {
            Diseñando = e.Button == MouseButtons.Left;
        }

        private void tlpDiseño_MouseUp(object sender, MouseEventArgs e)
        {
            Diseñando = false;
        }

        private void tlpDiseño_MouseLeave(object sender, EventArgs e)
        {
            tlpDiseño.Cursor = Cursors.Default;
        }

        #endregion

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalizadorSemantico.GuardarTablas();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalizadorSemantico.CargarTablas();
        }

        private void setError()
        {
            SourceCode.IndicatorCurrent = 0;
            SourceCode.Indicators[0].Style = IndicatorStyle.TextFore;
            SourceCode.Indicators[0].ForeColor = Color.Red;
            SourceCode.Indicators[1].Style = IndicatorStyle.FullBox;
            SourceCode.Indicators[1].ForeColor = Color.Red;
            SourceCode.Indicators[1].Alpha = 100;

            string[][] Tabla = AnalizadorLexico.TablaLexica;
            int Indice = ModuloErrores.IndiceTablaLexica;
            switch (ModuloErrores.TipoError)
            {
                case ModuloErrores.TipoDeError.Léxico:
                    if (ModuloErrores.Error)
                    {
                        SourceCode.IndicatorFillRange(ModuloErrores.IndiceTablaLexica, 1);
                        SourceCode.IndicatorCurrent++;
                        SourceCode.IndicatorFillRange(ModuloErrores.IndiceTablaLexica, 1);
                    }
                    break;
                case ModuloErrores.TipoDeError.Semántico:
                    if (ModuloErrores.Error)
                    {
                        int Empieza = Convert.ToInt32(Tabla[Indice][5]);
                        int Longitud = Tabla[Indice][2].Length;
                        if (Tabla[Indice][2] == "CONSTANTE")
                        {
                            if (Tabla[Indice-1][4] == "54")
                                Empieza++;
                            Longitud = ModuloErrores.PalabraError.Length;
                        }
                        SourceCode.IndicatorFillRange(Empieza, Longitud);
                        SourceCode.IndicatorCurrent++;
                        SourceCode.IndicatorFillRange(Empieza, Longitud);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
