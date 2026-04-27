namespace TPWinForm_equipo_10B.Vistas
{
    partial class frmAdministrarCategoria
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
            this.label2 = new System.Windows.Forms.Label();
            this.textCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.buttonECategoria = new System.Windows.Forms.Button();
            this.buttonACategoria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nueva categoria:";
            // 
            // textCategoria
            // 
            this.textCategoria.Location = new System.Drawing.Point(133, 73);
            this.textCategoria.Name = "textCategoria";
            this.textCategoria.Size = new System.Drawing.Size(155, 20);
            this.textCategoria.TabIndex = 10;
            this.textCategoria.TextChanged += new System.EventHandler(this.textCategoria_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.69811F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 33);
            this.label1.TabIndex = 9;
            this.label1.Text = "ADMINISTRAR CATEGORIAS";
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(18, 112);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.RowHeadersWidth = 45;
            this.dgvCategorias.Size = new System.Drawing.Size(365, 183);
            this.dgvCategorias.TabIndex = 8;
            this.dgvCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellContentClick);
            // 
            // buttonECategoria
            // 
            this.buttonECategoria.Location = new System.Drawing.Point(308, 311);
            this.buttonECategoria.Name = "buttonECategoria";
            this.buttonECategoria.Size = new System.Drawing.Size(75, 23);
            this.buttonECategoria.TabIndex = 7;
            this.buttonECategoria.Text = "Eliminar";
            this.buttonECategoria.UseVisualStyleBackColor = true;
            this.buttonECategoria.Click += new System.EventHandler(this.buttonECategoria_Click);
            // 
            // buttonACategoria
            // 
            this.buttonACategoria.Location = new System.Drawing.Point(308, 72);
            this.buttonACategoria.Name = "buttonACategoria";
            this.buttonACategoria.Size = new System.Drawing.Size(75, 23);
            this.buttonACategoria.TabIndex = 6;
            this.buttonACategoria.Text = "Agregar";
            this.buttonACategoria.UseVisualStyleBackColor = true;
            this.buttonACategoria.Click += new System.EventHandler(this.buttonACategoria_Click);
            // 
            // frmAdministrarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textCategoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCategorias);
            this.Controls.Add(this.buttonECategoria);
            this.Controls.Add(this.buttonACategoria);
            this.Name = "frmAdministrarCategoria";
            this.Text = "frmAdministrarCategoria";
            this.Load += new System.EventHandler(this.frmAdministrarCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.Button buttonECategoria;
        private System.Windows.Forms.Button buttonACategoria;
    }
}