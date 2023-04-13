using BLL;
using capa.Entidades;
using Capa.UI.Filtro;
using Capa.UI.Reporte;
using Capa.UI.Util;
using DAL;
using Entities;
using Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.UI.Facturacion
{
    public partial class frmFacturacion : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private Factura _Factura = new Factura();
        double valorDolar = 0;
        public frmFacturacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Este métodoc carga los datos que son llamados desde la base de datos y los coloca en sus respectivos combobox y datagrid views
        /// </summary>
        private void CargarDatos()
        {
            ITipoPagoBLL logicaTipoPago = new TipoPagoBLL();
            ITarjetaBLL logicaTarjeta = new TarjetaBLL();
            ITipoPolizaBLL logicaTipoPlan = new TipoPolizaBLL();
            try
            {
                cmbTarjetas.DataSource = logicaTarjeta.ObtenerTarjeta();
                cmbTarjetas.DisplayMember = "Nombre";
                cmbTarjetas.ValueMember = "Id";
                cmbTarjetas.SelectedIndex = -1;

                cmbTipoPago.DataSource = logicaTipoPago.ObtenerTipoPago();
                cmbTipoPago.DisplayMember = "Descripcion";
                cmbTipoPago.ValueMember = "Id";
                cmbTipoPago.SelectedIndex = -1;

                dgvDatosTipoPlan.DataSource = logicaTipoPlan.ObtenerTipoPolizas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        /// <summary>
        /// Cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Carga el culture info para Costa Rica y invoca al método que carga los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            Utilitarios.CultureInfo();
            CargarDatos();
        
        }


        /// <summary>
        /// Este método  verifica que hayan datos en la parte de tarjetas y si es así, invoca al dialog de filtro usuarios para poder escoger al usuario por facturar
        /// una vez hecho esto, vuelve al presente form con los campos de id y nombre cargados 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Usuario user = null;
           frmFiltroUsuario frm = new frmFiltroUsuario();

            try
            {
                erpError.Clear();
                if (cmbTarjetas.SelectedIndex == -1)
                {
                    erpError.SetError(cmbTarjetas, "Debe indicar el tipo de tarjeta");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtNumTarjeta.Text))
                {
                    erpError.SetError(txtNumTarjeta, "Debe digitar su número de tarjeta");
                    return;
                }
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    user = frm._User;
                    txtId.Text = user.Id.ToString();
                    txtNombre.Text = user.Nombre;
                    _Factura.IdUsuario = user.Id;
                }

                _Factura.IdTarjeta = (int)cmbTarjetas.SelectedValue;
                _Factura.NumeroTarjeta = int.Parse(txtNumTarjeta.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }


        /// <summary>
        /// Este método invoca al frame que muestra las coberturas del tipo de plan seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarCoberturas_Click(object sender, EventArgs e)
        {
            frmCoberturasAgregadas frm;
            TipoPoliza tipoPoliza = null;
            try
            {
                if (this.dgvDatosTipoPlan.SelectedRows.Count > 0)
                {
                    tipoPoliza = this.dgvDatosTipoPlan.SelectedRows[0].DataBoundItem as TipoPoliza;
                    frm = new frmCoberturasAgregadas(tipoPoliza.Id);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

    

        /// <summary>
        /// Este método invoca al método calcula costo que trae el precio a pagar según el tipo de pago seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ITipoPagoBLL logicaTipoPago = new TipoPagoBLL();


            TipoPoliza tipoPoliza = null;
            try
            {
                if (this.dgvDatosTipoPlan.SelectedRows.Count > 0)
                {


                    if (cmbTipoPago.SelectedIndex == -1)
                    {
                        erpError.SetError(cmbTipoPago, "Debe seleccionar un tipo de pago");
                        return;
                    }
                    TipoPago tipoPago = logicaTipoPago.ObtenerPorId((int)cmbTipoPago.SelectedValue);
                    tipoPoliza = this.dgvDatosTipoPlan.SelectedRows[0].DataBoundItem as TipoPoliza;

                    _Factura.CalculaCosto(tipoPago.Porcentaje, tipoPoliza.Costo, tipoPago.Descripcion);
                    txtTotal.Text = _Factura.TotalDolares.ToString("N2");
                    txtTotalColones.Text = Utilitarios.ConsumoDolar(_Factura.TotalDolares).ToString("N2");

                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }


        /// <summary>
        /// Este ,método limpia todos los campos del frame para poder facturar nuevamente 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                txtNumTarjeta.Clear();
                cmbTarjetas.SelectedIndex = -1;
                txtId.Clear();
                txtNombre.Clear();
                txtTotal.Text = "Total";
                txtTotalColones.Text = "Total";
                _Factura = new Factura();
                cmbTipoPago.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        /// <summary>
        /// Este método termina de llenar la factura con los datos para poder ser enviado a la capa lógica y de ahí ser enviado a la base de datos por medio de la DAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnFacturar_Click(object sender, EventArgs e)
        {
            IPolizaBLL logicaPoliza = new PolizaBLL();
            IFacturaBLL logicaFactura = new FacturaBLL();
            //IFacturaBLL logica = new FacturaLN();
            string rutaImagen = @"c:\temp\qr.png";
            int numeroFactura = 0;
            try
            {
                if (_Factura == null)
                {
                    MessageBox.Show("No hay datos por facturar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _Factura.FechaFacturacion = DateTime.Now;
                _Factura._Poliza = new Poliza();
                _Factura._Poliza.Id = logicaPoliza.GetNextNumeroPoliza();
                _Factura._Poliza.Descripcion = "Poliza";
                _Factura._Poliza.IdTipoPoliza = (int)this.dgvDatosTipoPlan.SelectedRows[0].Cells[0].Value;
                _Factura._Poliza.FechaVencimiento = new DateTime((DateTime.Now.Year + 1), DateTime.Now.Month, DateTime.Now.Day);
                _Factura._Poliza.IdUsuario =int.Parse(txtId.Text);
                _Factura._Poliza.IdFactura = _Factura._Poliza.Id;

                _Factura.IdPoliza = _Factura._Poliza.Id;
                _Factura.IdFactura = _Factura._Poliza.IdFactura;
                _Factura.IdTipoPago = (int)cmbTipoPago.SelectedValue;
                _Factura.TotalColones = decimal.Parse(txtTotalColones.Text);
                

                logicaFactura.Insertar(_Factura);

                numeroFactura = _Factura.IdFactura;

                if (_Factura == null)
                    MessageBox.Show("Error al crear factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    toolStripBtnNuevo_Click(null, null);

                //Si existe borrelo
                if (File.Exists(rutaImagen))
                    File.Delete(rutaImagen);

                // Crear imagen quickresponse
                Image quickResponseImage = QuickResponse.QuickResponseGenerador(numeroFactura.ToString(), 53);

                // Salvarla en c:\temp para luego ser leida
                quickResponseImage.Save(rutaImagen, ImageFormat.Png);

                frmRptFactura ofrmReporteFactura = new frmRptFactura(numeroFactura);
                ofrmReporteFactura.ShowDialog();
                _Factura = new Factura();
            }
            catch (Exception er)
            {
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(er.Message);
            }
        }
    }
}
