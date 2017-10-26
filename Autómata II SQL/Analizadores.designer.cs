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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analizadores));
            this.lblFuente = new System.Windows.Forms.Label();
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
            this.dgvTablas = new System.Windows.Forms.TabPage();
            this.dgvTablaTablas = new System.Windows.Forms.DataGridView();
            this.NoTabla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreTabla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAtributos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRestricciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpDiseño = new System.Windows.Forms.TableLayoutPanel();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.SourceCode = new ScintillaNET.Scintilla();
            this.Tablas.SuspendLayout();
            this.Lexico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLexico)).BeginInit();
            this.Identificadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).BeginInit();
            this.Constantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantes)).BeginInit();
            this.Sintactico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbol)).BeginInit();
            this.dgvTablas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaTablas)).BeginInit();
            this.tlpDiseño.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuente
            // 
            this.lblFuente.AutoSize = true;
            this.lblFuente.ForeColor = System.Drawing.Color.Black;
            this.lblFuente.Location = new System.Drawing.Point(3, 0);
            this.lblFuente.Name = "lblFuente";
            this.lblFuente.Size = new System.Drawing.Size(112, 23);
            this.lblFuente.TabIndex = 100;
            this.lblFuente.Text = "Código Fuente";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.ForeColor = System.Drawing.Color.Black;
            this.lblMensaje.Location = new System.Drawing.Point(3, 299);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(63, 23);
            this.lblMensaje.TabIndex = 100;
            this.lblMensaje.Text = "Holiwis";
            // 
            // Tablas
            // 
            this.Tablas.Controls.Add(this.Lexico);
            this.Tablas.Controls.Add(this.Identificadores);
            this.Tablas.Controls.Add(this.Constantes);
            this.Tablas.Controls.Add(this.Sintactico);
            this.Tablas.Controls.Add(this.dgvTablas);
            this.Tablas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tablas.Location = new System.Drawing.Point(450, 3);
            this.Tablas.Name = "Tablas";
            this.tlpDiseño.SetRowSpan(this.Tablas, 2);
            this.Tablas.SelectedIndex = 0;
            this.Tablas.Size = new System.Drawing.Size(441, 293);
            this.Tablas.TabIndex = 1;
            // 
            // Lexico
            // 
            this.Lexico.Controls.Add(this.dgvLexico);
            this.Lexico.Location = new System.Drawing.Point(4, 32);
            this.Lexico.Name = "Lexico";
            this.Lexico.Padding = new System.Windows.Forms.Padding(3);
            this.Lexico.Size = new System.Drawing.Size(433, 257);
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
            this.dgvLexico.Size = new System.Drawing.Size(427, 251);
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
            this.Identificadores.Location = new System.Drawing.Point(4, 32);
            this.Identificadores.Name = "Identificadores";
            this.Identificadores.Padding = new System.Windows.Forms.Padding(3);
            this.Identificadores.Size = new System.Drawing.Size(433, 257);
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
            this.dgvIdentificadores.Size = new System.Drawing.Size(427, 251);
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
            this.Constantes.Location = new System.Drawing.Point(4, 32);
            this.Constantes.Name = "Constantes";
            this.Constantes.Padding = new System.Windows.Forms.Padding(3);
            this.Constantes.Size = new System.Drawing.Size(433, 257);
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
            this.dgvConstantes.Size = new System.Drawing.Size(427, 251);
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
            this.Sintactico.Location = new System.Drawing.Point(4, 32);
            this.Sintactico.Name = "Sintactico";
            this.Sintactico.Padding = new System.Windows.Forms.Padding(3);
            this.Sintactico.Size = new System.Drawing.Size(433, 257);
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
            this.dgvArbol.Size = new System.Drawing.Size(427, 251);
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
            // dgvTablas
            // 
            this.dgvTablas.Controls.Add(this.dgvTablaTablas);
            this.dgvTablas.Location = new System.Drawing.Point(4, 32);
            this.dgvTablas.Name = "dgvTablas";
            this.dgvTablas.Padding = new System.Windows.Forms.Padding(3);
            this.dgvTablas.Size = new System.Drawing.Size(433, 257);
            this.dgvTablas.TabIndex = 4;
            this.dgvTablas.Text = "Tablas";
            this.dgvTablas.UseVisualStyleBackColor = true;
            // 
            // dgvTablaTablas
            // 
            this.dgvTablaTablas.AllowUserToAddRows = false;
            this.dgvTablaTablas.AllowUserToDeleteRows = false;
            this.dgvTablaTablas.AllowUserToResizeRows = false;
            this.dgvTablaTablas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTablaTablas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTablaTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaTablas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoTabla,
            this.NombreTabla,
            this.NoAtributos,
            this.NoRestricciones});
            this.dgvTablaTablas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTablaTablas.GridColor = System.Drawing.Color.Black;
            this.dgvTablaTablas.Location = new System.Drawing.Point(3, 3);
            this.dgvTablaTablas.Name = "dgvTablaTablas";
            this.dgvTablaTablas.ReadOnly = true;
            this.dgvTablaTablas.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvTablaTablas.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTablaTablas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTablaTablas.Size = new System.Drawing.Size(427, 251);
            this.dgvTablaTablas.TabIndex = 101;
            this.dgvTablaTablas.TabStop = false;
            // 
            // NoTabla
            // 
            this.NoTabla.HeaderText = "#Tabla";
            this.NoTabla.Name = "NoTabla";
            this.NoTabla.ReadOnly = true;
            // 
            // NombreTabla
            // 
            this.NombreTabla.FillWeight = 300F;
            this.NombreTabla.HeaderText = "Nombre";
            this.NombreTabla.Name = "NombreTabla";
            this.NombreTabla.ReadOnly = true;
            // 
            // NoAtributos
            // 
            this.NoAtributos.HeaderText = "#Atributos";
            this.NoAtributos.Name = "NoAtributos";
            this.NoAtributos.ReadOnly = true;
            // 
            // NoRestricciones
            // 
            this.NoRestricciones.HeaderText = "#Restricciones";
            this.NoRestricciones.Name = "NoRestricciones";
            this.NoRestricciones.ReadOnly = true;
            // 
            // tlpDiseño
            // 
            this.tlpDiseño.ColumnCount = 2;
            this.tlpDiseño.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiseño.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiseño.Controls.Add(this.Tablas, 1, 0);
            this.tlpDiseño.Controls.Add(this.lblFuente, 0, 0);
            this.tlpDiseño.Controls.Add(this.lblTiempo, 1, 2);
            this.tlpDiseño.Controls.Add(this.SourceCode, 0, 1);
            this.tlpDiseño.Controls.Add(this.lblMensaje, 0, 2);
            this.tlpDiseño.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiseño.Location = new System.Drawing.Point(0, 0);
            this.tlpDiseño.Name = "tlpDiseño";
            this.tlpDiseño.RowCount = 3;
            this.tlpDiseño.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDiseño.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDiseño.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDiseño.Size = new System.Drawing.Size(894, 329);
            this.tlpDiseño.TabIndex = 2;
            this.tlpDiseño.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tlpDiseño_MouseClick);
            this.tlpDiseño.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlpDiseño_MouseClick);
            this.tlpDiseño.MouseLeave += new System.EventHandler(this.tlpDiseño_MouseLeave);
            this.tlpDiseño.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tlpDiseño_MouseMove);
            this.tlpDiseño.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tlpDiseño_MouseUp);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.ForeColor = System.Drawing.Color.Black;
            this.lblTiempo.Location = new System.Drawing.Point(450, 299);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(163, 23);
            this.lblTiempo.TabIndex = 101;
            this.lblTiempo.Text = "Tiempo de Ejecución:";
            // 
            // SourceCode
            // 
            this.SourceCode.AnnotationVisible = ScintillaNET.Annotation.Standard;
            this.SourceCode.CaretLineBackColor = System.Drawing.Color.Silver;
            this.SourceCode.CaretLineBackColorAlpha = 75;
            this.SourceCode.CaretLineVisible = true;
            this.SourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceCode.Lexer = ScintillaNET.Lexer.Sql;
            this.SourceCode.Location = new System.Drawing.Point(3, 33);
            this.SourceCode.Margins.Left = 5;
            this.SourceCode.Margins.Right = 0;
            this.SourceCode.Name = "SourceCode";
            this.SourceCode.Size = new System.Drawing.Size(441, 263);
            this.SourceCode.TabIndex = 0;
            this.SourceCode.Zoom = 4;
            this.SourceCode.Delete += new System.EventHandler<ScintillaNET.ModificationEventArgs>(this.SourceCode_Delete);
            this.SourceCode.Insert += new System.EventHandler<ScintillaNET.ModificationEventArgs>(this.SourceCode_Insert);
            this.SourceCode.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.SourceCode_UpdateUI);
            this.SourceCode.TextChanged += new System.EventHandler(this.SourceCode_TextChanged);
            this.SourceCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SourceCode_KeyPress);
            // 
            // Analizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(894, 329);
            this.Controls.Add(this.tlpDiseño);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Analizadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analizadores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Tablas.ResumeLayout(false);
            this.Lexico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLexico)).EndInit();
            this.Identificadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).EndInit();
            this.Constantes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantes)).EndInit();
            this.Sintactico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArbol)).EndInit();
            this.dgvTablas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaTablas)).EndInit();
            this.tlpDiseño.ResumeLayout(false);
            this.tlpDiseño.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.TabPage dgvTablas;
        private System.Windows.Forms.DataGridView dgvTablaTablas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAtributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRestricciones;
        private System.Windows.Forms.TableLayoutPanel tlpDiseño;
        private System.Windows.Forms.Label lblTiempo;
        private ScintillaNET.Scintilla SourceCode;
    }
}

