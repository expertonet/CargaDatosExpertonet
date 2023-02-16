using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaDatosExpertonet
{
    public partial class frmRegistro : Form
    {
        SqlCommand comando;
        string slqInsert = string.Empty;
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());

        static public string vCertificado { get; set; }


        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnGenerarCertificado_Click(object sender, EventArgs e)
        {
            frmGenerarCertificado frmGenReg = new frmGenerarCertificado();

            frmGenReg.vRFC = txtRFC.Text;
            frmGenReg.ShowDialog();
            txtRutaCertificado.Text = vCertificado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            slqInsert = @"
                                  INSERT INTO [dbo].[PersonaFisicaMoral]
                                       ([RFC]
                                       ,[RazonSocial]
                                       ,[Alias]
                                       ,[Usuario]
                                       ,[Clave]
                                       ,[Certificado]
                                       ,[Id])
                                    VALUES
                                        ( '" + txtRFC.Text.Trim() + @"'
                                        ,'" + txtRazonSocial.Text.Trim() + @"'
                                        ,'" + txtAlias.Text.Trim() + @"'
                                        ,'" + txtUsuario.Text.Trim() + @"'
                                        ,'" + txtClave.Text.Trim() + @"'
                                        ,'" + txtRutaCertificado.Text.Trim() + @"'
                                        ,(select ISNULL(MAX(id)+1,1) from PersonaFisicaMoral))
                                    ";
            slqInsert = slqInsert.Replace("'null'", "null");
            comando = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            comando.ExecuteNonQuery();
            comando.Dispose();

            MessageBox.Show("Se guardo exiosamente !");
        }
    }
}
