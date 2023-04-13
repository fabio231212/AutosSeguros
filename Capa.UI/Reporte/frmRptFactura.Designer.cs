namespace Capa.UI.Reporte
{
    partial class frmRptFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uspObtenerFacturaReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetReportes = new Capa.UI.Reporte.DataSetReportes();
            this.rptVisor = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usp_ObtenerFacturaReporteTableAdapter = new Capa.UI.Reporte.DataSetReportesTableAdapters.usp_ObtenerFacturaReporteTableAdapter();
            this.tspBarraSuperior = new System.Windows.Forms.ToolStrip();
            this.EnviarEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.uspObtenerFacturaReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReportes)).BeginInit();
            this.tspBarraSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // uspObtenerFacturaReporteBindingSource
            // 
            this.uspObtenerFacturaReporteBindingSource.DataMember = "usp_ObtenerFacturaReporte";
            this.uspObtenerFacturaReporteBindingSource.DataSource = this.dataSetReportes;
            // 
            // dataSetReportes
            // 
            this.dataSetReportes.DataSetName = "DataSetReportes";
            this.dataSetReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptVisor
            // 
            reportDataSource1.Name = "dsFactura";
            reportDataSource1.Value = this.uspObtenerFacturaReporteBindingSource;
            this.rptVisor.LocalReport.DataSources.Add(reportDataSource1);
            this.rptVisor.LocalReport.ReportEmbeddedResource = "Capa.UI.Reporte.rptFactura.rdlc";
            this.rptVisor.Location = new System.Drawing.Point(0, 28);
            this.rptVisor.Name = "rptVisor";
            this.rptVisor.ServerReport.BearerToken = null;
            this.rptVisor.Size = new System.Drawing.Size(792, 515);
            this.rptVisor.TabIndex = 0;
            this.rptVisor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // usp_ObtenerFacturaReporteTableAdapter
            // 
            this.usp_ObtenerFacturaReporteTableAdapter.ClearBeforeFill = true;
            // 
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(165)))), ((int)(((byte)(209)))));
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnviarEmail,
            this.toolStripBtnSalir});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Size = new System.Drawing.Size(792, 25);
            this.tspBarraSuperior.TabIndex = 7;
            this.tspBarraSuperior.Text = "toolStrip1";
            // 
            // EnviarEmail
            // 
            this.EnviarEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.EnviarEmail.ForeColor = System.Drawing.Color.White;
            this.EnviarEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EnviarEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EnviarEmail.Name = "EnviarEmail";
            this.EnviarEmail.Size = new System.Drawing.Size(88, 22);
            this.EnviarEmail.Text = "Enviar Email";
            this.EnviarEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EnviarEmail.ToolTipText = "Enviar Email";
            this.EnviarEmail.Click += new System.EventHandler(this.EnviarEmail_Click);
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripBtnSalir.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(39, 22);
            this.toolStripBtnSalir.Text = "Salir";
            this.toolStripBtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnSalir.Click += new System.EventHandler(this.toolStripBtnSalir_Click);
            // 
            // frmRptFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 541);
            this.Controls.Add(this.tspBarraSuperior);
            this.Controls.Add(this.rptVisor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRptFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRptFactura";
            this.Load += new System.EventHandler(this.frmRptFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uspObtenerFacturaReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReportes)).EndInit();
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptVisor;
        private System.Windows.Forms.BindingSource uspObtenerFacturaReporteBindingSource;
        private DataSetReportes dataSetReportes;
        private DataSetReportesTableAdapters.usp_ObtenerFacturaReporteTableAdapter usp_ObtenerFacturaReporteTableAdapter;
        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.ToolStripButton EnviarEmail;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
    }
}