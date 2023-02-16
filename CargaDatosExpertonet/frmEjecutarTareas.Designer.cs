
namespace CargaDatosExpertonet
{
    partial class frmEjecutarTareas
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
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tEnviaSolicitud = new System.Windows.Forms.Timer(this.components);
            this.chkEjecucion = new System.Windows.Forms.CheckBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.tAactualizaEstado = new System.Windows.Forms.Timer(this.components);
            this.tDescargaXML = new System.Windows.Forms.Timer(this.components);
            this.tEnviaLocal = new System.Windows.Forms.Timer(this.components);
            this.tEnviaNominamex = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.Location = new System.Drawing.Point(204, 78);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(148, 54);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "Iniciar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 178);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(612, 373);
            this.txtLog.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ejecutar Tareas";
            // 
            // tEnviaSolicitud
            // 
            this.tEnviaSolicitud.Interval = 1000;
            this.tEnviaSolicitud.Tick += new System.EventHandler(this.timerTareas_Tick);
            // 
            // chkEjecucion
            // 
            this.chkEjecucion.AutoSize = true;
            this.chkEjecucion.Location = new System.Drawing.Point(436, 73);
            this.chkEjecucion.Name = "chkEjecucion";
            this.chkEjecucion.Size = new System.Drawing.Size(80, 17);
            this.chkEjecucion.TabIndex = 5;
            this.chkEjecucion.Text = "checkBox1";
            this.chkEjecucion.UseVisualStyleBackColor = true;
            this.chkEjecucion.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(12, 149);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(48, 26);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Log";
            // 
            // tAactualizaEstado
            // 
            this.tAactualizaEstado.Interval = 1000;
            this.tAactualizaEstado.Tick += new System.EventHandler(this.tAactualizaEstado_Tick);
            // 
            // tDescargaXML
            // 
            this.tDescargaXML.Interval = 1000;
            this.tDescargaXML.Tick += new System.EventHandler(this.tDescargaXML_Tick);
            // 
            // tEnviaLocal
            // 
            this.tEnviaLocal.Interval = 1000;
            this.tEnviaLocal.Tick += new System.EventHandler(this.tEnviaLocal_Tick);
            // 
            // tEnviaNominamex
            // 
            this.tEnviaNominamex.Interval = 1000;
            this.tEnviaNominamex.Tick += new System.EventHandler(this.tEnviaNominamex_Tick);
            // 
            // frmEjecutarTareas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 563);
            this.Controls.Add(this.chkEjecucion);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnEjecutar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEjecutarTareas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ejecutar Tareas";
            this.Load += new System.EventHandler(this.frmEjecutarTareas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tEnviaSolicitud;
        private System.Windows.Forms.CheckBox chkEjecucion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Timer tAactualizaEstado;
        private System.Windows.Forms.Timer tDescargaXML;
        private System.Windows.Forms.Timer tEnviaLocal;
        private System.Windows.Forms.Timer tEnviaNominamex;
    }
}