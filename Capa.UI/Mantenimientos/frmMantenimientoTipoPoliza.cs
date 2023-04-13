using BLL;
using Entities;
using Interfaces;
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

namespace Capa.UI.Mantenimientos
{
    public partial class frmMantenimientoTipoPoliza : Form
    {
    
    EstadoMantenimiento estadoMantenimiento;
        List<Cobertura> listaCobertura;
    private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
    public frmMantenimientoTipoPoliza()
        {
            InitializeComponent();
            listaCobertura = new List<Cobertura>();
        }


        /// <summary>
        /// Cargar los datos de las tablas y combos
        /// </summary>
        private void CargarDatos()
        {
            try
            {

                ITipoPolizaBLL logica = new TipoPolizaBLL();
                dgvDatos.DataSource = logica.ObtenerTipoPolizas();

                ICoberturaBLL logicaCobertura = new CoberturaBLL();
                cmbCobertura.DataSource = logicaCobertura.SeleccionarTodas();
                cmbCobertura.DisplayMember = "Descripcion";
                cmbCobertura.ValueMember = "Id";
                cmbCobertura.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);

            }
        }
        private void CambiarEstadoMantenimiento(EstadoMantenimiento estado)
        {
            txtDescripcion.Clear();
            txtId.Clear();
            txtCosto.Clear();
            dgvDatosCobertura.DataSource = null;
            cmbCobertura.SelectedIndex = -1;
            dgvCoberturasAgregadas.DataSource = null;
            txtDescripcion.Enabled = false;
            txtId.Enabled = false;
            listaCobertura = new List<Cobertura>();

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:


                    txtDescripcion.Enabled = true;
                    txtId.Enabled = true;
                  //  listaCobertura = new List<Cobertura>();
                    estadoMantenimiento = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    txtDescripcion.Enabled = true;
                    txtId.Enabled = false;


                    estadoMantenimiento = EstadoMantenimiento.Editar;
                    break;

                case EstadoMantenimiento.Borrar:
                    estadoMantenimiento = EstadoMantenimiento.Borrar;
                    break;

                case EstadoMantenimiento.Ninguno:
                    estadoMantenimiento = EstadoMantenimiento.Ninguno;
                    break;
            }
        }
        /// <summary>
        /// Cancela la ejecución y limpia los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CambiarEstadoMantenimiento(EstadoMantenimiento.Ninguno);
        }

        /// <summary>
        /// eveneto que se ejecuta al abrir el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMantenimientoTipoPoliza_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        /// <summary>
        /// Verifica que no haya añadido la cobertura anteriormente y lo guarda en una lista tipo cobertura. Además llena el txtcosto con la suma del
        ///total de las coberturas que es el mismo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarCobertura_Click(object sender, EventArgs e)
        {
            ICoberturaBLL logicaCobertura = new CoberturaBLL();
            Cobertura cobertura = logicaCobertura.SeleccionarPorId((int)cmbCobertura.SelectedValue);
            if (listaCobertura.FindAll(p => p.Id == cobertura.Id).Count > 0)
            {
                MessageBox.Show("La cobertura ya fue agregada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listaCobertura.Add(cobertura);
            decimal costo = 0;
            foreach (var item in listaCobertura)
            {
                costo += item.Total;
            }
            txtCosto.Text = costo.ToString();
            dgvDatosCobertura.DataSource = null;
            dgvDatosCobertura.DataSource =listaCobertura;
        }
        /// <summary>
        /// Valida los campos y actualiza los registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
          

            ErrorProvider oErrorProvider = new ErrorProvider();

            if (txtId.Text == "")
            {
                oErrorProvider.SetError(txtDescripcion, "Digite un Id");
                return;
            }
            if (txtDescripcion.Text == "")
            {
                oErrorProvider.SetError(txtDescripcion, "Digite una descripción");
                return;
            }
            if (dgvDatosCobertura.DataSource == null) {
                oErrorProvider.SetError(cmbCobertura, "Debe agregar al menos una cobertura");
                return;
            }


            try
            {
                TipoPoliza tipoPoliza = new TipoPoliza();
                tipoPoliza.Descripcion = txtDescripcion.Text;
                tipoPoliza.Id = int.Parse( txtId.Text);
                if (listaCobertura.Count == 0) {
                    MessageBox.Show("Debe agregar coberturas");
                    return;
            
                }
                foreach (var item in listaCobertura)
                {
                    tipoPoliza.Costo += item.Total;
                }
                


                ITipoPolizaBLL logica = new TipoPolizaBLL();
                logica.Insertar(tipoPoliza);

              
                    IDetallePolizaBLL logicaDetallePoliza = new DetallePolizaBLL();

                    foreach (var item in listaCobertura)
                    {
                        DetallePoliza detallePoliza = new DetallePoliza();
                        detallePoliza.IdTipoPoliza = tipoPoliza.Id;
                        detallePoliza.IdCobertura = item.Id;
                        logicaDetallePoliza.Insertar(detallePoliza);
                    }
                

                CargarDatos();
                CambiarEstadoMantenimiento(EstadoMantenimiento.Ninguno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }
        /// <summary>
        /// Selecciona el tipo de poliza y lo elimina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            TipoPoliza tipoPoliza = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstadoMantenimiento(EstadoMantenimiento.Editar);
                    //Extraer el DTO seleccionado
                    tipoPoliza = this.dgvDatos.SelectedRows[0].DataBoundItem as TipoPoliza;

                    this.txtId.Text = tipoPoliza.Id.ToString();
                    this.txtDescripcion.Text = tipoPoliza.Descripcion.ToString();
                    this.txtCosto.Text = tipoPoliza.Costo.ToString();


                    ICoberturaBLL logicaCobertura = new CoberturaBLL();
                    listaCobertura = logicaCobertura.CoberturasAgregadas(tipoPoliza.Id);
                    dgvDatosCobertura.DataSource = listaCobertura;
                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        /// <summary>
        /// Crea un tipo de poliza y muestra las coberturas que tiene agregadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                ICoberturaBLL logicaCobertura = new CoberturaBLL();
                TipoPoliza tipoPoliza = new TipoPoliza();
                tipoPoliza = this.dgvDatos.SelectedRows[0].DataBoundItem as TipoPoliza;
                dgvCoberturasAgregadas.DataSource = logicaCobertura.CoberturasAgregadas(tipoPoliza.Id);
            }
            else
            {
                MessageBox.Show("Seleccione el registro !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstadoMantenimiento(EstadoMantenimiento.Nuevo);
        }

        /// <summary>
        /// Elimina la cobertura del tipo de poliza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarCobAgregada_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosCobertura.SelectedRows.Count > 0)
            {
                Cobertura cobertura = this.dgvDatosCobertura.SelectedRows[0].DataBoundItem as Cobertura;
                
                IDetallePolizaBLL detallePolizaBLL = new DetallePolizaBLL();
                detallePolizaBLL.EliminarByPolCob(int.Parse(txtId.Text), cobertura.Id);

                ICoberturaBLL logicaCobertura = new CoberturaBLL();
                listaCobertura = logicaCobertura.CoberturasAgregadas(int.Parse(txtId.Text));
                dgvDatosCobertura.DataSource = listaCobertura;
                decimal costo = 0;
                foreach (var item in listaCobertura)
                {
                    costo += item.Total;
                }
            }
            else
            {
                MessageBox.Show("Seleccione el registro de la tabla!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina el tipo de poliza seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            IDetallePolizaBLL detallePolizaBLL = new DetallePolizaBLL();
            ITipoPolizaBLL logicaTipoPoliza = new TipoPolizaBLL();
            
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    

                    TipoPoliza tipoPoliza = this.dgvDatos.SelectedRows[0].DataBoundItem as TipoPoliza;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {tipoPoliza.Id} {tipoPoliza.Descripcion}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvCoberturasAgregadas.Rows.Count != 0)
                        {
                            detallePolizaBLL.EliminarByIdTipoPoliza(tipoPoliza.Id);
                        }
                        
                        logicaTipoPoliza.Eliminar(tipoPoliza.Id);
                        this.CargarDatos();
                        this.CambiarEstadoMantenimiento(EstadoMantenimiento.Nuevo);
                    }
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
        /// Sale del form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
