namespace TPWinForm_equipo_10B.Vistas
{
    partial class frmAdministrarMarca
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
            this.buttonAMarca = new System.Windows.Forms.Button();
            this.buttonEMarca = new System.Windows.Forms.Button();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAMarca
            // 
            this.buttonAMarca.Location = new System.Drawing.Point(316, 82);
            this.buttonAMarca.Name = "buttonAMarca";
            this.buttonAMarca.Size = new System.Drawing.Size(75, 23);
            this.buttonAMarca.TabIndex = 0;
            this.buttonAMarca.Text = "Agregar";
            this.buttonAMarca.UseVisualStyleBackColor = true;
            this.buttonAMarca.Click += new System.EventHandler(this.buttonAMarca_Click);
            // 
            // buttonEMarca
            // 
            this.buttonEMarca.Location = new System.Drawing.Point(316, 321);
            this.buttonEMarca.Name = "buttonEMarca";
            this.buttonEMarca.Size = new System.Drawing.Size(75, 23);
            this.buttonEMarca.TabIndex = 1;
            this.buttonEMarca.Text = "Eliminar";
            this.buttonEMarca.UseVisualStyleBackColor = true;
            this.buttonEMarca.Click += new System.EventHandler(this.buttonEMarca_Click);
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Location = new System.Drawing.Point(26, 122);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.RowHeadersWidth = 45;
            this.dgvMarcas.Size = new System.Drawing.Size(365, 183);
            this.dgvMarcas.TabIndex = 2;
            this.dgvMarcas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarcas_CellContentClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.69811F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "ADMINISTRAR MARCAS";
            // 
            // textMarca
            // 
            this.textMarca.Location = new System.Drawing.Point(129, 83);
            this.textMarca.Name = "textMarca";
            this.textMarca.Size = new System.Drawing.Size(167, 20);
            this.textMarca.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nueva marca:";
            // 
            // frmAdministrarMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textMarca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMarcas);
            this.Controls.Add(this.buttonEMarca);
            this.Controls.Add(this.buttonAMarca);
            this.Name = "frmAdministrarMarca";
            this.Text = "frmAdministrarMarca";
            this.Load += new System.EventHandler(this.frmAdministrarMarca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAMarca;
        private System.Windows.Forms.Button buttonEMarca;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMarca;
        private System.Windows.Forms.Label label2;
    }
}