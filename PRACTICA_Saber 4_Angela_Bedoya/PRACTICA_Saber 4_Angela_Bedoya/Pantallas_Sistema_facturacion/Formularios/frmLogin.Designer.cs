namespace Pantallas_Sistema_facturacion.Formularios
{
    partial class frmLogin
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

        private System.Windows.Forms.Panel pnlIzquierda;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblSubMarca;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblAcceder;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblMensaje;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlIzquierda = new System.Windows.Forms.Panel();
            this.lblSubMarca = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblAcceder = new System.Windows.Forms.Label();
            this.pnlIzquierda.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlIzquierda
            //
            this.pnlIzquierda.BackColor = System.Drawing.Color.FromArgb(41, 65, 100);
            this.pnlIzquierda.Controls.Add(this.lblSubMarca);
            this.pnlIzquierda.Controls.Add(this.lblMarca);
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierda.Location = new System.Drawing.Point(0, 0);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(340, 460);
            this.pnlIzquierda.TabIndex = 0;
            //
            // lblMarca
            //
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(36, 180);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(230, 41);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "Facturación";
            //
            // lblSubMarca
            //
            this.lblSubMarca.AutoSize = true;
            this.lblSubMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubMarca.ForeColor = System.Drawing.Color.FromArgb(200, 210, 225);
            this.lblSubMarca.Location = new System.Drawing.Point(38, 228);
            this.lblSubMarca.Name = "lblSubMarca";
            this.lblSubMarca.Size = new System.Drawing.Size(230, 19);
            this.lblSubMarca.TabIndex = 1;
            this.lblSubMarca.Text = "Sistema de gestión comercial";
            //
            // pnlDerecha
            //
            this.pnlDerecha.BackColor = System.Drawing.Color.White;
            this.pnlDerecha.Controls.Add(this.lblMensaje);
            this.pnlDerecha.Controls.Add(this.btnSalir);
            this.pnlDerecha.Controls.Add(this.btnIngresar);
            this.pnlDerecha.Controls.Add(this.txtClave);
            this.pnlDerecha.Controls.Add(this.lblClave);
            this.pnlDerecha.Controls.Add(this.txtUsuario);
            this.pnlDerecha.Controls.Add(this.lblUsuario);
            this.pnlDerecha.Controls.Add(this.lblAcceder);
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecha.Location = new System.Drawing.Point(340, 0);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(340, 460);
            this.pnlDerecha.TabIndex = 1;
            //
            // lblAcceder
            //
            this.lblAcceder.AutoSize = true;
            this.lblAcceder.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAcceder.ForeColor = System.Drawing.Color.FromArgb(41, 65, 100);
            this.lblAcceder.Location = new System.Drawing.Point(48, 62);
            this.lblAcceder.Name = "lblAcceder";
            this.lblAcceder.Size = new System.Drawing.Size(170, 30);
            this.lblAcceder.TabIndex = 0;
            this.lblAcceder.Text = "Iniciar sesión";
            //
            // lblUsuario
            //
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblUsuario.Location = new System.Drawing.Point(48, 130);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(53, 15);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            //
            // txtUsuario
            //
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.Location = new System.Drawing.Point(48, 150);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(244, 27);
            this.txtUsuario.TabIndex = 2;
            //
            // lblClave
            //
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblClave.Location = new System.Drawing.Point(48, 196);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(70, 15);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Contraseña";
            //
            // txtClave
            //
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtClave.Location = new System.Drawing.Point(48, 216);
            this.txtClave.MaxLength = 50;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '●';
            this.txtClave.Size = new System.Drawing.Size(244, 27);
            this.txtClave.TabIndex = 4;
            this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
            //
            // btnIngresar
            //
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(41, 65, 100);
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(48, 264);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(244, 42);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnSalir.FlatAppearance.BorderSize = 1;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.btnSalir.Location = new System.Drawing.Point(48, 314);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(244, 34);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            //
            // lblMensaje
            //
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.lblMensaje.Location = new System.Drawing.Point(48, 362);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 15);
            this.lblMensaje.TabIndex = 7;
            //
            // frmLogin
            //
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 460);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión - Sistema de Facturación";
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
