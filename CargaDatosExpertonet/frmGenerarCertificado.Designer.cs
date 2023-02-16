
namespace CargaDatosExpertonet
{
    partial class frmGenerarCertificado
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
            this.btnBuscaCer = new System.Windows.Forms.Button();
            this.txtCer = new System.Windows.Forms.TextBox();
            this.lblCer = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnBuscaKey = new System.Windows.Forms.Button();
            this.lblRFC = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCertificado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBuscaCer
            // 
            this.btnBuscaCer.Location = new System.Drawing.Point(436, 73);
            this.btnBuscaCer.Name = "btnBuscaCer";
            this.btnBuscaCer.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaCer.TabIndex = 0;
            this.btnBuscaCer.Text = "Buscar";
            this.btnBuscaCer.UseVisualStyleBackColor = true;
            this.btnBuscaCer.Click += new System.EventHandler(this.btnBuscaCer_Click);
            // 
            // txtCer
            // 
            this.txtCer.BackColor = System.Drawing.SystemColors.Window;
            this.txtCer.Location = new System.Drawing.Point(66, 76);
            this.txtCer.Multiline = true;
            this.txtCer.Name = "txtCer";
            this.txtCer.ReadOnly = true;
            this.txtCer.Size = new System.Drawing.Size(364, 89);
            this.txtCer.TabIndex = 1;
            // 
            // lblCer
            // 
            this.lblCer.AutoSize = true;
            this.lblCer.Location = new System.Drawing.Point(63, 60);
            this.lblCer.Name = "lblCer";
            this.lblCer.Size = new System.Drawing.Size(87, 13);
            this.lblCer.TabIndex = 2;
            this.lblCer.Text = "Certificado (.cer):";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(63, 195);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(104, 13);
            this.lblKey.TabIndex = 5;
            this.lblKey.Text = "Clave privada (.key):";
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.SystemColors.Window;
            this.txtKey.Location = new System.Drawing.Point(66, 211);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(364, 89);
            this.txtKey.TabIndex = 4;
            // 
            // btnBuscaKey
            // 
            this.btnBuscaKey.Location = new System.Drawing.Point(436, 208);
            this.btnBuscaKey.Name = "btnBuscaKey";
            this.btnBuscaKey.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaKey.TabIndex = 3;
            this.btnBuscaKey.Text = "Buscar";
            this.btnBuscaKey.UseVisualStyleBackColor = true;
            this.btnBuscaKey.Click += new System.EventHandler(this.btnBuscaKey_Click);
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.Location = new System.Drawing.Point(63, 10);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(31, 13);
            this.lblRFC.TabIndex = 7;
            this.lblRFC.Text = "RFC:";
            // 
            // txtRFC
            // 
            this.txtRFC.BackColor = System.Drawing.SystemColors.Window;
            this.txtRFC.Location = new System.Drawing.Point(66, 26);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(364, 20);
            this.txtRFC.TabIndex = 6;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(63, 317);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(146, 13);
            this.lblPass.TabIndex = 9;
            this.lblPass.Text = "Contraseña de clave privada:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(66, 333);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(364, 20);
            this.txtPass.TabIndex = 8;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(66, 359);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(96, 541);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(156, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archivos Cer|*.cer";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "Archivos Key|*.key";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(289, 541);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(156, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Certificado:";
            // 
            // txtCertificado
            // 
            this.txtCertificado.BackColor = System.Drawing.SystemColors.Window;
            this.txtCertificado.Location = new System.Drawing.Point(66, 429);
            this.txtCertificado.Multiline = true;
            this.txtCertificado.Name = "txtCertificado";
            this.txtCertificado.ReadOnly = true;
            this.txtCertificado.Size = new System.Drawing.Size(364, 89);
            this.txtCertificado.TabIndex = 13;
            // 
            // frmGenerarCertificado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 584);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCertificado);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblRFC);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnBuscaKey);
            this.Controls.Add(this.lblCer);
            this.Controls.Add(this.txtCer);
            this.Controls.Add(this.btnBuscaCer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerarCertificado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmGenerarCertificado";
            this.Load += new System.EventHandler(this.frmGenerarCertificado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscaCer;
        private System.Windows.Forms.TextBox txtCer;
        private System.Windows.Forms.Label lblCer;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnBuscaKey;
        private System.Windows.Forms.Label lblRFC;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCertificado;
    }
}