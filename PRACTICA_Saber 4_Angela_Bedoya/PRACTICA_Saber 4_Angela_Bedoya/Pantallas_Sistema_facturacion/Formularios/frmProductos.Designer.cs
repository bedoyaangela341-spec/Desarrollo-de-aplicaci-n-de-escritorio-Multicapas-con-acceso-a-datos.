namespace Pantallas_Sistema_facturacion.Formularios
{
    partial class frmProductos
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.txtFoto = new System.Windows.Forms.TextBox();
            this.btnExaminar = new System.Windows.Forms.Button();
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
            this.lblTitulo.Text = "Ingreso nuevo producto";
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 1;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.White;
            this.pnlDatos.Location = new System.Drawing.Point(0, 60);
            this.pnlDatos.Size = new System.Drawing.Size(760, 330);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblNombre.Location = new System.Drawing.Point(30, 20);
            this.lblNombre.Text = "Nombre del producto";
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
            this.txtNombre.MaxLength = 70;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblCodigo.Location = new System.Drawing.Point(30, 82);
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(30, 104);
            this.txtCodigo.Size = new System.Drawing.Size(320, 25);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.MaxLength = 30;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblCategoria.Location = new System.Drawing.Point(30, 144);
            this.lblCategoria.Text = "Categoría";
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.TabIndex = 7;
            // 
            // cboCategoria
            // 
            this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategoria.Location = new System.Drawing.Point(30, 166);
            this.cboCategoria.Size = new System.Drawing.Size(320, 25);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.TabIndex = 8;
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblDetalle.Location = new System.Drawing.Point(30, 206);
            this.lblDetalle.Text = "Detalle";
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.TabIndex = 9;
            // 
            // txtDetalle
            // 
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDetalle.Location = new System.Drawing.Point(30, 228);
            this.txtDetalle.Size = new System.Drawing.Size(320, 25);
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.TabIndex = 10;
            this.txtDetalle.MaxLength = 50;
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPrecioCompra.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblPrecioCompra.Location = new System.Drawing.Point(400, 20);
            this.lblPrecioCompra.Text = "Precio de compra";
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.TabIndex = 11;
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioCompra.Location = new System.Drawing.Point(400, 42);
            this.txtPrecioCompra.Size = new System.Drawing.Size(150, 25);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.TabIndex = 12;
            this.txtPrecioCompra.MaxLength = 15;
            this.txtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloDecimal_KeyPress);
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblPrecioVenta.Location = new System.Drawing.Point(570, 20);
            this.lblPrecioVenta.Text = "Precio de venta";
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.TabIndex = 13;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioVenta.Location = new System.Drawing.Point(570, 42);
            this.txtPrecioVenta.Size = new System.Drawing.Size(150, 25);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.TabIndex = 14;
            this.txtPrecioVenta.MaxLength = 15;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloDecimal_KeyPress);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblStock.Location = new System.Drawing.Point(400, 82);
            this.lblStock.Text = "Stock (unidades)";
            this.lblStock.Name = "lblStock";
            this.lblStock.TabIndex = 15;
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStock.Location = new System.Drawing.Point(400, 104);
            this.txtStock.Size = new System.Drawing.Size(150, 25);
            this.txtStock.Name = "txtStock";
            this.txtStock.TabIndex = 16;
            this.txtStock.MaxLength = 9;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros_KeyPress);
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFoto.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblFoto.Location = new System.Drawing.Point(400, 144);
            this.lblFoto.Text = "Foto (nombre del archivo)";
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.TabIndex = 17;
            // 
            // txtFoto
            // 
            this.txtFoto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFoto.Location = new System.Drawing.Point(400, 166);
            this.txtFoto.Size = new System.Drawing.Size(230, 25);
            this.txtFoto.Name = "txtFoto";
            this.txtFoto.TabIndex = 18;
            this.txtFoto.MaxLength = 50;
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.Color.FromArgb(96, 125, 139);
            this.btnExaminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExaminar.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnExaminar.Location = new System.Drawing.Point(640, 166);
            this.btnExaminar.Size = new System.Drawing.Size(80, 25);
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.TabIndex = 19;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnActualizar.Location = new System.Drawing.Point(400, 290);
            this.btnActualizar.Size = new System.Drawing.Size(150, 36);
            this.btnActualizar.Text = "Guardar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.TabIndex = 20;
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
            this.btnSalir.Location = new System.Drawing.Point(570, 290);
            this.btnSalir.Size = new System.Drawing.Size(150, 36);
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MensajeError
            // 
            this.MensajeError.ContainerControl = this;
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlDatos.Controls.Add(this.lblNombre);
            this.pnlDatos.Controls.Add(this.txtNombre);
            this.pnlDatos.Controls.Add(this.lblCodigo);
            this.pnlDatos.Controls.Add(this.txtCodigo);
            this.pnlDatos.Controls.Add(this.lblCategoria);
            this.pnlDatos.Controls.Add(this.cboCategoria);
            this.pnlDatos.Controls.Add(this.lblDetalle);
            this.pnlDatos.Controls.Add(this.txtDetalle);
            this.pnlDatos.Controls.Add(this.lblPrecioCompra);
            this.pnlDatos.Controls.Add(this.txtPrecioCompra);
            this.pnlDatos.Controls.Add(this.lblPrecioVenta);
            this.pnlDatos.Controls.Add(this.txtPrecioVenta);
            this.pnlDatos.Controls.Add(this.lblStock);
            this.pnlDatos.Controls.Add(this.txtStock);
            this.pnlDatos.Controls.Add(this.lblFoto);
            this.pnlDatos.Controls.Add(this.txtFoto);
            this.pnlDatos.Controls.Add(this.btnExaminar);
            this.pnlDatos.Controls.Add(this.btnActualizar);
            this.pnlDatos.Controls.Add(this.btnSalir);
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 390);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualización Producto";
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlTitulo);
            this.Name = "frmProductos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
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
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.TextBox txtFoto;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ErrorProvider MensajeError;
    }
}
