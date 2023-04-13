using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.UI.Reporte
{
    public partial class frmRptPolizaByIdUsuario : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmRptPolizaByIdUsuario()
        {
            InitializeComponent();
        }

        private void toolStripTxtId_Enter(object sender, EventArgs e)
        {
            if (toolStripTxtId.Text.Equals("Identificación"))
            {
                toolStripTxtId.Text = "";
                toolStripTxtId.ForeColor = Color.White;
            }
        }

        private void toolStripTxtId_Leave(object sender, EventArgs e)
        {
            if (toolStripTxtId.Text == "")
            {
                toolStripTxtId.Text = "Identificación";
                toolStripTxtId.ForeColor = Color.White;
            }
        }

        private void toolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            if (toolStripTxtId.Text == "" || toolStripTxtId.Text == "Identificación")
            {
                MessageBox.Show("Debe digitar la identificación");
                return;
            }
            try
            {
                this.usp_PolizaByIdUsuarioTableAdapter.Fill(this.dataSetReportes.usp_PolizaByIdUsuario, toolStripTxtId.Text.Trim());

                this.rptVisor.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void frmRptPolizaByIdUsuario_Load(object sender, EventArgs e)
        {

            this.rptVisor.RefreshReport();
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
