using BLL;
using Capa.UI.Util;
using Entities;
using Interfaces;
using log4net;
using SqlServerTypes;
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
    public partial class frmMantenimientoUsuarios : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoUsuarios()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Llena los combobox y la tabla 
        /// </summary>
        private void CargarCombos()
        {
            try
            {
                dgvDatosUsuario.AutoGenerateColumns = false;
                dgvDatosUsuario.RowTemplate.Height = 100;
                dgvDatosUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                IUsuarioBLL logica = new UsuarioBLL();
                dgvDatosUsuario.DataSource = logica.ObtenerUsuarios();

                IPaisBLL logicaPais = new PaisBLL();
                cmbPais.DataSource = logicaPais.ObtenerPaises();
                cmbPais.DisplayMember = "Nombre";
                cmbPais.ValueMember = "Id";
                cmbPais.SelectedIndex = -1;

                IGeneroBLL logicaGenero = new GeneroBLL();
                cmbGenero.DataSource = logicaGenero.ObtenerGenero();
                cmbGenero.DisplayMember = "Descripcion";
                cmbGenero.ValueMember = "Id";
                cmbGenero.SelectedIndex = -1;

                ITipoUsuarioBLL logicaTipoUsuario = new TipoUsuarioBLL();
                cmbTipoUsuario.DataSource = logicaTipoUsuario.ObtenerTiposUsuarios();
                cmbTipoUsuario.DisplayMember = "Descripcion";
                cmbTipoUsuario.ValueMember = "Id";
                cmbTipoUsuario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);

            }
        }
        /// <summary>
        /// Método que limpia y bloquea los campos según el enum
        /// </summary>
        /// <param name="estado"></param>
        private void CambiarEstadoMantenimiento(EstadoMantenimiento estado)
        {
            mskId.Clear();
            txtNombre.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            txtCorreo.Clear();
            mskTelefono.Clear();
            cmbGenero.SelectedIndex = -1;
            dtpFechaNacimiento.ResetText();
            dtpLicenciaVencimiento.ResetText();
            cmbTipoUsuario.SelectedIndex = -1;
            txtClave.Clear();
            txtConfirmarClave.Clear();
            txtPuntosLicencia.Clear();
            cmbNacionalidad.SelectedIndex = -1;
            txtDireccion.Clear();
            

            mskId.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido1.Enabled = false;
            txtApellido2.Enabled = false;
            txtCorreo.Enabled = false;
            mskTelefono.Enabled = false;
            cmbGenero.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
            dtpLicenciaVencimiento.Enabled = false;
            cmbTipoUsuario.Enabled = false;
            txtClave.Enabled = false;
            txtConfirmarClave.Enabled = false;
            txtPuntosLicencia.Enabled = false;
            cmbNacionalidad.Enabled = false;

            // Colocar la imagen de usuario por defecto
            this.pbFotoUsuario.Image = Capa.UI.Properties.Resources.icons8_natural_user_interface_2_120px;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    mskId.Enabled = true;
                    txtNombre.Enabled = true;
                    txtApellido1.Enabled = true;
                    txtApellido2.Enabled = true;
                    txtCorreo.Enabled = true;
                    mskTelefono.Enabled = true;
                    cmbGenero.Enabled = true;
                    dtpFechaNacimiento.Enabled = true;
                    dtpLicenciaVencimiento.Enabled = true;
                    cmbTipoUsuario.Enabled = true;
                    txtClave.Enabled = true;
                    txtConfirmarClave.Enabled = true;
                    txtPuntosLicencia.Enabled = true;
                    cmbNacionalidad.Enabled = true;

                    mskId.Focus();
                    break;

                case EstadoMantenimiento.Editar:
                    mskId.Enabled = true;
                    txtNombre.Enabled = true;
                    txtApellido1.Enabled = true;
                    txtApellido2.Enabled = true;
                    txtCorreo.Enabled = true;
                    mskTelefono.Enabled = true;
                    cmbGenero.Enabled = true;
                    dtpFechaNacimiento.Enabled = true;
                    dtpLicenciaVencimiento.Enabled = true;
                    cmbTipoUsuario.Enabled = true;
                    txtClave.Enabled = true;
                    txtConfirmarClave.Enabled = true;
                    txtPuntosLicencia.Enabled = true;
                    cmbNacionalidad.Enabled = true;
                    mskId.Focus();
                    break;

                case EstadoMantenimiento.Borrar:
                    break;

                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }

        private void frmMantenimientoUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Invoca al método cambiarEstado y limpia los campos
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
        /// Edita el usuario seleccionado 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = null;
            try
            {
                if (this.dgvDatosUsuario.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstadoMantenimiento(EstadoMantenimiento.Editar);
                    //Extraer el DTO seleccionado
                    oUsuario = this.dgvDatosUsuario.SelectedRows[0].DataBoundItem as Usuario;

                    this.mskId.Text = oUsuario.Id.ToString();
                    this.txtNombre.Text = oUsuario.Nombre.ToString();
                    this.txtApellido1.Text = oUsuario.Apellido1.ToString();
                    this.txtApellido2.Text = oUsuario.Apellido2.ToString();
                    this.txtCorreo.Text = oUsuario.Correo.ToString();
                    this.mskTelefono.Text = oUsuario.Telefono.ToString();
                    this.dtpFechaNacimiento.Value = oUsuario.FechaNacimiento;
                    this.dtpLicenciaVencimiento.Value = oUsuario.FechaLicenciaEx;
                    this.cmbNacionalidad.SelectedText = oUsuario.Nacionalidad.ToString();
                    this.txtClave.Text = oUsuario.Clave;
                    this.txtConfirmarClave.Text = oUsuario.Clave;

                    this.txtDireccion.Text = oUsuario.Direccion;
                    this.txtPuntosLicencia.Text = oUsuario.PuntosLicencia.ToString();
                    this.pbFotoUsuario.Image = new Bitmap(new MemoryStream(oUsuario.Foto));
                    this.pbFotoUsuario.Tag = oUsuario.Foto;
                }
                else
                {
                    MessageBox.Show("Seleccione el registro !","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }
        /// <summary>
        /// Elimina el registro seleccionado por medio del id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            IUsuarioBLL logica = new UsuarioBLL();

            try
            {
                if (this.dgvDatosUsuario.SelectedRows.Count > 0)
                {
                    this.CambiarEstadoMantenimiento(EstadoMantenimiento.Borrar);

                    Usuario oUsuario = this.dgvDatosUsuario.SelectedRows[0].DataBoundItem as Usuario;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oUsuario.Id} {oUsuario.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        logica.Eliminar(oUsuario.Id);
                        this.CargarCombos();
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
        /// Verifica que los datos estén correctos y elimina o actualiza según lo escogido por el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int resultado = 0;

            ErrorProvider oErrorProvider = new ErrorProvider();
            oErrorProvider.Clear();
            if (this.pbFotoUsuario.Tag == null)
            {
                MessageBox.Show("La Imagen  es un dato requerido !", "Atención");
                return;
            }

            if (!mskId.MaskFull)
            {
                oErrorProvider.SetError(mskId, "El id debe de tener 9 dígitos");
                return;
            }
            if (txtNombre.Text == "")
            {
                oErrorProvider.SetError(txtNombre, "Debe digitar su nombre");
                return;
            }
            
                if (txtCorreo.Text == "")
                {
                    oErrorProvider.SetError(txtCorreo, "Debe digitar su correo");
                    return;
                }
                if (!mskTelefono.MaskFull)
                {
                    oErrorProvider.SetError(mskTelefono, "El número telefónico debe tener 8 dígitos");
                    return;
                }
                if (cmbGenero.SelectedItem == null)
                {
                    oErrorProvider.SetError(cmbGenero, "Debe de seleccionar género");
                    return;
                }

            if(cmbPais.SelectedItem == null)
                {
                oErrorProvider.SetError(cmbPais, "Debe de seleccionar país");
                return;
            }
            if (cmbTipoUsuario.SelectedItem == null)
            {
                oErrorProvider.SetError(cmbTipoUsuario, "Debe de seleccionar un tipo de usuario");
                return;
            }
            if (cmbNacionalidad.SelectedIndex ==  -1)
            {
                oErrorProvider.SetError(cmbNacionalidad, "Seleccione su Nacionalidad");
                return;
            }

            if (cmbTipoUsuario.SelectedIndex == 1)
            {
                if (txtPuntosLicencia.Text == "")
                {
                    oErrorProvider.SetError(txtPuntosLicencia, "Digite sus puntos en la licencia");
                    return;
                }
            }
            if (txtDireccion.Text == "")
            {
                oErrorProvider.SetError(txtClave, "Digite una dirección");
                return;
            }


            if (txtClave.Text == "")
            {
                oErrorProvider.SetError(txtClave, "Digite su contraseña");
                return;
            }
            if (txtConfirmarClave.Text == "")
            {
                oErrorProvider.SetError(txtConfirmarClave, "Confirme su contraseña");
                return;
            }
            if (txtClave.Text.Length < 8)
            {
                MessageBox.Show("Su contraseña debe de contener 8 dígitos o más");
                return;
            }
            if (!txtClave.Text.Equals(txtConfirmarClave.Text))
            {
                MessageBox.Show("Las contraseñas no coindiden.");
                return;
            }
            try
            {
                Usuario user = new Usuario();

                user.Id = mskId.Text;
                user.Nombre = txtNombre.Text;
                user.Apellido1 = txtApellido1.Text;
                user.Apellido2 = txtApellido2.Text;
                user.Correo = txtCorreo.Text;
                user.Telefono = int.Parse(mskTelefono.Text);
                user.IdGenero = (int)cmbGenero.SelectedValue;
                user.IdTipoUsuario = (int)cmbTipoUsuario.SelectedValue;
                user.IdPais = (int)cmbPais.SelectedValue;
                user.FechaNacimiento = dtpFechaNacimiento.Value;
                user.FechaLicenciaEx = dtpLicenciaVencimiento.Value;
                user.Clave = Utilitarios.EncriptaClave(txtClave.Text);
                user.Foto = (byte[])pbFotoUsuario.Tag;
                if (user.IdTipoUsuario != 2)
                {
                    user.PuntosLicencia = 0;
                }
                else
                {
                    user.PuntosLicencia = int.Parse(txtPuntosLicencia.Text);
                }
                    user.Direccion = txtDireccion.Text;
                    user.Nacionalidad = cmbNacionalidad.Text;
                

                IUsuarioBLL logica = new UsuarioBLL();
                logica.Guardar(user);
                CargarCombos();
                CambiarEstadoMantenimiento(EstadoMantenimiento.Ninguno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }


        /// <summary>
        /// Abre una pestaña para busca una imagen de usuario en el dispositivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbFotoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                pbFotoUsuario.Image = null;
                OpenFileDialog opt = new OpenFileDialog();
                opt.Title = "Seleccione la Imagen ";
                opt.SupportMultiDottedExtensions = true;
                opt.DefaultExt = "*.jpg";
                opt.Filter = "Archivos de Imagenes (*.jpg)|*.jpg| All files (*.*)|*.*";
                opt.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                opt.FileName = "";

                if (opt.ShowDialog(this) == DialogResult.OK)
                {
                    //ruta = opt.FileName.Trim();
                    this.pbFotoUsuario.ImageLocation = opt.FileName;
                    pbFotoUsuario.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] cadenaBytes = File.ReadAllBytes(opt.FileName);

                    // Guarla la imagenen Bytes en el Tag de la imagen.
                    pbFotoUsuario.Tag = (byte[])cadenaBytes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        /// <summary>
        /// Bloque el campo puntos de licencia según el tipo de usuario seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoUsuario.SelectedIndex != 1)
            {
                txtPuntosLicencia.Enabled = false;
            }
            else {
                txtPuntosLicencia.Enabled = true;
            }
        }
    }
}
