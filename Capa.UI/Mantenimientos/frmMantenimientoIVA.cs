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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Capa.UI.Mantenimientos
{
    public partial class frmMantenimientoIVA : Form
    {
        EstadoMantenimiento estadoMantenimiento;
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoIVA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llena los datos 
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.RowTemplate.Height = 100;
                dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                I_IVA_BLL logica = new IVABLL();
                dgvDatos.DataSource = logica.SeleccionarTodas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);

            }
        }

        /// <summary>
        /// Cambia el estado de mantenimiento según el enum
        /// </summary>
        /// <param name="estado"></param>
        private void CambiarEstadoMantenimiento(EstadoMantenimiento estado)
        {
            txtPorcentaje.Clear();
            txtId.Clear();


            txtPorcentaje.Enabled = false;
            txtId.Enabled = false;


            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:


                    txtPorcentaje.Enabled = true;
                    txtId.Enabled = true;

                    estadoMantenimiento = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    txtPorcentaje.Enabled = true;
                    txtId.Enabled = true;

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
        /// guarda el registro en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
           

            ErrorProvider oErrorProvider = new ErrorProvider();


            if (txtPorcentaje.Text == "")
            {
                oErrorProvider.SetError(txtPorcentaje, "Digite un porcentaje");
                return;
            }


            try
            {
                IVA iva = new IVA();

                if (estadoMantenimiento == EstadoMantenimiento.Editar)
                {
                    iva.Id = Int32.Parse(txtId.Text);
                }
                iva.Porcentaje =Decimal.Parse( txtPorcentaje.Text);
                iva.Fecha = DateTime.Now;

                I_IVA_BLL logica = new IVABLL();
                logica.Insertar(iva);

                CargarDatos();
                CambiarEstadoMantenimiento(EstadoMantenimiento.Ninguno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }
        /// <summary>
        /// Limpia los campos por medio del método cambiar estado mantenimiento
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
        /// Selecciona el registro de la tabla para editarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            IVA oIVA = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstadoMantenimiento(EstadoMantenimiento.Editar);
                    //Extraer el DTO seleccionado
                    oIVA = this.dgvDatos.SelectedRows[0].DataBoundItem as IVA;

                    this.txtId.Text = oIVA.Id.ToString();
                    this.txtPorcentaje.Text = oIVA.Porcentaje.ToString();

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

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            I_IVA_BLL logica = new IVABLL();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.CambiarEstadoMantenimiento(EstadoMantenimiento.Borrar);

                    IVA oIva = this.dgvDatos.SelectedRows[0].DataBoundItem as IVA;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oIva.Id} {oIva.Porcentaje}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        logica.Eliminar(oIva.Id);
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

        private void frmMantenimientoIVA_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
