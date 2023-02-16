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
    public partial class frmTransfer : Form
    {
        public frmTransfer()
        {
            InitializeComponent();
        }

        DataTable dtArgumentos = new DataTable();
        DataTable tableSqlServer = new DataTable();
        DataTable table = new DataTable();
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());
        //csCnn cnn = new csCnn(csCnn.tipo.CasaRemoto);

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            if (cmbTablas.SelectedItem != null)
            {
                fnEstadoControles(false);
                if(((Button)sender).Tag.ToString() == "sqlserver")
                    await fnCargarEmpleadosSQLServer();
                else
                    await fnCargarEmpleadosMySql();
                fnEstadoControles(true);
            }
            else
                MessageBox.Show("Falta seleccionar una tabla!");
        }

        async Task<int> fnCargarEmpleadosSQLServer()
        {
            await Task.Run(() =>
            {
                try
                {
                    string strTabla = string.Empty;
                    cmbTablas.Invoke((MethodInvoker)(() => strTabla = cmbTablas.SelectedItem.ToString().Split('-')[0]));
                    cnn.spNameSQLServer = "spEmpleados";
                    cnn.cmdSQLServer.Parameters.Clear();
                    cnn.cmdSQLServer.Parameters.Add("Header", SqlDbType.NVarChar).Value = Convert.ToInt32(strTabla);

                    //for (int inArgX = 0; inArgX <= dtArgumentos.Rows.Count - 1; inArgX++)
                    //{
                    //    int inFlag1 = -1;
                    //    for (int inArgY = 0; inArgY <= gvArgumentosValoresSqlServer.RowCount - 1; inArgY++)
                    //        if (dtArgumentos.Rows[inArgX].ItemArray[3].ToString().Trim() == gvArgumentosValoresSqlServer.Rows[inArgY].Cells[1].Value.ToString().Trim())
                    //            inFlag1 = inArgY;

                    //    if (inFlag1 >= 0)
                    //        cnn.cmdSQLServer.Parameters.Add(dtArgumentos.Rows[inArgX].ItemArray[3].ToString().Trim(), (SqlDbType)Convert.ToInt32(dtArgumentos.Rows[inArgX].ItemArray[5].ToString().Split('|')[0].Trim())).Value = gvArgumentosValoresSqlServer.Rows[inFlag1].Cells[2].Value.ToString().Trim();
                    //    else
                    //    {
                    //        if(dtArgumentos.Rows[inArgX].ItemArray[8].ToString().Trim().ToUpper() == "NULL")
                    //            cnn.cmdSQLServer.Parameters.Add(dtArgumentos.Rows[inArgX].ItemArray[3].ToString().Trim(), (SqlDbType)Convert.ToInt32(dtArgumentos.Rows[inArgX].ItemArray[5].ToString().Split('|')[0].Trim())).Value = null;
                    //        else
                    //            cnn.cmdSQLServer.Parameters.Add(dtArgumentos.Rows[inArgX].ItemArray[3].ToString().Trim(), (SqlDbType)Convert.ToInt32(dtArgumentos.Rows[inArgX].ItemArray[5].ToString().Split('|')[0].Trim())).Value = dtArgumentos.Rows[inArgX].ItemArray[8].ToString().Trim();

                    //    }
                    //}

                    dataGridView1.Invoke((MethodInvoker)(() => dataGridView1.DataSource = cnn.LlenaTablaSQLServer()));
                    if (dataGridView1.RowCount == 0)
                        MessageBox.Show("No hay registros que cargar para el método " + cnn.spNameSQLServer);
                    else
                        lblNumRegSQLServer.Invoke((MethodInvoker)(() => lblNumRegSQLServer.Text = dataGridView1.Rows.Count.ToString() + " Registros"));
                }
                catch (Exception ex)
                { 
                    MessageBox.Show(ex.Message);
                }

            });
            return 0;
        }
        
        async Task<int> fnCargarEmpleadosMySql()
        {
            await Task.Run(() =>
            {
                try
                {
                    string strTabla = string.Empty;
                    cmbTablas.Invoke((MethodInvoker)(() => strTabla = cmbTablas.SelectedItem.ToString().Split('-')[0]));
                    cnn.spNameMySql = "spEmpleados";
                    cnn.cmdMySql.Parameters.Clear();
                    cnn.cmdMySql.Parameters.Add("Header", MySqlDbType.Int32).Value = Convert.ToInt32(strTabla);

                    for (int inArgX = 0; inArgX <= dtArgumentos.Rows.Count - 1; inArgX++)
                    {
                        int inFlag1 = -1;
                        for (int inArgY = 0; inArgY <= gvArgumentosValores.RowCount - 1; inArgY++)
                            if (dtArgumentos.Rows[inArgX].ItemArray[3].ToString().Trim() == gvArgumentosValores.Rows[inArgY].Cells[1].Value.ToString().Trim())
                                inFlag1 = inArgY;

                        if (inFlag1 >= 0)
                            cnn.cmdMySql.Parameters.Add(dtArgumentos.Rows[inArgX].ItemArray[3].ToString().Trim(), (MySqlDbType)Convert.ToInt32(dtArgumentos.Rows[inArgX].ItemArray[5].ToString().Split('|')[1].Trim())).Value = gvArgumentosValores.Rows[inFlag1].Cells[2].Value.ToString().Trim();
                        else
                            cnn.cmdMySql.Parameters.Add(dtArgumentos.Rows[inArgX].ItemArray[3].ToString().Trim(), (MySqlDbType)Convert.ToInt32(dtArgumentos.Rows[inArgX].ItemArray[5].ToString().Split('|')[1].Trim())).Value = null;
                    }


                    dataGridView2.Invoke((MethodInvoker)(() => dataGridView2.DataSource = cnn.LlenaTablaMySql()));
                    if (dataGridView2.RowCount == 0)
                        MessageBox.Show("No hay registros que cargar para el método " + cnn.spNameMySql);
                    else
                        lblNumRegMySql.Invoke((MethodInvoker)(() => lblNumRegMySql.Text = dataGridView2.Rows.Count.ToString() + " Registros"));
                }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            });
            return 0;

        }

        void fnEstadoControles(Boolean status)
        {
            btnSqlServer.Enabled = status;
            btnCargar.Enabled = status;
            btnTransfer.Enabled = status;
            dataGridView1.Enabled = status;
            dataGridView2.Enabled = status;
        }

        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            fnEstadoControles(false);
            await fnTransferirEmpleados_SQLServer_to_Mysql();
            await fnCargarEmpleadosMySql();
            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Visible = false));
            fnEstadoControles(true);
        }

        async Task<int> fnTransferirEmpleados_SQLServer_to_Mysql()
        {
            await Task.Run(() =>
            {
                DialogResult dialogResult;
                int inCount = 1;
                string strTabla = string.Empty;
                cmbTablas.Invoke((MethodInvoker)(() => strTabla = cmbTablas.SelectedItem.ToString().Split('-')[0]));

                if (dataGridView1.Rows.Count > 0)
                {
                    dialogResult = MessageBox.Show("Transferir " + (dataGridView1.RowCount).ToString() + " registros?", "Transferir", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        progressBar1.Invoke((MethodInvoker)(() => progressBar1.Visible = true));
                        progressBar1.Invoke((MethodInvoker)(() => progressBar1.Minimum = 1));
                        progressBar1.Invoke((MethodInvoker)(() => progressBar1.Maximum = dataGridView1.Rows.Count));

                        cnn.spNameMySql = "spEmpleados";
                        cnn.cmdMySql.CommandText = cnn.spNameMySql;
                        cnn.fnConectar();
                        for (int renglon = 0; renglon <= dataGridView1.RowCount - 1; renglon++)
                        {
                            cnn.cmdMySql.Parameters.Clear();
                            cnn.cmdMySql.Parameters.Add("Header", MySqlDbType.Int32).Value = Convert.ToInt32(strTabla) * (-1);
                            for (int argumento = 0; argumento <= dtArgumentos.Rows.Count - 1; argumento++)
                            { 
                                int flagColumna = -1; //, inFlag2 = -1;
                                for (int columna = 0; columna <= dataGridView1.Rows[renglon].Cells.Count - 1; columna++)
                                    if (dtArgumentos.Rows[argumento].ItemArray[3].ToString().Trim() == dataGridView1.Rows[renglon].Cells[columna].OwningColumn.Name.ToString().Trim())
                                    {
                                        flagColumna = columna;
                                        break;
                                    }
                                if (flagColumna >= 0)
                                {
                                    if (dataGridView1.Rows[renglon].Cells[flagColumna].Value == System.DBNull.Value)
                                        cnn.cmdMySql.Parameters.Add(dtArgumentos.Rows[argumento].ItemArray[3].ToString().Trim(), (MySqlDbType)Convert.ToInt32(dtArgumentos.Rows[argumento].ItemArray[5].ToString().Split('|')[1].Trim())).Value = null;
                                    else
                                        cnn.cmdMySql.Parameters.Add(dtArgumentos.Rows[argumento].ItemArray[3].ToString().Trim(), (MySqlDbType)Convert.ToInt32(dtArgumentos.Rows[argumento].ItemArray[5].ToString().Split('|')[1].Trim())).Value = dataGridView1.Rows[renglon].Cells[flagColumna].Value.ToString().Trim();
                                }
                                else
                                    cnn.cmdMySql.Parameters.Add(dtArgumentos.Rows[argumento].ItemArray[3].ToString().Trim(), (MySqlDbType)Convert.ToInt32(dtArgumentos.Rows[argumento].ItemArray[5].ToString().Split('|')[1].Trim())).Value = null;
                            }
                            cnn.cmdMySql.ExecuteNonQuery();
                            lblNumRegMySql.Invoke((MethodInvoker)(() => lblNumRegMySql.Text = inCount.ToString()+" Registros insertados"));
                            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = inCount));
                            inCount++;
                        }
                    }
                }
                else
                    MessageBox.Show("No existen registros para transferir");
            });
            return 0;
        }

        void fnCargarFiltrosSQLServer(string strHeader)
        {
            try
            {
                cnn.spNameSQLServer = "spFiltroInicial";
                cnn.cmdSQLServer.Parameters.Clear();
                cnn.cmdSQLServer.Parameters.Add("@inHeader", SqlDbType.NVarChar).Value = strHeader;

                cmbFiltroValores.Items.Clear();
                foreach (DataRow item in cnn.LlenaTablaSQLServer().Rows)
                    cmbFiltroValores.Items.Add(item[0].ToString() + "-" + item[1].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRow row;
            DataRow rowSqlServer;
            string strValor = string.Empty;

            if (rbTexto.Checked == true)
                strValor = txtValor.Text.Trim();
            else if (rbFecha.Checked == true)
                strValor = dpValor.Value.ToString("yyyy-MM-dd HH:MM:ss");

            string strTag = string.Empty;
            if (sender.GetType().Name.ToUpper() == "TEXTBOX")
                strTag = ((TextBox)sender).Tag.ToString();
            else if(sender.GetType().Name.ToUpper() == "BUTTON")
                strTag = ((Button)sender).Tag.ToString();

            if (strTag == "sqlserver")
            {
                rowSqlServer = tableSqlServer.NewRow();
                rowSqlServer["nparametro"] = dtArgumentos.Rows[cmbArgumento.SelectedIndex].ItemArray[4].ToString();
                rowSqlServer["parametro"] = dtArgumentos.Rows[cmbArgumento.SelectedIndex].ItemArray[3].ToString();
                rowSqlServer["valor"] = strValor;
                tableSqlServer.Rows.Add(rowSqlServer);

                gvArgumentosValoresSqlServer.DataSource = tableSqlServer;
            }
            else
            {
                row = table.NewRow();
                row["nparametro"] = dtArgumentos.Rows[cmbArgumento.SelectedIndex].ItemArray[4].ToString();
                row["parametro"] = cmbArgumento.SelectedItem.ToString().Trim();
                row["valor"] = strValor;
                table.Rows.Add(row);

                gvArgumentosValores.DataSource = table;
            }

            txtValor.Text = string.Empty;
        }

        private void cmbArgumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnCargarFiltrosSQLServer((cmbArgumento.SelectedIndex+1).ToString());
            cmbFiltroValores.SelectedItem = null;
            cmbFiltroValores.Text = "";
        }

        private void cmbFiltroValores_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValor.Text = cmbFiltroValores.SelectedItem.ToString().Split('-')[0];
        }

        void fnCargarTablasSQLServer()
        {
            try
            {
                cnn.spNameMySql = "spnomFiltroInicial";
                cnn.cmdMySql.Parameters.Clear();
                cnn.cmdMySql.Parameters.Add("Header", MySqlDbType.VarChar).Value = "1";

                cmbTablas.Items.Clear();
                foreach (DataRow item in cnn.LlenaTablaMySql().Rows)
                    cmbTablas.Items.Add(item[0].ToString() + "-" + item[1].ToString());

                cnn.cmdMySql.Parameters.Clear();
                cnn.cmdMySql.Parameters.Add("Header", MySqlDbType.VarChar).Value = "2";
                dtArgumentos = cnn.LlenaTablaMySql();

                for (int x=0; x<= dtArgumentos.Rows.Count-1; x++)
                    cmbArgumento.Items.Insert(x, dtArgumentos.Rows[x].ItemArray[4].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            DataColumn columnSQLServer;
            DataColumn column;

            fnCargarTablasSQLServer();

            columnSQLServer = new DataColumn();
            columnSQLServer.DataType = System.Type.GetType("System.String");
            columnSQLServer.ColumnName = "nparametro";
            tableSqlServer.Columns.Add(columnSQLServer);

            columnSQLServer = new DataColumn();
            columnSQLServer.DataType = System.Type.GetType("System.String");
            columnSQLServer.ColumnName = "parametro";
            tableSqlServer.Columns.Add(columnSQLServer);

            columnSQLServer = new DataColumn();
            columnSQLServer.DataType = Type.GetType("System.String");
            columnSQLServer.ColumnName = "valor";
            tableSqlServer.Columns.Add(columnSQLServer);
            gvArgumentosValoresSqlServer.DataSource = tableSqlServer;


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "nparametro";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "parametro";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "valor";
            table.Columns.Add(column);
            gvArgumentosValores.DataSource = table;
        }

        private void fnCambiaTextoFecha(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Tag.ToString() == "texto")
            {
                txtValor.Visible = true;
                dpValor.Visible = false;
            }
            else
            {
                txtValor.Visible = false;
                dpValor.Visible = true;
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Left)
                {
                    ((TextBox)sender).Tag = "sqlserver";
                    btnAgregar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    ((TextBox)sender).Tag = "mysql";
                    btnAgregar_Click(sender, e);
                }
            }
        }

    }
}