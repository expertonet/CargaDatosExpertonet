using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaDatosExpertonet
{
    public class csCnn
    {
        public SqlConnection conexionSQLServer;
        public SqlCommand cmdSQLServer = new SqlCommand();
        public string spNameSQLServer;

        public MySqlConnection conexionMySql;
        public MySqlCommand cmdMySql = new MySqlCommand();
        public string spNameMySql;

        SqlCommand comando;
        string slqInsert = string.Empty;

        static public String _DB_SERVER_SQL_ = String.Empty;
        static public String _DB_SQL_ = String.Empty;
        static public String _USER_SQL_ = String.Empty;
        static public String _PASS_SQL_ = String.Empty;

        //public string Server_SQL { get { return _DB_SERVER_SQL_; } set { _DB_SERVER_SQL_ = value; } }
        //public string DB_SQL { get { return _DB_SQL_; } set { _DB_SQL_ = value; } }
        //public string USER_SQL { get { return _USER_SQL_; } set { _USER_SQL_ = value; } }
        //public string PASS_SQL { get { return _PASS_SQL_; } set { _PASS_SQL_ = value; } }




        static public String _DB_SERVER_MySQL_ = String.Empty;
        static public String _DB_MySQL_ = String.Empty;
        static public String _USER_MySQL_ = String.Empty;
        static public String _PASS_MySQL_ = String.Empty;

        //public string Server_MySQL { get { return _DB_SERVER_MySQL_; } set { _DB_SERVER_MySQL_ = value; } }
        //public string DB_MySQL { get { return _DB_MySQL_; } set { _DB_MySQL_ = value; } }
        //public string USER_MySQL { get { return _USER_MySQL_; } set { _USER_MySQL_ = value; } }
        //public string PASS_MySQL { get { return _PASS_MySQL_; } set { _PASS_MySQL_ = value; } }





        public enum tipo
        {
            Oficina = 1,
            Casa = 2,
            CasaRemoto = 3,
            BNTMexico = 4
        }
        public csCnn()
        {

        }


        public void fnCadenaConexionSQLServer()
        {
            conexionSQLServer = new SqlConnection(@"Data Source=" + _DB_SERVER_SQL_ + ";Initial Catalog=" + _DB_SQL_ + ";User ID=" + _USER_SQL_ + ";Password =" + _PASS_SQL_ + ";Persist Security Info=True");
        }

        public csCnn(tipo inOrigenConexion)
        {
            if((int)inOrigenConexion == (int)tipo.Oficina)
            {
                //conexionSQLServer = new SqlConnection("Data Source=201.103.190.255;Initial Catalog=pnet8prod;User ID=pnet8;Password =pnet8;Persist Security Info=True");
                //conexionMySql = new MySqlConnection("server=localhost;userid=root;password=1234;database=nominamex");

            }
            else if ((int)inOrigenConexion == (int)tipo.Casa)
            {
                conexionSQLServer = new SqlConnection("Data Source=localhost;Initial Catalog=FACTURAS_CFDI_33;User ID=sa;Password =123;Persist Security Info=True");
                //conexionSQLServer = new SqlConnection("Data Source=desktop-bbvbvkq;Initial Catalog=pnet8prod;User ID=sa;Password =desa;Persist Security Info=True");

                //conexionSQLServer = new SqlConnection("Data Source=localhost;Initial Catalog=FACTURAS_CFDI_33;User ID=sa;Password =123;Persist Security Info=True");

                //conexionSQLServer = new SqlConnection(fnCadenaConexionSQLServer());

                //conexionMySql = new MySqlConnection("server=162.241.203.237;userid=experton_expertonet;password=experton_expertonet;database=experton_CFDI33");
                conexionMySql = new MySqlConnection("server=localhost;userid=root;password=nominamex;database=nominame_CFDI33");
            }
            else if ((int)inOrigenConexion == (int)tipo.CasaRemoto)
            {
                ////conexionSQLServer = new SqlConnection("Data Source=expertonet.com;Initial Catalog=nmexprod;User ID=sa;Password =Compartamos0100#;Persist Security Info=True");
                //conexionSQLServer = new SqlConnection("Data Source=localhost;Initial Catalog=nmexprod;User ID=sa;Password =123;Persist Security Info=True");
                //conexionMySql = new MySqlConnection("server=162.241.60.127;userid=tbnmexic_nominamex;password=tbnmexic_nominamex;database=tbnmexic_nominamex");
            }
            else if ((int)inOrigenConexion == (int)tipo.BNTMexico)
            {
                //conexionSQLServer = new SqlConnection("Data Source=DESKTOP-BBVBVKQ\\SQLMETA4;Initial Catalog=pnet8prod;User ID=sa;Password =desa;Persist Security Info=True");
                //conexionMySql = new MySqlConnection("server=162.241.60.127;userid=tbnmexic_nominamex;password=tbnmexic_nominamex;database=tbnmexic_calculo");
            }
            else
            {
                MessageBox.Show("Conexion invalida");
                return;
            }

            fnConectar();
        }

        public void fnConectar()
        {
            fnConectarSQLServer();
            fnConectarMySql();
        }

        public void fnConectarMySql()
        {
            int inReitentos = 1;
            DialogResult dialogResult;
            while (conexionMySql.State == ConnectionState.Closed)
            {
                conexionMySql.Open();
                if (conexionMySql.State == ConnectionState.Open)
                    break;
                if (inReitentos >= 3)
                {
                    dialogResult = MessageBox.Show("Se supero el maximo de 3 reitentos de conexión SQLServer para el método " + spNameMySql + ", cancelar el proceso?", "Conexión", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;
                    else
                        inReitentos = 1;
                }
            }
            
        }
        public void fnConectarSQLServer()
        {
            int inReitentos = 1;
            DialogResult dialogResult;
            while (conexionSQLServer.State == ConnectionState.Closed)
            {
                conexionSQLServer.Open();

                if (conexionSQLServer.State == ConnectionState.Open)
                    break;
                if (inReitentos >= 3)
                {
                    dialogResult = MessageBox.Show("Se supero el maximo de 3 reitentos de conexión SQLServer para el método " + spNameSQLServer + ", cancelar el proceso?", "Conexión", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;
                    else
                        inReitentos = 1;
                }
            }
        }

        public DataTable LlenaTablaSQLServer()
        {
            DataTable dtSQLServer = new DataTable();
            SqlDataAdapter daSQLServer = new SqlDataAdapter();

            fnConectarSQLServer();
            cmdSQLServer.Connection = conexionSQLServer;
            cmdSQLServer.CommandType = CommandType.StoredProcedure;
            cmdSQLServer.CommandText = spNameSQLServer;
            daSQLServer.SelectCommand = cmdSQLServer;
            daSQLServer.Fill(dtSQLServer);
            return dtSQLServer;
        }

        public DataTable LlenaTablaMySql()
        {
            DataTable dtMySql = new DataTable();
            MySqlDataAdapter daMySql = new MySqlDataAdapter();

            fnConectarMySql();
            cmdMySql.Connection = conexionMySql;
            cmdMySql.CommandType = CommandType.StoredProcedure;
            cmdMySql.CommandText = spNameMySql;
            daMySql.SelectCommand = cmdMySql; 
            daMySql.Fill(dtMySql);
            return dtMySql;
        }

        static public tipo fnAmbienteTrabajo()
        {
            tipo TipoAmbiente;

            string NombreComputadora = Environment.MachineName.ToUpper().Trim();
            if (NombreComputadora == "PACO")
                TipoAmbiente = tipo.Casa;
            else if (NombreComputadora == "FSALAS-PC")
                TipoAmbiente = tipo.Oficina;
            else
                TipoAmbiente = tipo.Casa;

            return TipoAmbiente;
        }
        public void BorrarTabla(string strTableName, string UUID)
        {
            slqInsert = "delete from "+strTableName+ " where CAST(UUID AS VARCHAR(1000))='" + UUID+"'";
            comando = new SqlCommand(slqInsert, conexionSQLServer);
            fnConectarSQLServer();
            comando.ExecuteNonQuery();
            comando.Dispose();


        }
    }
}
