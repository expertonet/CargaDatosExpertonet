using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CargaDatosExpertonet
{
    public partial class frmFacturas : Form
    {
        //csCnn._DB_SERVER_SQL_="";
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());

        SqlCommand cmdReader;
        SqlDataReader reader;
        string slqInsert;

        SqlCommand comando;

        public frmFacturas()
        {
            InitializeComponent();
        }

        private void frmFacturas_Load(object sender, EventArgs e)
        {
            slqInsert = "SELECT [Banco_Id] ,[Banco] FROM [BANCOS] ORDER BY [Banco_Id]";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            cmbBancos.Items.Clear();
            while (reader.Read())
                cmbBancos.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[1].ToString());
            cmdReader.Dispose();
            reader.Close();


            HabilitarControles(false);
            ActualizaGrid();
        }

        public void GuardaFactura()
        {
            slqInsert = @"
            INSERT INTO [dbo].[FACTURAS]
                       ([Operacion]
                       ,[Fecha]
                       ,[Monto]
                       ,[Emisor]
                       ,[Receptor]
                       ,[Concepto]
                       ,[Pendientes]
                       ,[Referencia]
                       ,[Cuenta]
                       ,[Banco_Id])
            VALUES
                ( " + txtOperacion.Text + @"
                ,'" + txtFecha.Text + @"'
                ," + txtMonto.Text + @"
                ,'" + txtEmisor.Text + @"'
                ,'" + txtReceptor.Text + @"'
                ,'" + txtConcepto.Text + @"'
                ,'" + txtPendientes.Text + @"'
                ,'" + txtReferencia.Text + @"'
                ,'" + txtCuenta.Text + @"'
                ," + (cmbBancos.SelectedIndex+1) + @")

            ";
            slqInsert = slqInsert.Replace("'null'", "null");
            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            comando.ExecuteNonQuery();
            comando.Dispose();


        }

        public void HabilitarControles(bool valor)
        {
            //txtOperacion.Enabled = valor;
            txtFecha.Enabled = valor;
            dtFehca.Enabled = valor;
            txtMonto.Enabled = valor;
            txtEmisor.Enabled = valor;
            txtReceptor.Enabled = valor;
            txtConcepto.Enabled = valor;
            txtPendientes.Enabled = valor;
            txtReferencia.Enabled = valor;
            //txtBanco.Enabled = valor;
            cmbBancos.Enabled = valor;
            txtCuenta.Enabled = valor;

        }

        public void LimpiaControles()
        {
            txtOperacion.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtMonto.Text = string.Empty;
            txtEmisor.Text = string.Empty;
            txtReceptor.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            txtPendientes.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            //txtBanco.Text = string.Empty;
            cmbBancos.SelectedIndex = -1;
            txtCuenta.Text = string.Empty;
        }

        public void ActualizaGrid()
        {
            try
            {
                slqInsert = @"
                    SELECT [Operacion]
                          ,[Fecha]
                          ,[Monto]
                          ,[Emisor]
                          ,[Receptor]
                          ,[Concepto]
                          ,[Pendientes]
                          ,[Referencia]
                          ,[Cuenta]
                          ,[BANCOS].[Banco]
                      FROM [dbo].[FACTURAS]
	                    INNER JOIN [BANCOS]
		                    ON FACTURAS.Banco_Id = [BANCOS].Banco_Id
                     ";

                cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                cnn.fnConectarSQLServer();
                reader = cmdReader.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    //var name = reader1.GetString(0);
                    dataGridView1.Rows.Add(new object[] {
                        0,
                reader.GetValue(0),
                reader.GetValue(1),
                reader.GetValue(2),
                reader.GetValue(3),
                reader.GetValue(4),
                reader.GetValue(5),
                reader.GetValue(6),
                reader.GetValue(7),
                reader.GetValue(8),
                reader.GetValue(9),
                });

                }
                cmdReader.Dispose();
                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            GuardaFactura();
            LimpiaControles();
            HabilitarControles(false);
            ActualizaGrid();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            slqInsert = "select isnull(max(Operacion)+1,1) from FACTURAS";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            if (reader.Read())
                txtOperacion.Text = reader[0].ToString();
            cmdReader.Dispose();
            reader.Close();

            HabilitarControles(true);
        }

        private void dtFehca_ValueChanged(object sender, EventArgs e)
        {
            txtFecha.Text = dtFehca.Text;
        }
    }
}
