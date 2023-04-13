using BLL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.UI.Filtro
{
    public partial class frmCoberturasAgregadas : Form
    {
        private int idTipoPoliza;
        public frmCoberturasAgregadas(int idTipoPoliza)
        {
            InitializeComponent();
            this.idTipoPoliza = idTipoPoliza;
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCoberturasAgregadas_Load(object sender, EventArgs e)
        {
            ICoberturaBLL logica = new CoberturaBLL();
            dgvCoberturasAgregadas.DataSource = logica.CoberturasAgregadas(idTipoPoliza);
        }
    }
}
