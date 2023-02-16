using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;
using Cursor = System.Windows.Forms.Cursor;
using System.Xml;
using System.Data.SqlClient;
using System.Security;
using System.Web;

using System.Security.Cryptography.X509Certificates;

using System.IO.Compression;

//using Microsoft.Data.Sqlite;

using System.Data.SQLite;


namespace CargaDatosExpertonet
{
    public partial class frmETL : Form
    {
        PictureBox pic = null;
        Button btn = null;
        bool down = false;
        Point inicial;
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());


        SQLiteConnection connection;
        SQLiteCommand comm;
        SQLiteDataReader read;
        string strSQLite;

        SqlCommand cmdReader;
        SqlDataReader reader;
        string slqInsert;
        string sRFCEmisor;
        static string srfcSolicitante;

        int vTipoEmision;
        int vEstadoFactura;



        #region Variables para la conexión al SAT

        //static byte[] pfx = File.ReadAllBytes(@"C:\xnet\ReportesNomina\CONPAQi\Contador_Sat\Solo un sello\TBNMEXICO\TBN110919K19\TBN.pfx");
        //static string password = "M57740168";
        //static string RfcEmisor = "TBN110919K19";
        //static string RfcReceptor = "";
        //static string FechaInicial = "2021-10-01";
        //static string FechaFinal = "2021-10-31";

        static byte[] pfx;
        static string password;
        static string RfcEmisor;
        static string RfcReceptor;
        static string FechaInicial;
        static string FechaFinal;
        static string tipoSolicitud;

        static string urlAutentica = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc";
        static string urlAutenticaAction = "http://DescargaMasivaTerceros.gob.mx/IAutenticacion/Autentica";

        static string urlSolicitud = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc";
        static string urlSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/ISolicitaDescargaService/SolicitaDescarga";

        static string urlVerificarSolicitud = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc";
        static string urlVerificarSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/IVerificaSolicitudDescargaService/VerificaSolicitudDescarga";

        static string urlDescargarSolicitud = "https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc";
        static string urlDescargarSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/IDescargaMasivaTercerosService/Descargar";


        #endregion



        public frmETL()
        {
            InitializeComponent();
        }

