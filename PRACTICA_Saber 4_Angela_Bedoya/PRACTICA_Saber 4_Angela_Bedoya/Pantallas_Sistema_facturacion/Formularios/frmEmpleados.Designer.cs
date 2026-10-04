namespace Pantallas_Sistema_facturacion.Formularios
{
    partial class frmEmpleados
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblIngreso = new System.Windows.Forms.Label();
            this.dtpIngreso = new System.Windows.Forms.DateTimePicker();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblRetiro = new System.Windows.Forms.Label();
            this.dtpRetiro = new System.Windows.Forms.DateTimePicker();
            this.lblDatosAdicionales = new System.Windows.Forms.Label();
            this.txtDatosAdicionales = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.MensajeError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlTitulo.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MensajeError)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(76, 41, 100);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Size = new System.Drawing.Size(760, 60);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(24, 14);
            this.lblTitulo.Text = "Ingreso nuevo empleado";
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 1;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.White;
            this.pnlDatos.Location = new System.Drawing.Point(0, 60);
            this.pnlDatos.Size = new System.Drawing.Size(760, 420);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblNombre.Location = new System.Drawing.Point(30, 20);
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(30, 42);
            this.txtNombre.Size = new System.Drawing.Size(320, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.TabIndex = 4;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblDocumento.Location = new System.Drawing.Point(30, 82);
            this.lblDocumento.Text = "N° Documento";
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.TabIndex = 5;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDocumento.Location = new System.Drawing.Point(30, 104);
            this.txtDocumento.Size = new System.Drawing.Size(320, 25);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.TabIndex = 6;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblDireccion.Location = new System.Drawing.Point(30, 144);
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.TabIndex = 7;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDireccion.Location = new System.Drawing.Point(30, 166);
            this.txtDireccion.Size = new System.Drawing.Size(320, 25);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.TabIndex = 8;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblTelefono.Location = new System.Drawing.Point(30, 206);
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.TabIndex = 9;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefono.Location = new System.Drawing.Point(30, 228);
            this.txtTelefono.Size = new System.Drawing.Size(320, 25);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.TabIndex = 10;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblEmail.Location = new System.Drawing.Point(30, 268);
            this.lblEmail.Text = "Correo";
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(30, 290);
            this.txtEmail.Size = new System.Drawing.Size(320, 25);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TabIndex = 12;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblRol.Location = new System.Drawing.Point(400, 20);
            this.lblRol.Text = "Rol";
            this.lblRol.Name = "lblRol";
            this.lblRol.TabIndex = 13;
            // 
            // cboRol
            // 
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(400, 42);
            this.cboRol.Size = new System.Drawing.Size(320, 25);
            this.cboRol.Name = "cboRol";
            this.cboRol.TabIndex = 14;
            // 
            // lblIngreso
            // 
            this.lblIngreso.AutoSize = true;
            this.lblIngreso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblIngreso.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblIngreso.Location = new System.Drawing.Point(400, 82);
            this.lblIngreso.Text = "Fecha ingreso";
            this.lblIngreso.Name = "lblIngreso";
            this.lblIngreso.TabIndex = 15;
            // 
            // dtpIngreso
            // 
            this.dtpIngreso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIngreso.Location = new System.Drawing.Point(400, 104);
            this.dtpIngreso.Size = new System.Drawing.Size(150, 25);
            this.dtpIngreso.Name = "dtpIngreso";
            this.dtpIngreso.TabIndex = 16;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkActivo.Location = new System.Drawing.Point(400, 146);
            this.chkActivo.Text = "Empleado activo (sin fecha de retiro)";
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.TabIndex = 17;
            this.chkActivo.CheckedChanged += new System.EventHandler(this.chkActivo_CheckedChanged);
            // 
            // lblRetiro
            // 
            this.lblRetiro.AutoSize = true;
            this.lblRetiro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRetiro.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblRetiro.Location = new System.Drawing.Point(400, 176);
            this.lblRetiro.Text = "Fecha retiro";
            this.lblRetiro.Name = "lblRetiro";
            this.lblRetiro.TabIndex = 18;
            // 
            // dtpRetiro
            // 
            this.dtpRetiro.Enabled = false;
            this.dtpRetiro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpRetiro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRetiro.Location = new System.Drawing.Point(400, 198);
            this.dtpRetiro.Size = new System.Drawing.Size(150, 25);
            this.dtpRetiro.Name = "dtpRetiro";
            this.dtpRetiro.TabIndex = 19;
            // 
            // lblDatosAdicionales
            // 
            this.lblDatosAdicionales.AutoSize = true;
            this.lblDatosAdicionales.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDatosAdicionales.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblDatosAdicionales.Location = new System.Drawing.Point(400, 238);
            this.lblDatosAdicionales.Text = "Datos adicionales";
            this.lblDatosAdicionales.Name = "lblDatosAdicionales";
            this.lblDatosAdicionales.TabIndex = 20;
            // 
            // txtDatosAdicionales
            // 
            this.txtDatosAdicionales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDatosAdicionales.Location = new System.Drawing.Point(400, 260);
            this.txtDatosAdicionales.Size = new System.Drawing.Size(320, 25);
            this.txtDatosAdicionales.Multiline = true;
            this.txtDatosAdicionales.Size = new System.Drawing.Size(320, 82);
            this.txtDatosAdicionales.Name = "txtDatosAdicionales";
            this.txtDatosAdicionales.TabIndex = 21;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnActualizar.Location = new System.Drawing.Point(400, 360);
            this.btnActualizar.Size = new System.Drawing.Size(150, 36);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.TabIndex = 22;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(96, 125, 139);
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnSalir.Location = new System.Drawing.Point(570, 360);
            this.btnSalir.Size = new System.Drawing.Size(150, 36);
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MensajeError
            // 
            this.MensajeError.ContainerControl = this;
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlDatos.Controls.Add(this.lblNombre);
            this.pnlDatos.Controls.Add(this.txtNombre);
            this.pnlDatos.Controls.Add(this.lblDocumento);
            this.pnlDatos.Controls.Add(this.txtDocumento);
            this.pnlDatos.Controls.Add(this.lblDireccion);
            this.pnlDatos.Controls.Add(this.txtDireccion);
            this.pnlDatos.Controls.Add(this.lblTelefono);
            this.pnlDatos.Controls.Add(this.txtTelefono);
            this.pnlDatos.Controls.Add(this.lblEmail);
            this.pnlDatos.Controls.Add(this.txtEmail);
            this.pnlDatos.Controls.Add(this.lblRol);
            this.pnlDatos.Controls.Add(this.cboRol);
            this.pnlDatos.Controls.Add(this.lblIngreso);
            this.pnlDatos.Controls.Add(this.dtpIngreso);
            this.pnlDatos.Controls.Add(this.chkActivo);
            this.pnlDatos.Controls.Add(this.lblRetiro);
            this.pnlDatos.Controls.Add(this.dtpRetiro);
            this.pnlDatos.Controls.Add(this.lblDatosAdicionales);
            this.pnlDatos.Controls.Add(this.txtDatosAdicionales);
            this.pnlDatos.Controls.Add(this.btnActualizar);
            this.pnlDatos.Controls.Add(this.btnSalir);
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 480);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualización Empleado";
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlTitulo);
            this.Name = "frmEmpleados";
            this.Load += new System.EventHandler(this.frmEmpleados_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MensajeError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblIngreso;
        private System.Windows.Forms.DateTimePicker dtpIngreso;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label lblRetiro;
        private System.Windows.Forms.DateTimePicker dtpRetiro;
        private System.Windows.Forms.Label lblDatosAdicionales;
        private System.Windows.Forms.TextBox txtDatosAdicionales;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ErrorProvider MensajeError;
    }
}
