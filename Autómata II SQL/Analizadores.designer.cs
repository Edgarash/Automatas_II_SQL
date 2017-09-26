namespace Autómata_II_SQL
{
    partial class Analizadores
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analizadores));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblFuente = new System.Windows.Forms.Label();
            this.SourceCode = new ScintillaNET.Scintilla();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.Tablas = new System.Windows.Forms.TabControl();
            this.Lexico = new System.Windows.Forms.TabPage();
            this.dgvLexico = new System.Windows.Forms.DataGridView();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificadores = new System.Windows.Forms.TabPage();
            this.dgvIdentificadores = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lineas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Constantes = new System.Windows.Forms.TabPage();
            this.dgvConstantes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sintactico = new System.Windows.Forms.TabPage();
            this.dgvArbol = new System.Windows.Forms.DataGridView();
            this.Pila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaLexica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.Tablas.SuspendLayout();
            this.Lexico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLexico)).BeginInit();
            this.Identificadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).BeginInit();
            this.Constantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantes)).BeginInit();
            this.Sintactico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbol)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Tablas);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 528);
            this.splitContainer1.SplitterDistance = 607;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblMensaje);
            this.splitContainer2.Size = new System.Drawing.Size(607, 528);
            this.splitContainer2.SplitterDistance = 496;
            this.splitContainer2.TabIndex = 9;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblFuente);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.SourceCode);
            this.splitContainer3.Size = new System.Drawing.Size(607, 496);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.TabIndex = 0;
            // 
            // lblFuente
            // 
            this.lblFuente.AutoSize = true;
            this.lblFuente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFuente.ForeColor = System.Drawing.Color.Black;
            this.lblFuente.Location = new System.Drawing.Point(0, 0);
            this.lblFuente.Name = "lblFuente";
            this.lblFuente.Size = new System.Drawing.Size(112, 23);
            this.lblFuente.TabIndex = 100;
            this.lblFuente.Text = "Código Fuente";
            // 
            // SourceCode
            // 
            this.SourceCode.AnnotationVisible = ScintillaNET.Annotation.Standard;
            this.SourceCode.CaretLineBackColor = System.Drawing.Color.Silver;
            this.SourceCode.CaretLineBackColorAlpha = 75;
            this.SourceCode.CaretLineVisible = true;
            this.SourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceCode.Lexer = ScintillaNET.Lexer.Sql;
            this.SourceCode.Location = new System.Drawing.Point(0, 0);
            this.SourceCode.Margins.Left = 5;
            this.SourceCode.Margins.Right = 0;
            this.SourceCode.Name = "SourceCode";
            this.SourceCode.Size = new System.Drawing.Size(607, 467);
            this.SourceCode.TabIndex = 0;
            this.SourceCode.Zoom = 4;
            this.SourceCode.Delete += new System.EventHandler<ScintillaNET.ModificationEventArgs>(this.SourceCode_Delete);
            this.SourceCode.Insert += new System.EventHandler<ScintillaNET.ModificationEventArgs>(this.SourceCode_Insert);
            this.SourceCode.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.SourceCode_UpdateUI);
            this.SourceCode.TextChanged += new System.EventHandler(this.SourceCode_TextChanged);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensaje.Location = new System.Drawing.Point(0, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 23);
            this.lblMensaje.TabIndex = 100;
            // 
            // Tablas
            // 
            this.Tablas.Controls.Add(this.Lexico);
            this.Tablas.Controls.Add(this.Identificadores);
            this.Tablas.Controls.Add(this.Constantes);
            this.Tablas.Controls.Add(this.Sintactico);
            this.Tablas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tablas.Location = new System.Drawing.Point(0, 0);
            this.Tablas.Name = "Tablas";
            this.Tablas.SelectedIndex = 0;
            this.Tablas.Size = new System.Drawing.Size(397, 528);
            this.Tablas.TabIndex = 1;
            // 
            // Lexico
            // 
            this.Lexico.Controls.Add(this.dgvLexico);
            this.Lexico.Location = new System.Drawing.Point(4, 32);
            this.Lexico.Name = "Lexico";
            this.Lexico.Padding = new System.Windows.Forms.Padding(3);
            this.Lexico.Size = new System.Drawing.Size(389, 492);
            this.Lexico.TabIndex = 0;
            this.Lexico.Text = "Léxico";
            this.Lexico.UseVisualStyleBackColor = true;
            // 
            // dgvLexico
            // 
            this.dgvLexico.AllowUserToAddRows = false;
            this.dgvLexico.AllowUserToDeleteRows = false;
            this.dgvLexico.AllowUserToResizeRows = false;
            this.dgvLexico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLexico.BackgroundColor = System.Drawing.Color.White;
            this.dgvLexico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLexico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.N,
            this.Linea,
            this.Token,
            this.Tipo,
            this.Codigo});
            this.dgvLexico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLexico.GridColor = System.Drawing.Color.Black;
            this.dgvLexico.Location = new System.Drawing.Point(3, 3);
            this.dgvLexico.Name = "dgvLexico";
            this.dgvLexico.ReadOnly = true;
            this.dgvLexico.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvLexico.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLexico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLexico.Size = new System.Drawing.Size(383, 486);
            this.dgvLexico.TabIndex = 100;
            this.dgvLexico.TabStop = false;
            // 
            // N
            // 
            this.N.FillWeight = 1F;
            this.N.HeaderText = "N°";
            this.N.Name = "N";
            this.N.ReadOnly = true;
            // 
            // Linea
            // 
            this.Linea.FillWeight = 1F;
            this.Linea.HeaderText = "Línea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            // 
            // Token
            // 
            this.Token.FillWeight = 3F;
            this.Token.HeaderText = "Token";
            this.Token.Name = "Token";
            this.Token.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.FillWeight = 1F;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Codigo
            // 
            this.Codigo.FillWeight = 1F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Identificadores
            // 
            this.Identificadores.Controls.Add(this.dgvIdentificadores);
            this.Identificadores.ForeColor = System.Drawing.Color.White;
            this.Identificadores.Location = new System.Drawing.Point(4, 22);
            this.Identificadores.Name = "Identificadores";
            this.Identificadores.Padding = new System.Windows.Forms.Padding(3);
            this.Identificadores.Size = new System.Drawing.Size(389, 502);
            this.Identificadores.TabIndex = 1;
            this.Identificadores.Text = "Identificadores";
            this.Identificadores.UseVisualStyleBackColor = true;
            // 
            // dgvIdentificadores
            // 
            this.dgvIdentificadores.AllowUserToAddRows = false;
            this.dgvIdentificadores.AllowUserToDeleteRows = false;
            this.dgvIdentificadores.AllowUserToResizeRows = false;
            this.dgvIdentificadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIdentificadores.BackgroundColor = System.Drawing.Color.White;
            this.dgvIdentificadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdentificadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.CodigoID,
            this.Lineas});
            this.dgvIdentificadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIdentificadores.GridColor = System.Drawing.Color.Black;
            this.dgvIdentificadores.Location = new System.Drawing.Point(3, 3);
            this.dgvIdentificadores.Name = "dgvIdentificadores";
            this.dgvIdentificadores.ReadOnly = true;
            this.dgvIdentificadores.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvIdentificadores.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIdentificadores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvIdentificadores.Size = new System.Drawing.Size(383, 496);
            this.dgvIdentificadores.TabIndex = 100;
            this.dgvIdentificadores.TabStop = false;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 93.68331F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CodigoID
            // 
            this.CodigoID.FillWeight = 76.14214F;
            this.CodigoID.HeaderText = "Codigo";
            this.CodigoID.Name = "CodigoID";
            this.CodigoID.ReadOnly = true;
            // 
            // Lineas
            // 
            this.Lineas.FillWeight = 130.1745F;
            this.Lineas.HeaderText = "Líneas";
            this.Lineas.Name = "Lineas";
            this.Lineas.ReadOnly = true;
            // 
            // Constantes
            // 
            this.Constantes.Controls.Add(this.dgvConstantes);
            this.Constantes.Location = new System.Drawing.Point(4, 22);
            this.Constantes.Name = "Constantes";
            this.Constantes.Padding = new System.Windows.Forms.Padding(3);
            this.Constantes.Size = new System.Drawing.Size(389, 502);
            this.Constantes.TabIndex = 3;
            this.Constantes.Text = "Constantes";
            this.Constantes.UseVisualStyleBackColor = true;
            // 
            // dgvConstantes
            // 
            this.dgvConstantes.AllowUserToAddRows = false;
            this.dgvConstantes.AllowUserToDeleteRows = false;
            this.dgvConstantes.AllowUserToResizeRows = false;
            this.dgvConstantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConstantes.BackgroundColor = System.Drawing.Color.White;
            this.dgvConstantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvConstantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConstantes.GridColor = System.Drawing.Color.Black;
            this.dgvConstantes.Location = new System.Drawing.Point(3, 3);
            this.dgvConstantes.Name = "dgvConstantes";
            this.dgvConstantes.ReadOnly = true;
            this.dgvConstantes.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvConstantes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConstantes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvConstantes.Size = new System.Drawing.Size(383, 496);
            this.dgvConstantes.TabIndex = 100;
            this.dgvConstantes.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 52.48005F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 190.3553F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 57.16461F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Líneas";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Sintactico
            // 
            this.Sintactico.Controls.Add(this.dgvArbol);
            this.Sintactico.Location = new System.Drawing.Point(4, 22);
            this.Sintactico.Name = "Sintactico";
            this.Sintactico.Padding = new System.Windows.Forms.Padding(3);
            this.Sintactico.Size = new System.Drawing.Size(389, 502);
            this.Sintactico.TabIndex = 2;
            this.Sintactico.Text = "Sintáctico";
            this.Sintactico.UseVisualStyleBackColor = true;
            // 
            // dgvArbol
            // 
            this.dgvArbol.AllowUserToAddRows = false;
            this.dgvArbol.AllowUserToDeleteRows = false;
            this.dgvArbol.AllowUserToResizeRows = false;
            this.dgvArbol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArbol.BackgroundColor = System.Drawing.Color.White;
            this.dgvArbol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArbol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pila,
            this.TablaLexica,
            this.X,
            this.K});
            this.dgvArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArbol.GridColor = System.Drawing.Color.Black;
            this.dgvArbol.Location = new System.Drawing.Point(3, 3);
            this.dgvArbol.Name = "dgvArbol";
            this.dgvArbol.ReadOnly = true;
            this.dgvArbol.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvArbol.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvArbol.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvArbol.Size = new System.Drawing.Size(383, 496);
            this.dgvArbol.TabIndex = 100;
            this.dgvArbol.TabStop = false;
            // 
            // Pila
            // 
            this.Pila.FillWeight = 58.64819F;
            this.Pila.HeaderText = "Pila";
            this.Pila.Name = "Pila";
            this.Pila.ReadOnly = true;
            // 
            // TablaLexica
            // 
            this.TablaLexica.FillWeight = 235.1987F;
            this.TablaLexica.HeaderText = "Tabla Léxica";
            this.TablaLexica.Name = "TablaLexica";
            this.TablaLexica.ReadOnly = true;
            // 
            // X
            // 
            this.X.FillWeight = 50.76142F;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            // 
            // K
            // 
            this.K.FillWeight = 55.39167F;
            this.K.HeaderText = "K";
            this.K.Name = "K";
            this.K.ReadOnly = true;
            // 
            // Analizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1008, 528);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Analizadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analizadores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.Tablas.ResumeLayout(false);
            this.Lexico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLexico)).EndInit();
            this.Identificadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).EndInit();
            this.Constantes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantes)).EndInit();
            this.Sintactico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ScintillaNET.Scintilla SourceCode;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.TabControl Tablas;
        private System.Windows.Forms.TabPage Lexico;
        private System.Windows.Forms.DataGridView dgvLexico;
        private System.Windows.Forms.TabPage Identificadores;
        private System.Windows.Forms.DataGridView dgvIdentificadores;
        private System.Windows.Forms.TabPage Sintactico;
        private System.Windows.Forms.DataGridView dgvArbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pila;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaLexica;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn K;
        private System.Windows.Forms.Label lblFuente;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabPage Constantes;
        private System.Windows.Forms.DataGridView dgvConstantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lineas;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}

