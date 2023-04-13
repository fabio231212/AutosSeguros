namespace Capa.UI.Reporte
{
    partial class frmRptPolizaByIdUsuario
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
            this.uspPolizaByIdUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetReportes = new Capa.UI.Reporte.DataSetReportes();
            this.tspBarraSuperior = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripTxtId = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripBtnBuscar = new System.Windows.Forms.ToolStripButton();
            this.rptVisor = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usp_PolizaByIdUsuarioTableAdapter = new Capa.UI.Reporte.DataSetReportesTableAdapters.usp_PolizaByIdUsuarioTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uspPolizaByIdUsuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReportes)).BeginInit();
            this.tspBarraSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // uspPolizaByIdUsuarioBindingSource
            // 
            this.uspPolizaByIdUsuarioBindingSource.DataMember = "usp_PolizaByIdUsuario";
            this.uspPolizaByIdUsuarioBindingSource.DataSource = this.dataSetReportes;
            // 
            // dataSetReportes
            // 
            this.dataSetReportes.DataSetName = "DataSetReportes";
            this.dataSetReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(165)))), ((int)(((byte)(209)))));
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnSalir,
            this.toolStripTxtId,
            this.toolStripBtnBuscar});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Size = new System.Drawing.Size(800, 25);
            this.tspBarraSuperior.TabIndex = 8;
            this.tspBarraSuperior.Text = "toolStrip1";
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
            // toolStripTxtId
            // 
            this.toolStripTxtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(165)))), ((int)(((byte)(209)))));
            this.toolStripTxtId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripTxtId.ForeColor = System.Drawing.Color.White;
            this.toolStripTxtId.Name = "toolStripTxtId";
            this.toolStripTxtId.Size = new System.Drawing.Size(100, 25);
            this.toolStripTxtId.Text = "Identificación";
            this.toolStripTxtId.Enter += new System.EventHandler(this.toolStripTxtId_Enter);
            this.toolStripTxtId.Leave += new System.EventHandler(this.toolStripTxtId_Leave);
            // 
            // toolStripBtnBuscar
            // 
            this.toolStripBtnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripBtnBuscar.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBuscar.Name = "toolStripBtnBuscar";
            this.toolStripBtnBuscar.Size = new System.Drawing.Size(52, 22);
            this.toolStripBtnBuscar.Text = "Buscar";
            this.toolStripBtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnBuscar.Click += new System.EventHandler(this.toolStripBtnBuscar_Click);
            // 
            // rptVisor
            // 
            reportDataSource1.Name = "dsPolizaByIdUsuario";
            reportDataSource1.Value = this.uspPolizaByIdUsuarioBindingSource;
            this.rptVisor.LocalReport.DataSources.Add(reportDataSource1);
            this.rptVisor.LocalReport.ReportEmbeddedResource = "Capa.UI.Reporte.rptPolizaByIdUsuario.rdlc";
            this.rptVisor.Location = new System.Drawing.Point(0, 28);
            this.rptVisor.Name = "rptVisor";
            this.rptVisor.ServerReport.BearerToken = null;
            this.rptVisor.Size = new System.Drawing.Size(800, 427);
            this.rptVisor.TabIndex = 9;
            this.rptVisor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // usp_PolizaByIdUsuarioTableAdapter
            // 
            this.usp_PolizaByIdUsuarioTableAdapter.ClearBeforeFill = true;
            // 
            // frmRptPolizaByIdUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptVisor);
            this.Controls.Add(this.tspBarraSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRptPolizaByIdUsuario";
            this.Text = "frmRptPolizaByIdUsuario";
            this.Load += new System.EventHandler(this.frmRptPolizaByIdUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uspPolizaByIdUsuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReportes)).EndInit();
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.ToolStripTextBox toolStripTxtId;
        private System.Windows.Forms.ToolStripButton toolStripBtnBuscar;
        private Microsoft.Reporting.WinForms.ReportViewer rptVisor;
        private System.Windows.Forms.BindingSource uspPolizaByIdUsuarioBindingSource;
        private DataSetReportes dataSetReportes;
        private DataSetReportesTableAdapters.usp_PolizaByIdUsuarioTableAdapter usp_PolizaByIdUsuarioTableAdapter;
    }
}