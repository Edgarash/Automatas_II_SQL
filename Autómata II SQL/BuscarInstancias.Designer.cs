namespace Autómata_II_SQL
{
    partial class BuscarInstancias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbInstancia = new System.Windows.Forms.ComboBox();
            this.btnBuscarInstancia = new ControlesM.KuroButton();
            this.lblInstancia = new System.Windows.Forms.Label();
            this.cbBaseDatos = new System.Windows.Forms.ComboBox();
            this.btnBuscarBD = new ControlesM.KuroButton();
            this.lblBasedeDatos = new System.Windows.Forms.Label();
            this.btnAceptar = new ControlesM.KuroButton();
            this.lblEsperar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbInstancia
            // 
            this.cbInstancia.FormattingEnabled = true;
            this.cbInstancia.Location = new System.Drawing.Point(23, 40);
            this.cbInstancia.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbInstancia.Name = "cbInstancia";
            this.cbInstancia.Size = new System.Drawing.Size(394, 28);
            this.cbInstancia.TabIndex = 0;
            this.cbInstancia.SelectedIndexChanged += new System.EventHandler(this.cbInstancia_SelectedIndexChanged);
            // 
            // btnBuscarInstancia
            // 
            this.btnBuscarInstancia.BackColor = System.Drawing.Color.White;
            this.btnBuscarInstancia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnBuscarInstancia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBuscarInstancia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInstancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBuscarInstancia.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarInstancia.Location = new System.Drawing.Point(440, 18);
            this.btnBuscarInstancia.Name = "btnBuscarInstancia";
            this.btnBuscarInstancia.Size = new System.Drawing.Size(143, 50);
            this.btnBuscarInstancia.TabIndex = 1;
            this.btnBuscarInstancia.Text = "Buscar Instancia";
            this.btnBuscarInstancia.UseVisualStyleBackColor = false;
            this.btnBuscarInstancia.Click += new System.EventHandler(this.btnBuscarInstancia_Click);
            // 
            // lblInstancia
            // 
            this.lblInstancia.AutoSize = true;
            this.lblInstancia.Location = new System.Drawing.Point(23, 13);
            this.lblInstancia.Name = "lblInstancia";
            this.lblInstancia.Size = new System.Drawing.Size(86, 20);
            this.lblInstancia.TabIndex = 2;
            this.lblInstancia.Text = "Instancias:";
            // 
            // cbBaseDatos
            // 
            this.cbBaseDatos.FormattingEnabled = true;
            this.cbBaseDatos.Location = new System.Drawing.Point(23, 111);
            this.cbBaseDatos.Margin = new System.Windows.Forms.Padding(5);
            this.cbBaseDatos.Name = "cbBaseDatos";
            this.cbBaseDatos.Size = new System.Drawing.Size(394, 28);
            this.cbBaseDatos.TabIndex = 0;
            // 
            // btnBuscarBD
            // 
            this.btnBuscarBD.BackColor = System.Drawing.Color.White;
            this.btnBuscarBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnBuscarBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBuscarBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBuscarBD.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarBD.Location = new System.Drawing.Point(440, 89);
            this.btnBuscarBD.Name = "btnBuscarBD";
            this.btnBuscarBD.Size = new System.Drawing.Size(143, 50);
            this.btnBuscarBD.TabIndex = 1;
            this.btnBuscarBD.Text = "Cargar Bases de Datos";
            this.btnBuscarBD.UseVisualStyleBackColor = false;
            this.btnBuscarBD.Click += new System.EventHandler(this.btnBuscarBD_Click);
            // 
            // lblBasedeDatos
            // 
            this.lblBasedeDatos.AutoSize = true;
            this.lblBasedeDatos.Location = new System.Drawing.Point(23, 84);
            this.lblBasedeDatos.Name = "lblBasedeDatos";
            this.lblBasedeDatos.Size = new System.Drawing.Size(127, 20);
            this.lblBasedeDatos.TabIndex = 2;
            this.lblBasedeDatos.Text = "Bases de Datos:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Location = new System.Drawing.Point(249, 165);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(143, 50);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblEsperar
            // 
            this.lblEsperar.AutoSize = true;
            this.lblEsperar.Location = new System.Drawing.Point(23, 180);
            this.lblEsperar.Name = "lblEsperar";
            this.lblEsperar.Size = new System.Drawing.Size(130, 20);
            this.lblEsperar.TabIndex = 3;
            this.lblEsperar.Text = "Espere por favor.";
            this.lblEsperar.Visible = false;
            // 
            // BuscarInstancias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 236);
            this.Controls.Add(this.lblEsperar);
            this.Controls.Add(this.lblBasedeDatos);
            this.Controls.Add(this.lblInstancia);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnBuscarBD);
            this.Controls.Add(this.btnBuscarInstancia);
            this.Controls.Add(this.cbBaseDatos);
            this.Controls.Add(this.cbInstancia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "BuscarInstancias";
            this.Text = "BuscarInstancias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbInstancia;
        private ControlesM.KuroButton btnBuscarInstancia;
        private System.Windows.Forms.Label lblInstancia;
        private System.Windows.Forms.ComboBox cbBaseDatos;
        private ControlesM.KuroButton btnBuscarBD;
        private System.Windows.Forms.Label lblBasedeDatos;
        private ControlesM.KuroButton btnAceptar;
        private System.Windows.Forms.Label lblEsperar;
    }
}