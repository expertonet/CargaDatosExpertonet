using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CargaDatosExpertonet
{
    public class csGlobal
    {
        static string urlAutentica = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc";
        static string urlAutenticaAction = "http://DescargaMasivaTerceros.gob.mx/IAutenticacion/Autentica";

        static string urlSolicitud = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc";
        static string urlSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/ISolicitaDescargaService/SolicitaDescarga";

        static string urlVerificarSolicitud = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc";
        static string urlVerificarSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/IVerificaSolicitudDescargaService/VerificaSolicitudDescarga";

        static string urlDescargarSolicitud = "https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc";
        static string urlDescargarSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/IDescargaMasivaTercerosService/Descargar";

        static public string fnEnviaSolicitud(byte[] vpfx, string password, string RfcEmisor, string RfcReceptor, string srfcSolicitante, string FechaInicial, string FechaFinal, string TipoSolicitud_Id, string TipoSolicitud, string TipoEmision_Id, string TipoEmision)
        {
            csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());
            string slqInsert;
            SqlCommand cmdReader;
            
            string idSolicitud = string.Empty;
            try
            {
                //Obtener Certificados
                X509Certificate2 certifcate;
                certifcate = new X509Certificate2(vpfx, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

                //Obtener Token
                Autenticacion service = new Autenticacion(urlAutentica, urlAutenticaAction);
                string xml = service.Generate(certifcate);
                string token = service.Send();

                string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));

                //Generar Solicitud
                Solicitud solicitud = new Solicitud(urlSolicitud, urlSolicitudAction);
                string xmlSolicitud = solicitud.Generate(certifcate, RfcEmisor, RfcReceptor, srfcSolicitante, FechaInicial, FechaFinal, TipoSolicitud);
                idSolicitud = solicitud.Send(autorization);

                if (idSolicitud.Split('|')[0] != "301")
                {
                    slqInsert = @"
                            INSERT INTO [dbo].[Solicitud]
                                       ([Solicitud_Id]
                                       ,[EstadoSolicitud_Id]
                                       ,[Fecha]
                                       ,[FechaInicio]
                                       ,[FechaFin]
                                       ,[RFCEmisor]
                                       ,[RFCReceptor]
                                       ,[TipoEmision_Id]
                                       ,[RFCSolicitante]
                                       ,[TipoSolicitud_Id]
                                       ,Fehca_Creacion)
                            VALUES
                                ('" + idSolicitud.Split('|')[2] + @"'
                                ,'2" + @"'
                                ,'" + DateTime.Today.ToString() + @"'
                                ,'" + FechaInicial + @"'
                                ,'" + FechaFinal + @"'
                                ,'" + RfcEmisor + @"'
                                ,'" + RfcReceptor + @"'
                                ," + TipoEmision_Id + @"
                                ,'" + RfcEmisor + @"'
                                ," + TipoSolicitud_Id + @"
                                ,getdate())
                                ";
                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                    cnn.fnConectarSQLServer();
                    cmdReader.ExecuteNonQuery();
                    cmdReader.Dispose();
                }
                else
                {
                    throw new InvalidOperationException("XML Mal Formado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return idSolicitud;
        }

        static public string FnActualizaSolicitud(byte[] vpfx, string password, string RfcEmisor, string RfcReceptor, string srfcSolicitante, string FechaInicial, string FechaFinal, string TipoSolicitud_Id, string TipoSolicitud, string TipoEmision_Id, string TipoEmision, string idSolicitud)
        {
            //csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());
            //string slqInsert;
            //SqlCommand cmdReader;

            string EstadoSolicitud = string.Empty;

            try
            {
                //Obtener Certificados
                X509Certificate2 certifcate;
                certifcate = new X509Certificate2(vpfx, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

                //Obtener Token
                Autenticacion service = new Autenticacion(urlAutentica, urlAutenticaAction);
                string xml = service.Generate(certifcate);
                string token = service.Send();

                string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));

                //Valida Solicitud
                VerificaSolicitud verifica = new VerificaSolicitud(urlVerificarSolicitud, urlVerificarSolicitudAction);
                string xmlVerifica = verifica.Generate(certifcate, RfcEmisor, idSolicitud);
                EstadoSolicitud = verifica.Send(autorization);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return EstadoSolicitud;

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    string GridRFC = string.Empty;

            //    if (row.Cells[2].Value.ToString() != string.Empty)
            //        GridRFC = row.Cells[2].Value.ToString();
            //    else
            //        GridRFC = row.Cells[3].Value.ToString();

            //    slqInsert = "SELECT Id,RFC,RazonSocial,Alias,Usuario,Clave,Certificado FROM PersonaFisicaMoral WHERE RFC = '" + GridRFC + "'";
            //    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            //    //cmdReader.Parameters.AddWithValue("$id", cmbEempresas.SelectedIndex + 1);

            //    cnn.fnConectarSQLServer();
            //    reader = cmdReader.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        //cmbEempresas.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[3].ToString());


            //        if (reader["Certificado"].ToString() != "")
            //            pfx = File.ReadAllBytes(reader["Certificado"].ToString());
            //        password = reader["Clave"].ToString();
            //        //srfcSolicitante = reader["RFC"].ToString();
            //        sRFCEmisor = reader["RFC"].ToString();



            //    }
            //    cmdReader.Dispose();
            //    reader.Close();


            //    RfcEmisor = sRFCEmisor;


            //    //pfx = File.ReadAllBytes(row.Cells[1].Value.ToString());

            //    //Obtener Certificados
            //    X509Certificate2 certifcate = ObtenerX509Certificado(pfx);

            //    //Obtener Token
            //    string token = ObtenerToken(certifcate);
            //    string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));
            //    //Console.WriteLine("Token: " + token);

            //    //Generar Solicitud
            //    //string idSolicitud = GenerarSolicitud(certifcate, autorization);
            //    string idPaquete;

            //    //idPaquete = ValidarSolicitud(certifcate, autorization, row.Cells[1].Value.ToString());

            //    //Valida Solicitud
            //    VerificaSolicitud verifica = new VerificaSolicitud(urlVerificarSolicitud, urlVerificarSolicitudAction);
            //    string xmlVerifica = verifica.Generate(certifcate, RfcEmisor, idSolicitud);
            //    idPaquete = verifica.Send(autorization);

            //}


        }

    }


}
