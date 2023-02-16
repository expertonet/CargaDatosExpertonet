
namespace CargaDatosExpertonet
{
    partial class frmCopiaArchivos
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
            this.btnTransferir = new System.Windows.Forms.Button();
            this.lblNombreTabla = new System.Windows.Forms.Label();
            this.lblNumRegistros = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(339, 69);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(75, 23);
            this.btnTransferir.TabIndex = 0;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // lblNombreTabla
            // 
            this.lblNombreTabla.AutoSize = true;
            this.lblNombreTabla.Location = new System.Drawing.Point(294, 151);
            this.lblNombreTabla.Name = "lblNombreTabla";
            this.lblNombreTabla.Size = new System.Drawing.Size(108, 13);
            this.lblNombreTabla.TabIndex = 1;
            this.lblNombreTabla.Text = "Numero de renglones";
            // 
            // lblNumRegistros
            // 
            this.lblNumRegistros.AutoSize = true;
            this.lblNumRegistros.Location = new System.Drawing.Point(294, 175);
            this.lblNumRegistros.Name = "lblNumRegistros";
            this.lblNumRegistros.Size = new System.Drawing.Size(108, 13);
            this.lblNumRegistros.TabIndex = 2;
            this.lblNumRegistros.Text = "Numero de renglones";
            // 
            // frmCopiaArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNumRegistros);
            this.Controls.Add(this.lblNombreTabla);
            this.Controls.Add(this.btnTransferir);
            this.Name = "frmCopiaArchivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TransferLite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.Label lblNombreTabla;
        private System.Windows.Forms.Label lblNumRegistros;
    }
}