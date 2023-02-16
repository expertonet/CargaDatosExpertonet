
namespace CargaDatosExpertonet
{
    partial class frmETL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ContexMenuETL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCargaCFDi = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbTipoEmision = new System.Windows.Forms.ComboBox();
            this.cmbEstadoFactura = new System.Windows.Forms.ComboBox();
            this.lblTipoEmision = new System.Windows.Forms.Label();
            this.lblEstadoFactura = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCargaMetadata = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnEnviarSolicitud = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flDescripcion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFCSolicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rfc_Emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFC_Receptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoSolicitudGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnActualizaSolicitud = new System.Windows.Forms.Button();
            this.lblEmpresas = new System.Windows.Forms.Label();
            this.cmbEempresas = new System.Windows.Forms.ComboBox();
            this.lblDescripcionEmpresas = new System.Windows.Forms.Label();
            this.txtFechaInicial = new System.Windows.Forms.TextBox();
            this.txtFechaFinal = new System.Windows.Forms.TextBox();
            this.lblTipoSolicitud = new System.Windows.Forms.Label();
            this.cmbTipoSolicitud = new System.Windows.Forms.ComboBox();
            this.lblTipoEmision2 = new System.Windows.Forms.Label();
            this.cmbTipoEmision2 = new System.Windows.Forms.ComboBox();
            this.btnDescargaCFDI = new System.Windows.Forms.Button();
            this.btnAutomatizado = new System.Windows.Forms.Button();
            this.tmrAutomatico = new System.Windows.Forms.Timer(this.components);
            this.mnuETL = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarAutomáticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalImportados = new System.Windows.Forms.Label();
            this.ContexMenuETL.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.mnuETL.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContexMenuETL
            // 
            this.ContexMenuETL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarToolStripMenuItem});
            this.ContexMenuETL.Name = "contextMenuStrip1";
            this.ContexMenuETL.Size = new System.Drawing.Size(114, 26);
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.botonToolStripMenuItem});
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.insertarToolStripMenuItem.Text = "Insertar";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // botonToolStripMenuItem
            // 
            this.botonToolStripMenuItem.Name = "botonToolStripMenuItem";
            this.botonToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.botonToolStripMenuItem.Text = "Boton";
            this.botonToolStripMenuItem.Click += new System.EventHandler(this.botonToolStripMenuItem_Click);
            // 
            // btnCargaCFDi
            // 
            this.btnCargaCFDi.Location = new System.Drawing.Point(39, 187);
            this.btnCargaCFDi.Name = "btnCargaCFDi";
            this.btnCargaCFDi.Size = new System.Drawing.Size(141, 23);
            this.btnCargaCFDi.TabIndex = 1;
            this.btnCargaCFDi.Text = "Seleccionar y Cargar CFDi";
            this.btnCargaCFDi.UseVisualStyleBackColor = true;
            this.btnCargaCFDi.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CFDi (*.XML)|*.XML| All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Importar CFDi";
            // 
            // cmbTipoEmision
            // 
            this.cmbTipoEmision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEmision.FormattingEnabled = true;
            this.cmbTipoEmision.Location = new System.Drawing.Point(39, 63);
            this.cmbTipoEmision.Name = "cmbTipoEmision";
            this.cmbTipoEmision.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoEmision.TabIndex = 2;
            // 
            // cmbEstadoFactura
            // 
            this.cmbEstadoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFactura.FormattingEnabled = true;
            this.cmbEstadoFactura.Location = new System.Drawing.Point(39, 128);
            this.cmbEstadoFactura.Name = "cmbEstadoFactura";
            this.cmbEstadoFactura.Size = new System.Drawing.Size(121, 21);
            this.cmbEstadoFactura.TabIndex = 3;
            // 
            // lblTipoEmision
            // 
            this.lblTipoEmision.AutoSize = true;
            this.lblTipoEmision.Location = new System.Drawing.Point(36, 47);
            this.lblTipoEmision.Name = "lblTipoEmision";
            this.lblTipoEmision.Size = new System.Drawing.Size(82, 13);
            this.lblTipoEmision.TabIndex = 4;
            this.lblTipoEmision.Text = "Tipo de Emisión";
            // 
            // lblEstadoFactura
            // 
            this.lblEstadoFactura.AutoSize = true;
            this.lblEstadoFactura.Location = new System.Drawing.Point(36, 112);
            this.lblEstadoFactura.Name = "lblEstadoFactura";
            this.lblEstadoFactura.Size = new System.Drawing.Size(105, 13);
            this.lblEstadoFactura.TabIndex = 5;
            this.lblEstadoFactura.Text = "Estado de la Factura";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCargaMetadata);
            this.groupBox1.Controls.Add(this.lblEstadoFactura);
            this.groupBox1.Controls.Add(this.lblTipoEmision);
            this.groupBox1.Controls.Add(this.cmbEstadoFactura);
            this.groupBox1.Controls.Add(this.cmbTipoEmision);
            this.groupBox1.Controls.Add(this.btnCargaCFDi);
            this.groupBox1.Location = new System.Drawing.Point(31, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 219);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Importación de Facturas";
            // 
            // btnCargaMetadata
            // 
            this.btnCargaMetadata.Location = new System.Drawing.Point(210, 187);
            this.btnCargaMetadata.Name = "btnCargaMetadata";
            this.btnCargaMetadata.Size = new System.Drawing.Size(141, 23);
            this.btnCargaMetadata.TabIndex = 6;
            this.btnCargaMetadata.Text = "Cargar Metadata";
            this.btnCargaMetadata.UseVisualStyleBackColor = true;
            this.btnCargaMetadata.Click += new System.EventHandler(this.btnCargaMetadata_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(31, 292);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(373, 254);
            this.txtLog.TabIndex = 7;
            // 
            // btnEnviarSolicitud
            // 
            this.btnEnviarSolicitud.Location = new System.Drawing.Point(432, 290);
            this.btnEnviarSolicitud.Name = "btnEnviarSolicitud";
            this.btnEnviarSolicitud.Size = new System.Drawing.Size(122, 23);
            this.btnEnviarSolicitud.TabIndex = 8;
            this.btnEnviarSolicitud.Text = "Enviar Solicitud";
            this.btnEnviarSolicitud.UseVisualStyleBackColor = true;
            this.btnEnviarSolicitud.Click += new System.EventHandler(this.btnEnviarSolicitud_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flDescripcion,
            this.IdSolicitud,
            this.RFCSolicitante,
            this.Rfc_Emisor,
            this.RFC_Receptor,
            this.IdEstado,
            this.EstadoSolicitud,
            this.TipoEmision,
            this.TipoSolicitudGrid,
            this.Fecha,
            this.FechaInicio,
            this.FechaFin,
            this.fecha_creacion});
            this.dataGridView1.Location = new System.Drawing.Point(432, 328);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1159, 333);
            this.dataGridView1.TabIndex = 9;
            // 
            // flDescripcion
            // 
            this.flDescripcion.FalseValue = "0";
            this.flDescripcion.HeaderText = "";
            this.flDescripcion.IndeterminateValue = "0";
            this.flDescripcion.Name = "flDescripcion";
            this.flDescripcion.TrueValue = "1";
            this.flDescripcion.Width = 5;
            // 
            // IdSolicitud
            // 
            this.IdSolicitud.HeaderText = "ID Solicitud";
            this.IdSolicitud.Name = "IdSolicitud";
            this.IdSolicitud.ReadOnly = true;
            this.IdSolicitud.Width = 79;
            // 
            // RFCSolicitante
            // 
            this.RFCSolicitante.HeaderText = "RFC Solicitante";
            this.RFCSolicitante.Name = "RFCSolicitante";
            this.RFCSolicitante.ReadOnly = true;
            this.RFCSolicitante.Width = 96;
            // 
            // Rfc_Emisor
            // 
            this.Rfc_Emisor.HeaderText = "RFC Emisor";
            this.Rfc_Emisor.Name = "Rfc_Emisor";
            this.Rfc_Emisor.ReadOnly = true;
            this.Rfc_Emisor.Width = 80;
            // 
            // RFC_Receptor
            // 
            this.RFC_Receptor.HeaderText = "RFC Receptor";
            this.RFC_Receptor.Name = "RFC_Receptor";
            this.RFC_Receptor.ReadOnly = true;
            this.RFC_Receptor.Width = 92;
            // 
            // IdEstado
            // 
            this.IdEstado.HeaderText = "Id Estado";
            this.IdEstado.Name = "IdEstado";
            this.IdEstado.ReadOnly = true;
            this.IdEstado.Width = 71;
            // 
            // EstadoSolicitud
            // 
            this.EstadoSolicitud.HeaderText = "Estado";
            this.EstadoSolicitud.Name = "EstadoSolicitud";
            this.EstadoSolicitud.ReadOnly = true;
            this.EstadoSolicitud.Width = 65;
            // 
            // TipoEmision
            // 
            this.TipoEmision.HeaderText = "TipoEmision";
            this.TipoEmision.Name = "TipoEmision";
            this.TipoEmision.ReadOnly = true;
            this.TipoEmision.Width = 89;
            // 
            // TipoSolicitudGrid
            // 
            this.TipoSolicitudGrid.HeaderText = "Tipo Solicitud";
            this.TipoSolicitudGrid.Name = "TipoSolicitudGrid";
            this.TipoSolicitudGrid.ReadOnly = true;
            this.TipoSolicitudGrid.Width = 88;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha Solicitud";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 96;
            // 
            // FechaInicio
            // 
            this.FechaInicio.HeaderText = "Fecha Inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 83;
            // 
            // FechaFin
            // 
            this.FechaFin.HeaderText = "Fecha Fin";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 73;
            // 
            // fecha_creacion
            // 
            this.fecha_creacion.HeaderText = "Fecha Creacion";
            this.fecha_creacion.Name = "fecha_creacion";
            this.fecha_creacion.Width = 98;
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.CustomFormat = "yyyy-MM-dd";
            this.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicial.Location = new System.Drawing.Point(535, 198);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(18, 20);
            this.dtFechaInicial.TabIndex = 10;
            this.dtFechaInicial.ValueChanged += new System.EventHandler(this.dtFechaInicial_ValueChanged);
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.CustomFormat = "yyyy-MM-dd";
            this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaFinal.Location = new System.Drawing.Point(686, 198);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(18, 20);
            this.dtFechaFinal.TabIndex = 12;
            this.dtFechaFinal.ValueChanged += new System.EventHandler(this.dtFechaFinal_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Fecha Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fecha Final";
            // 
            // btnActualizaSolicitud
            // 
            this.btnActualizaSolicitud.Location = new System.Drawing.Point(677, 290);
            this.btnActualizaSolicitud.Name = "btnActualizaSolicitud";
            this.btnActualizaSolicitud.Size = new System.Drawing.Size(110, 23);
            this.btnActualizaSolicitud.TabIndex = 15;
            this.btnActualizaSolicitud.Text = "Actualiza Solicitud";
            this.btnActualizaSolicitud.UseVisualStyleBackColor = true;
            this.btnActualizaSolicitud.Click += new System.EventHandler(this.btnActualizaSolicitud_Click);
            // 
            // lblEmpresas
            // 
            this.lblEmpresas.AutoSize = true;
            this.lblEmpresas.Location = new System.Drawing.Point(429, 28);
            this.lblEmpresas.Name = "lblEmpresas";
            this.lblEmpresas.Size = new System.Drawing.Size(48, 13);
            this.lblEmpresas.TabIndex = 7;
            this.lblEmpresas.Text = "Empresa";
            // 
            // cmbEempresas
            // 
            this.cmbEempresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEempresas.FormattingEnabled = true;
            this.cmbEempresas.Location = new System.Drawing.Point(432, 44);
            this.cmbEempresas.Name = "cmbEempresas";
            this.cmbEempresas.Size = new System.Drawing.Size(121, 21);
            this.cmbEempresas.TabIndex = 6;
            this.cmbEempresas.SelectedIndexChanged += new System.EventHandler(this.cmbEempresas_SelectedIndexChanged);
            // 
            // lblDescripcionEmpresas
            // 
            this.lblDescripcionEmpresas.AutoSize = true;
            this.lblDescripcionEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionEmpresas.Location = new System.Drawing.Point(562, 48);
            this.lblDescripcionEmpresas.Name = "lblDescripcionEmpresas";
            this.lblDescripcionEmpresas.Size = new System.Drawing.Size(0, 20);
            this.lblDescripcionEmpresas.TabIndex = 16;
            // 
            // txtFechaInicial
            // 
            this.txtFechaInicial.BackColor = System.Drawing.SystemColors.Window;
            this.txtFechaInicial.Location = new System.Drawing.Point(432, 198);
            this.txtFechaInicial.Name = "txtFechaInicial";
            this.txtFechaInicial.ReadOnly = true;
            this.txtFechaInicial.Size = new System.Drawing.Size(100, 20);
            this.txtFechaInicial.TabIndex = 17;
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.BackColor = System.Drawing.SystemColors.Window;
            this.txtFechaFinal.Location = new System.Drawing.Point(583, 198);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.ReadOnly = true;
            this.txtFechaFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFechaFinal.TabIndex = 18;
            // 
            // lblTipoSolicitud
            // 
            this.lblTipoSolicitud.AutoSize = true;
            this.lblTipoSolicitud.Location = new System.Drawing.Point(429, 77);
            this.lblTipoSolicitud.Name = "lblTipoSolicitud";
            this.lblTipoSolicitud.Size = new System.Drawing.Size(71, 13);
            this.lblTipoSolicitud.TabIndex = 20;
            this.lblTipoSolicitud.Text = "Tipo Solicitud";
            // 
            // cmbTipoSolicitud
            // 
            this.cmbTipoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSolicitud.FormattingEnabled = true;
            this.cmbTipoSolicitud.Location = new System.Drawing.Point(432, 93);
            this.cmbTipoSolicitud.Name = "cmbTipoSolicitud";
            this.cmbTipoSolicitud.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoSolicitud.TabIndex = 19;
            // 
            // lblTipoEmision2
            // 
            this.lblTipoEmision2.AutoSize = true;
            this.lblTipoEmision2.Location = new System.Drawing.Point(430, 123);
            this.lblTipoEmision2.Name = "lblTipoEmision2";
            this.lblTipoEmision2.Size = new System.Drawing.Size(81, 13);
            this.lblTipoEmision2.TabIndex = 22;
            this.lblTipoEmision2.Text = "Tipo de emisión";
            // 
            // cmbTipoEmision2
            // 
            this.cmbTipoEmision2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEmision2.FormattingEnabled = true;
            this.cmbTipoEmision2.Location = new System.Drawing.Point(433, 139);
            this.cmbTipoEmision2.Name = "cmbTipoEmision2";
            this.cmbTipoEmision2.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoEmision2.TabIndex = 21;
            // 
            // btnDescargaCFDI
            // 
            this.btnDescargaCFDI.Location = new System.Drawing.Point(838, 290);
            this.btnDescargaCFDI.Name = "btnDescargaCFDI";
            this.btnDescargaCFDI.Size = new System.Drawing.Size(110, 23);
            this.btnDescargaCFDI.TabIndex = 23;
            this.btnDescargaCFDI.Text = "Descargar CFDi\'s";
            this.btnDescargaCFDI.UseVisualStyleBackColor = true;
            this.btnDescargaCFDI.Click += new System.EventHandler(this.btnDescargaCFDI_Click);
            // 
            // btnAutomatizado
            // 
            this.btnAutomatizado.Location = new System.Drawing.Point(851, 195);
            this.btnAutomatizado.Name = "btnAutomatizado";
            this.btnAutomatizado.Size = new System.Drawing.Size(97, 23);
            this.btnAutomatizado.TabIndex = 24;
            this.btnAutomatizado.Text = "Automatizado";
            this.btnAutomatizado.UseVisualStyleBackColor = true;
            this.btnAutomatizado.Click += new System.EventHandler(this.btnAutomatizado_Click);
            // 
            // tmrAutomatico
            // 
            this.tmrAutomatico.Interval = 1000;
            // 
            // mnuETL
            // 
            this.mnuETL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.mnuETL.Location = new System.Drawing.Point(0, 0);
            this.mnuETL.Name = "mnuETL";
            this.mnuETL.Size = new System.Drawing.Size(1603, 24);
            this.mnuETL.TabIndex = 25;
            this.mnuETL.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurarAutomáticoToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // configurarAutomáticoToolStripMenuItem
            // 
            this.configurarAutomáticoToolStripMenuItem.Name = "configurarAutomáticoToolStripMenuItem";
            this.configurarAutomáticoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.configurarAutomáticoToolStripMenuItem.Text = "Programar Tareas";
            this.configurarAutomáticoToolStripMenuItem.Click += new System.EventHandler(this.configurarAutomáticoToolStripMenuItem_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "Metadata SAT|*.metadata";
            this.openFileDialog2.InitialDirectory = "C:\\PaquetesDescargados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "CFDI Importados:";
            // 
            // lblTotalImportados
            // 
            this.lblTotalImportados.AutoSize = true;
            this.lblTotalImportados.Location = new System.Drawing.Point(118, 262);
            this.lblTotalImportados.Name = "lblTotalImportados";
            this.lblTotalImportados.Size = new System.Drawing.Size(0, 13);
            this.lblTotalImportados.TabIndex = 27;
            // 
            // frmETL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1603, 673);
            this.ContextMenuStrip = this.ContexMenuETL;
            this.Controls.Add(this.lblTotalImportados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mnuETL);
            this.Controls.Add(this.btnAutomatizado);
            this.Controls.Add(this.btnDescargaCFDI);
            this.Controls.Add(this.lblTipoEmision2);
            this.Controls.Add(this.cmbTipoEmision2);
            this.Controls.Add(this.lblTipoSolicitud);
            this.Controls.Add(this.cmbTipoSolicitud);
            this.Controls.Add(this.txtFechaFinal);
            this.Controls.Add(this.txtFechaInicial);
            this.Controls.Add(this.lblDescripcionEmpresas);
            this.Controls.Add(this.lblEmpresas);
            this.Controls.Add(this.btnActualizaSolicitud);
            this.Controls.Add(this.cmbEempresas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFechaFinal);
            this.Controls.Add(this.dtFechaInicial);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEnviarSolicitud);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.mnuETL;
            this.Name = "frmETL";
            this.Text = "frmETL";
            this.Load += new System.EventHandler(this.frmETL_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmETL_MouseMove);
            this.ContexMenuETL.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.mnuETL.ResumeLayout(false);
            this.mnuETL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ContexMenuETL;
        private System.Windows.Forms.ToolStripMenuItem insertarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem botonToolStripMenuItem;
        private System.Windows.Forms.Button btnCargaCFDi;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbTipoEmision;
        private System.Windows.Forms.ComboBox cmbEstadoFactura;
        private System.Windows.Forms.Label lblTipoEmision;
        private System.Windows.Forms.Label lblEstadoFactura;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnEnviarSolicitud;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtFechaInicial;
        private System.Windows.Forms.DateTimePicker dtFechaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnActualizaSolicitud;
        private System.Windows.Forms.Label lblEmpresas;
        private System.Windows.Forms.ComboBox cmbEempresas;
        private System.Windows.Forms.Label lblDescripcionEmpresas;
        private System.Windows.Forms.TextBox txtFechaInicial;
        private System.Windows.Forms.TextBox txtFechaFinal;
        private System.Windows.Forms.Label lblTipoSolicitud;
        private System.Windows.Forms.ComboBox cmbTipoSolicitud;
        private System.Windows.Forms.Label lblTipoEmision2;
        private System.Windows.Forms.ComboBox cmbTipoEmision2;
        private System.Windows.Forms.Button btnDescargaCFDI;
        private System.Windows.Forms.Button btnAutomatizado;
        private System.Windows.Forms.Timer tmrAutomatico;
        private System.Windows.Forms.MenuStrip mnuETL;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarAutomáticoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFCSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rfc_Emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC_Receptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoSolicitudGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion;
        private System.Windows.Forms.Button btnCargaMetadata;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalImportados;
    }
}