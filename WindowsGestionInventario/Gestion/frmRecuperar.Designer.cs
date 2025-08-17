namespace Gestion
{
    partial class frmRecuperar
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
            this.dgvRecuperar = new System.Windows.Forms.DataGridView();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.pbxRecuperar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecuperar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRecuperar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecuperar
            // 
            this.dgvRecuperar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecuperar.Location = new System.Drawing.Point(65, 12);
            this.dgvRecuperar.MultiSelect = false;
            this.dgvRecuperar.Name = "dgvRecuperar";
            this.dgvRecuperar.ReadOnly = true;
            this.dgvRecuperar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecuperar.Size = new System.Drawing.Size(466, 283);
            this.dgvRecuperar.TabIndex = 0;
            this.dgvRecuperar.SelectionChanged += new System.EventHandler(this.dgvRecuperar_SelectionChanged);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperar.Location = new System.Drawing.Point(434, 310);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(97, 29);
            this.btnRecuperar.TabIndex = 1;
            this.btnRecuperar.Text = "Recuperar";
            this.btnRecuperar.UseVisualStyleBackColor = true;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(70, 312);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(62, 23);
            this.lblFiltro.TabIndex = 2;
            this.lblFiltro.Text = "Filtro:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.Location = new System.Drawing.Point(139, 314);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(289, 20);
            this.txtFiltro.TabIndex = 3;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // pbxRecuperar
            // 
            this.pbxRecuperar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbxRecuperar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxRecuperar.Location = new System.Drawing.Point(556, 13);
            this.pbxRecuperar.Name = "pbxRecuperar";
            this.pbxRecuperar.Size = new System.Drawing.Size(246, 282);
            this.pbxRecuperar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRecuperar.TabIndex = 4;
            this.pbxRecuperar.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(705, 370);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(97, 29);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmRecuperar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 411);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pbxRecuperar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.dgvRecuperar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(830, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(830, 450);
            this.Name = "frmRecuperar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro eliminados";
            this.Load += new System.EventHandler(this.frmRecuperar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecuperar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRecuperar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRecuperar;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.PictureBox pbxRecuperar;
        private System.Windows.Forms.Button btnCerrar;
    }
}