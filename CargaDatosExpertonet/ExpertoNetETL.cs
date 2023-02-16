using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CargaDatosExpertonet
{
    public partial class ExpertoNetETL : Form
    {
        private int childFormNumber = 0;

        public ExpertoNetETL()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void primeraVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmPrimeraVersion = new frmTransfer();
            frmPrimeraVersion.MdiParent = this;
            frmPrimeraVersion.Show();
        }

        private void segundaVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSegundaVersion = new frmETL();
            frmSegundaVersion.MdiParent = this;
            frmSegundaVersion.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAcerca = new frmAcercaDe();
            frmAcerca.ShowDialog();
        }

        private void cargarXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = @"C:\xnet\ReportesNomina\CONPAQi\Facturacion_TBN\Emitidas\xml\2021\0.xml";
            XmlTextReader reader = null;

            try
            {

                // Load the reader with the data file and ignore all white space nodes.
                reader = new XmlTextReader(filename);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.Write("<{0}>", reader.Name);
                            break;
                        case XmlNodeType.Text:
                            Console.Write(reader.Value);
                            break;
                        case XmlNodeType.CDATA:
                            Console.Write("<![CDATA[{0}]]>", reader.Value);
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            Console.Write("<!--{0}-->", reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                            Console.Write("<?xml version='1.0'?>");
                            break;
                        case XmlNodeType.Document:
                            break;
                        case XmlNodeType.DocumentType:
                            Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.EntityReference:
                            Console.Write(reader.Name);
                            break;
                        case XmlNodeType.EndElement:
                            Console.Write("</{0}>", reader.Name);
                            break;
                    }
                }
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

        }

        private void ExpertoNetETL_Load(object sender, EventArgs e)
        {

        }

        private void polizasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form fPolizas = new frmPolizas();
            fPolizas.MdiParent = this;
            fPolizas.Show();

        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fFacturas = new frmFacturas();
            fFacturas.MdiParent = this;
            fFacturas.Show();

        }

        private void programarTareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAuto = new fmrConfigAutomatico();
            frmAuto.MdiParent = this;
            frmAuto.Show();

        }

        private void ejecutarTareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmEjecutaTareas = new frmEjecutarTareas();
            frmEjecutaTareas.MdiParent = this;
            frmEjecutaTareas.Show();

        }

        private void copiarArchivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmCopiaArc = new frmCopiaArchivos();
            //frmCopiaArc.MdiParent = this;
            frmCopiaArc.ShowDialog();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistro frmRegistro = new frmRegistro();
            frmRegistro.MdiParent = this;
            frmRegistro.Show();

        }
    }
}
