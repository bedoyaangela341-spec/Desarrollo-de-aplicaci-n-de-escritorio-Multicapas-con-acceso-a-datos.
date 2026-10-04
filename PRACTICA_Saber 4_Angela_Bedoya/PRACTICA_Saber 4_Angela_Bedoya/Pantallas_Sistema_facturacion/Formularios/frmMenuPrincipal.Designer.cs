namespace Pantallas_Sistema_facturacion.Formularios
{
    partial class frmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnSeguridad;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblRol;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnSeguridad = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.lblSistema = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pnlLateral.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlLateral
            //
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(30, 30, 46);
            this.pnlLateral.Controls.Add(this.btnCerrarSesion);
            this.pnlLateral.Controls.Add(this.btnSeguridad);
            this.pnlLateral.Controls.Add(this.btnEmpleados);
            this.pnlLateral.Controls.Add(this.btnProductos);
            this.pnlLateral.Controls.Add(this.btnClientes);
            this.pnlLateral.Controls.Add(this.lblSistema);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(240, 560);
            this.pnlLateral.TabIndex = 0;
            //
            // lblSistema
            //
            this.lblSistema.AutoSize = true;
            this.lblSistema.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSistema.ForeColor = System.Drawing.Color.White;
            this.lblSistema.Location = new System.Drawing.Point(24, 28);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(150, 25);
            this.lblSistema.TabIndex = 0;
            this.lblSistema.Text = "Facturación";
            //
            // btnClientes
            //
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.btnClientes.Location = new System.Drawing.Point(0, 100);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(240, 54);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "  🧾  Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            //
            // btnProductos
            //
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(41, 65, 100);
            this.btnProductos.Location = new System.Drawing.Point(0, 154);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(240, 54);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "  📦  Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            //
            // btnEmpleados
            //
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnEmpleados.BackColor = System.Drawing.Color.FromArgb(76, 41, 100);
            this.btnEmpleados.Location = new System.Drawing.Point(0, 208);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(240, 54);
            this.btnEmpleados.TabIndex = 3;
            this.btnEmpleados.Text = "  👤  Empleados";
            this.btnEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.UseVisualStyleBackColor = false;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            //
            // btnSeguridad
            //
            this.btnSeguridad.FlatAppearance.BorderSize = 0;
            this.btnSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeguridad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSeguridad.ForeColor = System.Drawing.Color.White;
            this.btnSeguridad.BackColor = System.Drawing.Color.FromArgb(96, 78, 20);
            this.btnSeguridad.Location = new System.Drawing.Point(0, 262);
            this.btnSeguridad.Name = "btnSeguridad";
            this.btnSeguridad.Size = new System.Drawing.Size(240, 54);
            this.btnSeguridad.TabIndex = 4;
            this.btnSeguridad.Text = "  🔒  Seguridad";
            this.btnSeguridad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeguridad.UseVisualStyleBackColor = false;
            this.btnSeguridad.Click += new System.EventHandler(this.btnSeguridad_Click);
            //
            // btnCerrarSesion
            //
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(220, 220, 230);
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(30, 30, 46);
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 500);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(240, 44);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "  ⏻  Cerrar sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            //
            // pnlContenido
            //
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(245, 246, 248);
            this.pnlContenido.Controls.Add(this.lblRol);
            this.pnlContenido.Controls.Add(this.lblBienvenida);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(240, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(560, 560);
            this.pnlContenido.TabIndex = 1;
            //
            // lblBienvenida
            //
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblBienvenida.Location = new System.Drawing.Point(40, 40);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(400, 25);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Seleccione una opción del menú para comenzar.";
            //
            // lblRol
            //
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.lblRol.Location = new System.Drawing.Point(40, 72);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(60, 19);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "";
            //
            // frmMenuPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlLateral);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Facturación";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenuPrincipal_FormClosed);
            this.pnlLateral.ResumeLayout(false);
            this.pnlLateral.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
