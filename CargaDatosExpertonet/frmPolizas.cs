using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CargaDatosExpertonet
{
    public partial class frmPolizas : Form
    {
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());

        SqlCommand cmdReader;
        SqlDataReader reader;
        string slqInsert;

        SqlCommand comando;
        public frmPolizas()
        {
            InitializeComponent();
        }

        private void frmPolizas_Load(object sender, EventArgs e)
        {
            //slqInsert = "SELECT OPERACION, OPERACION OPERACION2 FROM [FACTURAS] ORDER BY OPERACION";
            //cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            //cnn.fnConectarSQLServer();
            //reader = cmdReader.ExecuteReader();
            //cmbOperacion.Items.Clear();
            //while (reader.Read())
            //    cmbOperacion.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[1].ToString());
            //cmdReader.Dispose();
            //reader.Close();
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbOperacion_MouseClick(object sender, MouseEventArgs e)
        {
            slqInsert = "SELECT OPERACION, OPERACION OPERACION2 FROM [FACTURAS] ORDER BY OPERACION";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            reader = cmdReader.ExecuteReader();
            cmbOperacion.Items.Clear();
            while (reader.Read())
                cmbOperacion.Items.Insert(Convert.ToInt32(reader[0]) - 1, reader[1].ToString());
            cmdReader.Dispose();
            reader.Close();
        }
    }
}
