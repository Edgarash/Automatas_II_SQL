using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Autómata_II_SQL
{
    public partial class BuscarInstancias : Form
    {
        public BuscarInstancias()
        {
            InitializeComponent();
        }

        private void btnBuscarInstancia_Click(object sender, EventArgs e)
        {
            cbInstancia.Items.Clear();
            btnAceptar.Visible = btnBuscarBD.Visible = btnBuscarInstancia.Visible = false;
            lblEsperar.Visible = true;
            lblEsperar.Refresh();
            cbInstancia.Items.AddRange(InstanciasLocales() ?? new string[] { });
            cbInstancia.SelectedIndex = -1;
            if (cbInstancia.Items.Count > 0)
            {
                cbInstancia.SelectedIndex = 0;
                btnBuscarBD.PerformClick();
            }
            btnAceptar.Visible = btnBuscarBD.Visible = btnBuscarInstancia.Visible = true;
            lblEsperar.Visible = false;
        }

        public static string[] InstanciasLocales()
        {
            SqlDataSourceEnumerator Instance = SqlDataSourceEnumerator.Instance;
            DataTable DataTable = Instance.GetDataSources();
            string[] Ins = new string[DataTable.Rows.Count];
            for (int i = 0; i < Ins.Length; i++)
                if (DataTable.Rows[i]["ServerName"] != null)
                    Ins[i] = DataTable.Rows[i]["ServerName"].ToString() + @"\" + DataTable.Rows[i]["InstanceName"].ToString();
            return Ins;
        }

        private void btnBuscarBD_Click(object sender, EventArgs e)
        {
            cbBaseDatos.Items.Clear();
            btnAceptar.Visible = btnBuscarBD.Visible = btnBuscarInstancia.Visible = false;
            lblEsperar.Visible = true;
            lblEsperar.Refresh();
            cbBaseDatos.Items.AddRange(VerBasesDeDatos(cbInstancia.Text) ?? new string[] { });
            cbBaseDatos.SelectedIndex = -1;
            if (cbBaseDatos.Items.Count > 0)
                cbBaseDatos.SelectedIndex = 0;
            btnAceptar.Visible = btnBuscarBD.Visible = btnBuscarInstancia.Visible = true;
            lblEsperar.Visible = false;
        }

        public static string[] VerBasesDeDatos(string Nombre_Instancia)
        {
            //Comando
            string Ver = "Select name FROM sys.databases Where name Not In ('master','model','msdb','tempdb')",
                    Connect = "Integrated Security=SSPI;Persist Security Info=False;" +
                    "Initial Catalog=master;server=" + Nombre_Instancia + ";";
            //Arreglo Que Contendrá Las Bases De Datos En La Instancia
            string[] Databases = { "" };
            //Objeto De Conexión
            SqlConnection Connection = new SqlConnection(Connect);
            try
            {
                //Adaptador De Datos De SQL
                SqlDataAdapter Resultado = new SqlDataAdapter(Ver, Connection);
                //Tabla Que Obtendrá Los Resultados De La Búsqueda
                DataTable Tabla = new DataTable();
                Tabla.Locale = System.Globalization.CultureInfo.InvariantCulture;
                //Se Llenan Los Resultados En La Tabla
                Resultado.Fill(Tabla);
                //Se Inicia El Arreglo Con El Número De Bases Encontradas
                Databases = new string[Tabla.Rows.Count];
                for (int i = 0; i < Databases.Length; i++)
                    //Tabla Contiene Los Datos
                    //Rows Son Las Diferentes Bases De Datos Encontradas
                    //ItemArray Contiene Información Varia De La Base De Datos
                    //En El Índice 0 Se Encuentra El Nombre De La Base De Datos
                    if (Tabla.Rows[i]["name"].ToString() != null)
                        Databases[i] = Tabla.Rows[i]["name"].ToString();
                return Databases;
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }
            finally
            {
                // Por Si Se Produce Un Error,
                // Comprobar Si La Conexión Está Abierta
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }

        private void cbInstancia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInstancia.SelectedIndex > -1)
                btnBuscarBD.PerformClick();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ConexionBaseDeDatos.CadenaConexion = "Integrated Security=SSPI;Persist Security Info=False;" +
                    "Initial Catalog=" + cbBaseDatos.SelectedItem.ToString() + ";server=" + cbInstancia.SelectedItem.ToString() + ";";
            Hide();
        }
    }
}
