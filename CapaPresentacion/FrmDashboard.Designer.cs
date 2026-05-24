namespace CapaPresentacion
{
    partial class FrmDashboard
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.flowInstalaciones = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.panelProceso = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEnProceso = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.panelHoy = new System.Windows.Forms.Panel();
            this.lblInstalacionesHoy = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.panelPendientes = new System.Windows.Forms.Panel();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.panelFinalizado = new System.Windows.Forms.Panel();
            this.lblFinalizados = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.panelLineaPendiente = new System.Windows.Forms.Panel();
            this.panelLineaProceso = new System.Windows.Forms.Panel();
            this.panelLineaFinalizado = new System.Windows.Forms.Panel();
            this.panelLineaHoy = new System.Windows.Forms.Panel();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowInstalaciones.SuspendLayout();
            this.panelProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.panelHoy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            this.panelPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.panelFinalizado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel8.Controls.Add(this.dataGridView1);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Location = new System.Drawing.Point(308, 331);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(614, 335);
            this.panel8.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(528, 262);
            this.dataGridView1.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(214, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 21);
            this.label13.TabIndex = 0;
            this.label13.Text = "Pedidos recientes";
            // 
            // flowInstalaciones
            // 
            this.flowInstalaciones.BackColor = System.Drawing.Color.White;
            this.flowInstalaciones.Controls.Add(this.button1);
            this.flowInstalaciones.Controls.Add(this.label14);
            this.flowInstalaciones.Location = new System.Drawing.Point(972, 331);
            this.flowInstalaciones.Name = "flowInstalaciones";
            this.flowInstalaciones.Size = new System.Drawing.Size(342, 325);
            this.flowInstalaciones.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(110, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ver calendario";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(71, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 21);
            this.label14.TabIndex = 0;
            this.label14.Text = "Instalaciones proximas";
            // 
            // panelProceso
            // 
            this.panelProceso.BackColor = System.Drawing.Color.White;
            this.panelProceso.Controls.Add(this.panelLineaProceso);
            this.panelProceso.Controls.Add(this.label3);
            this.panelProceso.Controls.Add(this.lblEnProceso);
            this.panelProceso.Controls.Add(this.pictureBox13);
            this.panelProceso.Location = new System.Drawing.Point(557, 164);
            this.panelProceso.Name = "panelProceso";
            this.panelProceso.Size = new System.Drawing.Size(235, 70);
            this.panelProceso.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "En proceso";
            // 
            // lblEnProceso
            // 
            this.lblEnProceso.AutoSize = true;
            this.lblEnProceso.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnProceso.Location = new System.Drawing.Point(124, 46);
            this.lblEnProceso.Name = "lblEnProceso";
            this.lblEnProceso.Size = new System.Drawing.Size(0, 21);
            this.lblEnProceso.TabIndex = 4;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::CapaPresentacion.Properties.Resources.descarga__9_;
            this.pictureBox13.Location = new System.Drawing.Point(3, 16);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(50, 38);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 0;
            this.pictureBox13.TabStop = false;
            // 
            // panelHoy
            // 
            this.panelHoy.BackColor = System.Drawing.Color.White;
            this.panelHoy.Controls.Add(this.panelLineaHoy);
            this.panelHoy.Controls.Add(this.lblInstalacionesHoy);
            this.panelHoy.Controls.Add(this.label2);
            this.panelHoy.Controls.Add(this.pictureBox16);
            this.panelHoy.Location = new System.Drawing.Point(1104, 164);
            this.panelHoy.Name = "panelHoy";
            this.panelHoy.Size = new System.Drawing.Size(235, 70);
            this.panelHoy.TabIndex = 16;
            // 
            // lblInstalacionesHoy
            // 
            this.lblInstalacionesHoy.AutoSize = true;
            this.lblInstalacionesHoy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstalacionesHoy.Location = new System.Drawing.Point(161, 40);
            this.lblInstalacionesHoy.Name = "lblInstalacionesHoy";
            this.lblInstalacionesHoy.Size = new System.Drawing.Size(0, 21);
            this.lblInstalacionesHoy.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Instalaciones de hoy";
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = global::CapaPresentacion.Properties.Resources.WhatsApp_Image_2026_05_20_at_5_46_09_PM;
            this.pictureBox16.Location = new System.Drawing.Point(3, 14);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(52, 40);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox16.TabIndex = 0;
            this.pictureBox16.TabStop = false;
            // 
            // panelPendientes
            // 
            this.panelPendientes.BackColor = System.Drawing.Color.White;
            this.panelPendientes.Controls.Add(this.panelLineaPendiente);
            this.panelPendientes.Controls.Add(this.lblPendientes);
            this.panelPendientes.Controls.Add(this.lblP);
            this.panelPendientes.Controls.Add(this.pictureBox15);
            this.panelPendientes.Location = new System.Drawing.Point(286, 164);
            this.panelPendientes.Name = "panelPendientes";
            this.panelPendientes.Size = new System.Drawing.Size(235, 70);
            this.panelPendientes.TabIndex = 13;
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendientes.Location = new System.Drawing.Point(122, 46);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(0, 21);
            this.lblPendientes.TabIndex = 3;
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP.Location = new System.Drawing.Point(65, 16);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(152, 21);
            this.lblP.TabIndex = 2;
            this.lblP.Text = "Pedidos Pendientes";
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = global::CapaPresentacion.Properties.Resources.descarga__11_;
            this.pictureBox15.Location = new System.Drawing.Point(3, 14);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(47, 38);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 0;
            this.pictureBox15.TabStop = false;
            // 
            // panelFinalizado
            // 
            this.panelFinalizado.BackColor = System.Drawing.Color.White;
            this.panelFinalizado.Controls.Add(this.panelLineaFinalizado);
            this.panelFinalizado.Controls.Add(this.lblFinalizados);
            this.panelFinalizado.Controls.Add(this.label5);
            this.panelFinalizado.Controls.Add(this.pictureBox14);
            this.panelFinalizado.Location = new System.Drawing.Point(831, 164);
            this.panelFinalizado.Name = "panelFinalizado";
            this.panelFinalizado.Size = new System.Drawing.Size(235, 70);
            this.panelFinalizado.TabIndex = 15;
            // 
            // lblFinalizados
            // 
            this.lblFinalizados.AutoSize = true;
            this.lblFinalizados.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalizados.Location = new System.Drawing.Point(106, 40);
            this.lblFinalizados.Name = "lblFinalizados";
            this.lblFinalizados.Size = new System.Drawing.Size(0, 21);
            this.lblFinalizados.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(78, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Finalizado";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::CapaPresentacion.Properties.Resources.descarga__10_;
            this.pictureBox14.Location = new System.Drawing.Point(0, 16);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(58, 38);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 0;
            this.pictureBox14.TabStop = false;
            // 
            // panelLineaPendiente
            // 
            this.panelLineaPendiente.Location = new System.Drawing.Point(0, 60);
            this.panelLineaPendiente.Name = "panelLineaPendiente";
            this.panelLineaPendiente.Size = new System.Drawing.Size(235, 10);
            this.panelLineaPendiente.TabIndex = 19;
            this.panelLineaPendiente.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLineaPendiente_Paint);
            // 
            // panelLineaProceso
            // 
            this.panelLineaProceso.Location = new System.Drawing.Point(0, 58);
            this.panelLineaProceso.Name = "panelLineaProceso";
            this.panelLineaProceso.Size = new System.Drawing.Size(235, 12);
            this.panelLineaProceso.TabIndex = 0;
            // 
            // panelLineaFinalizado
            // 
            this.panelLineaFinalizado.Location = new System.Drawing.Point(0, 57);
            this.panelLineaFinalizado.Name = "panelLineaFinalizado";
            this.panelLineaFinalizado.Size = new System.Drawing.Size(235, 13);
            this.panelLineaFinalizado.TabIndex = 0;
            // 
            // panelLineaHoy
            // 
            this.panelLineaHoy.Location = new System.Drawing.Point(0, 57);
            this.panelLineaHoy.Name = "panelLineaHoy";
            this.panelLineaHoy.Size = new System.Drawing.Size(235, 13);
            this.panelLineaHoy.TabIndex = 9;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 645);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.flowInstalaciones);
            this.Controls.Add(this.panelProceso);
            this.Controls.Add(this.panelHoy);
            this.Controls.Add(this.panelPendientes);
            this.Controls.Add(this.panelFinalizado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDashboard";
            this.Text = "FrmDashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowInstalaciones.ResumeLayout(false);
            this.flowInstalaciones.PerformLayout();
            this.panelProceso.ResumeLayout(false);
            this.panelProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.panelHoy.ResumeLayout(false);
            this.panelHoy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            this.panelPendientes.ResumeLayout(false);
            this.panelPendientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.panelFinalizado.ResumeLayout(false);
            this.panelFinalizado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel flowInstalaciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelProceso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEnProceso;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Panel panelHoy;
        private System.Windows.Forms.Label lblInstalacionesHoy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.Panel panelPendientes;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Panel panelFinalizado;
        private System.Windows.Forms.Label lblFinalizados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Panel panelLineaPendiente;
        private System.Windows.Forms.Panel panelLineaProceso;
        private System.Windows.Forms.Panel panelLineaHoy;
        private System.Windows.Forms.Panel panelLineaFinalizado;
    }
}