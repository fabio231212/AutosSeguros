using BLL;
using Capa.UI.Util;
using Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.UI.Login
{
    public partial class frmIniciarSesion : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmIniciarSesion()
        {
            InitializeComponent();
        }

       /// <summary>
       /// Usado para la movilidad por pantalla
       /// </summary>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapure();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void btnCerrar_Click(object sender, EventArgs e)
        {  
                    System.Windows.Forms.Application.Exit();             
    }
        /// <summary>
        /// Minimiza el login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /// <summary>
        /// este método trae el picture box de ocultar para el frente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbVisible_Click(object sender, EventArgs e)
        {
      
                txtPassword.UseSystemPasswordChar = false;
                pbOcultar.BringToFront();
            
        }
        /// <summary>
        /// este método trae el picture box de mostrar para el frente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbOcultar_Click(object sender, EventArgs e)
        {
           
                txtPassword.UseSystemPasswordChar = true;
                pbVisible.BringToFront();
            

        }

        /// <summary>
        /// Este método valida que los campos de correo y clave estén con datos, si es así, llama al bll y el bll llamar al dal para consultar en la base de datos la
        /// existencia de ese usuario, si la respuesta es positiva, entonces carga el frame principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                IUsuarioBLL logica = new UsuarioBLL();

                if (txtCorreo.Text == "CORREO" || txtCorreo.Text == "")
                {
                    MessageBox.Show("Debe de ingresar su correo");
                    txtCorreo.Clear();
                    txtCorreo.Focus(); ;

                    return;
                }
                if (txtPassword.Text == "CLAVE" || txtPassword.Text == "")
                {
                    MessageBox.Show("Debe de ingresar una clave");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }


                    if (logica.VerificarAcceso(txtCorreo.Text, Utilitarios.EncriptaClave(txtPassword.Text)))
                    {

                    frmPrincipal frm = new frmPrincipal();
                    frm.Show();
                    this.Hide();
                    frm.FormClosed += VolverInicioDeSesion;
                }
                else
                {
                    MessageBox.Show("Email o contraseña incorrectos");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void frmIniciarSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapure();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

 
        /// <summary>
        /// Este método se ejecuta cada vez que se vuelve al presente frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolverInicioDeSesion(Object sender, FormClosedEventArgs e)
        {
            txtCorreo.Clear();
            txtPassword.Clear();
            txtPassword.UseSystemPasswordChar = false;
            this.Show();
        }

        private void frmIniciarSesion_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
    }
