
namespace CargaDatosExpertonet
{
    partial class frmTransfer
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
            this.btnCargar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSqlServer = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNumRegSQLServer = new System.Windows.Forms.Label();
            this.lblNumRegMySql = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTablas = new System.Windows.Forms.ComboBox();
            this.gvArgumentosValores = new System.Windows.Forms.DataGridView();
            this.cmbArgumento = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.rbTexto = new System.Windows.Forms.RadioButton();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dpValor = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.cmbFiltroValores = new System.Windows.Forms.ComboBox();
            this.gvArgumentosValoresSqlServer = new System.Windows.Forms.DataGridView();
            this.btnAgregarSQLServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArgumentosValores)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvArgumentosValoresSqlServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(1395, 204);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(65, 23);
            this.btnCargar.TabIndex = 1;
            this.btnCargar.Tag = "mysql";
            this.btnCargar.Text = "Consultar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 233);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(693, 355);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnSqlServer
            // 
            this.btnSqlServer.Location = new System.Drawing.Point(634, 204);
            this.btnSqlServer.Name = "btnSqlServer";
            this.btnSqlServer.Size = new System.Drawing.Size(65, 23);
            this.btnSqlServer.TabIndex = 3;
            this.btnSqlServer.Tag = "sqlserver";
            this.btnSqlServer.Text = "Consultar";
            this.btnSqlServer.UseVisualStyleBackColor = true;
            this.btnSqlServer.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(760, 230);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(692, 355);
            this.dataGridView2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Empleados SQL Server";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(699, 410);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(55, 23);
            this.btnTransfer.TabIndex = 6;
            this.btnTransfer.Text = ">>>>";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(765, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Empleados MySql";
            // 
            // lblNumRegSQLServer
            // 
            this.lblNumRegSQLServer.AutoSize = true;
            this.lblNumRegSQLServer.Location = new System.Drawing.Point(6, 591);
            this.lblNumRegSQLServer.Name = "lblNumRegSQLServer";
            this.lblNumRegSQLServer.Size = new System.Drawing.Size(60, 13);
            this.lblNumRegSQLServer.TabIndex = 16;
            this.lblNumRegSQLServer.Text = "0 Registros";
            // 
            // lblNumRegMySql
            // 
            this.lblNumRegMySql.AutoSize = true;
            this.lblNumRegMySql.Location = new System.Drawing.Point(765, 591);
            this.lblNumRegMySql.Name = "lblNumRegMySql";
            this.lblNumRegMySql.Size = new System.Drawing.Size(60, 13);
            this.lblNumRegMySql.TabIndex = 17;
            this.lblNumRegMySql.Text = "0 Registros";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(199, 621);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1109, 23);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(653, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Trabla";
            // 
            // cmbTablas
            // 
            this.cmbTablas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablas.FormattingEnabled = true;
            this.cmbTablas.Location = new System.Drawing.Point(699, 15);
            this.cmbTablas.Name = "cmbTablas";
            this.cmbTablas.Size = new System.Drawing.Size(154, 21);
            this.cmbTablas.TabIndex = 19;
            // 
            // gvArgumentosValores
            // 
            this.gvArgumentosValores.AllowUserToAddRows = false;
            this.gvArgumentosValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvArgumentosValores.Location = new System.Drawing.Point(1060, 15);
            this.gvArgumentosValores.Name = "gvArgumentosValores";
            this.gvArgumentosValores.Size = new System.Drawing.Size(350, 175);
            this.gvArgumentosValores.TabIndex = 30;
            // 
            // cmbArgumento
            // 
            this.cmbArgumento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbArgumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArgumento.FormattingEnabled = true;
            this.cmbArgumento.Location = new System.Drawing.Point(645, 53);
            this.cmbArgumento.Name = "cmbArgumento";
            this.cmbArgumento.Size = new System.Drawing.Size(279, 21);
            this.cmbArgumento.TabIndex = 31;
            this.cmbArgumento.SelectedIndexChanged += new System.EventHandler(this.cmbArgumento_SelectedIndexChanged);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(699, 146);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(225, 20);
            this.txtValor.TabIndex = 32;
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(950, 31);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 33;
            this.btnAgregar.Tag = "mysql";
            this.btnAgregar.Text = "Agregar >>";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // rbTexto
            // 
            this.rbTexto.AutoSize = true;
            this.rbTexto.Checked = true;
            this.rbTexto.Location = new System.Drawing.Point(13, 2);
            this.rbTexto.Name = "rbTexto";
            this.rbTexto.Size = new System.Drawing.Size(52, 17);
            this.rbTexto.TabIndex = 34;
            this.rbTexto.TabStop = true;
            this.rbTexto.Tag = "texto";
            this.rbTexto.Text = "Texto";
            this.rbTexto.UseVisualStyleBackColor = true;
            this.rbTexto.CheckedChanged += new System.EventHandler(this.fnCambiaTextoFecha);
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Location = new System.Drawing.Point(89, 3);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(55, 17);
            this.rbFecha.TabIndex = 35;
            this.rbFecha.Tag = "fecha";
            this.rbFecha.Text = "Fecha";
            this.rbFecha.UseVisualStyleBackColor = true;
            this.rbFecha.CheckedChanged += new System.EventHandler(this.fnCambiaTextoFecha);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbFecha);
            this.panel2.Controls.Add(this.rbTexto);
            this.panel2.Location = new System.Drawing.Point(699, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 20);
            this.panel2.TabIndex = 36;
            // 
            // dpValor
            // 
            this.dpValor.CustomFormat = "yyyy-MM-dd HH:MM:ss";
            this.dpValor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpValor.Location = new System.Drawing.Point(699, 147);
            this.dpValor.Name = "dpValor";
            this.dpValor.Size = new System.Drawing.Size(144, 20);
            this.dpValor.TabIndex = 40;
            this.dpValor.Visible = false;
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Location = new System.Drawing.Point(485, 98);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(54, 13);
            this.lblFiltroNombre.TabIndex = 42;
            this.lblFiltroNombre.Text = "Catálogos";
            // 
            // cmbFiltroValores
            // 
            this.cmbFiltroValores.FormattingEnabled = true;
            this.cmbFiltroValores.Location = new System.Drawing.Point(548, 90);
            this.cmbFiltroValores.Name = "cmbFiltroValores";
            this.cmbFiltroValores.Size = new System.Drawing.Size(486, 21);
            this.cmbFiltroValores.TabIndex = 41;
            this.cmbFiltroValores.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroValores_SelectedIndexChanged);
            // 
            // gvArgumentosValoresSqlServer
            // 
            this.gvArgumentosValoresSqlServer.AllowUserToAddRows = false;
            this.gvArgumentosValoresSqlServer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvArgumentosValoresSqlServer.Location = new System.Drawing.Point(86, 12);
            this.gvArgumentosValoresSqlServer.Name = "gvArgumentosValoresSqlServer";
            this.gvArgumentosValoresSqlServer.Size = new System.Drawing.Size(350, 175);
            this.gvArgumentosValoresSqlServer.TabIndex = 43;
            // 
            // btnAgregarSQLServer
            // 
            this.btnAgregarSQLServer.Location = new System.Drawing.Point(473, 31);
            this.btnAgregarSQLServer.Name = "btnAgregarSQLServer";
            this.btnAgregarSQLServer.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarSQLServer.TabIndex = 44;
            this.btnAgregarSQLServer.Tag = "sqlserver";
            this.btnAgregarSQLServer.Text = "<< Agregar";
            this.btnAgregarSQLServer.UseVisualStyleBackColor = true;
            this.btnAgregarSQLServer.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Parámetros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(659, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Valor";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(734, 177);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(91, 13);
            this.lblKey.TabIndex = 47;
            this.lblKey.Text = "Empleados MySql";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(760, 233);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(692, 355);
            this.dataGridView3.TabIndex = 4;
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 670);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregarSQLServer);
            this.Controls.Add(this.gvArgumentosValoresSqlServer);
            this.Controls.Add(this.lblFiltroNombre);
            this.Controls.Add(this.cmbFiltroValores);
            this.Controls.Add(this.dpValor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cmbArgumento);
            this.Controls.Add(this.gvArgumentosValores);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTablas);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblNumRegMySql);
            this.Controls.Add(this.lblNumRegSQLServer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnSqlServer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCargar);
            this.Name = "frmTransfer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArgumentosValores)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvArgumentosValoresSqlServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSqlServer;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNumRegSQLServer;
        private System.Windows.Forms.Label lblNumRegMySql;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTablas;
        private System.Windows.Forms.DataGridView gvArgumentosValores;
        private System.Windows.Forms.ComboBox cmbArgumento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.RadioButton rbTexto;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dpValor;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.ComboBox cmbFiltroValores;
        private System.Windows.Forms.DataGridView gvArgumentosValoresSqlServer;
        private System.Windows.Forms.Button btnAgregarSQLServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}

