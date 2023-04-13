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
    public partial class frmRptVentasByDia : Form
    {
        public frmRptVentasByDia()
        {
            InitializeComponent();
        }

        private void frmRptVentasByDia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetReportes.usp_SELECT_VentasByDia' table. You can move, or remove it, as needed.
            this.usp_SELECT_VentasByDiaTableAdapter.Fill(this.dataSetReportes.usp_SELECT_VentasByDia);

            this.reportViewer1.RefreshReport();
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
