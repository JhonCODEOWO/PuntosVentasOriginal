namespace ProyectoDesImpSisInf.Ventanas_Emergentes
{
    partial class Administrar_Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrar_Productos));
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvProductos = new System.Windows.Forms.ListView();
            this.panel_Datos = new System.Windows.Forms.Panel();
            this.nudCantP = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecioVP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_NombreP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_IdP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrarPanel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.pnl_titu.SuspendLayout();
            this.panel_Datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantP)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pnl_titu.Controls.Add(this.label2);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(458, 43);
            this.pnl_titu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Image = global::ProyectoDesImpSisInf.Properties.Resources.orden;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 39);
            this.label2.TabIndex = 8;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(416, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administración de productos";
            // 
            // lvProductos
            // 
            this.lvProductos.HideSelection = false;
            this.lvProductos.Location = new System.Drawing.Point(6, 107);
            this.lvProductos.Name = "lvProductos";
            this.lvProductos.Size = new System.Drawing.Size(439, 347);
            this.lvProductos.TabIndex = 7;
            this.lvProductos.UseCompatibleStateImageBehavior = false;
            // 
            // panel_Datos
            // 
            this.panel_Datos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Datos.Controls.Add(this.nudCantP);
            this.panel_Datos.Controls.Add(this.button5);
            this.panel_Datos.Controls.Add(this.label7);
            this.panel_Datos.Controls.Add(this.txtPrecioVP);
            this.panel_Datos.Controls.Add(this.label6);
            this.panel_Datos.Controls.Add(this.txt_NombreP);
            this.panel_Datos.Controls.Add(this.label3);
            this.panel_Datos.Controls.Add(this.txt_IdP);
            this.panel_Datos.Controls.Add(this.label5);
            this.panel_Datos.Controls.Add(this.panel2);
            this.panel_Datos.Location = new System.Drawing.Point(56, 107);
            this.panel_Datos.Name = "panel_Datos";
            this.panel_Datos.Size = new System.Drawing.Size(353, 347);
            this.panel_Datos.TabIndex = 8;
            this.panel_Datos.Visible = false;
            // 
            // nudCantP
            // 
            this.nudCantP.Location = new System.Drawing.Point(9, 255);
            this.nudCantP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCantP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantP.Name = "nudCantP";
            this.nudCantP.Size = new System.Drawing.Size(52, 20);
            this.nudCantP.TabIndex = 20;
            this.nudCantP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(68, 303);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(228, 39);
            this.button5.TabIndex = 19;
            this.button5.Text = "Agregar datos a la base de datos";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Cantidad en stock";
            // 
            // txtPrecioVP
            // 
            this.txtPrecioVP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioVP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVP.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioVP.Location = new System.Drawing.Point(7, 195);
            this.txtPrecioVP.Name = "txtPrecioVP";
            this.txtPrecioVP.Size = new System.Drawing.Size(114, 25);
            this.txtPrecioVP.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Precio de venta";
            // 
            // txt_NombreP
            // 
            this.txt_NombreP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_NombreP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreP.ForeColor = System.Drawing.Color.Black;
            this.txt_NombreP.Location = new System.Drawing.Point(7, 134);
            this.txt_NombreP.Name = "txt_NombreP";
            this.txt_NombreP.Size = new System.Drawing.Size(230, 25);
            this.txt_NombreP.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nombre del producto";
            // 
            // txt_IdP
            // 
            this.txt_IdP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IdP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdP.ForeColor = System.Drawing.Color.DimGray;
            this.txt_IdP.Location = new System.Drawing.Point(7, 74);
            this.txt_IdP.Name = "txt_IdP";
            this.txt_IdP.Size = new System.Drawing.Size(100, 25);
            this.txt_IdP.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Id del producto";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Indigo;
            this.panel2.Controls.Add(this.btnCerrarPanel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 43);
            this.panel2.TabIndex = 4;
            // 
            // btnCerrarPanel
            // 
            this.btnCerrarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarPanel.FlatAppearance.BorderSize = 0;
            this.btnCerrarPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnCerrarPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnCerrarPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarPanel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPanel.ForeColor = System.Drawing.Color.White;
            this.btnCerrarPanel.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarPanel.Image")));
            this.btnCerrarPanel.Location = new System.Drawing.Point(309, 4);
            this.btnCerrarPanel.Name = "btnCerrarPanel";
            this.btnCerrarPanel.Size = new System.Drawing.Size(32, 32);
            this.btnCerrarPanel.TabIndex = 6;
            this.btnCerrarPanel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarPanel.UseVisualStyleBackColor = true;
            this.btnCerrarPanel.Click += new System.EventHandler(this.btnCerrarPanel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ingresa tus datos";
            // 
            // button3
            // 
            this.button3.Image = global::ProyectoDesImpSisInf.Properties.Resources.archivo_de_registro;
            this.button3.Location = new System.Drawing.Point(339, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 52);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::ProyectoDesImpSisInf.Properties.Resources.eliminar__2_;
            this.btnEliminar.Location = new System.Drawing.Point(284, 49);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(49, 52);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::ProyectoDesImpSisInf.Properties.Resources.add_icon_icons_com_74429;
            this.BtnAgregar.Location = new System.Drawing.Point(396, 49);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(50, 52);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Administrar_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(458, 466);
            this.Controls.Add(this.panel_Datos);
            this.Controls.Add(this.lvProductos);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.pnl_titu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Administrar_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar_Productos";
            this.Load += new System.EventHandler(this.Administrar_Productos_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.panel_Datos.ResumeLayout(false);
            this.panel_Datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantP)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView lvProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_Datos;
        private System.Windows.Forms.NumericUpDown nudCantP;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrecioVP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_NombreP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_IdP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrarPanel;
        private System.Windows.Forms.Label label4;
    }
}