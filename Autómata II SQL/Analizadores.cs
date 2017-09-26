using System;
using System.Drawing;
using ScintillaNET;
using System.Windows.Forms;

namespace Autómata_II_SQL
{
    public partial class Analizadores : Form
    {
        public Analizadores()
        {
            InitializeComponent();
            InitialiseScintilla();
        }

        private void Analizar(string Cadena)
        {
            //Limpiando Parámetros
            dgvLexico.Rows.Clear();
            dgvIdentificadores.Rows.Clear();
            dgvArbol.Rows.Clear();

            //Verificando Cadena Vacía
            if (!string.IsNullOrWhiteSpace(Cadena))
            {
                //Análisis Léxico
                bool Error = AnalizadorLexico.Analizar(Cadena.ToUpper());
                //Tabla Léxica
                string[][] TablaLexica = AnalizadorLexico.TablaLexica;
                dgvLexico.RowCount = TablaLexica.Length;
                for (int i = 0; i < TablaLexica.Length; i++)
                    for (int j = 0; j < TablaLexica[i].Length; j++)
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
                ////Analizador
                //if (!Error)
                //{
                //    AnalizadorSintactico.Analizar();
                //    //Tabla Arbol Sintactico
                //    string[][] Arbol = AnalizadorSintactico.ArbolSintactico;
                //    dgvArbol.RowCount = Arbol.Length;
                //    for (int i = 0; i < Arbol.Length; i++)
                //        for (int j = 0; j < Arbol[i].Length; j++)
                //            dgvArbol[j, i].Value = Arbol[i][j];
                //}
                //Mensaje Error
                if (Error)
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = ModuloErrores.MensajeErrorLéxico(ModuloErrores.Error.Léxico, AnalizadorLexico.NoLinea);
                }
                else
                {
                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = ModuloErrores.MensajeError(ModuloErrores.Error.Sintáctico, 0, 0, ' ');
                    //if (!AnalizadorSintactico.Error)
                    //{
                    //    lblMensaje.ForeColor = Color.Green;
                    //    lblMensaje.Text = ModuloErrores.MensajeError(ModuloErrores.Error.Sintáctico, 0, 0, ' ');
                    //}
                    //else
                    //{
                    //    lblMensaje.ForeColor = Color.Red;
                    //    int Apuntador = AnalizadorSintactico.Apuntador - 1;
                    //    int Lin = Convert.ToInt32(AnalizadorLexico.TablaLexica[Apuntador][1]);
                    //    char Token = AnalizadorLexico.TablaLexica[Apuntador][2][0];
                    //    lblMensaje.Text = ModuloErrores.MensajeError(ModuloErrores.Error.Sintáctico, AnalizadorSintactico.NumError, Lin, Token);
                    //}
                }
            }
            else
                lblMensaje.Text = "";
        }

        private void SourceCode_TextChanged(object sender, EventArgs e)
        {
            SourceCode.ChangeLexerState(0, SourceCode.Text.Length - 1);
            Analizar(SourceCode.Text);
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

            SourceCode.SetKeywords(0, "ADD ALTER AS ASC AUTHORIZATION BACKUP BEGIN BREAK BROWSE BULK BY CASCADE CASE CHECK CHECKPOINT CLOSE CLUSTERED COLUMN COMMIT COMPUTE CONSTRAINT CONTAINSTABLE CONTINUE CREATE CURRENT CURRENT_DATE CURSOR DATABASE DBCC DEALLOCATE DECLARE DEFAULT DELETE DENY DESC DISK DISTINCT DISTRIBUTED DOUBLE DROP DUMP ELSE END ERRLVL ESCAPE EXCEPT EXEC EXECUTE EXIT EXTERNAL FETCH FILE FILLFACTOR FOR FOREIGN FREETEXT FREETEXTTABLE FROM FULL FUNCTION GOTO GRANT GROUP HAVING HOLDLOCK IDENTITY IDENTITY_INSERT IDENTITYCOL IF INDEX INSERT INTERSECT INTO KEY KILL LINENO LOAD MERGE NATIONAL NOCHECK NONCLUSTERED OF OFF OFFSETS ON OPEN OPENDATASOURCE OPENQUERY OPENROWSET OPENXML OPTION ORDER OVER PERCENT PLAN PRECISION PRIMARY PRINT PROC PROCEDURE PUBLIC RAISERROR READ READTEXT RECONFIGURE REFERENCES REPLICATION RESTORE RESTRICT RETURN REVERT REVOKE ROLLBACK ROWCOUNT ROWGUIDCOL RULE SAVE SCHEMA SECURITYAUDIT SELECT SEMANTICKEYPHRASETABLE SEMANTICSIMILARITYDETAILSTABLE SEMANTICSIMILARITYTABLE SET SETUSER SHUTDOWN STATISTICS TABLE TABLESAMPLE TEXTSIZE THEN TO TOP TRAN TRANSACTION TRIGGER TRUNCATE UNION UNIQUE UPDATETEXT USE USER VALUES VARYING VIEW WAITFOR WHEN WHERE WHILE WITH WITHIN GROUP WRITETEXT".ToLower());
            SourceCode.SetKeywords(1, "ALL AND ANY BETWEEN CROSS EXISTS IN INNER IS JOIN LEFT LIKE NOT NULL OR OUTER PIVOT RIGHT SOME UNPIVOT".ToLower());
        }

        int lastCaretPos = 0;
        private void SourceCode_UpdateUI(object sender, UpdateUIEventArgs e)
        {
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

    
    }
}
