namespace UI
{
    partial class FrmClientes
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
            label1 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            grid = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtApellidos = new TextBox();
            txtNombres = new TextBox();
            txtCorreo = new TextBox();
            txtDni = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 18);
            label1.Name = "label1";
            label1.Size = new Size(49, 17);
            label1.TabIndex = 0;
            label1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(74, 15);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Apellidos, nombres o DNI";
            txtBuscar.Size = new Size(400, 25);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(480, 14);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(82, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(12, 60);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(890, 360);
            grid.TabIndex = 18;
            grid.SelectionChanged += grid_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 439);
            label2.Name = "label2";
            label2.Size = new Size(65, 17);
            label2.TabIndex = 3;
            label2.Text = "Apellidos.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(263, 439);
            label3.Name = "label3";
            label3.Size = new Size(66, 17);
            label3.TabIndex = 5;
            label3.Text = "Nombres:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 509);
            label4.Name = "label4";
            label4.Size = new Size(33, 17);
            label4.TabIndex = 9;
            label4.Text = "DNI:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(171, 509);
            label5.Name = "label5";
            label5.Size = new Size(61, 17);
            label5.TabIndex = 11;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(330, 509);
            label6.Name = "label6";
            label6.Size = new Size(65, 17);
            label6.TabIndex = 13;
            label6.Text = "Dirección:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(516, 443);
            label7.Name = "label7";
            label7.Size = new Size(52, 17);
            label7.TabIndex = 7;
            label7.Text = "Correo:";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(15, 463);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(236, 25);
            txtApellidos.TabIndex = 4;
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(263, 463);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(236, 25);
            txtNombres.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(516, 463);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(386, 25);
            txtCorreo.TabIndex = 8;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(17, 532);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(134, 25);
            txtDni.TabIndex = 10;
            txtDni.KeyPress += txtDni_KeyPress;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(171, 532);
            txtTelefono.MaxLength = 9;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(134, 25);
            txtTelefono.TabIndex = 12;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(330, 532);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(572, 25);
            txtDireccion.TabIndex = 14;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(14, 581);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 26);
            btnNuevo.TabIndex = 15;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(95, 581);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 26);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(176, 581);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 26);
            btnEliminar.TabIndex = 17;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 619);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtDni);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombres);
            Controls.Add(txtApellidos);
            Controls.Add(grid);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView grid;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtApellidos;
        private TextBox txtNombres;
        private TextBox txtCorreo;
        private TextBox txtDni;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
    }
}