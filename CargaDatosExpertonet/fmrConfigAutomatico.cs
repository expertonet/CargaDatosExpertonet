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
    public partial class fmrConfigAutomatico : Form
    {
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());
        SqlCommand cmdReader;
        SqlDataReader reader;
        string slqInsert;
        string sRFCEmisor;
        static string srfcSolicitante;
        int VprogDiario = 0;

        public fmrConfigAutomatico()
        {
            InitializeComponent();
        }

        private void cmbEempresas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void fmrConfigAutomatico_Load(object sender, EventArgs e)
        {
            slqInsert = "SELECT Id,RFC FROM PersonaFisicaMoral order by Id";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            cmbEempresas.Items.Clear();
            while (reader.Read())
                cmbEempresas.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[1].ToString());
            cmdReader.Dispose();
            reader.Close();

            slqInsert = "select TipoSolicitud_Id, TipoSolicitud from TipoSolicitud order by TipoSolicitud_Id";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            cmbTipoSolicitud.Items.Clear();
            while (reader.Read())
                cmbTipoSolicitud.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[1].ToString());
            cmdReader.Dispose();
            reader.Close();



            slqInsert = "select TipoEmision_Id, TipoEmision from TipoEmision order by TipoEmision_Id";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            cmbTipoEmision2.Items.Clear();
            while (reader.Read())
                cmbTipoEmision2.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[1].ToString());
            cmdReader.Dispose();
            reader.Close();


            ActualizaGrid();
        }


        public void ActualizaGrid()
        {
            try
            {
                slqInsert = @"
select 
	id, 
    id_solicitud,
	rfc, 
	a.rfc_emisor,
	a.rfc_receptor,
	b.TipoSolicitud, 
	c.TipoEmision, 
	fecha_inicial, 
	fecha_final, 
	fecha_programacion, 
	hora_programacion, 
	d.TipoAutomatico, 
	e.estado,
	f.EstadoEjecucion
from automatico a
	inner join TipoSolicitud b
		on a.tipo_solicitud = b.TipoSolicitud_Id
	inner join TipoEmision c
		on a.tipo_emision = c.TipoEmision_Id
	inner join tipo_automatico d
		on a.TipoAutomatico_id = d.TipoAutomatico_id
	inner join estado_automatico e
		on a.estado_id = e.estado_id
	inner join estado_ejecucion f
		on a.EstadoEjecucion_id = f.EstadoEjecucion_id

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
                reader.GetValue(10),
                reader.GetValue(11),
                reader.GetValue(12),
                reader.GetValue(13),
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





        private void configurarAutomáticoToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void dtFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            txtFechaInicial.Text = dtFechaInicial.Text;
        }

        private void dtFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            txtFechaFinal.Text = dtFechaFinal.Text;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string RfcEmisor;
            string RfcReceptor;

            if (cmbTipoEmision2.SelectedIndex == 0)
            {
                RfcReceptor = "";
                RfcEmisor = cmbEempresas.Text;
            }
            else
            {
                RfcReceptor = cmbEempresas.Text;
                RfcEmisor = "";
            }




            slqInsert = @"
INSERT INTO [dbo].[AUTOMATICO]
           ([rfc]
           ,[rfc_emisor]
           ,[rfc_receptor]
           ,[tipo_solicitud]
           ,[tipo_emision]
           ,[fecha_inicial]
           ,[fecha_final]
           ,[fecha_programacion]
           ,[hora_programacion]
           ,[TipoAutomatico_id]
           ,[estado_id]
           ,[EstadoEjecucion_id])
                            VALUES
                                ('" + cmbEempresas.Text + @"'
                                ,'" + RfcEmisor + @"'
                                ,'" + RfcReceptor + @"'
                                ," + (cmbTipoSolicitud.SelectedIndex+1).ToString() + @"
                                ," + (cmbTipoEmision2.SelectedIndex+1).ToString() + @"
                                ,'" + txtFechaInicial.Text + @"'
                                ,'" + txtFechaFinal.Text + @"'
                                ,'" + txtFechaProgramacion.Text + @"'
                                ,'" + txtHoraProgramacion.Text.Replace(" p.m.", "").Replace(" a.m.", "") + @"'
                                ," + VprogDiario + @"
                                ," + Convert.ToInt32(chkEstado.Checked).ToString() + @"
                                ," + "0" + @")
                                ";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            cmdReader.ExecuteNonQuery();
            cmdReader.Dispose();
            reader.Close();

            ActualizaGrid();
        }

        private void dtFechaProgramacion_ValueChanged(object sender, EventArgs e)
        {
            txtFechaProgramacion.Text = dtFechaProgramacion.Text;
        }

        private void dtHoraProgramacion_ValueChanged(object sender, EventArgs e)
        {
            txtHoraProgramacion.Text = txtHoraProgramacion.Text;
        }

        private void radFechaHora_CheckedChanged(object sender, EventArgs e)
        {
            funProgAutomatico(true);
        }

        private void radDiario_CheckedChanged(object sender, EventArgs e)
        {
            funProgAutomatico(false);
        }

        void funProgAutomatico(bool vValor)
        {
            label1.Visible = vValor;
            txtFechaInicial.Visible = vValor;
            dtFechaInicial.Visible = vValor;

            label4.Visible = vValor;
            txtFechaProgramacion.Visible = vValor;
            dtFechaProgramacion.Visible = vValor;



            label2.Visible = vValor;
            txtFechaFinal.Visible = vValor;
            dtFechaFinal.Visible = vValor;

            VprogDiario = Convert.ToInt32(!vValor);

            if (vValor==false)
            {
                txtFechaInicial.Text = "1800-01-01";
                txtFechaFinal.Text = "4000-01-01";
                txtFechaProgramacion.Text = "4000-01-01";
            }
            else
            {
                txtFechaInicial.Text =string.Empty;
                txtFechaFinal.Text = string.Empty;
                txtFechaProgramacion.Text = string.Empty;

            }


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizaGrid();
        }
    }
}
