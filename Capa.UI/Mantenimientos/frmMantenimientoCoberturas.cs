using BLL;
using Entities;
using Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.UI.Mantenimientos
{
    public partial class frmMantenimientoCoberturas : Form
    {
        EstadoMantenimiento estadoMantenimiento;
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoCoberturas()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            try
            {
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.RowTemplate.Height = 100;
                dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                ICoberturaBLL logica = new CoberturaBLL();
                dgvDatos.DataSource = logica.SeleccionarTodas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);

            }
        }
        /// <summary>
        /// Cambia el estado matenimiento según el enum
        /// </summary>
        /// <param name="estado"></param>
        private void CambiarEstadoMantenimiento(EstadoMantenimiento estado)
        {
            txtDescripcion.Clear();
            txtId.Clear();
            txtPrecio.Clear();

            txtDescripcion.Enabled = false;
            txtId.Enabled = false;
            txtPrecio.Enabled = false;


            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:


                    txtDescripcion.Enabled = true;
                    txtId.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtDescripcion.Focus();
                    estadoMantenimiento = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    txtDescripcion.Enabled = true;
                    txtId.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtDescripcion.Focus();
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
        /// Limpia los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.CambiarEstadoMantenimiento(EstadoMantenimiento.Nuevo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        /// <summary>
        /// Selecciona el registro del dgv para editarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            Cobertura oCobertura = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstadoMantenimiento(EstadoMantenimiento.Editar);
                    //Extraer el DTO seleccionado
                    oCobertura = this.dgvDatos.SelectedRows[0].DataBoundItem as Cobertura;

                    this.txtId.Text = oCobertura.Id.ToString();
                    this.txtDescripcion.Text = oCobertura.Descripcion.ToString();
                    this.txtPrecio.Text = oCobertura.Precio.ToString();

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
        /// Selecciona el registro para eliminarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            ICoberturaBLL logica = new CoberturaBLL();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.CambiarEstadoMantenimiento(EstadoMantenimiento.Borrar);

                    Cobertura oCObertura = this.dgvDatos.SelectedRows[0].DataBoundItem as Cobertura;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oCObertura.Id} {oCObertura.Descripcion}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        logica.Eliminar(oCObertura.Id);
                        this.CargarDatos();
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

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Valida los campos, crea el objeto tipo cobertura y lo guarda en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int resultado = 0;

            ErrorProvider oErrorProvider = new ErrorProvider();
            if (txtPrecio.Text == "") {
                oErrorProvider.SetError(txtPrecio, "Digite un precio");
                return;
            }
          
            if (txtDescripcion.Text == "")
            {
                oErrorProvider.SetError(txtDescripcion, "Digite una descripción");
                return;
            }

           
            try
            {
                Cobertura cobertura = new Cobertura();

                if (estadoMantenimiento == EstadoMantenimiento.Editar)
                {
                    cobertura.Id = Int32.Parse(txtId.Text);
                }
                cobertura.Descripcion = txtDescripcion.Text;
                cobertura.Precio = Decimal.Parse(txtPrecio.Text);

                ICoberturaBLL logica = new CoberturaBLL();
                logica.Insertar(cobertura);
                
                CargarDatos();
                CambiarEstadoMantenimiento(EstadoMantenimiento.Ninguno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void frmMantenimientoCoberturas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
