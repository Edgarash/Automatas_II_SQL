using ControlesM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autómata_II_SQL
{
    public partial class Resultados : KuroForm
    {
        object[] Resultado { get; set; }
        public Resultados(object[] Resultados)
        {
            InitializeComponent();
            this.Resultado = Resultados;
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            for (int i = 0; i < Resultado.Length; i++)
            {
                TabPage temp = new TabPage("Resultado #" + (i+1).ToString());
                if (Resultado[i].GetType() == typeof(int))
                {
                    Label Muestra = new Label();
                    Muestra.AutoSize = true;
                    Muestra.Location = new Point(10, 10);
                    Muestra.BackColor = Color.Black;
                    if ((int)Resultado[i] == -1)
                        Muestra.Text = "La tabla fue creada correctamente.";
                    else
                        Muestra.Text = (int)Resultado[i] + " filas afectadas";
                    temp.Controls.Add(Muestra);
                }
                else
                {
                    if (Resultado[i].GetType() == typeof(DataTable))
                    {
                        KuroDGV Selec = new KuroDGV();
                        Selec.ColumnHeadersHeight = 30;
                        Selec.DataSource = (DataTable)Resultado[i];
                        Selec.Dock = DockStyle.Fill;
                        temp.Controls.Add(Selec);
                    }
                }
                tabControl1.Controls.Add(temp);
            }
        }
    }
}
