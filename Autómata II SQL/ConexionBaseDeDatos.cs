using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using static Autómata_II_SQL.AnalizadorSemantico;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Autómata_II_SQL
{
    public static class ConexionBaseDeDatos
    {
        static SqlConnection Conexion { get; set; }
        public static string CadenaConexion { get; set; }

        public static void IniciarConexion()
        {
            Conexion = new SqlConnection(CadenaConexion);
        }

        public static void LlenarTablas()
        {
            IniciarConexion();
            Conexion.Close();
            Conexion.Open();

            SqlCommand Comando = new SqlCommand("Select TABLE_NAME as Tabla from INFORMATION_SCHEMA.TABLES;", Conexion);
            SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
            DataTable TablaTemp = new DataTable();
            Adaptador.Fill(TablaTemp);

            Tablas = new List<string[]>();
            Atributos = new List<string[]>();
            Restricciones = new List<string[]>();
            for (int i = 0; i < TablaTemp.Rows.Count; i++)
            {
                DataRow x = TablaTemp.Rows[i];
                Tablas.Add(new string[] 
                {
                    (i + 1).ToString(),
                    x["Tabla"].ToString().ToUpper(),
                    "",
                    "0"
                });
                //Llenar atributos
                SqlCommand Com = new SqlCommand(
                    @"Select 
                    ORDINAL_POSITION as Num,
                    COLUMN_NAME as Columna,
                    IS_NULLABLE as 'Null',
                    DATA_TYPE as Tipo,
                    CHARACTER_MAXIMUM_LENGTH as CharLen,
                    NUMERIC_PRECISION as NumLen
                    from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + Tablas[i][1] +"';", Conexion);
                SqlDataAdapter Adaptadorcito = new SqlDataAdapter(Com);
                DataTable Tablita = new DataTable();
                Adaptadorcito.Fill(Tablita);
                for (int j = 0; j < Tablita.Rows.Count; j++)
                {
                    DataRow y = Tablita.Rows[j];
                    string Type = y["Tipo"].ToString().ToUpper();
                    bool Char = Type == "CHAR";
                    Atributos.Add(new string[]
                    {
                        Tablas[i][0],
                        (Atributos.Count+1).ToString(),
                        y["Columna"].ToString().ToUpper(),
                        Type,
                        Char ? y["CharLen"].ToString() : y["NumLen"].ToString(),
                        y["Null"].ToString().ToUpper() == "YES" ? "0" : "1"
                    });
                }
                Tablas[i][2] = Tablita.Rows.Count.ToString();
                //
                Com = new SqlCommand("exec sp_pkeys '" + Tablas[i][1] + "';", Conexion);
                Tablita = new DataTable();
                Adaptadorcito = new SqlDataAdapter(Com);
                Adaptadorcito.Fill(Tablita);
                for (int j = 0; j < Tablita.Rows.Count; j++)
                {
                    DataRow y = Tablita.Rows[j];
                    string Atrib = null;
                    string NombreCampo = y["COLUMN_NAME"].ToString().ToUpper();
                    for (int k = 0; k < Atributos.Count && Atrib == null; k++)
                        if (Atributos[k][0] == Tablas[i][0])
                            if (Atributos[k][2] == NombreCampo)
                                Atrib = Atributos[k][1];
                    Restricciones.Add(new string[]
                    {
                        Tablas[i][0],
                        (Restricciones.Count+1).ToString(),
                        "PK",
                        y["PK_NAME"].ToString().ToUpper(),
                        Atrib,
                        "-",
                        "-"
                    });
                }
                Tablas[i][3] = (Convert.ToInt32(Tablas[i][3])+Tablita.Rows.Count).ToString();
                //
                Com = new SqlCommand("exec sp_fkeys @fktable_name = '" + Tablas[i][1] + "';", Conexion);
                Adaptadorcito = new SqlDataAdapter(Com);
                Tablita = new DataTable();
                Adaptadorcito.Fill(Tablita);
                for (int j = 0; j < Tablita.Rows.Count; j++)
                {
                    DataRow y = Tablita.Rows[j];
                    string
                        Tabla = y["PKTABLE_NAME"].ToString().ToUpper(),
                        Columna = y["PKCOLUMN_NAME"].ToString().ToUpper(),
                        Foranea = y["FKCOLUMN_NAME"].ToString().ToUpper(),
                        numTabla = null,
                        numColumna = null,
                        numForanea = null;
                    for (int k = 0; k < Tablas.Count && numTabla == null; k++)
                        if (Tablas[k][1] == Tabla)
                            numTabla = Tablas[k][0];
                    for (int k = 0; k < Atributos.Count && (numColumna == null || numForanea == null); k++)
                    {
                        if (Atributos[k][0] == numTabla)
                        {
                            if (Atributos[k][2] == Columna)
                            {
                                numColumna = Atributos[k][1];
                            }
                        }
                        else
                        {
                            if (Atributos[k][0] == Tablas[i][0])
                            {
                                numForanea = Atributos[k][1];
                            }
                        }
                    }
                    Restricciones.Add(new string[]
                    {
                        Tablas[i][0],
                        (Restricciones.Count+1).ToString(),
                        "FK",
                        y["FK_NAME"].ToString().ToUpper(),
                        numForanea,
                        numTabla,
                        numColumna
                    });
                }
                Tablas[i][3] = (Convert.ToInt32(Tablas[i][3]) + Tablita.Rows.Count).ToString();
            }

            Conexion.Close();
        }
    }
}
