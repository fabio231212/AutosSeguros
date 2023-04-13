using Capa.UI.Facturacion;
using Capa.UI.Mantenimientos;
using Capa.UI.Reporte;
using Entities;
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

namespace Capa.UI
{
    public partial class frmPrincipal : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void VerificarTipoUsuario()
        {

            if (CacheUsuario.IdTipoUsuario == 3)
            {
                toolStripMenuItemMantenimientos.Visible = false;
                toolStripMenuItemProcesos.Visible = false;

            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("¿Desea Cerrar Sesión?", "Atención", MessageBoxButtons.YesNo);
              
                    if (r == DialogResult.Yes)
                    {
                        this.Close();
                    }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);

            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("¿Desea Salir?", "Atención", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
                 _MyLogControlEventos.Error("Se cierra la aplicación");
            }
        }

        private void TsMenuItemUsuarios_Click(object sender, EventArgs e)
        {

            frmMantenimientoUsuarios ofrmMantenimientoUsuarios;

            try
            {
                ofrmMantenimientoUsuarios = new frmMantenimientoUsuarios();
                ofrmMantenimientoUsuarios.MdiParent = this;
                ofrmMantenimientoUsuarios.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void TsMenuItemCoberturas_Click(object sender, EventArgs e)
        {
            frmMantenimientoCoberturas ofrmMantenimientoCoberturas;

            try
            {
                ofrmMantenimientoCoberturas = new frmMantenimientoCoberturas();
                ofrmMantenimientoCoberturas.MdiParent = this;
                ofrmMantenimientoCoberturas.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMantenimientoIVA ofrmMantenimientoIva;

            try
            {
                ofrmMantenimientoIva = new frmMantenimientoIVA();
                ofrmMantenimientoIva.MdiParent = this;
                ofrmMantenimientoIva.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void TsMenuItemPolizas_Click(object sender, EventArgs e)
        {
         
        }

        private void tipoPolizaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoTipoPoliza ofrmMantenimientoTipoPolizas;

            try
            {
                ofrmMantenimientoTipoPolizas = new frmMantenimientoTipoPoliza();
                ofrmMantenimientoTipoPolizas.MdiParent = this;
                ofrmMantenimientoTipoPolizas.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void TsMenuItemFacturacion_Click(object sender, EventArgs e)
        {
            frmFacturacion ofrmFacturacion;

            try
            {
                ofrmFacturacion = new frmFacturacion();
                ofrmFacturacion.MdiParent = this;
                ofrmFacturacion.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

 

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRptPolizasByFecha frmPolizasVendidas;

            try
            {
                frmPolizasVendidas = new frmRptPolizasByFecha();
                frmPolizasVendidas.MdiParent = this;
                frmPolizasVendidas.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void PolizasPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptPolizaByIdUsuario frmRptPolizasByIdUsuario;

            try
            {
                frmRptPolizasByIdUsuario = new frmRptPolizaByIdUsuario();
                frmRptPolizasByIdUsuario.MdiParent = this;
                frmRptPolizasByIdUsuario.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void anularFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoAnulaFac frmAnulaFacturas;

            try
            {
                frmAnulaFacturas = new frmMantenimientoAnulaFac();
                frmAnulaFacturas.MdiParent = this;
                frmAnulaFacturas.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void ventasPorDíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptVentasByDia frmVentas;

            try
            {
                frmVentas = new frmRptVentasByDia();
                frmVentas.MdiParent = this;
                frmVentas.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            VerificarTipoUsuario();
        }
    }
}