        private void Ctr_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Control ctr = (Control)sender;
            if (down)
            {
                ctr.Left = e.X + ctr.Left - inicial.X;
                ctr.Top = e.Y + ctr.Top - inicial.Y;
            }
        }

        private void Ctr_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) => down = false;

        private void Ctr_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                down = true;
                inicial = e.Location;
            }

        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pic = new PictureBox
            {
                Location = new Point(inicial.X, inicial.Y),
                Name = "pic",
                Size = new Size(50, 50),
                ImageLocation = Directory.GetCurrentDirectory() + @"\img\excel.png",
                SizeMode = PictureBoxSizeMode.StretchImage

            };
            pic.MouseDown += Ctr_MouseDown;
            pic.MouseUp += Ctr_MouseUp;
            pic.MouseMove += Ctr_MouseMove;

            this.Controls.Add(pic);
        }


        private void frmETL_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        private void frmETL_Load(object sender, EventArgs e)
        {

            slqInsert = "select TipoEmision_Id, TipoEmision from TipoEmision order by TipoEmision_Id";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            cmbTipoEmision.Items.Clear();
            while (reader.Read())
                cmbTipoEmision.Items.Insert(Convert.ToInt32(reader[0])-1, reader[1].ToString());
            cmdReader.Dispose();
            reader.Close();

            slqInsert = "select EstadoFactura_Id, EstadoFactura from EstadoFactura order by EstadoFactura_Id";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            cmbEstadoFactura.Items.Clear();
            while (reader.Read())
                cmbEstadoFactura.Items.Insert(Convert.ToInt32(reader[0])-1, reader[1].ToString());
            cmdReader.Dispose();
            reader.Close();

            slqInsert = "SELECT Id,RFC,RazonSocial,Alias,Usuario,Clave,Certificado FROM PersonaFisicaMoral ORDER BY Id";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            cmbEempresas.Items.Clear();
            while (reader.Read())
                cmbEempresas.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[3].ToString());
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
                    SELECT 
	                        Solicitud.Solicitud_Id
	                    , Solicitud.RFCSolicitante
	                    , Solicitud.RFCEmisor
	                    , Solicitud.RFCReceptor
	                    , Solicitud.EstadoSolicitud_Id
	                    , EstadoSolicitud.EstadoSolicitud
					    , TipoEmision.TipoEmision
					    , TipoSolicitud.TipoSolicitud
	                    , Solicitud.Fecha 
	                    , Solicitud.FechaInicio
	                    , Solicitud.FechaFin
                        , Solicitud.Fehca_Creacion
                    FROM Solicitud 
	                    INNER JOIN EstadoSolicitud 
		                    ON Solicitud.EstadoSolicitud_Id = EstadoSolicitud.EstadoSolicitud_Id
					    INNER JOIN TipoEmision
						    ON Solicitud.TipoEmision_Id = TipoEmision.TipoEmision_Id
					    INNER JOIN TipoSolicitud 
						    ON Solicitud.TipoSolicitud_Id = TipoSolicitud.TipoSolicitud_Id
                    WHERE Solicitud.EstadoSolicitud_Id <> 6
                    Order By Solicitud.Fehca_Creacion DESC
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

        private void botonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn = new Button
            {
                Location = new Point(inicial.X, inicial.Y),
                Name = "btn",
                Text = "Boton",
                Size = new Size(75, 75)
            };

            btn.MouseDown += Ctr_MouseDown;
            btn.MouseUp += Ctr_MouseUp;
            btn.MouseMove += Ctr_MouseMove;

            this.Controls.Add(btn);
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoEmision.SelectedIndex < 0)
                    throw new InvalidOperationException("Falta seleccionar el Tipo de Emisión");

                if (cmbEstadoFactura.SelectedIndex < 0)
                    throw new InvalidOperationException("Falta seleccioanr el Estao de la Factura");

                vTipoEmision = cmbTipoEmision.SelectedIndex + 1;
                vEstadoFactura = cmbEstadoFactura.SelectedIndex + 1;


                XmlDocument XmlDoc = new XmlDocument();
                DialogResult dr = this.openFileDialog1.ShowDialog();

                if (dr == DialogResult.Cancel)
                    throw new InvalidOperationException("Importación cancelada");


                DialogResult msg1 = MessageBox.Show("Se importarán " + openFileDialog1.FileNames.Count().ToString() + " Facturas " + cmbTipoEmision.Items[cmbTipoEmision.SelectedIndex] + ", " + cmbEstadoFactura.Items[cmbEstadoFactura.SelectedIndex], "", MessageBoxButtons.YesNo);

                if (msg1 == DialogResult.No)
                    throw new InvalidOperationException("Importación cancelada");

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    await fnImportarCFDI();
                    MessageBox.Show("Proceso terminado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        async Task<int> fnImportarCFDI()
        {
            await Task.Run(() =>
            {
                //Comprobante
                string LugarExpedicion = string.Empty;
                string MetodoPago = string.Empty;
                string TipoDeComprobante = string.Empty;
                string Total = string.Empty;
                string Moneda = string.Empty;
                string Certificado = string.Empty;
                string SubTotal = string.Empty;
                string NoCertificado = string.Empty;
                string FormaPago = string.Empty;
                string Sello = string.Empty;
                string Fecha = string.Empty;
                string Folio = string.Empty;
                string Serie = string.Empty;
                string Version = string.Empty;
                string CondicionesDePago = string.Empty;
                string Descuento = string.Empty;
                string TipoCambio = string.Empty;
                string Confirmacion = string.Empty;
                string Comprobante_Id = string.Empty;

                //Emisor
                string Rfc = string.Empty;
                string Nombre = string.Empty;
                string RegimenFiscal = string.Empty;

                //Receptor
                string RfcR = string.Empty;
                string NombreR = string.Empty;
                string ResidenciaFiscalR = string.Empty;
                string NumRegIdTribR = string.Empty;
                string UsoCFDIR = string.Empty;


                //Conceptos
                string Conceptos_Id = string.Empty;


                //Concepto
                string ClaveProdServ = string.Empty;
                string NoIdentificacion = string.Empty;
                string Cantidad = string.Empty;
                string ClaveUnidad = string.Empty;
                string Unidad = string.Empty;
                string Descripcion = string.Empty;
                string ValorUnitario = string.Empty;
                string Importe = string.Empty;
                string DescuentoC = string.Empty;
                string Concepto_Id = string.Empty;

                //Impuestos
                string Impuestos_Id = string.Empty;

                //Transladados
                string Traslados_Id = string.Empty;

                //Tranladado
                string Base = string.Empty;
                string Impuesto = string.Empty;
                string TipoFactor = string.Empty;
                string TasaOCuota = string.Empty;
                string ImporteT = string.Empty;

                //Retenciones
                string Retenciones_Id = string.Empty;

                //Retencion
                string BaseR = string.Empty;
                string ImpuestoR = string.Empty;
                string TipoFactorR = string.Empty;
                string TasaOCuotaR = string.Empty;
                string ImporteR = string.Empty;

                //ImpuestosNodo
                string Impuestos_IdNodo0 = string.Empty;
                string TotalImpuestosRetenidos = string.Empty;
                string TotalImpuestosTrasladados = string.Empty;

                //RetencionesNodo
                string Retenciones_Id_IdNodo0 = string.Empty;

                //RetencionNodo
                string BaseNodo0 = string.Empty;
                string ImpuestoNodo0 = string.Empty;
                string TipoFactorNodo0 = string.Empty;
                string TasaOCuotaNodo0 = string.Empty;
                string ImporteNodo0 = string.Empty;

                //TrasladosNodo
                string Traslados_Id_IdNodo0 = string.Empty;

                //TraladoNodo
                string BaseRNodo0 = string.Empty;
                string ImpuestoRNodo0 = string.Empty;
                string TipoFactorRNodo0 = string.Empty;
                string TasaOCuotaRNodo0 = string.Empty;
                string ImporteRNodo0 = string.Empty;

                //Complemento
                string Complemento_Id = string.Empty;

                //TimbreFiscalDigital
                string VersionTimbreFiscal = string.Empty;
                string UUID = string.Empty;
                string FechaTimbrado = string.Empty;
                string RfcProvCertif = string.Empty;
                string TDLeyenda = string.Empty;
                string SelloCFD = string.Empty;
                string NoCertificadoSAT = string.Empty;
                string SelloSAT = string.Empty;

                //Pagos
                string Pagos_Id = string.Empty;
                string VersionPagos = string.Empty;

                //Pago
                string Pago_Id = string.Empty;
                string PagoFechaPago = string.Empty;
                string PagoFormaDePagoP = string.Empty;
                string PagoMonedaP = string.Empty;
                string PagoMonto = string.Empty;
                string NumOperacionPago = string.Empty;
                string PagoRfcEmisorCtaOrd = string.Empty;
                string PagoNomBancoOrdExt = string.Empty;
                string PagoCtaOrdenante = string.Empty;
                string PagoRfcEmisorCtaBen = string.Empty;
                string PagoCtaBeneficiario = string.Empty;
                string TipoCadPago = string.Empty;
                string CertPago = string.Empty;
                string CadPago = string.Empty;
                string SelloPago = string.Empty;
                string PagoTipoCambioP = string.Empty;

                //DoctoRelacionado
                string doctoIdDocumento = string.Empty;
                string doctoMonedaDR = string.Empty;
                string doctoMetodoDePagoDR = string.Empty;
                string doctoNumParcialidad = string.Empty;
                string doctoImpSaldoAnt = string.Empty;
                string doctoImpPagado = string.Empty;
                string doctoImpSaldoInsoluto = string.Empty;
                string docRfcEmisorCtaBen = string.Empty;
                string docTipoCambioDR = string.Empty;
                string docSerie = string.Empty;
                string docFolio = string.Empty;

                string slqInsert = string.Empty;


                //Nomina
                string Version_nomina = string.Empty;
                string TipoNomina_nomina = string.Empty;
                string FechaPago_nomina = string.Empty;
                string FechaInicialPago_nomina = string.Empty;
                string FechaFinalPago_nomina = string.Empty;
                string NumDiasPagados_nomina = string.Empty;
                string TotalPercepciones_nomina = string.Empty;
                string TotalDeducciones_nomina = string.Empty;
                string TotalOtrosPagos_nomina = string.Empty;
                string Nomina_Id_nomina = string.Empty;


                //EmisorNomina
                string Curp_emisornomina = string.Empty;
                string RegistroPatronal_emisornomina = string.Empty;
                string RfcPatronOrigen_emisornomina = string.Empty;
                string Emisor_Id = string.Empty;


                //EntidadSNCFNomina
                string OrigenRecurso_nominaentidadsncf = string.Empty;
                string MontoRecursoPropio_nominaentidadsncf = string.Empty;



                //nomina12:Receptor
                string Curp_receptornomina = string.Empty;
                string NumSeguridadSocial_receptornomina = string.Empty;
                string FechaInicioRelLaboral_receptornomina = string.Empty;
                string Antigüedad_receptornomina = string.Empty;
                string TipoContrato_receptornomina = string.Empty;
                string Sindicalizado_receptornomina = string.Empty;
                string TipoJornada_receptornomina = string.Empty;
                string TipoRegimen_receptornomina = string.Empty;
                string NumEmpleado_receptornomina = string.Empty;
                string Departamento_receptornomina = string.Empty;
                string Puesto_receptornomina = string.Empty;
                string RiesgoPuesto_receptornomina = string.Empty;
                string PeriodicidadPago_receptornomina = string.Empty;
                string Banco_receptornomina = string.Empty;
                string CuentaBancaria_receptornomina = string.Empty;
                string SalarioBaseCotApor_receptornomina = string.Empty;
                string SalarioDiarioIntegrado_receptornomina = string.Empty;
                string ClaveEntFed_receptornomina = string.Empty;
                string Receptor_Id_receptornomina = string.Empty;
                string Nomina_Id_receptornomina = string.Empty;


                //nomina12:SubContratacion
                string RfcLabora_nominasubcontratacion = string.Empty;
                string PorcentajeTiempo_nominasubcontratacion = string.Empty;
                string Receptor_Id_nominasubcontratacion = string.Empty;


                //nomina12:Deducciones
                string TotalOtrasDeducciones_nominadeducciones = string.Empty;
                string TotalImpuestosRetenidos_nominadeducciones = string.Empty;
                string Deducciones_Id_nominadeducciones = string.Empty;


                //nomina12:Deduccion
                string TipoDeduccion_nominadeduccion = string.Empty;
                string Clave_nominadeduccion = string.Empty;
                string Concepto_nominadeduccion = string.Empty;
                string Importe_nominadeduccion = string.Empty;


                //nomina12:Percepciones
                string TotalSueldos_nominapercepciones = string.Empty;
                string TotalSeparacionIndemnizacion_nominapercepciones = string.Empty;
                string TotalJubilacionPensionRetiro_nominapercepciones = string.Empty;
                string TotalGravado_nominapercepciones = string.Empty;
                string TotalExento_nominapercepciones = string.Empty;
                string Percepciones_Id_nominapercepciones = string.Empty;


                //nomina12:Percepcion
                string TipoPercepcion_nominapercepcion = string.Empty;
                string Clave_nominapercepcion = string.Empty;
                string Concepto_nominapercepcion = string.Empty;
                string ImporteGravado_nominapercepcion = string.Empty;
                string ImporteExento_nominapercepcion = string.Empty;
                string Percepcion_Id_nominapercepcion = string.Empty;


                //nomina12:AccionesOTitulos
                string ValorMercado_nominaaccionesotitulos = string.Empty;
                string PrecioAlOtorgarse_nominaaccionesotitulos = string.Empty;
                string Percepcion_Id_nominaaccionesotitulos = string.Empty;


                //nomina12:HorasExtra
                string Dias_nominahorasextra = string.Empty;
                string TipoHoras_nominahorasextra = string.Empty;
                string HorasExtra_nominahorasextra = string.Empty;
                string ImportePagado_nominahorasextra = string.Empty;


                //nomina12:SeparacionIndemnizacion
                string TotalPagado_nominaeparacionIndemnizacion = string.Empty;
                string NumAñosServicio_nominaeparacionIndemnizacion = string.Empty;
                string UltimoSueldoMensOrd_nominaeparacionIndemnizacion = string.Empty;
                string IngresoAcumulable_nominaeparacionIndemnizacion = string.Empty;
                string IngresoNoAcumulable_nominaeparacionIndemnizacion = string.Empty;



                //nomina12:JubilacionPensionRetiro
                string TotalUnaExhibicion_nominaJubilacionPensionRetiro = string.Empty;
                string TotalParcialidad_nominaJubilacionPensionRetiro = string.Empty;
                string MontoDiario_nominaJubilacionPensionRetiro = string.Empty;
                string IngresoAcumulable_nominaJubilacionPensionRetiro = string.Empty;
                string IngresoNoAcumulable_nominaJubilacionPensionRetiro = string.Empty;

                //nomina12:OtrosPagos
                string OtrosPagos_Id_nominaOtrosPagos = string.Empty;


                //nomina12:OtroPago
                string TipoOtroPago_nominaOtroPago = string.Empty;
                string Clave_nominaOtroPago = string.Empty;
                string Concepto_nominaOtroPago = string.Empty;
                string Importe_nominaOtroPago = string.Empty;
                string OtroPago_Id_nominaOtroPago = string.Empty;


                //nomina12:CompensacionSaldosAFavor
                string SaldoAFavor_CompensacionSaldosAFavor = string.Empty;
                string Año_CompensacionSaldosAFavor = string.Empty;
                string RemanenteSalFav_CompensacionSaldosAFavor = string.Empty;


                //nomina12:SubsidioAlEmpleo
                string SubsidioCausado_nominaSubsidioAlEmpleo = string.Empty;


                //nomina12:Incapacidades
                string Incapacidades_Id_nominaIncapacidades = string.Empty;


                //nomina12:Incapacidad
                string DiasIncapacidad_nominaIncapacidad = string.Empty;
                string TipoIncapacidad_nominaIncapacidad = string.Empty;
                string ImporteMonetario_nominaIncapacidad = string.Empty;


                //cfdi:CuentaPredial
                string Numero_nominaCuentaPredial = string.Empty;


                //ComplementoConcepto
                string ComplementoConcepto_Id_ComplementoConcepto = string.Empty;


                //instEducativas
                string version_instEducativas = string.Empty;
                string nombreAlumno_instEducativas = string.Empty;
                string CURP_instEducativas = string.Empty;
                string nivelEducativo_instEducativas = string.Empty;
                string autRVOE_instEducativas = string.Empty;
                string rfcPago_instEducativas = string.Empty;




                //registrofiscal:CFDIRegistroFiscal
                string Version_CFDIRegistroFiscal = string.Empty;
                string Folio_CFDIRegistroFiscal = string.Empty;


                SqlCommand cmdReader;
                SqlDataReader reader;
                SqlCommand comando;

                SqlDataAdapter adapter;
                DataSet ds1 = new DataSet();

                int inTotalImportados = 1;

                try
                {
                    //if (cmbTipoEmision.SelectedIndex < 0)
                    //    throw new InvalidOperationException("Falta seleccionar el Tipo de Emisión");

                    //if (cmbEstadoFactura.SelectedIndex < 0)
                    //    throw new InvalidOperationException("Falta seleccioanr el Estao de la Factura");

                    //int vTipoEmision = cmbTipoEmision.SelectedIndex + 1;
                    //int vEstadoFactura = cmbEstadoFactura.SelectedIndex + 1;


                    XmlDocument XmlDoc = new XmlDocument();
                    //DialogResult dr = this.openFileDialog1.ShowDialog();

                    //if (dr == DialogResult.Cancel)
                    //    throw new InvalidOperationException("Importación cancelada");


                    //DialogResult msg1 = MessageBox.Show("Se importarán " + openFileDialog1.FileNames.Count().ToString() + " Facturas " + cmbTipoEmision.Items[cmbTipoEmision.SelectedIndex] + ", " + cmbEstadoFactura.Items[cmbEstadoFactura.SelectedIndex], "", MessageBoxButtons.YesNo);

                    //if (msg1 == DialogResult.No)
                    //    throw new InvalidOperationException("Importación cancelada");

                    //if (dr == System.Windows.Forms.DialogResult.OK)
                    //{
                    foreach (String file in openFileDialog1.FileNames)
                    {
                        lblTotalImportados.Invoke((MethodInvoker)(() => lblTotalImportados.Text = inTotalImportados.ToString() + " Registros insertados"));
                        XmlDoc.Load(file);

                        foreach (XmlNode Node1 in XmlDoc.DocumentElement.ChildNodes)
                            if (Node1.Name == "cfdi:Complemento")
                                foreach (XmlNode Node6 in Node1)
                                    if (Node6.Name == "tfd:TimbreFiscalDigital")
                                        UUID = fnObtenValorNodo(Node6, "UUID");

                        cnn.spNameSQLServer = "spDeleteUUID";
                        cnn.cmdSQLServer.Parameters.Clear();
                        cnn.cmdSQLServer.Parameters.Add("uuid", SqlDbType.VarChar).Value = UUID;
                        cnn.LlenaTablaSQLServer();
                        
                        if (XmlDoc.DocumentElement.Name == "cfdi:Comprobante")
                        {
                            Confirmacion = fnObtenValor(ref XmlDoc, "Confirmacion");
                            LugarExpedicion = fnObtenValor(ref XmlDoc, "LugarExpedicion");
                            MetodoPago = fnObtenValor(ref XmlDoc, "MetodoPago");
                            TipoDeComprobante = fnObtenValor(ref XmlDoc, "TipoDeComprobante");
                            Total = fnObtenValor(ref XmlDoc, "Total");
                            TipoCambio = fnObtenValor(ref XmlDoc, "TipoCambio");
                            Moneda = fnObtenValor(ref XmlDoc, "Moneda");
                            Descuento = fnObtenValor(ref XmlDoc, "Descuento");
                            SubTotal = fnObtenValor(ref XmlDoc, "SubTotal");
                            CondicionesDePago = fnObtenValor(ref XmlDoc, "CondicionesDePago");
                            Certificado = fnObtenValor(ref XmlDoc, "Certificado");
                            NoCertificado = fnObtenValor(ref XmlDoc, "NoCertificado");
                            FormaPago = fnObtenValor(ref XmlDoc, "FormaPago");
                            Sello = fnObtenValor(ref XmlDoc, "Sello");
                            Fecha = fnObtenValor(ref XmlDoc, "Fecha");
                            Folio = fnObtenValor(ref XmlDoc, "Folio");
                            Serie = fnObtenValor(ref XmlDoc, "Serie");
                            Version = fnObtenValor(ref XmlDoc, "Version");

                            slqInsert = "select isnull(max(Comprobante_Id)+1,1) from Comprobante";
                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                            cnn.fnConectarSQLServer();
                            reader = cmdReader.ExecuteReader();
                            if (reader.Read())
                                Comprobante_Id = reader[0].ToString();
                            cmdReader.Dispose();
                            reader.Close();

                            slqInsert = @"
                            INSERT INTO [dbo].[Comprobante]
                                ([Version]
                                ,[Serie]
                                ,[Folio]
                                ,[Fecha]
                                ,[Sello]
                                ,[FormaPago]
                                ,[NoCertificado]
                                ,[Certificado]
                                ,[CondicionesDePago]
                                ,[SubTotal]
                                ,[Descuento]
                                ,[Moneda]
                                ,[TipoCambio]
                                ,[Total]
                                ,[TipoDeComprobante]
                                ,[MetodoPago]
                                ,[LugarExpedicion]
                                ,[Confirmacion]
                                ,[TipoEmision_Id]
                                ,[EstadoFactura_Id]
                                ,[EstatusCancelacion_Id]
                                ,[Comprobante_Id]
                                ,UUID)
                            VALUES
                                ( '" + Version + @"'
                                ,'" + Serie + @"'
                                ,'" + Folio + @"'
                                ,'" + Fecha + @"'
                                ,'" + Sello + @"'
                                ,'" + FormaPago + @"'
                                ,'" + NoCertificado + @"'
                                ,'" + Certificado + @"'
                                ,'" + CondicionesDePago + @"'
                                ," + SubTotal + @"
                                ," + Descuento + @"
                                ,'" + Moneda + @"'
                                ," + TipoCambio + @"
                                ," + Total + @"
                                ,'" + TipoDeComprobante + @"'
                                ,'" + MetodoPago + @"'
                                ,'" + LugarExpedicion + @"'
                                ,'" + Confirmacion + @"'
                                ," + vTipoEmision + @"
                                ," + vEstadoFactura + @"
                                ," + 3 + @"
                                ," + Comprobante_Id + @"
                                ,'" + UUID + @"')
                            ";
                            slqInsert = slqInsert.Replace("'null'", "null");
                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                            cnn.fnConectarSQLServer();
                            comando.ExecuteNonQuery();
                            comando.Dispose();

                            foreach (XmlNode Node1 in XmlDoc.DocumentElement.ChildNodes)
                            {
                                if (Node1.Name == "cfdi:Emisor")
                                {
                                    Rfc = fnObtenValorNodo(Node1, "Rfc");
                                    Nombre = fnObtenValorNodo(Node1, "Nombre");
                                    RegimenFiscal = fnObtenValorNodo(Node1, "RegimenFiscal");

                                    slqInsert = @"
                                INSERT INTO [dbo].[Emisor]
                                    ([Rfc]
                                    ,[Nombre]
                                    ,[RegimenFiscal]
                                    ,[Comprobante_Id]
                                    ,UUID)
                                VALUES
                                    ( '" + Rfc + @"'
                                    ,'" + Nombre + @"'
                                    ,'" + RegimenFiscal + @"'
                                    ," + Comprobante_Id + @"
                                    ,'" + UUID + @"')
                                ";
                                    slqInsert = slqInsert.Replace("'null'", "null");
                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    comando.ExecuteNonQuery();
                                    comando.Dispose();
                                }
                                else if (Node1.Name == "cfdi:Receptor")
                                {
                                    RfcR = fnObtenValorNodo(Node1, "Rfc");
                                    NombreR = fnObtenValorNodo(Node1, "Nombre");
                                    ResidenciaFiscalR = fnObtenValorNodo(Node1, "ResidenciaFiscal");
                                    NumRegIdTribR = fnObtenValorNodo(Node1, "NumRegIdTrib");
                                    UsoCFDIR = fnObtenValorNodo(Node1, "UsoCFDI");

                                    slqInsert = @"
                                INSERT INTO [dbo].[Receptor]
                                    ([Rfc]
                                    ,[Nombre]
                                    ,[ResidenciaFiscal]
                                    ,[NumRegIdTrib]
                                    ,[UsoCFDI]
                                    ,[Comprobante_Id]
                                    ,UUID)
                                VALUES
                                    ( '" + RfcR + @"'
                                    ,'" + NombreR + @"'
                                    ,'" + ResidenciaFiscalR + @"'
                                    ,'" + NumRegIdTribR + @"'
                                    ,'" + UsoCFDIR + @"'
                                    ," + Comprobante_Id + @"
                                    ,'" + UUID + @"')
                                ";
                                    slqInsert = slqInsert.Replace("'null'", "null");
                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    comando.ExecuteNonQuery();
                                    comando.Dispose();
                                }
                                else if (Node1.Name == "cfdi:Conceptos")
                                {
                                    slqInsert = "select isnull(max(Conceptos_Id)+1,1) from Conceptos";
                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    reader = cmdReader.ExecuteReader();
                                    if (reader.Read())
                                        Conceptos_Id = reader[0].ToString();
                                    cmdReader.Dispose();
                                    reader.Close();

                                    slqInsert = @"
                                INSERT INTO [dbo].[Conceptos]
                                    ([Conceptos_Id]
                                    ,[Comprobante_Id]
                                    ,UUID)
                                VALUES
                                    ( " + Conceptos_Id + @"
                                    ," + Comprobante_Id + @"
                                    ,'" + UUID + @"')
                                ";
                                    slqInsert = slqInsert.Replace("'null'", "null");
                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    comando.ExecuteNonQuery();
                                    comando.Dispose();

                                    foreach (XmlNode Node2 in Node1)
                                    {
                                        if (Node2.Name == "cfdi:Concepto")
                                        {
                                            ClaveProdServ = fnObtenValorNodo(Node2, "ClaveProdServ");
                                            NoIdentificacion = fnObtenValorNodo(Node2, "NoIdentificacion");
                                            Cantidad = fnObtenValorNodo(Node2, "Cantidad");
                                            ClaveUnidad = fnObtenValorNodo(Node2, "ClaveUnidad");
                                            Unidad = fnObtenValorNodo(Node2, "Unidad");
                                            Descripcion = fnObtenValorNodo(Node2, "Descripcion").Replace("'", "");
                                            ValorUnitario = fnObtenValorNodo(Node2, "ValorUnitario");
                                            Importe = fnObtenValorNodo(Node2, "Importe");
                                            DescuentoC = fnObtenValorNodo(Node2, "Descuento");

                                            slqInsert = "select isnull(max(Concepto_Id)+1,1) from Concepto";
                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            reader = cmdReader.ExecuteReader();
                                            if (reader.Read())
                                                Concepto_Id = reader[0].ToString();
                                            cmdReader.Dispose();
                                            reader.Close();

                                            slqInsert = @"
                                        INSERT INTO [dbo].[Concepto]
                                            ([ClaveProdServ]
                                            ,[NoIdentificacion]
                                            ,[Cantidad]
                                            ,[ClaveUnidad]
                                            ,[Unidad]
                                            ,[Descripcion]
                                            ,[ValorUnitario]
                                            ,[Importe]
                                            ,[Descuento]
                                            ,[Concepto_Id]
                                            ,[Conceptos_Id]
                                            ,UUID)
                                        VALUES
                                            ( '" + ClaveProdServ + @"'
                                            ,'" + NoIdentificacion + @"'
                                            ," + Cantidad + @"
                                            ,'" + ClaveUnidad + @"'
                                            ,'" + Unidad + @"'
                                            ,'" + Descripcion + @"'
                                            ," + ValorUnitario + @"
                                            ," + Importe + @"
                                            ," + DescuentoC + @"
                                            ," + Concepto_Id + @"
                                            ," + Conceptos_Id + @"
                                            ,'" + UUID + @"')
                                        ";

                                            slqInsert = slqInsert.Replace("'null'", "null");
                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            comando.ExecuteNonQuery();
                                            comando.Dispose();

                                            foreach (XmlNode Node3 in Node2)
                                            {
                                                if (Node3.Name == "cfdi:Impuestos")
                                                {
                                                    slqInsert = "select isnull(max(Impuestos_Id)+1,1) from Impuestos";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        Impuestos_Id = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                    INSERT INTO [dbo].[Impuestos]
                                                            ([Impuestos_Id]
                                                            ,[Concepto_Id]
                                                            ,[Comprobante_Id]
                                                            ,UUID)
                                                    VALUES
                                                        ( '" + Impuestos_Id + @"'
                                                        ," + Concepto_Id + @"
                                                        ," + Comprobante_Id + @"
                                                        ,'" + UUID + @"')
                                                    ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node4 in Node3)
                                                    {
                                                        if (Node4.Name == "cfdi:Traslados")
                                                        {
                                                            slqInsert = "select isnull(max(Traslados_Id)+1,1) from Traslados";
                                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            reader = cmdReader.ExecuteReader();
                                                            if (reader.Read())
                                                                Traslados_Id = reader[0].ToString();
                                                            cmdReader.Dispose();
                                                            reader.Close();

                                                            slqInsert = @"
                                                        INSERT INTO [dbo].[Traslados]
                                                                    ([Traslados_Id]
                                                                    ,[Impuestos_Id]
                                                                    ,UUID)
                                                        VALUES
                                                            ( '" + Traslados_Id + @"'
                                                            ," + Impuestos_Id + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();

                                                            foreach (XmlNode Node5 in Node4)
                                                            {
                                                                if (Node5.Name == "cfdi:Traslado")
                                                                {
                                                                    Base = fnObtenValorNodo(Node5, "Base");
                                                                    Impuesto = fnObtenValorNodo(Node5, "Impuesto");
                                                                    TipoFactor = fnObtenValorNodo(Node5, "TipoFactor");
                                                                    TasaOCuota = fnObtenValorNodo(Node5, "TasaOCuota");
                                                                    ImporteT = fnObtenValorNodo(Node5, "Importe");

                                                                    slqInsert = @"
                                                                    INSERT INTO [dbo].[Traslado]
                                                                        ([Base]
                                                                        ,[Impuesto]
                                                                        ,[TipoFactor]
                                                                        ,[TasaOCuota]
                                                                        ,[Importe]
                                                                        ,[Traslados_Id]
                                                                        ,UUID)
                                                                    VALUES
                                                                        ( " + Base + @"
                                                                        ,'" + Impuesto + @"'
                                                                        ,'" + TipoFactor + @"'
                                                                        ," + TasaOCuota + @"
                                                                        ," + ImporteT + @"
                                                                        ," + Traslados_Id + @"
                                                                        ,'" + UUID + @"')
                                                                    ";
                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();

                                                                }
                                                                else
                                                                {
                                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node5.Name, " No encontrado") });
                                                                }
                                                            }
                                                        }
                                                        else if (Node4.Name == "cfdi:Retenciones")
                                                        {
                                                            slqInsert = "select isnull(max(Retenciones_Id)+1,1) from Retenciones";
                                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            reader = cmdReader.ExecuteReader();
                                                            if (reader.Read())
                                                                Retenciones_Id = reader[0].ToString();
                                                            cmdReader.Dispose();
                                                            reader.Close();

                                                            slqInsert = @"
                                                            INSERT INTO [dbo].[Retenciones]
                                                                    ([Retenciones_Id]
                                                                    ,[Impuestos_Id]
                                                                    ,UUID)
                                                            VALUES
                                                                ( '" + Retenciones_Id + @"'
                                                                ," + Impuestos_Id + @"
                                                                ,'" + UUID + @"')
                                                            ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();

                                                            foreach (XmlNode Node5 in Node4)
                                                            {
                                                                if (Node5.Name == "cfdi:Retencion")
                                                                {
                                                                    BaseR = fnObtenValorNodo(Node5, "Base");
                                                                    ImpuestoR = fnObtenValorNodo(Node5, "Impuesto");
                                                                    TipoFactorR = fnObtenValorNodo(Node5, "TipoFactor");
                                                                    TasaOCuotaR = fnObtenValorNodo(Node5, "TasaOCuota");
                                                                    ImporteR = fnObtenValorNodo(Node5, "Importe");

                                                                    slqInsert = @"
                                                                    INSERT INTO [dbo].[Retencion]
                                                                            ([Base]
                                                                            ,[Impuesto]
                                                                            ,[TipoFactor]
                                                                            ,[TasaOCuota]
                                                                            ,[Importe]
                                                                            ,[Retenciones_Id]
                                                                            ,UUID)
                                                                    VALUES
                                                                        ( " + BaseR + @"
                                                                        ,'" + ImpuestoR + @"'
                                                                        ,'" + TipoFactorR + @"'
                                                                        ," + TasaOCuotaR + @"
                                                                        ," + ImporteR + @"
                                                                        ," + Retenciones_Id + @"
                                                                        ,'" + UUID + @"')
                                                                    ";
                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();
                                                                }
                                                                else
                                                                {
                                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node5.Name, " No encontrado") });
                                                                }

                                                            }
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node4.Name, " No encontrado") });
                                                        }
                                                    }
                                                }
                                                else if (Node3.Name == "cfdi:CuentaPredial")
                                                {
                                                    Numero_nominaCuentaPredial = fnObtenValorNodo(Node3, "Numero");
                                                    slqInsert = @"
                                                INSERT INTO dbo.CuentaPredial
                                                    (Numero
                                                    ,Concepto_Id
                                                    ,UUID)
                                                VALUES
                                                    ( '" + Numero_nominaCuentaPredial + @"'
                                                    ," + Concepto_Id + @"
                                                            ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();
                                                }
                                                else if (Node3.Name == "cfdi:ComplementoConcepto")
                                                {
                                                    slqInsert = "select isnull(max(ComplementoConcepto_Id)+1,1) from ComplementoConcepto";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        ComplementoConcepto_Id_ComplementoConcepto = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                INSERT INTO [dbo].[ComplementoConcepto]
                                                    ([Concepto_Id]
                                                    ,[UUID]
                                                    ,[ComplementoConcepto_Id])
                                                VALUES
                                                    (" + Concepto_Id + @"
                                                    ,'" + UUID + @"'
                                                    ," + ComplementoConcepto_Id_ComplementoConcepto + @")
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node4 in Node3)
                                                    {
                                                        if (Node4.Name == "iedu:instEducativas")
                                                        {
                                                            version_instEducativas = fnObtenValorNodo(Node4, "version");
                                                            nombreAlumno_instEducativas = fnObtenValorNodo(Node4, "nombreAlumno");
                                                            CURP_instEducativas = fnObtenValorNodo(Node4, "CURP");
                                                            nivelEducativo_instEducativas = fnObtenValorNodo(Node4, "nivelEducativo");
                                                            autRVOE_instEducativas = fnObtenValorNodo(Node4, "autRVOE");
                                                            rfcPago_instEducativas = fnObtenValorNodo(Node4, "rfcPago");

                                                            slqInsert = @"
                                                        INSERT INTO [dbo].[instEducativas]
                                                            ([version]
                                                            ,[nombreAlumno]
                                                            ,[CURP]
                                                            ,[nivelEducativo]
                                                            ,[autRVOE]
                                                            ,[rfcPago]
                                                            ,[ComplementoConcepto_Id]
                                                            ,[UUID])
                                                        VALUES
                                                            ( '" + version_instEducativas + @"'
                                                            ,'" + nombreAlumno_instEducativas + @"'
                                                            ,'" + CURP_instEducativas + @"'
                                                            ,'" + nivelEducativo_instEducativas + @"'
                                                            ,'" + autRVOE_instEducativas + @"'
                                                            ,'" + rfcPago_instEducativas + @"'
                                                            ," + ComplementoConcepto_Id_ComplementoConcepto + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else if (Node4.Name == "terceros:PorCuentadeTerceros")
                                                        {
                                                            //PorCuentadeTerceros
                                                            string version_PorCuentadeTerceros = string.Empty;
                                                            string rfc_PorCuentadeTerceros = string.Empty;
                                                            string nombre_PorCuentadeTerceros = string.Empty;
                                                            string PorCuentadeTerceros_Id_PorCuentadeTerceros = string.Empty;


                                                            slqInsert = "select isnull(max(PorCuentadeTerceros_Id)+1,1) from PorCuentadeTerceros_terceros11";
                                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            reader = cmdReader.ExecuteReader();
                                                            if (reader.Read())
                                                                PorCuentadeTerceros_Id_PorCuentadeTerceros = reader[0].ToString();
                                                            cmdReader.Dispose();
                                                            reader.Close();

                                                            version_PorCuentadeTerceros = fnObtenValorNodo(Node4, "version");
                                                            rfc_PorCuentadeTerceros = fnObtenValorNodo(Node4, "rfc");
                                                            nombre_PorCuentadeTerceros = fnObtenValorNodo(Node4, "nombre");

                                                            slqInsert = @"
                                                        INSERT INTO [dbo].[PorCuentadeTerceros_terceros11]
                                                            ([version]
                                                            ,[rfc]
                                                            ,[nombre]
                                                            ,[PorCuentadeTerceros_Id]
                                                            ,[ComplementoConcepto_Id]
                                                            ,[UUID])
                                                        VALUES
                                                            ( '" + version_PorCuentadeTerceros + @"'
                                                            ,'" + rfc_PorCuentadeTerceros + @"'
                                                            ,'" + nombre_PorCuentadeTerceros + @"'
                                                            ," + PorCuentadeTerceros_Id_PorCuentadeTerceros + @"
                                                            ," + ComplementoConcepto_Id_ComplementoConcepto + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();

                                                            foreach (XmlNode Node5 in Node4)
                                                            {
                                                                if (Node5.Name == "terceros:InformacionFiscalTercero")
                                                                {
                                                                    string calle_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string noExterior_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string noInterior_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string colonia_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string localidad_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string referencia_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string municipio_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string estado_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string pais_PorCuentadeTerceros_terceros11 = string.Empty;
                                                                    string codigoPosta_PorCuentadeTerceros_terceros11 = string.Empty;

                                                                    calle_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "calle");
                                                                    noExterior_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "noExterior");
                                                                    noInterior_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "noInterior");
                                                                    colonia_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "colonia");
                                                                    localidad_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "localidad");
                                                                    referencia_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "referencia");
                                                                    municipio_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "municipio");
                                                                    estado_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "estado");
                                                                    pais_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "pais");
                                                                    codigoPosta_PorCuentadeTerceros_terceros11 = fnObtenValorNodo(Node5, "codigoPostal");

                                                                    slqInsert = @"
                                                                INSERT INTO [dbo].[InformacionFiscalTercero_terceros11]
                                                                    ([calle]
                                                                    ,[noExterior]
                                                                    ,[noInterior]
                                                                    ,[colonia]
                                                                    ,[localidad]
                                                                    ,[referencia]
                                                                    ,[municipio]
                                                                    ,[estado]
                                                                    ,[pais]
                                                                    ,[codigoPostal]
                                                                    ,[PorCuentadeTerceros_Id]
                                                                    ,[UUID])
                                                                VALUES
                                                                    ( '" + calle_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + noExterior_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + noInterior_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + colonia_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + localidad_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + referencia_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + municipio_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + estado_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + pais_PorCuentadeTerceros_terceros11 + @"'
                                                                    ,'" + codigoPosta_PorCuentadeTerceros_terceros11 + @"'
                                                                    ," + PorCuentadeTerceros_Id_PorCuentadeTerceros + @"
                                                                    ,'" + UUID + @"')
                                                                ";

                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();
                                                                }
                                                                else if (Node5.Name == "terceros:CuentaPredial")
                                                                {
                                                                    string numero_CuentaPredial = string.Empty;

                                                                    numero_CuentaPredial = fnObtenValorNodo(Node5, "numero");

                                                                    slqInsert = @"
                                                                INSERT INTO[dbo].[CuentaPredial_terceros11]
                                                                            ([numero]
                                                                            ,[PorCuentadeTerceros_Id]
                                                                            ,[UUID])
                                                                VALUES
                                                                    ( '" + numero_CuentaPredial + @"'
                                                                    ," + PorCuentadeTerceros_Id_PorCuentadeTerceros + @"
                                                                    ,'" + UUID + @"')
                                                                ";

                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();
                                                                }
                                                                else if (Node5.Name == "terceros:Parte")
                                                                {
                                                                    string cantidad_Parte_terceros11 = string.Empty;
                                                                    string unidad_Parte_terceros11 = string.Empty;
                                                                    string noIdentificacion_Parte_terceros11 = string.Empty;
                                                                    string descripcion_Parte_terceros11 = string.Empty;
                                                                    string valorUnitario_Parte_terceros11 = string.Empty;
                                                                    string importe_Parte_terceros11 = string.Empty;
                                                                    string Parte_Id_Parte_terceros11 = string.Empty;

                                                                    slqInsert = "select isnull(max(Parte_Id)+1,1) from Parte_terceros11";
                                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    reader = cmdReader.ExecuteReader();
                                                                    if (reader.Read())
                                                                        Parte_Id_Parte_terceros11 = reader[0].ToString();
                                                                    cmdReader.Dispose();
                                                                    reader.Close();

                                                                    cantidad_Parte_terceros11 = fnObtenValorNodo(Node5, "cantidad");
                                                                    unidad_Parte_terceros11 = fnObtenValorNodo(Node5, "unidad");
                                                                    noIdentificacion_Parte_terceros11 = fnObtenValorNodo(Node5, "noIdentificacion");
                                                                    descripcion_Parte_terceros11 = fnObtenValorNodo(Node5, "descripcion");
                                                                    valorUnitario_Parte_terceros11 = fnObtenValorNodo(Node5, "valorUnitario");
                                                                    importe_Parte_terceros11 = fnObtenValorNodo(Node5, "importe");

                                                                    slqInsert = @"
                                                                INSERT INTO[dbo].[Parte_terceros11]
                                                                    ([cantidad]
                                                                    ,[unidad]
                                                                    ,[noIdentificacion]
                                                                    ,[descripcion]
                                                                    ,[valorUnitario]
                                                                    ,[importe]
                                                                    ,[Parte_Id]
                                                                    ,[PorCuentadeTerceros_Id]
                                                                    ,[UUID])
                                                                VALUES
                                                                    ( '" + cantidad_Parte_terceros11 + @"'
                                                                    ,'" + unidad_Parte_terceros11 + @"'
                                                                    ,'" + noIdentificacion_Parte_terceros11 + @"'
                                                                    ,'" + descripcion_Parte_terceros11 + @"'
                                                                    ,'" + valorUnitario_Parte_terceros11 + @"'
                                                                    ,'" + importe_Parte_terceros11 + @"'
                                                                    ," + Parte_Id_Parte_terceros11 + @"
                                                                    ," + PorCuentadeTerceros_Id_PorCuentadeTerceros + @"
                                                                    ,'" + UUID + @"')
                                                                    ";

                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();

                                                                    foreach (XmlNode Node6 in Node5)
                                                                    {
                                                                        if (Node6.Name == "terceros:InformacionAduanera")
                                                                        {
                                                                            string numero_InformacionAduanera = string.Empty;
                                                                            string fecha_InformacionAduanera = string.Empty;
                                                                            string aduana_InformacionAduanera = string.Empty;

                                                                            numero_InformacionAduanera = fnObtenValorNodo(Node6, "numero");
                                                                            fecha_InformacionAduanera = fnObtenValorNodo(Node6, "fecha");
                                                                            aduana_InformacionAduanera = fnObtenValorNodo(Node6, "aduana");

                                                                            slqInsert = @"
                                                                        INSERT INTO[dbo].[InformacionAduanera_terceros11]
                                                                            ([numero]
                                                                            ,[fecha]
                                                                            ,[aduana]
                                                                            ,[Parte_Id]
                                                                            ,[PorCuentadeTerceros_Id]
                                                                            ,[UUID])
                                                                        VALUES
                                                                            ( '" + numero_InformacionAduanera + @"'
                                                                            ,'" + fecha_InformacionAduanera + @"'
                                                                            ,'" + aduana_InformacionAduanera + @"'
                                                                            ," + Parte_Id_Parte_terceros11 + @"
                                                                            ," + PorCuentadeTerceros_Id_PorCuentadeTerceros + @"
                                                                            ,'" + UUID + @"')
                                                                        ";

                                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                            cnn.fnConectarSQLServer();
                                                                            comando.ExecuteNonQuery();
                                                                            comando.Dispose();
                                                                        }
                                                                        else
                                                                        {
                                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node6.Name, " No encontrado") });
                                                                        }
                                                                    }
                                                                }
                                                                else if (Node5.Name == "terceros:Impuestos")
                                                                {
                                                                    string Impuestos_Id_Impuestos_terceros11 = string.Empty;

                                                                    slqInsert = "select isnull(max(Impuestos_Id)+1,1) from Impuestos_terceros11";
                                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    reader = cmdReader.ExecuteReader();
                                                                    if (reader.Read())
                                                                        Impuestos_Id_Impuestos_terceros11 = reader[0].ToString();
                                                                    cmdReader.Dispose();
                                                                    reader.Close();

                                                                    slqInsert = @"
                                                                INSERT INTO[dbo].[Impuestos_terceros11]
                                                                            ([Impuestos_Id]
                                                                            ,[PorCuentadeTerceros_Id]
                                                                            ,[UUID])
                                                                VALUES
                                                                    ( '" + Impuestos_Id_Impuestos_terceros11 + @"'
                                                                    ," + PorCuentadeTerceros_Id_PorCuentadeTerceros + @"
                                                                    ,'" + UUID + @"')
                                                                ";

                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();

                                                                    foreach (XmlNode Node6 in Node5)
                                                                    {
                                                                        if (Node6.Name == "terceros:Traslados")
                                                                        {
                                                                            string Traslados_Id_Traslados_terceros11 = string.Empty;

                                                                            slqInsert = "select isnull(max(Impuestos_Id)+1,1) from Traslados_terceros11";
                                                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                            cnn.fnConectarSQLServer();
                                                                            reader = cmdReader.ExecuteReader();
                                                                            if (reader.Read())
                                                                                Traslados_Id_Traslados_terceros11 = reader[0].ToString();
                                                                            cmdReader.Dispose();
                                                                            reader.Close();

                                                                            slqInsert = @"
                                                                        INSERT INTO[dbo].[Traslados_terceros11]
                                                                                    ([Traslados_Id]
                                                                                    ,[Impuestos_Id]
                                                                                    ,[UUID])
                                                                        VALUES
                                                                            ( " + Traslados_Id_Traslados_terceros11 + @"
                                                                            ," + Impuestos_Id_Impuestos_terceros11 + @"
                                                                            ,'" + UUID + @"')
                                                                        ";

                                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                            cnn.fnConectarSQLServer();
                                                                            comando.ExecuteNonQuery();
                                                                            comando.Dispose();

                                                                            foreach (XmlNode Node7 in Node6)
                                                                            {
                                                                                if (Node7.Name == "terceros:Traslado")
                                                                                {
                                                                                    string impuesto_Traslado_terceros11 = string.Empty;
                                                                                    string tasa_Traslado_terceros11 = string.Empty;
                                                                                    string importe_Traslado_terceros11 = string.Empty;

                                                                                    impuesto_Traslado_terceros11 = fnObtenValorNodo(Node7, "impuesto");
                                                                                    tasa_Traslado_terceros11 = fnObtenValorNodo(Node7, "tasa");
                                                                                    importe_Traslado_terceros11 = fnObtenValorNodo(Node7, "importe");


                                                                                    slqInsert = @"
                                                                                INSERT INTO[dbo].[Traslado_terceros11]
                                                                                            ([impuesto]
                                                                                            ,[tasa]
                                                                                            ,[importe]
                                                                                            ,[Traslados_Id]
                                                                                            ,[UUID])
                                                                                VALUES
                                                                                    ( '" + impuesto_Traslado_terceros11 + @"'
                                                                                    ," + tasa_Traslado_terceros11 + @"
                                                                                    ," + importe_Traslado_terceros11 + @"
                                                                                    ," + Impuestos_Id_Impuestos_terceros11 + @"
                                                                                    ,'" + UUID + @"')
                                                                                ";

                                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                                    cnn.fnConectarSQLServer();
                                                                                    comando.ExecuteNonQuery();
                                                                                    comando.Dispose();
                                                                                }
                                                                                else
                                                                                {
                                                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node7.Name, " No encontrado") });
                                                                                }
                                                                            }

                                                                        }
                                                                        else if (Node6.Name == "terceros:Retenciones")
                                                                        {

                                                                            string Retenciones_Id_Retenciones_terceros11 = string.Empty;

                                                                            slqInsert = "select isnull(max(Impuestos_Id)+1,1) from Traslados_terceros11";
                                                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                            cnn.fnConectarSQLServer();
                                                                            reader = cmdReader.ExecuteReader();
                                                                            if (reader.Read())
                                                                                Retenciones_Id_Retenciones_terceros11 = reader[0].ToString();
                                                                            cmdReader.Dispose();
                                                                            reader.Close();

                                                                            slqInsert = @"
                                                                                INSERT INTO[dbo].[Retenciones_terceros11]
                                                                                            ([Retenciones_Id]
                                                                                            ,[Impuestos_Id]
                                                                                            ,[UUID])
                                                                                VALUES
                                                                                    ( " + Retenciones_Id_Retenciones_terceros11 + @"
                                                                                    ," + Impuestos_Id_Impuestos_terceros11 + @"
                                                                                    ,'" + UUID + @"')
                                                                                ";

                                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                            cnn.fnConectarSQLServer();
                                                                            comando.ExecuteNonQuery();
                                                                            comando.Dispose();

                                                                            foreach (XmlNode Node7 in Node6)
                                                                            {
                                                                                if (Node7.Name == "terceros:Retencion")
                                                                                {

                                                                                    string impuesto_Retencion_terceros11 = string.Empty;
                                                                                    string importe_Retencion_terceros11 = string.Empty;

                                                                                    impuesto_Retencion_terceros11 = fnObtenValorNodo(Node7, "impuesto");
                                                                                    importe_Retencion_terceros11 = fnObtenValorNodo(Node7, "importe");

                                                                                    slqInsert = @"
                                                                                INSERT INTO[dbo].[Retencion_terceros11]
                                                                                            ([impuesto]
                                                                                            ,[importe]
                                                                                            ,[Retenciones_Id]
                                                                                            ,[UUID])
                                                                                VALUES
                                                                                    ( " + impuesto_Retencion_terceros11 + @"
                                                                                    ," + importe_Retencion_terceros11 + @"
                                                                                    ," + Impuestos_Id_Impuestos_terceros11 + @"
                                                                                    ,'" + UUID + @"')
                                                                                ";

                                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                                    cnn.fnConectarSQLServer();
                                                                                    comando.ExecuteNonQuery();
                                                                                    comando.Dispose();
                                                                                }
                                                                                else
                                                                                {
                                                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node7.Name, " No encontrado") });
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node6.Name, " No encontrado") });
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node5.Name, " No encontrado") });
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node4.Name, " No encontrado") });
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node3.Name, " No encontrado") });
                                                }
                                            }
                                        }
                                        else
                                        {
                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node2.Name, " No encontrado") });
                                        }
                                    }
                                }
                                else if (Node1.Name == "cfdi:Impuestos")
                                {
                                    TotalImpuestosRetenidos = fnObtenValorNodo(Node1, "TotalImpuestosRetenidos");
                                    TotalImpuestosTrasladados = fnObtenValorNodo(Node1, "TotalImpuestosTrasladados");

                                    slqInsert = "select isnull(max(Impuestos_Id)+1,1) from ImpuestosNodo0";
                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    reader = cmdReader.ExecuteReader();
                                    if (reader.Read())
                                        Impuestos_IdNodo0 = reader[0].ToString();
                                    cmdReader.Dispose();
                                    reader.Close();

                                    slqInsert = @"
                                INSERT INTO [dbo].[ImpuestosNodo0]
                                    ([Impuestos_Id]
                                    ,[Comprobante_Id]
                                    ,[TotalImpuestosRetenidos]
                                    ,[TotalImpuestosTrasladados]
                                    ,UUID)
                                VALUES
                                    ( " + Impuestos_IdNodo0 + @"
                                    ," + Comprobante_Id + @"
                                    ," + TotalImpuestosRetenidos + @"
                                    ," + TotalImpuestosTrasladados + @"
                                    ,'" + UUID + @"')
                                ";
                                    slqInsert = slqInsert.Replace("'null'", "null");
                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    comando.ExecuteNonQuery();
                                    comando.Dispose();

                                    foreach (XmlNode Node6 in Node1)
                                    {
                                        if (Node6.Name == "cfdi:Retenciones")
                                        {
                                            slqInsert = "select isnull(max(Retenciones_Id)+1,1) from RetencionesNodo0";
                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            reader = cmdReader.ExecuteReader();
                                            if (reader.Read())
                                                Retenciones_Id_IdNodo0 = reader[0].ToString();
                                            cmdReader.Dispose();
                                            reader.Close();

                                            slqInsert = @"
                                        INSERT INTO [dbo].[RetencionesNodo0]
                                            ([Retenciones_Id]
                                            ,[Impuestos_Id]
                                            ,UUID)
                                        VALUES
                                            ( " + Retenciones_Id_IdNodo0 + @"
                                            ," + Impuestos_IdNodo0 + @"
                                            ,'" + UUID + @"')
                                        ";
                                            slqInsert = slqInsert.Replace("'null'", "null");
                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            comando.ExecuteNonQuery();
                                            comando.Dispose();

                                            foreach (XmlNode Node7 in Node6)
                                            {
                                                if (Node7.Name == "cfdi:Retencion")
                                                {
                                                    BaseNodo0 = fnObtenValorNodo(Node7, "Base");
                                                    ImpuestoNodo0 = fnObtenValorNodo(Node7, "Impuesto");
                                                    TipoFactorNodo0 = fnObtenValorNodo(Node7, "TipoFactor");
                                                    TasaOCuotaNodo0 = fnObtenValorNodo(Node7, "TasaOCuota");
                                                    ImporteNodo0 = fnObtenValorNodo(Node7, "Importe");



                                                    slqInsert = @"
                                                INSERT INTO [dbo].[RetencionNodo0]
                                                    ([Impuesto]
                                                    ,[Importe]
                                                    ,[Retenciones_Id]
                                                    ,UUID)
                                                VALUES
                                                    ('" + ImpuestoNodo0 + @"'
                                                    ," + ImporteNodo0 + @"
                                                    ," + Retenciones_Id_IdNodo0 + @"
                                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();
                                                }
                                                else
                                                {
                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node7.Name, " No encontrado") });
                                                }

                                            }
                                        }
                                        else if (Node6.Name == "cfdi:Traslados")
                                        {
                                            slqInsert = "select isnull(max(Traslados_Id)+1,1) from TrasladosNodo0";
                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            reader = cmdReader.ExecuteReader();
                                            if (reader.Read())
                                                Traslados_Id_IdNodo0 = reader[0].ToString();
                                            cmdReader.Dispose();
                                            reader.Close();

                                            slqInsert = @"
                                        INSERT INTO [dbo].[TrasladosNodo0]
                                                ([Traslados_Id]
                                                ,[Impuestos_Id]
                                                ,UUID)
                                        VALUES
                                            ( " + Traslados_Id_IdNodo0 + @"
                                            ," + Impuestos_IdNodo0 + @"
                                                                ,'" + UUID + @"')
                                        ";
                                            slqInsert = slqInsert.Replace("'null'", "null");
                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            comando.ExecuteNonQuery();
                                            comando.Dispose();

                                            foreach (XmlNode Node7 in Node6)
                                            {
                                                if (Node7.Name == "cfdi:Traslado")
                                                {
                                                    BaseRNodo0 = fnObtenValorNodo(Node7, "Base");
                                                    ImpuestoRNodo0 = fnObtenValorNodo(Node7, "Impuesto");
                                                    TipoFactorRNodo0 = fnObtenValorNodo(Node7, "TipoFactor");
                                                    TasaOCuotaRNodo0 = fnObtenValorNodo(Node7, "TasaOCuota");
                                                    ImporteRNodo0 = fnObtenValorNodo(Node7, "Importe");



                                                    slqInsert = @"
                                                INSERT INTO [dbo].[TrasladoNodo0]
                                                    ([Impuesto]
                                                    ,[TipoFactor]
                                                    ,[TasaOCuota]
                                                    ,[Importe]
                                                    ,[Traslados_Id]
                                                    ,UUID)
                                                VALUES
                                                    ('" + ImpuestoRNodo0 + @"'
                                                    ,'" + TipoFactorRNodo0 + @"'
                                                    ," + TasaOCuotaRNodo0 + @"
                                                    ," + ImporteRNodo0 + @"
                                                    ," + Traslados_Id_IdNodo0 + @"
                                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();
                                                }
                                                else
                                                {
                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node7.Name, " No encontrado") });
                                                }

                                            }
                                        }
                                        else
                                        {
                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node6.Name, " No encontrado") });
                                        }

                                    }

                                }
                                else if (Node1.Name == "cfdi:Complemento")
                                {
                                    slqInsert = "select isnull(max(Complemento_Id)+1,1) from Complemento";
                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    reader = cmdReader.ExecuteReader();
                                    if (reader.Read())
                                        Complemento_Id = reader[0].ToString();
                                    cmdReader.Dispose();
                                    reader.Close();

                                    slqInsert = @"
                                INSERT INTO [dbo].[Complemento]
                                    ([Comprobante_Id]
                                    ,[Complemento_Id]
                                    ,UUID)
                                VALUES
                                    ( " + Comprobante_Id + @"
                                    ," + Complemento_Id + @"
                                    ,'" + UUID + @"')
                                ";
                                    slqInsert = slqInsert.Replace("'null'", "null");
                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    comando.ExecuteNonQuery();
                                    comando.Dispose();

                                    foreach (XmlNode Node6 in Node1)
                                    {
                                        if (Node6.Name == "tfd:TimbreFiscalDigital")
                                        {
                                            VersionTimbreFiscal = fnObtenValorNodo(Node6, "Version");
                                            UUID = fnObtenValorNodo(Node6, "UUID");
                                            FechaTimbrado = fnObtenValorNodo(Node6, "FechaTimbrado");
                                            RfcProvCertif = fnObtenValorNodo(Node6, "RfcProvCertif");
                                            TDLeyenda = fnObtenValorNodo(Node6, "Leyenda");
                                            SelloCFD = fnObtenValorNodo(Node6, "SelloCFD");
                                            NoCertificadoSAT = fnObtenValorNodo(Node6, "NoCertificadoSAT");
                                            SelloSAT = fnObtenValorNodo(Node6, "SelloSAT");

                                            slqInsert = @"
                                        INSERT INTO [dbo].[TimbreFiscalDigital]
                                            ([Version]
                                            ,[UUID]
                                            ,[FechaTimbrado]
                                            ,[RfcProvCertif]
                                            ,[Leyenda]
                                            ,[SelloCFD]
                                            ,[NoCertificadoSAT]
                                            ,[SelloSAT]
                                            ,[Complemento_Id])
                                        VALUES
                                            ( '" + VersionTimbreFiscal + @"'
                                            ,'" + UUID + @"'
                                            ,'" + FechaTimbrado + @"'
                                            ,'" + RfcProvCertif + @"'
                                            ,'" + TDLeyenda + @"'
                                            ,'" + SelloCFD + @"'
                                            ,'" + NoCertificadoSAT + @"'
                                            ,'" + SelloSAT + @"'
                                            ," + Complemento_Id + @")
                                        ";
                                            slqInsert = slqInsert.Replace("'null'", "null");
                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            comando.ExecuteNonQuery();
                                            comando.Dispose();
                                        }
                                        else if (Node6.Name == "pago10:Pagos")
                                        {
                                            VersionPagos = fnObtenValorNodo(Node6, "Version");

                                            slqInsert = "select isnull(max(Pagos_Id)+1,1) from Pagos";
                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            reader = cmdReader.ExecuteReader();
                                            if (reader.Read())
                                                Pagos_Id = reader[0].ToString();
                                            cmdReader.Dispose();
                                            reader.Close();

                                            slqInsert = @"
                                        INSERT INTO [dbo].[Pagos]
                                            ([Pagos_Id]
                                            ,[Complemento_Id]
                                            ,[Version]
                                            ,UUID)
                                        VALUES
                                            ( " + Pagos_Id + @"
                                              ," + Complemento_Id + @"
                                            ,'" + VersionPagos + @"'
                                            ,'" + UUID + @"')
                                        ";
                                            slqInsert = slqInsert.Replace("'null'", "null");
                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            comando.ExecuteNonQuery();
                                            comando.Dispose();

                                            foreach (XmlNode Node7 in Node6)
                                            {
                                                if (Node7.Name == "pago10:Pago")
                                                {
                                                    PagoFechaPago = fnObtenValorNodo(Node7, "FechaPago");
                                                    PagoFormaDePagoP = fnObtenValorNodo(Node7, "FormaDePagoP");
                                                    PagoMonedaP = fnObtenValorNodo(Node7, "MonedaP");
                                                    PagoTipoCambioP = fnObtenValorNodo(Node7, "TipoCambioP");
                                                    PagoMonto = fnObtenValorNodo(Node7, "Monto");
                                                    NumOperacionPago = fnObtenValorNodo(Node7, "NumOperacionPago");
                                                    PagoRfcEmisorCtaOrd = fnObtenValorNodo(Node7, "RfcEmisorCtaOrd");
                                                    PagoNomBancoOrdExt = fnObtenValorNodo(Node7, "NomBancoOrdExt");
                                                    PagoCtaOrdenante = fnObtenValorNodo(Node7, "CtaOrdenante");
                                                    PagoRfcEmisorCtaBen = fnObtenValorNodo(Node7, "RfcEmisorCtaBen");
                                                    PagoCtaBeneficiario = fnObtenValorNodo(Node7, "CtaBeneficiario");
                                                    TipoCadPago = fnObtenValorNodo(Node7, "TipoCadPago");
                                                    CertPago = fnObtenValorNodo(Node7, "CertPago");
                                                    CadPago = fnObtenValorNodo(Node7, "CadPago");
                                                    SelloPago = fnObtenValorNodo(Node7, "SelloPago");

                                                    slqInsert = "select isnull(max(Pago_Id)+1,1) from Pago";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        Pago_Id = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                INSERT INTO [dbo].[Pago]
                                                    ([FechaPago]
                                                    ,[FormaDePagoP]
                                                    ,[MonedaP]
                                                    ,[TipoCambioP]
                                                    ,[Monto]
                                                    , NumOperacion
                                                    ,[RfcEmisorCtaOrd]
                                                    ,[NomBancoOrdExt]
                                                    ,[CtaOrdenante]
                                                    ,[RfcEmisorCtaBen]
                                                    ,[CtaBeneficiario]
                                                    ,[TipoCadPago]
                                                    ,[CertPago]
                                                    ,[CadPago]
                                                    ,[SelloPago]
                                                    ,[Pago_Id]
                                                    ,[Pagos_Id]
                                                    ,UUID)
                                                VALUES
                                                    ( '" + PagoFechaPago + @"'
                                                      ,'" + PagoFormaDePagoP + @"'
                                                      ,'" + PagoMonedaP + @"'
                                                      ," + PagoTipoCambioP + @"
                                                      ," + PagoMonto + @"
                                                      ,'" + NumOperacionPago + @"'
                                                      ,'" + PagoRfcEmisorCtaOrd + @"'
                                                      ,'" + PagoNomBancoOrdExt + @"'
                                                      ,'" + PagoCtaOrdenante + @"'
                                                      ,'" + PagoRfcEmisorCtaBen + @"'
                                                      ,'" + PagoCtaBeneficiario + @"'
                                                      ,'" + TipoCadPago + @"'
                                                      ,'" + CertPago + @"'
                                                      ,'" + CadPago + @"'
                                                      ,'" + SelloPago + @"'
                                                      ," + Pago_Id + @"
                                                      ," + Pagos_Id + @"
                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node8 in Node7)
                                                    {
                                                        if (Node8.Name == "pago10:DoctoRelacionado")
                                                        {
                                                            doctoIdDocumento = fnObtenValorNodo(Node8, "IdDocumento");
                                                            docSerie = fnObtenValorNodo(Node8, "Serie");
                                                            docFolio = fnObtenValorNodo(Node8, "Folio");
                                                            doctoMonedaDR = fnObtenValorNodo(Node8, "MonedaDR");
                                                            docTipoCambioDR = fnObtenValorNodo(Node8, "TipoCambioDR");
                                                            doctoMetodoDePagoDR = fnObtenValorNodo(Node8, "MetodoDePagoDR");
                                                            doctoNumParcialidad = fnObtenValorNodo(Node8, "NumParcialidad");
                                                            doctoImpSaldoAnt = fnObtenValorNodo(Node8, "ImpSaldoAnt");
                                                            doctoImpPagado = fnObtenValorNodo(Node8, "ImpPagado");
                                                            doctoImpSaldoInsoluto = fnObtenValorNodo(Node8, "ImpSaldoInsoluto");

                                                            slqInsert = @"
                                                        INSERT INTO [dbo].[DoctoRelacionado]
                                                            ([IdDocumento]
                                                            ,[Serie]
															,[Folio]
                                                            ,[MonedaDR]
                                                            ,[TipoCambioDR]															   
                                                            ,[MetodoDePagoDR]
                                                            ,[NumParcialidad]
                                                            ,[ImpSaldoAnt]
                                                            ,[ImpPagado]
                                                            ,[ImpSaldoInsoluto]
                                                            ,[Pago_Id]
                                                            ,UUID)
                                                        VALUES
                                                        ( '" + doctoIdDocumento + @"'
                                                            ,'" + docSerie + @"'
                                                            ,'" + docFolio + @"'
                                                            ,'" + doctoMonedaDR + @"'
                                                            ,'" + docTipoCambioDR + @"'
                                                            ,'" + doctoMetodoDePagoDR + @"'
                                                            ," + doctoNumParcialidad + @"
                                                            ," + doctoImpSaldoAnt + @"
                                                            ," + doctoImpPagado + @"
                                                            ," + doctoImpSaldoInsoluto + @"
                                                            ," + Pago_Id + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node8.Name, " No encontrado") });
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node7.Name, " No encontrado") });
                                                }

                                            }
                                        }
                                        else if (Node6.Name == "nomina12:Nomina")
                                        {
                                            Version_nomina = fnObtenValorNodo(Node6, "Version");
                                            TipoNomina_nomina = fnObtenValorNodo(Node6, "TipoNomina");
                                            FechaPago_nomina = fnObtenValorNodo(Node6, "FechaPago");
                                            FechaInicialPago_nomina = fnObtenValorNodo(Node6, "FechaInicialPago");
                                            FechaFinalPago_nomina = fnObtenValorNodo(Node6, "FechaFinalPago");
                                            NumDiasPagados_nomina = fnObtenValorNodo(Node6, "NumDiasPagados");
                                            TotalPercepciones_nomina = fnObtenValorNodo(Node6, "TotalPercepciones");
                                            TotalDeducciones_nomina = fnObtenValorNodo(Node6, "TotalDeducciones");
                                            TotalOtrosPagos_nomina = fnObtenValorNodo(Node6, "TotalOtrosPagos");
                                            Nomina_Id_nomina = fnObtenValorNodo(Node6, "Nomina_Id");

                                            slqInsert = "select isnull(max(Nomina_Id)+1,1) from nomina";
                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            reader = cmdReader.ExecuteReader();
                                            if (reader.Read())
                                                Nomina_Id_nomina = reader[0].ToString();
                                            cmdReader.Dispose();
                                            reader.Close();

                                            slqInsert = @"
                                        INSERT INTO [dbo].[Nomina]
                                            ([Version]
                                            ,[TipoNomina]
                                            ,[FechaPago]
                                            ,[FechaInicialPago]
                                            ,[FechaFinalPago]
                                            ,[NumDiasPagados]
                                            ,[TotalPercepciones]
                                            ,[TotalDeducciones]
                                            ,[TotalOtrosPagos]
                                            ,[Nomina_Id]
                                            ,[Complemento_Id]
                                            ,UUID)
                                        VALUES
                                            ( '" + VersionPagos + @"'
                                            ,'" + TipoNomina_nomina + @"'
                                            ,'" + FechaPago_nomina + @"'
                                            ,'" + FechaInicialPago_nomina + @"'
                                            ,'" + FechaFinalPago_nomina + @"'
                                            ," + NumDiasPagados_nomina + @"
                                            ," + TotalPercepciones_nomina + @"
                                            ," + TotalDeducciones_nomina + @"
                                            ," + TotalOtrosPagos_nomina + @"
                                            ," + Nomina_Id_nomina + @"
                                            ," + Complemento_Id + @"
                                            ,'" + UUID + @"')
                                        ";
                                            slqInsert = slqInsert.Replace("'null'", "null");
                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            comando.ExecuteNonQuery();
                                            comando.Dispose();

                                            foreach (XmlNode Node7 in Node6)
                                            {
                                                if (Node7.Name == "nomina12:Emisor")
                                                {
                                                    Curp_emisornomina = fnObtenValorNodo(Node7, "Curp");
                                                    RegistroPatronal_emisornomina = fnObtenValorNodo(Node7, "RegistroPatronal");
                                                    RfcPatronOrigen_emisornomina = fnObtenValorNodo(Node7, "RfcPatronOrigen");
                                                    //Emisor_Id = fnObtenValorNodo(Node7, "Emisor");



                                                    slqInsert = "select isnull(max(Emisor_Id)+1,1) from EmisorNomina";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        Emisor_Id = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                INSERT INTO dbo.EmisorNomina
                                                        (Curp
                                                        ,RegistroPatronal
                                                        ,RfcPatronOrigen
                                                        ,Emisor_Id
                                                        ,Nomina_Id
                                                        ,UUID)
                                                VALUES
                                                    ( '" + Curp_emisornomina + @"'
                                                    ,'" + RegistroPatronal_emisornomina + @"'
                                                    ,'" + RfcPatronOrigen_emisornomina + @"'
                                                    ," + Emisor_Id + @"
                                                    ," + Nomina_Id_nomina + @"
                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node8 in Node7)
                                                    {
                                                        if (Node8.Name == "nomina12:EntidadSNCF")
                                                        {
                                                            OrigenRecurso_nominaentidadsncf = fnObtenValorNodo(Node8, "OrigenRecurso");
                                                            MontoRecursoPropio_nominaentidadsncf = fnObtenValorNodo(Node8, "MontoRecursoPropio");

                                                            slqInsert = @"
                                                        INSERT INTO dbo.EntidadSNCF
                                                            (OrigenRecurso
                                                            ,MontoRecursoPropio
                                                            ,Emisor_Id
                                                            ,UUID)
                                                        VALUES
                                                            ( '" + OrigenRecurso_nominaentidadsncf + @"'
                                                            ," + MontoRecursoPropio_nominaentidadsncf + @"
                                                            ," + Emisor_Id + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node8.Name, " No encontrado") });
                                                        }
                                                    }
                                                }
                                                else if (Node7.Name == "nomina12:Receptor")
                                                {
                                                    Curp_receptornomina = fnObtenValorNodo(Node7, "Curp");
                                                    NumSeguridadSocial_receptornomina = fnObtenValorNodo(Node7, "NumSeguridadSocial");
                                                    FechaInicioRelLaboral_receptornomina = fnObtenValorNodo(Node7, "FechaInicioRelLaboral");
                                                    Antigüedad_receptornomina = fnObtenValorNodo(Node7, "Antigüedad");
                                                    TipoContrato_receptornomina = fnObtenValorNodo(Node7, "TipoContrato");
                                                    Sindicalizado_receptornomina = fnObtenValorNodo(Node7, "Sindicalizado");
                                                    TipoJornada_receptornomina = fnObtenValorNodo(Node7, "TipoJornada");
                                                    TipoRegimen_receptornomina = fnObtenValorNodo(Node7, "TipoRegimen");
                                                    NumEmpleado_receptornomina = fnObtenValorNodo(Node7, "NumEmpleado");
                                                    Departamento_receptornomina = fnObtenValorNodo(Node7, "Departamento");
                                                    Puesto_receptornomina = fnObtenValorNodo(Node7, "Puesto");
                                                    RiesgoPuesto_receptornomina = fnObtenValorNodo(Node7, "RiesgoPuesto");
                                                    PeriodicidadPago_receptornomina = fnObtenValorNodo(Node7, "PeriodicidadPago");
                                                    Banco_receptornomina = fnObtenValorNodo(Node7, "Banco");
                                                    CuentaBancaria_receptornomina = fnObtenValorNodo(Node7, "CuentaBancaria");
                                                    SalarioBaseCotApor_receptornomina = fnObtenValorNodo(Node7, "SalarioBaseCotApor");
                                                    SalarioDiarioIntegrado_receptornomina = fnObtenValorNodo(Node7, "SalarioDiarioIntegrado");
                                                    ClaveEntFed_receptornomina = fnObtenValorNodo(Node7, "ClaveEntFed");

                                                    slqInsert = "select isnull(max(Receptor_Id)+1,1) from ReceptorNomina";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        Receptor_Id_receptornomina = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                INSERT INTO dbo.ReceptorNomina
                                                    (Curp
                                                    ,NumSeguridadSocial
                                                    ,FechaInicioRelLaboral
                                                    ,Antigüedad
                                                    ,TipoContrato
                                                    ,Sindicalizado
                                                    ,TipoJornada
                                                    ,TipoRegimen
                                                    ,NumEmpleado
                                                    ,Departamento
                                                    ,Puesto
                                                    ,RiesgoPuesto
                                                    ,PeriodicidadPago
                                                    ,Banco
                                                    ,CuentaBancaria
                                                    ,SalarioBaseCotApor
                                                    ,SalarioDiarioIntegrado
                                                    ,ClaveEntFed
                                                    ,Receptor_Id
                                                    ,Nomina_Id
                                                    ,UUID)
                                                VALUES
                                                    ('" + Curp_receptornomina + @"'
                                                    ,'" + NumSeguridadSocial_receptornomina + @"'
                                                    ,'" + FechaInicioRelLaboral_receptornomina + @"'
                                                    ,'" + Antigüedad_receptornomina + @"'
                                                    ,'" + TipoContrato_receptornomina + @"'
                                                    ,'" + Sindicalizado_receptornomina + @"'
                                                    ,'" + TipoJornada_receptornomina + @"'
                                                    ,'" + TipoRegimen_receptornomina + @"'
                                                    ,'" + NumEmpleado_receptornomina + @"'
                                                    ,'" + Departamento_receptornomina + @"'
                                                    ,'" + Puesto_receptornomina + @"'
                                                    ,'" + RiesgoPuesto_receptornomina + @"'
                                                    ,'" + PeriodicidadPago_receptornomina + @"'
                                                    ,'" + Banco_receptornomina + @"'
                                                    ," + CuentaBancaria_receptornomina + @"
                                                    ," + SalarioBaseCotApor_receptornomina + @"
                                                    ," + SalarioDiarioIntegrado_receptornomina + @"
                                                    ,'" + ClaveEntFed_receptornomina + @"'
                                                    ," + Receptor_Id_receptornomina + @"
                                                    ," + Nomina_Id_nomina + @"
                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node8 in Node7)
                                                    {
                                                        if (Node8.Name == "nomina12:SubContratacion")
                                                        {
                                                            RfcLabora_nominasubcontratacion = fnObtenValorNodo(Node8, "RfcLabora");
                                                            PorcentajeTiempo_nominasubcontratacion = fnObtenValorNodo(Node8, "PorcentajeTiempo");

                                                            slqInsert = @"
                                                        INSERT INTO dbo.SubContratacion
                                                            (RfcLabora
                                                            ,PorcentajeTiempo
                                                            ,Receptor_Id
                                                            ,UUID)
                                                        VALUES
                                                            ( '" + RfcLabora_nominasubcontratacion + @"'
                                                            ," + PorcentajeTiempo_nominasubcontratacion + @"
                                                            ," + Receptor_Id_receptornomina + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node8.Name, " No encontrado") });
                                                        }
                                                    }
                                                }
                                                else if (Node7.Name == "nomina12:Deducciones")
                                                {
                                                    TotalOtrasDeducciones_nominadeducciones = fnObtenValorNodo(Node7, "TotalOtrasDeducciones");
                                                    TotalImpuestosRetenidos_nominadeducciones = fnObtenValorNodo(Node7, "TotalImpuestosRetenidos");

                                                    slqInsert = "select isnull(max(Deducciones_Id)+1,1) from Deducciones";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        Deducciones_Id_nominadeducciones = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                INSERT INTO dbo.Deducciones
                                                    (TotalOtrasDeducciones
                                                    ,TotalImpuestosRetenidos
                                                    ,Deducciones_Id
                                                    ,Nomina_Id
                                                    ,UUID)
                                                VALUES
                                                    (" + TotalOtrasDeducciones_nominadeducciones + @"
                                                    ," + TotalImpuestosRetenidos_nominadeducciones + @"
                                                    ," + Deducciones_Id_nominadeducciones + @"
                                                    ," + Nomina_Id_nomina + @"
                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node8 in Node7)
                                                    {
                                                        if (Node8.Name == "nomina12:Deduccion")
                                                        {
                                                            TipoDeduccion_nominadeduccion = fnObtenValorNodo(Node8, "TipoDeduccion");
                                                            Clave_nominadeduccion = fnObtenValorNodo(Node8, "Clave");
                                                            Concepto_nominadeduccion = fnObtenValorNodo(Node8, "Concepto");
                                                            Importe_nominadeduccion = fnObtenValorNodo(Node8, "Importe");

                                                            slqInsert = @"
                                                        INSERT INTO dbo.Deduccion
                                                            (TipoDeduccion
                                                            ,Clave
                                                            ,Concepto
                                                            ,Importe
                                                            ,Deducciones_Id
                                                            ,UUID)
                                                        VALUES
                                                            ( '" + TipoDeduccion_nominadeduccion + @"'
                                                            ,'" + Clave_nominadeduccion + @"'
                                                            ,'" + Concepto_nominadeduccion + @"'
                                                            ," + Importe_nominadeduccion + @"
                                                            ," + Deducciones_Id_nominadeducciones + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node8.Name, " No encontrado") });
                                                        }
                                                    }
                                                }
                                                else if (Node7.Name == "nomina12:Percepciones")
                                                {
                                                    TotalSueldos_nominapercepciones = fnObtenValorNodo(Node7, "TotalSueldos");
                                                    TotalSeparacionIndemnizacion_nominapercepciones = fnObtenValorNodo(Node7, "TotalSeparacionIndemnizacion");
                                                    TotalJubilacionPensionRetiro_nominapercepciones = fnObtenValorNodo(Node7, "TotalJubilacionPensionRetiro");
                                                    TotalGravado_nominapercepciones = fnObtenValorNodo(Node7, "TotalGravado");
                                                    TotalExento_nominapercepciones = fnObtenValorNodo(Node7, "TotalExento");

                                                    slqInsert = "select isnull(max(Percepciones_Id)+1,1) from Percepciones";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        Percepciones_Id_nominapercepciones = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                INSERT INTO dbo.Percepciones
                                                    (TotalSueldos
                                                    ,TotalSeparacionIndemnizacion
                                                    ,TotalJubilacionPensionRetiro
                                                    ,TotalGravado
                                                    ,TotalExento
                                                    ,Percepciones_Id
                                                    ,Nomina_Id
                                                    ,UUID)
                                                 VALUES
                                                    (" + TotalSueldos_nominapercepciones + @"
                                                    ," + TotalSeparacionIndemnizacion_nominapercepciones + @"
                                                    ," + TotalJubilacionPensionRetiro_nominapercepciones + @"
                                                    ," + TotalGravado_nominapercepciones + @"
                                                    ," + TotalExento_nominapercepciones + @"
                                                    ," + Percepciones_Id_nominapercepciones + @"
                                                    ," + Nomina_Id_nomina + @"
                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node8 in Node7)
                                                    {
                                                        if (Node8.Name == "nomina12:Percepcion")
                                                        {
                                                            TipoPercepcion_nominapercepcion = fnObtenValorNodo(Node8, "TipoPercepcion");
                                                            Clave_nominapercepcion = fnObtenValorNodo(Node8, "Clave");
                                                            Concepto_nominapercepcion = fnObtenValorNodo(Node8, "Concepto");
                                                            ImporteGravado_nominapercepcion = fnObtenValorNodo(Node8, "ImporteGravado");
                                                            ImporteExento_nominapercepcion = fnObtenValorNodo(Node8, "ImporteExento");

                                                            slqInsert = "select isnull(max(Percepcion_Id)+1,1) from Percepcion";
                                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            reader = cmdReader.ExecuteReader();
                                                            if (reader.Read())
                                                                Percepcion_Id_nominapercepcion = reader[0].ToString();
                                                            cmdReader.Dispose();
                                                            reader.Close();

                                                            slqInsert = @"
                                                        INSERT INTO [dbo].[Percepcion]
                                                            ([TipoPercepcion]
                                                            ,[Clave]
                                                            ,[Concepto]
                                                            ,[ImporteGravado]
                                                            ,[ImporteExento]
                                                            ,[Percepcion_Id]
                                                            ,[Percepciones_Id]
                                                            ,UUID)
                                                        VALUES
                                                            ( '" + TipoPercepcion_nominapercepcion + @"'
                                                            ,'" + Clave_nominapercepcion + @"'
                                                            ,'" + Concepto_nominapercepcion + @"'
                                                            ," + ImporteGravado_nominapercepcion + @"
                                                            ," + ImporteExento_nominapercepcion + @"
                                                            ," + Percepcion_Id_nominapercepcion + @"
                                                            ," + Percepciones_Id_nominapercepciones + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();

                                                            foreach (XmlNode Node9 in Node8)
                                                            {
                                                                if (Node9.Name == "nomina12:AccionesOTitulos")
                                                                {
                                                                    ValorMercado_nominaaccionesotitulos = fnObtenValorNodo(Node9, "ValorMercado");
                                                                    PrecioAlOtorgarse_nominaaccionesotitulos = fnObtenValorNodo(Node9, "PrecioAlOtorgarse");

                                                                    slqInsert = @"
                                                                INSERT INTO dbo.AccionesOTitulos
                                                                    (ValorMercado
                                                                    ,PrecioAlOtorgarse
                                                                    ,Percepcion_Id
                                                                    ,UUID)
                                                                VALUES
                                                                    ( " + ValorMercado_nominaaccionesotitulos + @"
                                                                    ," + PrecioAlOtorgarse_nominaaccionesotitulos + @"
                                                                    ," + Percepcion_Id_nominapercepcion + @"
                                                                    ,'" + UUID + @"')
                                                                ";
                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();
                                                                }
                                                                else if (Node9.Name == "nomina12:HorasExtra")
                                                                {
                                                                    Dias_nominahorasextra = fnObtenValorNodo(Node9, "Dias");
                                                                    TipoHoras_nominahorasextra = fnObtenValorNodo(Node9, "TipoHoras");
                                                                    HorasExtra_nominahorasextra = fnObtenValorNodo(Node9, "HorasExtra");
                                                                    ImportePagado_nominahorasextra = fnObtenValorNodo(Node9, "ImportePagado");

                                                                    slqInsert = @"
                                                                INSERT INTO dbo.HorasExtra
                                                                    (Dias
                                                                    ,TipoHoras
                                                                    ,HorasExtra
                                                                    ,ImportePagado
                                                                    ,Percepcion_Id
                                                                    ,UUID)
                                                                VALUES
                                                                    ( " + Dias_nominahorasextra + @"
                                                                    ,'" + TipoHoras_nominahorasextra + @"'
                                                                    ," + HorasExtra_nominahorasextra + @"
                                                                    ," + ImportePagado_nominahorasextra + @"
                                                                    ," + Percepcion_Id_nominapercepcion + @"
                                                                    ,'" + UUID + @"')
                                                                ";
                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();
                                                                }
                                                                else
                                                                {
                                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node9.Name, " No encontrado") });
                                                                }
                                                            }
                                                        }
                                                        else if (Node8.Name == "nomina12:SeparacionIndemnizacion")
                                                        {
                                                            TotalPagado_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "TotalPagado");
                                                            NumAñosServicio_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "NumAñosServicio");
                                                            UltimoSueldoMensOrd_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "UltimoSueldoMensOrd");
                                                            IngresoAcumulable_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "IngresoAcumulable");
                                                            IngresoNoAcumulable_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "IngresoNoAcumulable");

                                                            slqInsert = @"
                                                        INSERT INTO dbo.SeparacionIndemnizacion
                                                            (TotalPagado
                                                            ,NumAñosServicio
                                                            ,UltimoSueldoMensOrd
                                                            ,IngresoAcumulable
                                                            ,IngresoNoAcumulable
                                                            ,Percepciones_Id
                                                            ,UUID)
                                                        VALUES
                                                            ( " + TotalPagado_nominaeparacionIndemnizacion + @"
                                                            ," + NumAñosServicio_nominaeparacionIndemnizacion + @"
                                                            ," + UltimoSueldoMensOrd_nominaeparacionIndemnizacion + @"
                                                            ," + IngresoAcumulable_nominaeparacionIndemnizacion + @"
                                                            ," + IngresoNoAcumulable_nominaeparacionIndemnizacion + @"
                                                            ," + Percepciones_Id_nominapercepciones + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else if (Node8.Name == "nomina12:JubilacionPensionRetiro")
                                                        {
                                                            TotalUnaExhibicion_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "TotalUnaExhibicion");
                                                            TotalParcialidad_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "TotalParcialidad");
                                                            MontoDiario_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "MontoDiario");
                                                            IngresoAcumulable_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "IngresoAcumulable");
                                                            IngresoNoAcumulable_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "IngresoNoAcumulable");

                                                            slqInsert = @"
                                                        INSERT INTO dbo.JubilacionPensionRetiro
                                                            (TotalUnaExhibicion
                                                            ,TotalParcialidad
                                                            ,MontoDiario
                                                            ,IngresoAcumulable
                                                            ,IngresoNoAcumulable
                                                            ,Percepciones_Id
                                                            ,UUID)
                                                        VALUES
                                                            ( " + TotalUnaExhibicion_nominaJubilacionPensionRetiro + @"
                                                            ," + TotalParcialidad_nominaJubilacionPensionRetiro + @"
                                                            ," + MontoDiario_nominaJubilacionPensionRetiro + @"
                                                            ," + IngresoAcumulable_nominaJubilacionPensionRetiro + @"
                                                            ," + IngresoNoAcumulable_nominaJubilacionPensionRetiro + @"
                                                            ," + Percepciones_Id_nominapercepciones + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node8.Name, " No encontrado") });
                                                        }
                                                    }
                                                }
                                                else if (Node7.Name == "nomina12:OtrosPagos")
                                                {
                                                    slqInsert = "select isnull(max(OtrosPagos_Id)+1,1) from OtrosPagos";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        OtrosPagos_Id_nominaOtrosPagos = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                INSERT INTO dbo.OtrosPagos
                                                    (OtrosPagos_Id
                                                    ,Nomina_Id
                                                    ,UUID)
                                                 VALUES
                                                    (" + OtrosPagos_Id_nominaOtrosPagos + @"
                                                    ," + Nomina_Id_nomina + @"
                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node8 in Node7)
                                                    {
                                                        if (Node8.Name == "nomina12:OtroPago")
                                                        {
                                                            TipoOtroPago_nominaOtroPago = fnObtenValorNodo(Node8, "TipoOtroPago");
                                                            Clave_nominaOtroPago = fnObtenValorNodo(Node8, "Clave");
                                                            Concepto_nominaOtroPago = fnObtenValorNodo(Node8, "Concepto");
                                                            Importe_nominaOtroPago = fnObtenValorNodo(Node8, "Importe");

                                                            slqInsert = "select isnull(max(OtroPago_Id)+1,1) from OtroPago";
                                                            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            reader = cmdReader.ExecuteReader();
                                                            if (reader.Read())
                                                                OtroPago_Id_nominaOtroPago = reader[0].ToString();
                                                            cmdReader.Dispose();
                                                            reader.Close();

                                                            slqInsert = @"
                                                        INSERT INTO [dbo].[OtroPago]
                                                            ([TipoOtroPago]
                                                            ,[Clave]
                                                            ,[Concepto]
                                                            ,[Importe]
                                                            ,[OtroPago_Id]
                                                            ,[OtrosPagos_Id]
                                                            ,UUID)
                                                        VALUES
                                                            ( '" + TipoOtroPago_nominaOtroPago + @"'
                                                            ,'" + Clave_nominaOtroPago + @"'
                                                            ,'" + Concepto_nominaOtroPago + @"'
                                                            ," + Importe_nominaOtroPago + @"
                                                            ," + OtroPago_Id_nominaOtroPago + @"
                                                            ," + OtrosPagos_Id_nominaOtrosPagos + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();

                                                            foreach (XmlNode Node9 in Node8)
                                                            {
                                                                if (Node9.Name == "nomina12:CompensacionSaldosAFavor")
                                                                {
                                                                    SaldoAFavor_CompensacionSaldosAFavor = fnObtenValorNodo(Node9, "SaldoAFavor");
                                                                    Año_CompensacionSaldosAFavor = fnObtenValorNodo(Node9, "Año");
                                                                    RemanenteSalFav_CompensacionSaldosAFavor = fnObtenValorNodo(Node9, "RemanenteSalFav");

                                                                    slqInsert = @"
                                                                INSERT INTO dbo.CompensacionSaldosAFavor
                                                                    (SaldoAFavor
                                                                    ,Año
                                                                    ,RemanenteSalFav
                                                                    ,OtroPago_Id
                                                                    ,UUID)
                                                                VALUES
                                                                    ( " + SaldoAFavor_CompensacionSaldosAFavor + @"
                                                                    ," + Año_CompensacionSaldosAFavor + @"
                                                                    ," + RemanenteSalFav_CompensacionSaldosAFavor + @"
                                                                    ," + OtroPago_Id_nominaOtroPago + @")
                                                                    ,'" + UUID + @"')
                                                                ";
                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();
                                                                }
                                                                else if (Node9.Name == "nomina12:SubsidioAlEmpleo")
                                                                {
                                                                    SubsidioCausado_nominaSubsidioAlEmpleo = fnObtenValorNodo(Node9, "SubsidioCausado");

                                                                    slqInsert = @"
                                                                INSERT INTO dbo.SubsidioAlEmpleo
                                                                    (SubsidioCausado
                                                                    ,OtroPago_Id
                                                                    ,UUID)
                                                                VALUES
                                                                    ( " + SubsidioCausado_nominaSubsidioAlEmpleo + @"
                                                                    ," + OtroPago_Id_nominaOtroPago + @"
                                                                    ,'" + UUID + @"')
                                                                ";
                                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                                    cnn.fnConectarSQLServer();
                                                                    comando.ExecuteNonQuery();
                                                                    comando.Dispose();
                                                                }
                                                                else
                                                                {
                                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node9.Name, " No encontrado") });
                                                                }

                                                            }
                                                        }
                                                        else if (Node8.Name == "nomina12:SeparacionIndemnizacion")
                                                        {
                                                            TotalPagado_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "TotalPagado");
                                                            NumAñosServicio_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "NumAñosServicio");
                                                            UltimoSueldoMensOrd_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "UltimoSueldoMensOrd");
                                                            IngresoAcumulable_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "IngresoAcumulable");
                                                            IngresoNoAcumulable_nominaeparacionIndemnizacion = fnObtenValorNodo(Node8, "IngresoNoAcumulable");

                                                            slqInsert = @"
                                                        INSERT INTO dbo.SeparacionIndemnizacion
                                                            (TotalPagado
                                                            ,NumAñosServicio
                                                            ,UltimoSueldoMensOrd
                                                            ,IngresoAcumulable
                                                            ,IngresoNoAcumulable
                                                            ,Percepciones_Id
                                                            ,UUID)
                                                        VALUES
                                                            ( " + TotalPagado_nominaeparacionIndemnizacion + @"
                                                            ," + NumAñosServicio_nominaeparacionIndemnizacion + @"
                                                            ," + UltimoSueldoMensOrd_nominaeparacionIndemnizacion + @"
                                                            ," + IngresoAcumulable_nominaeparacionIndemnizacion + @"
                                                            ," + IngresoNoAcumulable_nominaeparacionIndemnizacion + @"
                                                            ," + Percepciones_Id_nominapercepciones + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else if (Node8.Name == "nomina12:JubilacionPensionRetiro")
                                                        {
                                                            TotalUnaExhibicion_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "TotalUnaExhibicion");
                                                            TotalParcialidad_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "TotalParcialidad");
                                                            MontoDiario_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "MontoDiario");
                                                            IngresoAcumulable_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "IngresoAcumulable");
                                                            IngresoNoAcumulable_nominaJubilacionPensionRetiro = fnObtenValorNodo(Node8, "IngresoNoAcumulable");

                                                            slqInsert = @"
                                                        INSERT INTO dbo.JubilacionPensionRetiro
                                                            (TotalUnaExhibicion
                                                            ,TotalParcialidad
                                                            ,MontoDiario
                                                            ,IngresoAcumulable
                                                            ,IngresoNoAcumulable
                                                            ,Percepciones_Id
                                                            ,UUID)
                                                        VALUES
                                                            ( " + TotalUnaExhibicion_nominaJubilacionPensionRetiro + @"
                                                            ," + TotalParcialidad_nominaJubilacionPensionRetiro + @"
                                                            ," + MontoDiario_nominaJubilacionPensionRetiro + @"
                                                            ," + IngresoAcumulable_nominaJubilacionPensionRetiro + @"
                                                            ," + IngresoNoAcumulable_nominaJubilacionPensionRetiro + @"
                                                            ," + Percepciones_Id_nominapercepciones + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node8.Name, " No encontrado") });
                                                        }
                                                    }
                                                }
                                                else if (Node7.Name == "nomina12:Incapacidades")
                                                {
                                                    slqInsert = "select isnull(max(Incapacidades_Id)+1,1) from Deducciones";
                                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    reader = cmdReader.ExecuteReader();
                                                    if (reader.Read())
                                                        Incapacidades_Id_nominaIncapacidades = reader[0].ToString();
                                                    cmdReader.Dispose();
                                                    reader.Close();

                                                    slqInsert = @"
                                                INSERT INTO dbo.Incapacidades
                                                    (Incapacidades_Id
                                                    ,Nomina_Id
                                                    ,UUID)
                                                VALUES
                                                    (" + Incapacidades_Id_nominaIncapacidades + @"
                                                    ," + Nomina_Id_nomina + @"
                                                    ,'" + UUID + @"')
                                                ";
                                                    slqInsert = slqInsert.Replace("'null'", "null");
                                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                    cnn.fnConectarSQLServer();
                                                    comando.ExecuteNonQuery();
                                                    comando.Dispose();

                                                    foreach (XmlNode Node8 in Node7)
                                                    {
                                                        if (Node8.Name == "nomina12:Incapacidad")
                                                        {
                                                            DiasIncapacidad_nominaIncapacidad = fnObtenValorNodo(Node8, "DiasIncapacidad");
                                                            TipoIncapacidad_nominaIncapacidad = fnObtenValorNodo(Node8, "TipoIncapacidad");
                                                            ImporteMonetario_nominaIncapacidad = fnObtenValorNodo(Node8, "ImporteMonetario");

                                                            slqInsert = @"
                                                        INSERT INTO dbo.Incapacidad
                                                            (DiasIncapacidad
                                                            ,TipoIncapacidad
                                                            ,ImporteMonetario
                                                            ,Incapacidades_Id
                                                            ,UUID)
                                                        VALUES
                                                            ( " + DiasIncapacidad_nominaIncapacidad + @"
                                                            ,'" + TipoIncapacidad_nominaIncapacidad + @"'
                                                            ," + ImporteMonetario_nominaIncapacidad + @"
                                                            ," + Incapacidades_Id_nominaIncapacidades + @"
                                                            ,'" + UUID + @"')
                                                        ";
                                                            slqInsert = slqInsert.Replace("'null'", "null");
                                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                                            cnn.fnConectarSQLServer();
                                                            comando.ExecuteNonQuery();
                                                            comando.Dispose();
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node8.Name, " No encontrado") });
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node7.Name, " No encontrado") });
                                                }
                                            }
                                        }
                                        else if (Node6.Name == "registrofiscal:CFDIRegistroFiscal")
                                        {
                                            Version_CFDIRegistroFiscal = fnObtenValorNodo(Node6, "Version");
                                            Folio_CFDIRegistroFiscal = fnObtenValorNodo(Node6, "Folio");

                                            slqInsert = @"
                                        INSERT INTO [dbo].[CFDIRegistroFiscal]
                                            ([Version]
                                            ,[Folio]
                                            ,[Complemento_Id]
                                            ,[UUID])
                                        VALUES
                                            ( '" + Version_CFDIRegistroFiscal + @"'
                                            ,'" + Folio_CFDIRegistroFiscal + @"'
                                            ," + Complemento_Id + @"
                                            ,'" + UUID + @"')
                                        ";
                                            slqInsert = slqInsert.Replace("'null'", "null");
                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            comando.ExecuteNonQuery();
                                            comando.Dispose();
                                        }
                                        else
                                        {
                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node6.Name, " No encontrado") });
                                        }
                                    }
                                }
                                else if (Node1.Name == "cfdi:CfdiRelacionados")
                                {
                                    string strResacionados_id = string.Empty;
                                    slqInsert = "select isnull(max(CfdiRelacionados_Id)+1,1) from CfdiRelacionados";
                                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    reader = cmdReader.ExecuteReader();
                                    if (reader.Read())
                                        strResacionados_id = reader[0].ToString();
                                    cmdReader.Dispose();
                                    reader.Close();

                                    string strTipoRelacion_CfdiRelacionados = fnObtenValorNodo(Node1, "TipoRelacion");

                                    slqInsert = @"
                                INSERT INTO [dbo].[CfdiRelacionados]
                                    ([TipoRelacion]
                                    ,[CfdiRelacionados_Id]
                                    ,[Comprobante_Id]
                                    ,[UUID])
                                VALUES
                                    ( '" + strTipoRelacion_CfdiRelacionados + @"'
                                    ," + strResacionados_id + @"
                                    ," + Comprobante_Id + @"
                                    ,'" + UUID + @"')
                                ";
                                    slqInsert = slqInsert.Replace("'null'", "null");
                                    comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                    cnn.fnConectarSQLServer();
                                    comando.ExecuteNonQuery();
                                    comando.Dispose();

                                    foreach (XmlNode Node2 in Node1)
                                    {
                                        if (Node2.Name == "cfdi:CfdiRelacionado")
                                        {
                                            string UUID_REL = fnObtenValorNodo(Node2, "UUID");

                                            slqInsert = @"
                                                INSERT INTO [dbo].[CfdiRelacionado]
                                                    ([UUID_REL]
                                                    ,[CfdiRelacionados_Id]
                                                    ,[UUID])
                                                VALUES
                                            ( '" + UUID_REL + @"'
                                            ," + strResacionados_id + @"
                                            ,'" + UUID + @"')
                                        ";
                                            slqInsert = slqInsert.Replace("'null'", "null");
                                            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                                            cnn.fnConectarSQLServer();
                                            comando.ExecuteNonQuery();
                                            comando.Dispose();
                                        }
                                        else
                                        {
                                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node2.Name, " No encontrado") });
                                        }
                                    }

                                }//cierre
                                else
                                {
                                    File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", Node1.Name, " No encontrado") });
                                }
                            }
                        }
                        else
                        {
                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\log.txt", new String[] { string.Concat("Factura: ", UUID, " Nodo", XmlDoc.DocumentElement.Name, " No encontrado") });
                        }
                        inTotalImportados++;
                    }                   
                }
                catch (Exception ex)
                {
                    txtLog.Invoke((MethodInvoker)(() => txtLog.Text = UUID));
                    MessageBox.Show(ex.Message);
                }
            });
            return 0;
        }

        private string fnObtenValor(ref XmlDocument xmlDoc, string v)
        {
            string ValorRetorno = "null";
            for(int x=0; x<= xmlDoc.DocumentElement.Attributes.Count-1; x++)
            {
                if(xmlDoc.DocumentElement.Attributes[x].Name == v)
                {
                    ValorRetorno = xmlDoc.DocumentElement.Attributes[x].Value.ToString();
                }
            }

            return ValorRetorno;
        }

        private string fnObtenValorNodo(XmlNode xmlDoc, string v)
        {
            string ValorRetorno = "null";
            for (int x = 0; x <= xmlDoc.Attributes.Count - 1; x++)
            {
                if (xmlDoc.Attributes[x].Name == v)
                {
                    ValorRetorno = xmlDoc.Attributes[x].Value.ToString();
                }
            }

            return ValorRetorno;
        }





        #region funciones que Conectan al SAT
        private static X509Certificate2 ObtenerX509Certificado(byte[] pfx)
        {
            return new X509Certificate2(pfx, password, X509KeyStorageFlags.MachineKeySet |
                            X509KeyStorageFlags.PersistKeySet |
                            X509KeyStorageFlags.Exportable);
        }

        private static void GuardarSolicitud(string idPaquete, string descargaResponse, string idSolicitud)
        {
            string path = @"C:\PaquetesDescargados\";
            byte[] file = Convert.FromBase64String(descargaResponse);
            Directory.CreateDirectory(path);

            //using ()
            ////using (FileStream fs = File.Create(path + idPaquete, file.Length))
            //{

            //}

            //string RutaArcnivoZip = path + idSolicitud + idPaquete + "-" + DateTime.Now.ToString().Replace(":", "_").Replace("/", "_").Replace(" ", "_").Replace(".", "") + ".zip";
            string RutaArcnivoZip = path + idSolicitud + idPaquete + ".zip";

            FileStream fs = File.Create(RutaArcnivoZip, file.Length);
            fs.Write(file, 0, file.Length);
            fs.Close();
            

            ZipArchive archive = ZipFile.Open(RutaArcnivoZip, ZipArchiveMode.Read);
            archive.ExtractToDirectory(path + idPaquete + "-" + DateTime.Now.ToString().Replace(":", "_").Replace("/", "_").Replace(" ", "_").Replace(".", ""));
            archive.Dispose();

            //using (var archive = ZipFile.Open(RutaArcnivoZip, ZipArchiveMode.Read))
            //{
            //    archive.ExtractToDirectory(path + idPaquete + "-" + DateTime.Now.ToString().Replace(":", "_").Replace("/", "_").Replace(" ", "_").Replace(".", ""));
            //}

            //Console.WriteLine("FileCreated: " + path + idPaquete + ".gzip");
        }

        private static string DescargarSolicitud(X509Certificate2 certifcate, string autorization, string idPaquete)
        {
            DescargarSolicitud descargarSolicitud = new DescargarSolicitud(urlDescargarSolicitud, urlDescargarSolicitudAction);
            string xmlDescarga = descargarSolicitud.Generate(certifcate, RfcEmisor, idPaquete);
            return descargarSolicitud.Send(autorization);
        }

        private static string ValidarSolicitud(X509Certificate2 certifcate, string autorization, string idSolicitud)
        {
            VerificaSolicitud verifica = new VerificaSolicitud(urlVerificarSolicitud, urlVerificarSolicitudAction);
            string xmlVerifica = verifica.Generate(certifcate, RfcEmisor, idSolicitud);
            return verifica.Send(autorization);
        }

        //private static string GenerarSolicitud(X509Certificate2 certifcate, string autorization)
        //{
        //    Solicitud solicitud = new Solicitud(urlSolicitud, urlSolicitudAction);
        //    string xmlSolicitud = solicitud.Generate(certifcate, RfcEmisor, RfcReceptor, srfcSolicitante, FechaInicial, FechaFinal, tipoSolicitud);
        //    return solicitud.Send(autorization);
        //}

        private static string ObtenerToken(X509Certificate2 certifcate)
        {
            Autenticacion service = new Autenticacion(urlAutentica, urlAutenticaAction);
            string xml = service.Generate(certifcate);
            return service.Send();
        }



        #endregion


        private void cmbEempresas_SelectedIndexChanged(object sender, EventArgs e)
        {

            slqInsert = "SELECT Id,RFC,RazonSocial,Alias,Usuario,Clave,Certificado FROM PersonaFisicaMoral WHERE Id = "+(cmbEempresas.SelectedIndex + 1).ToString();
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            //cmdReader.Parameters.AddWithValue("$id", cmbEempresas.SelectedIndex + 1);

            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            if (reader.Read())
            {
                //cmbEempresas.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[3].ToString());


                lblDescripcionEmpresas.Text = reader["RFC"].ToString() + " - " + reader["RazonSocial"].ToString();
                if (reader["Certificado"].ToString()!="")
                pfx = File.ReadAllBytes(reader["Certificado"].ToString());
                password = reader["Clave"].ToString();
                srfcSolicitante = reader["RFC"].ToString();
                sRFCEmisor = reader["RFC"].ToString();



            }
            cmdReader.Dispose();
            reader.Close();





            //if (connection.State == ConnectionState.Closed)
            //{
            //    connection = new SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + @"\db\" + "local.db");
            //    connection.Open();
            //}

            //strSQLite = @"SELECT Id,RFC,RazonSocial,Alias,Usuario,Clave,Certificado FROM PersonaFisicaMoral WHERE Id = $id;";
            //comm = new SQLiteCommand(strSQLite, connection);
            //comm.Parameters.AddWithValue("$id", cmbEempresas.SelectedIndex+1);
            //read = comm.ExecuteReader();
            //if(read.Read())
            //{
            //    lblDescripcionEmpresas.Text = read["RFC"].ToString() + " - " + read["RazonSocial"].ToString();
            //    pfx = File.ReadAllBytes(read["Certificado"].ToString());
            //    password = read["Clave"].ToString();
            //    RfcEmisor = read["RFC"].ToString();
            //}
            //read.Close();
            //comm.Dispose();
        }

        private void dtFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            txtFechaInicial.Text = dtFechaInicial.Text;
        }

        private void dtFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            txtFechaFinal.Text = dtFechaFinal.Text;
        }









        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            string idSolicitud = string.Empty;

            if (cmbEempresas.SelectedIndex == -1)
                throw new InvalidOperationException("Falta seleccioanr la empresa");

            if (cmbTipoSolicitud.SelectedIndex == -1)
                throw new InvalidOperationException("Falta seleccioanr el tipo de solicitud");


            if (txtFechaInicial.Text.Trim().Length == 0)
                throw new InvalidOperationException("Falta seleccioanr la fecha inicial");

            if (txtFechaFinal.Text.Trim().Length == 0)
                throw new InvalidOperationException("Falta seleccioanr la fecha final");


            if (cmbTipoSolicitud.SelectedIndex == 0)
                tipoSolicitud = "CFDI";
            else
                tipoSolicitud = "Metadata";


            if (cmbTipoEmision2.SelectedIndex == 0)
            {
                RfcReceptor = "";
                RfcEmisor = sRFCEmisor;
            }
            else
            {
                RfcReceptor = sRFCEmisor;
                RfcEmisor = "";
            }


            FechaInicial = txtFechaInicial.Text;
            FechaFinal = txtFechaFinal.Text;

            //idSolicitud = fnEnviaSolicitud(pfx);





            ////Obtener Certificados
            //X509Certificate2 certifcate;
            //certifcate = new X509Certificate2(pfx, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

            ////Obtener Token
            //Autenticacion service = new Autenticacion(urlAutentica, urlAutenticaAction);
            //string xml = service.Generate(certifcate);
            //string token = service.Send();

            //string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));

            ////Generar Solicitud
            //Solicitud solicitud = new Solicitud(urlSolicitud, urlSolicitudAction);
            //string xmlSolicitud = solicitud.Generate(certifcate, RfcEmisor, RfcReceptor, srfcSolicitante, FechaInicial, FechaFinal, tipoSolicitud);
            //idSolicitud = solicitud.Send(autorization);







            idSolicitud = csGlobal.fnEnviaSolicitud(pfx, password, RfcEmisor, RfcReceptor, srfcSolicitante, FechaInicial, FechaFinal, (cmbTipoSolicitud.SelectedIndex + 1).ToString(), tipoSolicitud, (cmbTipoSolicitud.SelectedIndex + 1).ToString(), cmbTipoEmision2.Text);

            //if (idSolicitud != string.Empty)
            //{
            //    slqInsert = @"
            //                INSERT INTO [dbo].[Solicitud]
            //                           ([Solicitud_Id]
            //                           ,[EstadoSolicitud_Id]
            //                           ,[Fecha]
            //                           ,[FechaInicio]
            //                           ,[FechaFin]
            //                           ,[RFCEmisor]
            //                           ,[RFCReceptor]
            //                           ,[TipoEmision_Id]
            //                           ,[RFCSolicitante]
            //                           ,[TipoSolicitud_Id])
            //                VALUES
            //                    ('" + idSolicitud + @"'
            //                    ,'2" + @"'
            //                    ,'" + DateTime.Today.ToString() + @"'
            //                    ,'" + FechaInicial + @"'
            //                    ,'" + FechaFinal + @"'
            //                    ,'" + RfcEmisor + @"'
            //                    ,'" + RfcReceptor + @"'
            //                    ," + (cmbTipoEmision2.SelectedIndex+1).ToString() + @"
            //                    ,'" + RfcEmisor + @"'
            //                    ," + (cmbTipoSolicitud.SelectedIndex+1).ToString() + @")
            //                    ";
            //    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            //    cnn.fnConectarSQLServer();
            //    cmdReader.ExecuteNonQuery();
            //    cmdReader.Dispose();
            //    reader.Close();
            //}

            ActualizaGrid();
        }

        private void btnActualizaSolicitud_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string GridRFC = string.Empty;

                if (row.Cells[2].Value.ToString() != string.Empty)
                    GridRFC = row.Cells[2].Value.ToString();
                else
                    GridRFC = row.Cells[3].Value.ToString();

                slqInsert = "SELECT Id,RFC,RazonSocial,Alias,Usuario,Clave,Certificado FROM PersonaFisicaMoral WHERE RFC = '" + GridRFC + "'";
                cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                //cmdReader.Parameters.AddWithValue("$id", cmbEempresas.SelectedIndex + 1);

                cnn.fnConectarSQLServer();
                reader = cmdReader.ExecuteReader();
                if (reader.Read())
                {
                    //cmbEempresas.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[3].ToString());


                    if (reader["Certificado"].ToString() != "")
                        pfx = File.ReadAllBytes(reader["Certificado"].ToString());
                    password = reader["Clave"].ToString();
                    //srfcSolicitante = reader["RFC"].ToString();
                    sRFCEmisor = reader["RFC"].ToString();



                }
                cmdReader.Dispose();
                reader.Close();


                RfcEmisor = sRFCEmisor;


                //pfx = File.ReadAllBytes(row.Cells[1].Value.ToString());

                //Obtener Certificados
                X509Certificate2 certifcate;
                certifcate = new X509Certificate2(pfx, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

                //Obtener Token
                Autenticacion service = new Autenticacion(urlAutentica, urlAutenticaAction);
                string xml = service.Generate(certifcate);
                string token = service.Send();

                //Generar Solicitud
                string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));
                string idPaquete;

                idPaquete = ValidarSolicitud(certifcate, autorization, row.Cells[1].Value.ToString());


                if (idPaquete != string.Empty)
                {
                    slqInsert = @"update Solicitud set idPaquete = '" + idPaquete + "'";
                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                    cnn.fnConectarSQLServer();
                    cmdReader.ExecuteNonQuery();
                    cmdReader.Dispose();
                    reader.Close();
                }


            }


            ActualizaGrid();

            MessageBox.Show("Petición terminada");
            //string idSolicitud = "ac5c2766-5cb6-4a49-b93b-e3bc28c8ec2b";


            //Console.WriteLine("IdSolicitud: " + idSolicitud);

            //Validar Solicitud
            //string idPaquete = ValidarSolicitud(certifcate, autorization, idSolicitud);


        }

        private void btnDescargaCFDI_Click(object sender, EventArgs e)
        {
            fnDescargaCFDI();
        }

        private void btnAutomatizado_Click(object sender, EventArgs e)
        {
            //fnAutomatizado();
        }

        public string fnEnviaSolicitud(byte[] vpfx)
        {
            string idSolicitud = string.Empty;
            try
            {            
                //Obtener Certificados
                X509Certificate2 certifcate = ObtenerX509Certificado(vpfx);

                //Obtener Token
                string token = ObtenerToken(certifcate);
                string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));
                //Console.WriteLine("Token: " + token);

                //idSolicitud = GenerarSolicitud(certifcate, autorization);


                //Generar Solicitud
                Solicitud solicitud = new Solicitud(urlSolicitud, urlSolicitudAction);
                string xmlSolicitud = solicitud.Generate(certifcate, RfcEmisor, RfcReceptor, srfcSolicitante, FechaInicial, FechaFinal, tipoSolicitud);
                idSolicitud = solicitud.Send(autorization);

                #region codigo original
                //string idSolicitud = "ac5c2766-5cb6-4a49-b93b-e3bc28c8ec2b";


                //Console.WriteLine("IdSolicitud: " + idSolicitud);

                ////Validar Solicitud
                //string idPaquete = ValidarSolicitud(certifcate, autorization, idSolicitud);
                ////Console.WriteLine("IdPaquete: " + idPaquete);

                //if (!string.IsNullOrEmpty(idPaquete))
                //{
                //    // Aqui falta mas logica para poder identificar si son mas de 1 Id de Paquetes 
                //    // para que se puedan descargar y guardar varios IDs de Paquetes que se resivieron 
                //    // seria algo mas o menos asi  
                //    //   
                //    //   String[] IdPaquetes = idPaquete.Split('|');
                //    //   for (int i = 0;i < IdPaquetes.Length - 1 )
                //    //   {
                //    //      String IDPaquete = IdPaquetes[i];
                //    //   
                //    //      string DescargaResponse = DescargarSolicitud(certifcate, autorization, IDPaquete);
                //    //      GuardarSolicitud(IDPaquete, DescargaResponse);
                //    //   
                //    //   }
                //    //   
                //    string descargaResponse = DescargarSolicitud(certifcate, autorization, idPaquete);

                //    GuardarSolicitud(idPaquete, descargaResponse);
                //}
                //Console.ReadLine();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return idSolicitud;
        }

        public void fnActualizaSolicitud()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string GridRFC = string.Empty;

                if (row.Cells[2].Value.ToString() != string.Empty)
                    GridRFC = row.Cells[2].Value.ToString();
                else
                    GridRFC = row.Cells[3].Value.ToString();

                slqInsert = "SELECT Id,RFC,RazonSocial,Alias,Usuario,Clave,Certificado FROM PersonaFisicaMoral WHERE RFC = '" + GridRFC + "'";
                cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                //cmdReader.Parameters.AddWithValue("$id", cmbEempresas.SelectedIndex + 1);

                cnn.fnConectarSQLServer();
                reader = cmdReader.ExecuteReader();
                if (reader.Read())
                {
                    //cmbEempresas.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[3].ToString());


                    if (reader["Certificado"].ToString() != "")
                        pfx = File.ReadAllBytes(reader["Certificado"].ToString());
                    password = reader["Clave"].ToString();
                    //srfcSolicitante = reader["RFC"].ToString();
                    sRFCEmisor = reader["RFC"].ToString();



                }
                cmdReader.Dispose();
                reader.Close();


                RfcEmisor = sRFCEmisor;


                //pfx = File.ReadAllBytes(row.Cells[1].Value.ToString());

                //Obtener Certificados
                X509Certificate2 certifcate = ObtenerX509Certificado(pfx);

                //Obtener Token
                string token = ObtenerToken(certifcate);
                string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));
                //Console.WriteLine("Token: " + token);

                //Generar Solicitud
                //string idSolicitud = GenerarSolicitud(certifcate, autorization);
                string idPaquete;

                idPaquete = ValidarSolicitud(certifcate, autorization, row.Cells[1].Value.ToString());
            }


            ActualizaGrid();

            MessageBox.Show("Petición terminada");
            //string idSolicitud = "ac5c2766-5cb6-4a49-b93b-e3bc28c8ec2b";


            //Console.WriteLine("IdSolicitud: " + idSolicitud);

            //Validar Solicitud
            //string idPaquete = ValidarSolicitud(certifcate, autorization, idSolicitud);
        }

        public void fnDescargaCFDI()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells[0].Value.ToString() == "1")
                {


                    slqInsert = "SELECT Id,RFC,RazonSocial,Alias,Usuario,Clave,Certificado FROM PersonaFisicaMoral WHERE RFC = '" + row.Cells[2].Value.ToString() + "'";
                    cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                    //cmdReader.Parameters.AddWithValue("$id", cmbEempresas.SelectedIndex + 1);

                    cnn.fnConectarSQLServer();
                    reader = cmdReader.ExecuteReader();
                    if (reader.Read())
                    {
                        //cmbEempresas.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[3].ToString());


                        if (reader["Certificado"].ToString() != "")
                            pfx = File.ReadAllBytes(reader["Certificado"].ToString());
                        password = reader["Clave"].ToString();
                        srfcSolicitante = reader["RFC"].ToString();
                        sRFCEmisor = reader["RFC"].ToString();



                    }
                    cmdReader.Dispose();
                    reader.Close();


                    RfcEmisor = sRFCEmisor;





                    //Obtener Certificados
                    X509Certificate2 certifcate = ObtenerX509Certificado(pfx);

                    //Obtener Token
                    string token = ObtenerToken(certifcate);
                    string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));
                    //Console.WriteLine("Token: " + token);

                    //Generar Solicitud
                    string idPaquete = string.Empty;

                    string idSolicitud = row.Cells[1].Value.ToString();


                    idPaquete = ValidarSolicitud(certifcate, autorization, idSolicitud);

                    if (!string.IsNullOrEmpty(idPaquete))
                    {
                        // Aqui falta mas logica para poder identificar si son mas de 1 Id de Paquetes 
                        // para que se puedan descargar y guardar varios IDs de Paquetes que se resivieron 
                        // seria algo mas o menos asi  
                        //   
                        //   String[] IdPaquetes = idPaquete.Split('|');
                        //   for (int i = 0;i < IdPaquetes.Length - 1 )
                        //   {
                        //      String IDPaquete = IdPaquetes[i];
                        //   
                        //      string DescargaResponse = DescargarSolicitud(certifcate, autorization, IDPaquete);
                        //      GuardarSolicitud(IDPaquete, DescargaResponse);
                        //   
                        //   }
                        //   
                        string descargaResponse = DescargarSolicitud(certifcate, autorization, idPaquete);
                        if (descargaResponse != string.Empty)
                        {
                            GuardarSolicitud(idPaquete, descargaResponse, idSolicitud);
                            MessageBox.Show("Archivo descargado!");
                        }
                        else
                            MessageBox.Show("No se descargo el archivo");
                    }
                }

            }

        }

        //public void fnAutomatizado()
        //{
        //    fnEnviaSolicitud();
        //    fnActualizaSolicitud();
        //    fnDescargaCFDI();
        //}

        private void configurarAutomáticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAuto = new fmrConfigAutomatico();
            frmAuto.MdiParent = this;
            frmAuto.Show();



        }

        private void btnCargaMetadata_Click(object sender, EventArgs e)
        {
            //Metadata SAT
            string UUID = string.Empty;
            string RfcEmisor = string.Empty;
            string NombreEmisor = string.Empty;
            string RfcReceptor = string.Empty;
            string NombreReceptor = string.Empty;
            string RfcPac = string.Empty;
            string FechaEmision = string.Empty;
            string FechaCertificacionSat = string.Empty;
            string Monto = string.Empty;
            string EfectoComprobante = string.Empty;
            string Estatus = string.Empty;
            string FechaCancelacion = string.Empty;

            String line;
            bool esTitulo = true;

            SqlCommand comando;


            try
            {
                
                DialogResult dr = this.openFileDialog2.ShowDialog();

                if (dr == DialogResult.Cancel)
                    throw new InvalidOperationException("Importación cancelada");

                DialogResult msg1 = MessageBox.Show("Se importará " + openFileDialog2.FileName.ToString(), "", MessageBoxButtons.YesNo);

                if (msg1 == DialogResult.Yes)
                {
                    StreamReader sr = new StreamReader(openFileDialog2.FileName.ToString());
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        if (esTitulo)
                        {
                            line = sr.ReadLine();
                            esTitulo = false;
                            continue;
                        }

                        UUID                    = line.Split('~')[0].ToString();
                        RfcEmisor               = line.Split('~')[1].ToString();
                        NombreEmisor            = line.Split('~')[2].ToString();
                        RfcReceptor             = line.Split('~')[3].ToString();
                        NombreReceptor          = line.Split('~')[4].ToString();
                        RfcPac                  = line.Split('~')[5].ToString();
                        FechaEmision            = line.Split('~')[6].ToString();
                        FechaCertificacionSat   = line.Split('~')[7].ToString();
                        Monto                   = line.Split('~')[8].ToString();
                        EfectoComprobante       = line.Split('~')[9].ToString();
                        Estatus                 = line.Split('~')[10].ToString();
                        FechaCancelacion        = line.Split('~')[11].ToString();

                        slqInsert = @"
                                        INSERT INTO [dbo].[MetadataSAT]
                                                   ([UUID]
                                                   ,[RfcEmisor]
                                                   ,[NombreEmisor]
                                                   ,[RfcReceptor]
                                                   ,[NombreReceptor]
                                                   ,[RfcPac]
                                                   ,[FechaEmision]
                                                   ,[FechaCertificacionSat]
                                                   ,[Monto]
                                                   ,[EfectoComprobante]
                                                   ,[Estatus]
                                                   ,FechaCancelacion)
                                        VALUES
                                            ( '" + UUID + @"'
                                            ,'" + RfcEmisor + @"'
                                            ,'" + NombreEmisor + @"'
                                            ,'" + RfcReceptor + @"'
                                            ,'" + NombreReceptor + @"'
                                            ,'" + RfcPac + @"'
                                            ,'" + FechaEmision + @"'
                                            ,'" + FechaCertificacionSat + @"'
                                            ," + Monto + @"
                                            ,'" + EfectoComprobante + @"'
                                            ,'" + Estatus + @"'
                                            ,'" + FechaCancelacion + @"')
                                        ";
                        slqInsert = slqInsert.Replace("'null'", "null");
                        comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                        cnn.fnConectarSQLServer();
                        comando.ExecuteNonQuery();
                        comando.Dispose();



                        line = sr.ReadLine();
                    }
                    sr.Close();
                    Console.ReadLine();
                }




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
