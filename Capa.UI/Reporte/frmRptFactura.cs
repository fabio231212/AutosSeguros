using BLL;
using Entities;
using Interfaces;
using log4net;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Capa.UI.Reporte
{
    public partial class frmRptFactura : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        int _IdFactura;
        public frmRptFactura(int idFactura)
        {
            _IdFactura = idFactura;
            InitializeComponent();
        }

        /// <summary>
        /// Carga el reporte por medio del tableadapter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRptFactura_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'DsReportes.Factura' table. You can move, or remove it, as needed.
            this.usp_ObtenerFacturaReporteTableAdapter.Fill(this.dataSetReportes.usp_ObtenerFacturaReporte, _IdFactura);
            string ruta = @"file:///" + @"C:/TEMP/qr.png";
            // Habilitar imagenes externas
            this.rptVisor.LocalReport.EnableExternalImages = true;
            ReportParameter param = new ReportParameter("quickresponse", ruta);
            this.rptVisor.LocalReport.SetParameters(param);
            this.rptVisor.RefreshReport();
        }

        /// <summary>
        /// Método que ejecuta la lógica asincrónicamente para enviar el correo electrónico al destinatario. Al ser  un método async
        /// tiene que devolver una Tarea(task) y no puede ser void
        /// </summary>
        /// <returns></returns>
        public Task<string> EnviarFacturaAsync()
        {
            return Task.Run(() =>
            {
                Usuario user = null;
                IUsuarioBLL logica = new UsuarioBLL();
                user = logica.GetUsuarioById(logica.ObtenerUsuarioIdByIdFac(_IdFactura));

                MailMessage mensaje = new MailMessage();
                mensaje.IsBodyHtml = true;
                mensaje.Subject = "Seguros Pita";
                mensaje.Body = "¡Hola! Esperamos que se encuentre bien. Le adjuntamos su factura de compra";
                mensaje.From = new MailAddress("pipiticaseguros@hotmail.com");
                mensaje.To.Add(user.Correo);
                SmtpClient smtp = new SmtpClient("smtp.office365.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("pipiticaseguros@hotmail.com", "pipitica1234");
                smtp.EnableSsl = true;
                Attachment attachment = new Attachment(@"c:\temp\reporteFactura.pdf");
                mensaje.Attachments.Add(attachment);
                smtp.Send(mensaje);
                return "Factura enviada correctamente";

            });
        }

        /// <summary>
        /// Este método es el que invoca al método que yo quiero que sea asíncrono por lo tanto tiene que llevar la palabra reservada
        /// async para que pueda entender la máquina que lo tiene que ejecutar en "segundo plano". Cuando invoca el método, le tiene que
        /// poner la palabra await que significa "en espera". Quiere decir que va a ejecutar ese método paralelamente a los
        /// otros procesos por lo que es más agradable con el usuario ya que no se queda esperando a que termine de enviar el correo
        /// Si no fuese asíncrono, podríamos ver como se queda como "congelado" hasta que termine el proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EnviarEmail_Click(object sender, EventArgs e)
        {
            string ruta = @"c:\temp\reporteFactura.pdf";
            var deviceInfo = @"<DeviceInfo>
            <EmbedFonts>None</EmbedFonts>
           </DeviceInfo>";
            try
            {
                if (!Directory.Exists(@"c:\temp"))
                    Directory.CreateDirectory(@"c:\temp");

                byte[] Bytes = this.rptVisor.LocalReport.Render(format: "PDF", deviceInfo: deviceInfo);

                using (FileStream stream = new FileStream(ruta, FileMode.Create))
                {
                    stream.Write(Bytes, 0, Bytes.Length);
                }

                MessageBox.Show(await EnviarFacturaAsync());
            }

            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el siguiente error: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _MyLogControlEventos.Error(ex.Message);
            }
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
