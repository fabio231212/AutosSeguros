using BLL;
using capa.Entidades;
using Entities;
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

namespace Capa.UI.Mantenimientos
{
    public partial class frmMantenimientoAnulaFac : Form
    {
        public frmMantenimientoAnulaFac()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Carga los datos en las tablas
        /// </summary>
        public void CargarDatos() {
            IFacturaBLL logicaFactura = new FacturaBLL();
            dgvDatos.DataSource = logicaFactura.SeleccionarFacturaHoy();
            dgvFacturasAnuladas.DataSource = logicaFactura.SeleccionarFacturasAnuladas();
        }

        private void frmMantenimientoAnulaFac_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        /// <summary>
        /// Selecciona el registro y anula la factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            IFacturaBLL logicaFactura = new FacturaBLL();
            // logicaFactura.AnularFactura()
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                Factura factura = this.dgvDatos.SelectedRows[0].DataBoundItem as Factura;
                logicaFactura.AnularFactura(factura.IdFactura);
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione el registro !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
