
namespace CpElec
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.c1Ribbon1 = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonConfigToolBar1 = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.ribbonQat1 = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTab1 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnProveedor = new C1.Win.C1Ribbon.RibbonButton();
            this.btnProducto = new C1.Win.C1Ribbon.RibbonButton();
            this.btnEmpleado = new C1.Win.C1Ribbon.RibbonButton();
            this.btnUsuario = new C1.Win.C1Ribbon.RibbonButton();
            this.btnCliente = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab2 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup2 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnVenta = new C1.Win.C1Ribbon.RibbonButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            this.c1Ribbon1.Tabs.Add(this.ribbonTab1);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab2);
            this.c1Ribbon1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.LargeImage = global::CpElec.Properties.Resources.ini;
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.Add(this.ribbonGroup1);
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Catálogo";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.btnProveedor);
            this.ribbonGroup1.Items.Add(this.btnProducto);
            this.ribbonGroup1.Items.Add(this.btnEmpleado);
            this.ribbonGroup1.Items.Add(this.btnUsuario);
            this.ribbonGroup1.Items.Add(this.btnCliente);
            this.ribbonGroup1.Name = "ribbonGroup1";
            // 
            // btnProveedor
            // 
            this.btnProveedor.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProveedor.LargeImage")));
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnProveedor.SmallImage")));
            this.btnProveedor.Text = "Proveedor";
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.LargeImage = global::CpElec.Properties.Resources.iconfinder_deliverables_45506;
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnProducto.SmallImage")));
            this.btnProducto.Text = "Producto";
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.LargeImage = global::CpElec.Properties.Resources.iconfinder_front_office_job_seeker_employee_unemployee_work_2620521;
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEmpleado.SmallImage")));
            this.btnEmpleado.Text = "Empleados";
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUsuario.LargeImage")));
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnUsuario.SmallImage")));
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.LargeImage = global::CpElec.Properties.Resources.iconfinder_2_330395;
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCliente.SmallImage")));
            this.btnCliente.Text = "Cliente";
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Groups.Add(this.ribbonGroup2);
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "Venta";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Items.Add(this.btnVenta);
            this.ribbonGroup2.Name = "ribbonGroup2";
            // 
            // btnVenta
            // 
            this.btnVenta.LargeImage = global::CpElec.Properties.Resources.iconfinder_cart_3688507;
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnVenta.SmallImage")));
            this.btnVenta.Text = "Venta";
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(46, 115);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(632, 295);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CpElec.Properties.Resources.fondo01;
            this.pictureBox2.Location = new System.Drawing.Point(252, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(380, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.c1Ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panda Electronic";
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.C1Ribbon.RibbonQat ribbonQat1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab1;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private C1.Win.C1Ribbon.RibbonButton btnProveedor;
        private C1.Win.C1Ribbon.RibbonButton btnProducto;
        private C1.Win.C1Ribbon.RibbonButton btnEmpleado;
        private C1.Win.C1Ribbon.RibbonButton btnUsuario;
        private C1.Win.C1Ribbon.RibbonButton btnCliente;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab2;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup2;
        private C1.Win.C1Ribbon.RibbonButton btnVenta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}