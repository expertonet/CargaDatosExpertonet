using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaDatosExpertonet
{
    public partial class frmGenerarCertificado : Form
    {
        public string vRFC { get; set; }
        public string vCertificado { get; set; }
        public frmGenerarCertificado()
        {
            InitializeComponent();
        }

        private void btnBuscaCer_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtCer.Text = openFileDialog1.FileName;
            }

        }

        private void btnBuscaKey_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog2.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtKey.Text = openFileDialog2.FileName;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string strCer = txtCer.Text.Trim();
            string strKey = txtKey.Text.Trim();
            string strPass = txtPass.Text.Trim();
            string strRFC = txtRFC.Text.Trim();

            string strRuta = @"C:\PaquetesDescargados\access\"+strRFC;
            string strArchivoCer = strRuta + "\\" + strRFC + "_Cer.pem";
            string strArchivoKey = strRuta + "\\" + strRFC + "_Key.pem";
            string strArchivoPfx = strRuta + "\\" + strRFC + ".pfx";

            Directory.CreateDirectory(strRuta);

            ExecuteCommand("openssl pkcs8 -inform der -in " + strKey + " -passin pass:" + strPass + " -out " + strArchivoKey);
            ExecuteCommand("openssl x509 -inform der -in "+strCer+" -out "+strArchivoCer);
            ExecuteCommand("openssl pkcs12 -passout pass:" + strPass + " -export -in " + strArchivoCer+" -inkey "+strArchivoKey+" -out "+strArchivoPfx);

            Thread.Sleep(200);

            File.Delete(strArchivoKey);
            File.Delete(strArchivoCer);

            txtCertificado.Text = strArchivoPfx;

            MessageBox.Show("Creación exitosa !!");
        }

        void ExecuteCommand(string _Command)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + _Command);

            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = procStartInfo; 
            proc.Start();
        }

        private void frmGenerarCertificado_Load(object sender, EventArgs e)
        {
            txtRFC.Text = this.vRFC;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmRegistro.vCertificado = txtCertificado.Text;
            this.Close();
        }
    }
}
