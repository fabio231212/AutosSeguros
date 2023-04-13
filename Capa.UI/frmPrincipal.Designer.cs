namespace Capa.UI
{
    partial class frmPrincipal
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
            this.mspMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMantenimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.TsMenuItemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.TsMenuItemCoberturas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoPolizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.TsMenuItemFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.anularFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.PolizasPorUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorDíaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.mspMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMenuPrincipal
            // 
            this.mspMenuPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(165)))), ((int)(((byte)(209)))));
            this.mspMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.mspMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemArchivo,
            this.toolStripMenuItemMantenimientos,
            this.toolStripMenuItemProcesos,
            this.ToolStripMenuItemReportes,
            this.toolStripMenuItemAcercaDe});
            this.mspMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mspMenuPrincipal.Name = "mspMenuPrincipal";
            this.mspMenuPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mspMenuPrincipal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mspMenuPrincipal.Size = new System.Drawing.Size(126, 619);
            this.mspMenuPrincipal.TabIndex = 3;
            this.mspMenuPrincipal.Text = "menuStrip1";
            // 
            // toolStripMenuItemArchivo
            // 
            this.toolStripMenuItemArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolStripMenuItemArchivo.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItemArchivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemArchivo.Name = "toolStripMenuItemArchivo";
            this.toolStripMenuItemArchivo.Size = new System.Drawing.Size(99, 19);
            this.toolStripMenuItemArchivo.Text = "Archivo";
            this.toolStripMenuItemArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStripMenuItemMantenimientos
            // 
            this.toolStripMenuItemMantenimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsMenuItemUsuarios,
            this.TsMenuItemCoberturas,
            this.toolStripMenuItem1,
            this.tipoPolizaToolStripMenuItem});
            this.toolStripMenuItemMantenimientos.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItemMantenimientos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemMantenimientos.Name = "toolStripMenuItemMantenimientos";
            this.toolStripMenuItemMantenimientos.Size = new System.Drawing.Size(99, 19);
            this.toolStripMenuItemMantenimientos.Text = "Mantenimientos";
            this.toolStripMenuItemMantenimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // TsMenuItemUsuarios
            // 
            this.TsMenuItemUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsMenuItemUsuarios.Name = "TsMenuItemUsuarios";
            this.TsMenuItemUsuarios.Size = new System.Drawing.Size(180, 22);
            this.TsMenuItemUsuarios.Text = "Usuarios";
            this.TsMenuItemUsuarios.Click += new System.EventHandler(this.TsMenuItemUsuarios_Click);
            // 
            // TsMenuItemCoberturas
            // 
            this.TsMenuItemCoberturas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsMenuItemCoberturas.Name = "TsMenuItemCoberturas";
            this.TsMenuItemCoberturas.Size = new System.Drawing.Size(180, 22);
            this.TsMenuItemCoberturas.Text = "Coberturas";
            this.TsMenuItemCoberturas.Click += new System.EventHandler(this.TsMenuItemCoberturas_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "IVA";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tipoPolizaToolStripMenuItem
            // 
            this.tipoPolizaToolStripMenuItem.Name = "tipoPolizaToolStripMenuItem";
            this.tipoPolizaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipoPolizaToolStripMenuItem.Text = "TipoPoliza";
            this.tipoPolizaToolStripMenuItem.Click += new System.EventHandler(this.tipoPolizaToolStripMenuItem_Click);
            // 
            // toolStripMenuItemProcesos
            // 
            this.toolStripMenuItemProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsMenuItemFacturacion,
            this.anularFacturaToolStripMenuItem});
            this.toolStripMenuItemProcesos.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItemProcesos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemProcesos.Name = "toolStripMenuItemProcesos";
            this.toolStripMenuItemProcesos.Size = new System.Drawing.Size(99, 19);
            this.toolStripMenuItemProcesos.Text = "Procesos";
            this.toolStripMenuItemProcesos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // TsMenuItemFacturacion
            // 
            this.TsMenuItemFacturacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsMenuItemFacturacion.Name = "TsMenuItemFacturacion";
            this.TsMenuItemFacturacion.Size = new System.Drawing.Size(151, 22);
            this.TsMenuItemFacturacion.Text = "Facturación";
            this.TsMenuItemFacturacion.Click += new System.EventHandler(this.TsMenuItemFacturacion_Click);
            // 
            // anularFacturaToolStripMenuItem
            // 
            this.anularFacturaToolStripMenuItem.Name = "anularFacturaToolStripMenuItem";
            this.anularFacturaToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.anularFacturaToolStripMenuItem.Text = "Anular Factura";
            this.anularFacturaToolStripMenuItem.Click += new System.EventHandler(this.anularFacturaToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemReportes
            // 
            this.ToolStripMenuItemReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PolizasPorUsuarioToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ventasPorDíaToolStripMenuItem});
            this.ToolStripMenuItemReportes.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItemReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripMenuItemReportes.Name = "ToolStripMenuItemReportes";
            this.ToolStripMenuItemReportes.Size = new System.Drawing.Size(99, 19);
            this.ToolStripMenuItemReportes.Text = "Reportes";
            this.ToolStripMenuItemReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // PolizasPorUsuarioToolStripMenuItem
            // 
            this.PolizasPorUsuarioToolStripMenuItem.Name = "PolizasPorUsuarioToolStripMenuItem";
            this.PolizasPorUsuarioToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.PolizasPorUsuarioToolStripMenuItem.Text = "Polizas por Usuario";
            this.PolizasPorUsuarioToolStripMenuItem.Click += new System.EventHandler(this.PolizasPorUsuarioToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItem2.Text = "Polizas Vendidas";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // ventasPorDíaToolStripMenuItem
            // 
            this.ventasPorDíaToolStripMenuItem.Name = "ventasPorDíaToolStripMenuItem";
            this.ventasPorDíaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ventasPorDíaToolStripMenuItem.Text = "Ventas por Día";
            this.ventasPorDíaToolStripMenuItem.Click += new System.EventHandler(this.ventasPorDíaToolStripMenuItem_Click);
            // 
            // toolStripMenuItemAcercaDe
            // 
            this.toolStripMenuItemAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemAcercaDe.Name = "toolStripMenuItemAcercaDe";
            this.toolStripMenuItemAcercaDe.Size = new System.Drawing.Size(99, 4);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 619);
            this.Controls.Add(this.mspMenuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mspMenuPrincipal;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.mspMenuPrincipal.ResumeLayout(false);
            this.mspMenuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemArchivo;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMantenimientos;
        private System.Windows.Forms.ToolStripMenuItem TsMenuItemUsuarios;
        private System.Windows.Forms.ToolStripMenuItem TsMenuItemCoberturas;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProcesos;
        private System.Windows.Forms.ToolStripMenuItem TsMenuItemFacturacion;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReportes;
        private System.Windows.Forms.ToolStripMenuItem PolizasPorUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tipoPolizaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem anularFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasPorDíaToolStripMenuItem;
    }
}