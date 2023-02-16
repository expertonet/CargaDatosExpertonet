
namespace CargaDatosExpertonet
{
    partial class fmrConfigAutomatico
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
            this.mnuETL = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarAutomáticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTipoEmision2 = new System.Windows.Forms.Label();
            this.cmbTipoEmision2 = new System.Windows.Forms.ComboBox();
            this.lblTipoSolicitud = new System.Windows.Forms.Label();
            this.cmbTipoSolicitud = new System.Windows.Forms.ComboBox();
            this.txtFechaFinal = new System.Windows.Forms.TextBox();
            this.txtFechaInicial = new System.Windows.Forms.TextBox();
            this.lblDescripcionEmpresas = new System.Windows.Forms.Label();
            this.lblEmpresas = new System.Windows.Forms.Label();
            this.cmbEempresas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtFechaProgramacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoraProgramacion = new System.Windows.Forms.DateTimePicker();
            this.dtFechaProgramacion = new System.Windows.Forms.DateTimePicker();
            this.radFechaHora = new System.Windows.Forms.RadioButton();
            this.radDiario = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.flDescripcion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_solicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFCSolicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfc_emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfc_receptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoSolicitudGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Programacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_Programacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_automatico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_ejecucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.mnuETL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuETL
            // 
            this.mnuETL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.mnuETL.Location = new System.Drawing.Point(0, 0);
            this.mnuETL.Name = "mnuETL";
            this.mnuETL.Size = new System.Drawing.Size(1212, 24);
            this.mnuETL.TabIndex = 39;
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
            this.configurarAutomáticoToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.configurarAutomáticoToolStripMenuItem.Text = "Configurar Automático";
            this.configurarAutomáticoToolStripMenuItem.Click += new System.EventHandler(this.configurarAutomáticoToolStripMenuItem_Click);
            // 
            // lblTipoEmision2
            // 
            this.lblTipoEmision2.AutoSize = true;
            this.lblTipoEmision2.Location = new System.Drawing.Point(34, 127);
            this.lblTipoEmision2.Name = "lblTipoEmision2";
            this.lblTipoEmision2.Size = new System.Drawing.Size(81, 13);
            this.lblTipoEmision2.TabIndex = 38;
            this.lblTipoEmision2.Text = "Tipo de emisión";
            // 
            // cmbTipoEmision2
            // 
            this.cmbTipoEmision2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEmision2.FormattingEnabled = true;
            this.cmbTipoEmision2.Location = new System.Drawing.Point(37, 143);
            this.cmbTipoEmision2.Name = "cmbTipoEmision2";
            this.cmbTipoEmision2.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoEmision2.TabIndex = 37;
            // 
            // lblTipoSolicitud
            // 
            this.lblTipoSolicitud.AutoSize = true;
            this.lblTipoSolicitud.Location = new System.Drawing.Point(33, 81);
            this.lblTipoSolicitud.Name = "lblTipoSolicitud";
            this.lblTipoSolicitud.Size = new System.Drawing.Size(71, 13);
            this.lblTipoSolicitud.TabIndex = 36;
            this.lblTipoSolicitud.Text = "Tipo Solicitud";
            // 
            // cmbTipoSolicitud
            // 
            this.cmbTipoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSolicitud.FormattingEnabled = true;
            this.cmbTipoSolicitud.Location = new System.Drawing.Point(36, 97);
            this.cmbTipoSolicitud.Name = "cmbTipoSolicitud";
            this.cmbTipoSolicitud.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoSolicitud.TabIndex = 35;
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.BackColor = System.Drawing.SystemColors.Window;
            this.txtFechaFinal.Location = new System.Drawing.Point(176, 71);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.ReadOnly = true;
            this.txtFechaFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFechaFinal.TabIndex = 34;
            // 
            // txtFechaInicial
            // 
            this.txtFechaInicial.BackColor = System.Drawing.SystemColors.Window;
            this.txtFechaInicial.Location = new System.Drawing.Point(25, 71);
            this.txtFechaInicial.Name = "txtFechaInicial";
            this.txtFechaInicial.ReadOnly = true;
            this.txtFechaInicial.Size = new System.Drawing.Size(100, 20);
            this.txtFechaInicial.TabIndex = 33;
            // 
            // lblDescripcionEmpresas
            // 
            this.lblDescripcionEmpresas.AutoSize = true;
            this.lblDescripcionEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionEmpresas.Location = new System.Drawing.Point(166, 52);
            this.lblDescripcionEmpresas.Name = "lblDescripcionEmpresas";
            this.lblDescripcionEmpresas.Size = new System.Drawing.Size(0, 20);
            this.lblDescripcionEmpresas.TabIndex = 32;
            // 
            // lblEmpresas
            // 
            this.lblEmpresas.AutoSize = true;
            this.lblEmpresas.Location = new System.Drawing.Point(33, 32);
            this.lblEmpresas.Name = "lblEmpresas";
            this.lblEmpresas.Size = new System.Drawing.Size(48, 13);
            this.lblEmpresas.TabIndex = 27;
            this.lblEmpresas.Text = "Empresa";
            // 
            // cmbEempresas
            // 
            this.cmbEempresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEempresas.FormattingEnabled = true;
            this.cmbEempresas.Location = new System.Drawing.Point(36, 48);
            this.cmbEempresas.Name = "cmbEempresas";
            this.cmbEempresas.Size = new System.Drawing.Size(121, 21);
            this.cmbEempresas.TabIndex = 26;
            this.cmbEempresas.SelectedIndexChanged += new System.EventHandler(this.cmbEempresas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Fecha Inicial";
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.CustomFormat = "yyyy-MM-dd";
            this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaFinal.Location = new System.Drawing.Point(279, 71);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(18, 20);
            this.dtFechaFinal.TabIndex = 29;
            this.dtFechaFinal.ValueChanged += new System.EventHandler(this.dtFechaFinal_ValueChanged);
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.CustomFormat = "yyyy-MM-dd";
            this.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicial.Location = new System.Drawing.Point(128, 71);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(18, 20);
            this.dtFechaInicial.TabIndex = 28;
            this.dtFechaInicial.ValueChanged += new System.EventHandler(this.dtFechaInicial_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flDescripcion,
            this.IdSolicitud,
            this.id_solicitud,
            this.RFCSolicitante,
            this.rfc_emisor,
            this.rfc_receptor,
            this.TipoSolicitudGrid,
            this.TipoEmision,
            this.FechaInicio,
            this.FechaFin,
            this.Fecha_Programacion,
            this.Hora_Programacion,
            this.tipo_automatico,
            this.Estado_id,
            this.estado_ejecucion});
            this.dataGridView1.Location = new System.Drawing.Point(12, 345);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1188, 300);
            this.dataGridView1.TabIndex = 40;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(36, 303);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 41;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(439, 303);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 42;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // txtFechaProgramacion
            // 
            this.txtFechaProgramacion.BackColor = System.Drawing.SystemColors.Window;
            this.txtFechaProgramacion.Location = new System.Drawing.Point(25, 128);
            this.txtFechaProgramacion.Name = "txtFechaProgramacion";
            this.txtFechaProgramacion.ReadOnly = true;
            this.txtFechaProgramacion.Size = new System.Drawing.Size(100, 20);
            this.txtFechaProgramacion.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Hora Programación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Fecha Programación";
            // 
            // txtHoraProgramacion
            // 
            this.txtHoraProgramacion.CustomFormat = "HH:mm:ss tt";
            this.txtHoraProgramacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtHoraProgramacion.Location = new System.Drawing.Point(178, 128);
            this.txtHoraProgramacion.Name = "txtHoraProgramacion";
            this.txtHoraProgramacion.ShowUpDown = true;
            this.txtHoraProgramacion.Size = new System.Drawing.Size(98, 20);
            this.txtHoraProgramacion.TabIndex = 44;
            this.txtHoraProgramacion.ValueChanged += new System.EventHandler(this.dtHoraProgramacion_ValueChanged);
            // 
            // dtFechaProgramacion
            // 
            this.dtFechaProgramacion.CustomFormat = "yyyy-MM-dd";
            this.dtFechaProgramacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaProgramacion.Location = new System.Drawing.Point(128, 128);
            this.dtFechaProgramacion.Name = "dtFechaProgramacion";
            this.dtFechaProgramacion.Size = new System.Drawing.Size(18, 20);
            this.dtFechaProgramacion.TabIndex = 43;
            this.dtFechaProgramacion.ValueChanged += new System.EventHandler(this.dtFechaProgramacion_ValueChanged);
            // 
            // radFechaHora
            // 
            this.radFechaHora.AutoSize = true;
            this.radFechaHora.Checked = true;
            this.radFechaHora.Location = new System.Drawing.Point(6, 16);
            this.radFechaHora.Name = "radFechaHora";
            this.radFechaHora.Size = new System.Drawing.Size(83, 17);
            this.radFechaHora.TabIndex = 48;
            this.radFechaHora.TabStop = true;
            this.radFechaHora.Text = "Fecha/Hora";
            this.radFechaHora.UseVisualStyleBackColor = true;
            this.radFechaHora.CheckedChanged += new System.EventHandler(this.radFechaHora_CheckedChanged);
            // 
            // radDiario
            // 
            this.radDiario.AutoSize = true;
            this.radDiario.Location = new System.Drawing.Point(118, 16);
            this.radDiario.Name = "radDiario";
            this.radDiario.Size = new System.Drawing.Size(52, 17);
            this.radDiario.TabIndex = 49;
            this.radDiario.Text = "Diario";
            this.radDiario.UseVisualStyleBackColor = true;
            this.radDiario.CheckedChanged += new System.EventHandler(this.radDiario_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEstado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFechaProgramacion);
            this.groupBox1.Controls.Add(this.radFechaHora);
            this.groupBox1.Controls.Add(this.radDiario);
            this.groupBox1.Controls.Add(this.dtFechaInicial);
            this.groupBox1.Controls.Add(this.txtFechaFinal);
            this.groupBox1.Controls.Add(this.dtFechaProgramacion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFechaInicial);
            this.groupBox1.Controls.Add(this.txtHoraProgramacion);
            this.groupBox1.Controls.Add(this.dtFechaFinal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(229, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 203);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(178, 164);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 51;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
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
            this.IdSolicitud.HeaderText = "ID";
            this.IdSolicitud.Name = "IdSolicitud";
            this.IdSolicitud.ReadOnly = true;
            this.IdSolicitud.Width = 43;
            // 
            // id_solicitud
            // 
            this.id_solicitud.HeaderText = "Id Solicitud";
            this.id_solicitud.Name = "id_solicitud";
            this.id_solicitud.Width = 84;
            // 
            // RFCSolicitante
            // 
            this.RFCSolicitante.HeaderText = "RFC";
            this.RFCSolicitante.Name = "RFCSolicitante";
            this.RFCSolicitante.ReadOnly = true;
            this.RFCSolicitante.Width = 53;
            // 
            // rfc_emisor
            // 
            this.rfc_emisor.HeaderText = "RFC Emisor";
            this.rfc_emisor.Name = "rfc_emisor";
            this.rfc_emisor.Width = 87;
            // 
            // rfc_receptor
            // 
            this.rfc_receptor.HeaderText = "RFC_Receptor";
            this.rfc_receptor.Name = "rfc_receptor";
            this.rfc_receptor.Width = 103;
            // 
            // TipoSolicitudGrid
            // 
            this.TipoSolicitudGrid.HeaderText = "Tipo Solicitud";
            this.TipoSolicitudGrid.Name = "TipoSolicitudGrid";
            this.TipoSolicitudGrid.ReadOnly = true;
            this.TipoSolicitudGrid.Width = 96;
            // 
            // TipoEmision
            // 
            this.TipoEmision.HeaderText = "TipoEmision";
            this.TipoEmision.Name = "TipoEmision";
            this.TipoEmision.ReadOnly = true;
            this.TipoEmision.Width = 89;
            // 
            // FechaInicio
            // 
            this.FechaInicio.HeaderText = "Fecha Inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 90;
            // 
            // FechaFin
            // 
            this.FechaFin.HeaderText = "Fecha Fin";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 79;
            // 
            // Fecha_Programacion
            // 
            this.Fecha_Programacion.HeaderText = "Fecha";
            this.Fecha_Programacion.Name = "Fecha_Programacion";
            this.Fecha_Programacion.Width = 62;
            // 
            // Hora_Programacion
            // 
            this.Hora_Programacion.HeaderText = "Hora";
            this.Hora_Programacion.Name = "Hora_Programacion";
            this.Hora_Programacion.Width = 55;
            // 
            // tipo_automatico
            // 
            this.tipo_automatico.HeaderText = "Tipo Automatico";
            this.tipo_automatico.Name = "tipo_automatico";
            // 
            // Estado_id
            // 
            this.Estado_id.HeaderText = "Estado";
            this.Estado_id.Name = "Estado_id";
            this.Estado_id.Width = 65;
            // 
            // estado_ejecucion
            // 
            this.estado_ejecucion.HeaderText = "Estado de Ejecucion";
            this.estado_ejecucion.Name = "estado_ejecucion";
            this.estado_ejecucion.Width = 119;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(170, 303);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 51;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // fmrConfigAutomatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 665);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mnuETL);
            this.Controls.Add(this.lblTipoEmision2);
            this.Controls.Add(this.cmbTipoEmision2);
            this.Controls.Add(this.lblTipoSolicitud);
            this.Controls.Add(this.cmbTipoSolicitud);
            this.Controls.Add(this.lblDescripcionEmpresas);
            this.Controls.Add(this.lblEmpresas);
            this.Controls.Add(this.cmbEempresas);
            this.Name = "fmrConfigAutomatico";
            this.Text = "Programar Tareas";
            this.Load += new System.EventHandler(this.fmrConfigAutomatico_Load);
            this.mnuETL.ResumeLayout(false);
            this.mnuETL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuETL;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarAutomáticoToolStripMenuItem;
        private System.Windows.Forms.Label lblTipoEmision2;
        private System.Windows.Forms.ComboBox cmbTipoEmision2;
        private System.Windows.Forms.Label lblTipoSolicitud;
        private System.Windows.Forms.ComboBox cmbTipoSolicitud;
        private System.Windows.Forms.TextBox txtFechaFinal;
        private System.Windows.Forms.TextBox txtFechaInicial;
        private System.Windows.Forms.Label lblDescripcionEmpresas;
        private System.Windows.Forms.Label lblEmpresas;
        private System.Windows.Forms.ComboBox cmbEempresas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaFinal;
        private System.Windows.Forms.DateTimePicker dtFechaInicial;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtFechaProgramacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtHoraProgramacion;
        private System.Windows.Forms.DateTimePicker dtFechaProgramacion;
        private System.Windows.Forms.RadioButton radFechaHora;
        private System.Windows.Forms.RadioButton radDiario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_solicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFCSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfc_emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfc_receptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoSolicitudGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Programacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_Programacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_automatico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_ejecucion;
        private System.Windows.Forms.Button btnActualizar;
    }
}