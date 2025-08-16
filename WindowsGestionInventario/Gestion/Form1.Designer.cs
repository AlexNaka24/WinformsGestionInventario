namespace Gestion
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListadoArticulos = new System.Windows.Forms.DataGridView();
            this.pbxImagenArticulo = new System.Windows.Forms.PictureBox();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.btnNuevoArticulo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoArticulos
            // 
            this.dgvListadoArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoArticulos.Location = new System.Drawing.Point(242, 26);
            this.dgvListadoArticulos.MultiSelect = false;
            this.dgvListadoArticulos.Name = "dgvListadoArticulos";
            this.dgvListadoArticulos.ReadOnly = true;
            this.dgvListadoArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoArticulos.Size = new System.Drawing.Size(400, 236);
            this.dgvListadoArticulos.TabIndex = 0;
            this.dgvListadoArticulos.SelectionChanged += new System.EventHandler(this.dgvListadoArticulos_SelectionChanged);
            // 
            // pbxImagenArticulo
            // 
            this.pbxImagenArticulo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbxImagenArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxImagenArticulo.Location = new System.Drawing.Point(674, 26);
            this.pbxImagenArticulo.Name = "pbxImagenArticulo";
            this.pbxImagenArticulo.Size = new System.Drawing.Size(201, 236);
            this.pbxImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagenArticulo.TabIndex = 1;
            this.pbxImagenArticulo.TabStop = false;
            // 
            // cboCampo
            // 
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(508, 405);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(121, 21);
            this.cboCampo.TabIndex = 2;
            // 
            // cboCriterio
            // 
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(478, 470);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(121, 21);
            this.cboCriterio.TabIndex = 3;
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(274, 471);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroAvanzado.TabIndex = 4;
            // 
            // btnNuevoArticulo
            // 
            this.btnNuevoArticulo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNuevoArticulo.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoArticulo.Location = new System.Drawing.Point(714, 309);
            this.btnNuevoArticulo.Name = "btnNuevoArticulo";
            this.btnNuevoArticulo.Size = new System.Drawing.Size(124, 35);
            this.btnNuevoArticulo.TabIndex = 5;
            this.btnNuevoArticulo.Text = "Agregar➕";
            this.btnNuevoArticulo.UseVisualStyleBackColor = false;
            this.btnNuevoArticulo.Click += new System.EventHandler(this.btnNuevoArticulo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(285, 321);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(274, 408);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 9;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(714, 391);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(124, 35);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar🛠️";
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(714, 470);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 35);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar❌";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(53, 470);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(107, 35);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnNuevoArticulo);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.pbxImagenArticulo);
            this.Controls.Add(this.dgvListadoArticulos);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListadoArticulos;
        private System.Windows.Forms.PictureBox pbxImagenArticulo;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.Button btnNuevoArticulo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
    }
}

