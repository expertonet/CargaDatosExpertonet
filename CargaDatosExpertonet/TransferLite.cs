using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaDatosExpertonet
{
    public partial class frmCopiaArchivos : Form
    {
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());


        public frmCopiaArchivos()
        {
            InitializeComponent();
        }

        async Task<int> fnCopyLocalHosting()
        {
            await Task.Run(() =>
            {
                SqlDataAdapter adapter;
            string slqInsert;
            string sCampos = string.Empty;
            string sCamposValor = string.Empty;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            MySqlCommand cmdReader;

            int numCampos = 0;
            string[] tipoCampo;



            slqInsert = "SELECT ID, NOMBRE_TABLA FROM ORDEN_TABLAS_CARGAR ORDER BY ORDEN_TABLA";
            adapter = new SqlDataAdapter(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            adapter.Fill(ds1);
            adapter.Dispose();

            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                slqInsert = @"select 
	                            a.name nombreTabla,
	                            b.column_id,
	                            b.name nombreCampo,
	                            c.name nombreTipo,
	                            b.max_length,
	                            b.precision
                            from sys.tables a
                                inner join sys.all_columns b
                                    on a.object_id = b.object_id
                                inner join sys.types c
                                    on b.system_type_id = c.system_type_id
                            where UPPER(TRIM(a.name)) = '" + row["NOMBRE_TABLA"] + @"'
                            order by b.column_id";

                adapter = new SqlDataAdapter(slqInsert, cnn.conexionSQLServer);
                cnn.fnConectarSQLServer();
                ds2.Reset();
                adapter.Fill(ds2);
                adapter.Dispose();

                numCampos = 0;
                tipoCampo = new string[ds2.Tables[0].Rows.Count];
                sCampos = string.Empty;

                foreach (DataRow row2 in ds2.Tables[0].Rows)
                {
                    sCampos += row2["nombreCampo"] + ",";
                    tipoCampo[numCampos] = row2["nombreTipo"].ToString().ToUpper();
                    numCampos++;
                }
                ds2.Reset();
                sCampos = sCampos.Substring(0, sCampos.Length - 1);


                slqInsert = "select " + sCampos + " from " + row["NOMBRE_TABLA"];
                adapter = new SqlDataAdapter(slqInsert, cnn.conexionSQLServer);
                cnn.fnConectarSQLServer();
                adapter.Fill(ds2);
                adapter.Dispose();

                    lblNombreTabla.Invoke((MethodInvoker)(() => lblNombreTabla.Text = slqInsert + " Registros insertados"));
                    int Contador = 0;
                foreach (DataRow row2 in ds2.Tables[0].Rows)
                {
                    sCamposValor = string.Empty;
                    for (int x = 0; x <= numCampos - 1; x++)
                    {
                        if (row2[x] == System.DBNull.Value)
                        {
                            sCamposValor += "null,";
                        }
                        else if (tipoCampo[x] == "INT" || tipoCampo[x] == "REAL" || tipoCampo[x] == "SMALLINT" || tipoCampo[x] == "BIGINT")
                        {
                            sCamposValor += row2[x] + ",";
                        }
                        else if (tipoCampo[x] == "VARCHAR" )
                        {
                            sCamposValor += "'" + row2[x] + "',";
                        }
                        else if (tipoCampo[x] == "DATETIME" )
                        {
                            sCamposValor += "'" + ((DateTime)row2[x]).ToString("yyyy/MM/dd HH:mm:ss.000") + "',";
                        }
                        else
                        {
                        sCamposValor += "'" + row2[x] + "',";

                        }
                    }
                    sCamposValor = sCamposValor.Substring(0, sCamposValor.Length - 1);

                    

                    slqInsert = "insert into " + row["NOMBRE_TABLA"] + " (" + sCampos + ")values(" + sCamposValor + ")";
                    cmdReader = new MySqlCommand(slqInsert, cnn.conexionMySql);
                    cnn.fnConectarMySql();
                    cmdReader.ExecuteNonQuery();
                    cmdReader.Dispose();
                        Contador++;
                        lblNumRegistros.Invoke((MethodInvoker)(() => lblNumRegistros.Text = Contador.ToString() + " Registros insertados"));
                    }

                }
            });
            return 0;
        }


        private async void btnTransferir_Click(object sender, EventArgs e)
        {
            await fnCopyLocalHosting();
            MessageBox.Show("Proceso terminado!");

        }
    }
}
