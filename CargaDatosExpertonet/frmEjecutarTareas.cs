using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaDatosExpertonet
{
    public partial class frmEjecutarTareas : Form
    {
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());

        string slqInsert;
        SqlDataReader reader;

        SqlCommand cmdReader;

        SqlDataAdapter adapter;

        DataSet ds1 = new DataSet();

        byte[] pfx;
        string password;
        string RfcEmisor;
        string RfcReceptor;
        string srfcSolicitante;
        string FechaInicial;
        string FechaFinal;

        string TipoSolicitud_Id;
        string TipoSolicitud;
        string TipoEmision_Id;
        string TipoEmision;
        string idSolicitud;
        string id;
        string EstadoSolicitud;

        public frmEjecutarTareas()
        {
            InitializeComponent();
        }

        private void frmEjecutarTareas_Load(object sender, EventArgs e)
        {
            btnEjecutar.BackColor = Color.OrangeRed;
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (chkEjecucion.Checked == false)
            {
                if(MessageBox.Show("Se iniciará las tareas","Ejecutar Tareas",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    chkEjecucion.Checked = true;
                    btnEjecutar.Text = "Ejecutando";
                    btnEjecutar.BackColor = Color.GreenYellow;
                    txtLog.Text = "Iniciando";
                    fnEcribeLog("Iniciando");
                    tEnviaSolicitud.Enabled = true;
                }
            }
            else
            {
                if (MessageBox.Show("Se detendrán las tareas", "Ejecutar Tareas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chkEjecucion.Checked = false;
                    btnEjecutar.Text = "Detenido";
                    btnEjecutar.BackColor = Color.OrangeRed;
                    txtLog.Text += "Detenido";
                    fnEcribeLog("Detenido");
                    tEnviaSolicitud.Enabled = false;
                }
            }
        }

        private void timerTareas_Tick(object sender, EventArgs e)
        {
            if (chkEjecucion.Checked)
            {
                tEnviaSolicitud.Enabled = false;
                slqInsert = @"
                                select 
	                                a.id, 
	                                a.rfc,
	                                b.Certificado,
	                                b.Clave,
	                                b.RazonSocial,
	                                c.TipoSolicitud_Id, 
									c.TipoSolicitud,
	                                d.TipoEmision_Id, 
									d.TipoEmision,
	                                a.fecha_inicial, 
	                                a.fecha_final, 
	                                a.fecha_programacion, 
	                                a.hora_programacion, 
	                                a.TipoAutomatico_id, 
	                                a.estado_id, 
	                                a.EstadoEjecucion_id
                                from automatico a
	                                inner join PersonaFisicaMoral b
		                                on a.rfc = b.RFC
									inner join TipoSolicitud c
										on a.tipo_solicitud = c.TipoSolicitud_Id
									inner join TipoEmision d
										on a.tipo_emision = d.TipoEmision_Id
                                where EstadoEjecucion_id = 0
                                order by a.id
                              ";
                //cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);

                adapter = new SqlDataAdapter(slqInsert, cnn.conexionSQLServer);

                cnn.fnConectarSQLServer();
                adapter.Fill(ds1);

                //cnn.fnConectarSQLServer();
                //reader = cmdReader.ExecuteReader();
                //cmdReader = null;

                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    pfx = File.ReadAllBytes(row["Certificado"].ToString());
                    password = row["Clave"].ToString();
                    RfcEmisor = row["rfc"].ToString();
                    RfcReceptor = "";
                    srfcSolicitante = row["rfc"].ToString();

                    if (row["TipoAutomatico_id"].ToString() == "1")
                    {
                        FechaInicial = DateTime.Today.AddDays(-30).AddDays(-8).ToString("yyyy-MM-dd");
                        FechaFinal = DateTime.Today.AddDays(-30).AddDays(-1).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        FechaInicial = row["fecha_inicial"].ToString();
                        FechaFinal = row["fecha_final"].ToString();
                    }

                    TipoSolicitud_Id = row["TipoSolicitud_Id"].ToString();
                    TipoSolicitud = row["TipoSolicitud"].ToString();
                    TipoEmision_Id = row["TipoEmision_Id"].ToString();
                    TipoEmision = row["TipoEmision"].ToString();
                    id = row["id"].ToString();

                    idSolicitud = csGlobal.fnEnviaSolicitud(pfx, password, RfcEmisor, RfcReceptor, srfcSolicitante, FechaInicial, FechaFinal, TipoSolicitud_Id, TipoSolicitud, TipoEmision_Id, TipoEmision);

                    slqInsert = "update AUTOMATICO set id_solicitud = '" + idSolicitud + "' where id = " + id;
                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                    cnn.fnConectarSQLServer();
                    cmdReader.ExecuteNonQuery();
                    cmdReader.Dispose();

                    slqInsert = "update AUTOMATICO set EstadoEjecucion_id = 1 where id = " + id;
                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                    cnn.fnConectarSQLServer();
                    cmdReader.ExecuteNonQuery();
                    cmdReader.Dispose();

                }

                tAactualizaEstado.Enabled = true;



                //while (reader.Read())
                //{
                //    pfx = File.ReadAllBytes(reader["Certificado"].ToString());
                //    password = reader["Clave"].ToString();
                //    RfcEmisor = reader["rfc"].ToString();
                //    RfcReceptor = "";
                //    srfcSolicitante = reader["rfc"].ToString();

                //    if (reader["TipoAutomatico_id"].ToString() == "1")
                //    {
                //        FechaInicial = DateTime.Today.AddDays(-30).AddDays(-8).ToString("yyyy-MM-dd");
                //        FechaFinal = DateTime.Today.AddDays(-30).AddDays(-1).ToString("yyyy-MM-dd");
                //    }
                //    else
                //    {
                //        FechaInicial = reader["fecha_inicial"].ToString();
                //        FechaFinal = reader["fecha_final"].ToString();
                //    }

                //    TipoSolicitud_Id = reader["TipoSolicitud_Id"].ToString();
                //    TipoSolicitud = reader["TipoSolicitud"].ToString();
                //    TipoEmision_Id = reader["TipoEmision_Id"].ToString();
                //    TipoEmision = reader["TipoEmision"].ToString();
                //    id = reader["id"].ToString();



                //    //lblDescripcionEmpresas.Text = reader["rfc"].ToString() + " - " + reader["RazonSocial"].ToString();
                //    //if (reader["Certificado"].ToString() != "")
                //    //    pfx = File.ReadAllBytes(reader["Certificado"].ToString());
                //    //password = reader["Clave"].ToString();
                //    //srfcSolicitante = reader["RFC"].ToString();
                //    //sRFCEmisor = reader["RFC"].ToString();


                //    idSolicitud = csGlobal.fnEnviaSolicitud(pfx, password, RfcEmisor, RfcReceptor, srfcSolicitante, FechaInicial, FechaFinal, TipoSolicitud_Id, TipoSolicitud, TipoEmision_Id, TipoEmision);
                //}
                //cmdReader.Dispose();
                //reader.Close();

                //slqInsert = "update AUTOMATICO set id_solicitud = '" + idSolicitud + "' where id = " + id;
                //cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                //cnn.fnConectarSQLServer();
                //cmdReader.ExecuteNonQuery();
                //cmdReader.Dispose();


            }
        }




        private void tAactualizaEstado_Tick(object sender, EventArgs e)
        {
            if (chkEjecucion.Checked)
            {
                slqInsert = @"
                                select 
	                                a.id, 
                                    a.id_solicitud,
	                                a.rfc,
	                                b.Certificado,
	                                b.Clave,
	                                b.RazonSocial,
	                                c.TipoSolicitud_Id, 
									c.TipoSolicitud,
	                                d.TipoEmision_Id, 
									d.TipoEmision,
	                                a.fecha_inicial, 
	                                a.fecha_final, 
	                                a.fecha_programacion, 
	                                a.hora_programacion, 
	                                a.TipoAutomatico_id, 
	                                a.estado_id, 
	                                a.EstadoEjecucion_id
                                from automatico a
	                                inner join PersonaFisicaMoral b
		                                on a.rfc = b.RFC
									inner join TipoSolicitud c
										on a.tipo_solicitud = c.TipoSolicitud_Id
									inner join TipoEmision d
										on a.tipo_emision = d.TipoEmision_Id
                                where EstadoEjecucion_id = 1
                                order by a.id
                              ";
                adapter = new SqlDataAdapter(slqInsert, cnn.conexionSQLServer);
                cnn.fnConectarSQLServer();
                adapter.Fill(ds1);

                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    pfx = File.ReadAllBytes(row["Certificado"].ToString());
                    password = row["Clave"].ToString();
                    RfcEmisor = row["rfc"].ToString();
                    RfcReceptor = "";
                    srfcSolicitante = row["rfc"].ToString();
                    idSolicitud = row["id_solicitud"].ToString();

                    if (row["TipoAutomatico_id"].ToString() == "1")
                    {
                        FechaInicial = DateTime.Today.AddDays(-30).AddDays(-8).ToString("yyyy-MM-dd");
                        FechaFinal = DateTime.Today.AddDays(-30).AddDays(-1).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        FechaInicial = row["fecha_inicial"].ToString();
                        FechaFinal = row["fecha_final"].ToString();
                    }

                    TipoSolicitud_Id = row["TipoSolicitud_Id"].ToString();
                    TipoSolicitud = row["TipoSolicitud"].ToString();
                    TipoEmision_Id = row["TipoEmision_Id"].ToString();
                    TipoEmision = row["TipoEmision"].ToString();
                    id = row["id"].ToString();

                    EstadoSolicitud = csGlobal.FnActualizaSolicitud(pfx, password, RfcEmisor, RfcReceptor, srfcSolicitante, FechaInicial, FechaFinal, TipoSolicitud_Id, TipoSolicitud, TipoEmision_Id, TipoEmision, idSolicitud);

                    slqInsert = "update Solicitud set EstadoSolicitud_Id = '" + EstadoSolicitud + "' where Solicitud_Id = " + idSolicitud;
                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                    cnn.fnConectarSQLServer();
                    cmdReader.ExecuteNonQuery();
                    cmdReader.Dispose();

                    slqInsert = "update AUTOMATICO set EstadoEjecucion_id = 2 where id = " + id;
                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                    cnn.fnConectarSQLServer();
                    cmdReader.ExecuteNonQuery();
                    cmdReader.Dispose();


                }
            }
        }

        private void tDescargaXML_Tick(object sender, EventArgs e)
        {

        }

        private void tEnviaLocal_Tick(object sender, EventArgs e)
        {

        }

        private void tEnviaNominamex_Tick(object sender, EventArgs e)
        {

        }





        public void fnEcribeLog(string Mensaje)
        {
            string path = Application.StartupPath + @"\logTareas.txt";
            string texto = string.Concat(DateTime.Now.ToString(), " ->", Mensaje, "\n");

            txtLog.Text += texto;
            File.AppendAllLines(path, new String[] { texto });
        }




    }
}
