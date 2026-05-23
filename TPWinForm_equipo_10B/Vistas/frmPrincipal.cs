using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TPWinForm_equipo_10B.Dominio;
using TPWinForm_equipo_10B.Negocio;
using TPWinForm_equipo_10B.Negocios;

namespace TPWinForm_equipo_10B.Vistas
{
    public partial class frmPrincipal : Form
    {
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button3;
        private Button btnModificar_Click;
        private Button btnEliminar_Click;
        private TextBox txtFiltro_TextChanged;
        private Label label3;
        private Button buttonCategoria;
        private Button buttonMarca;
        private Button btnAnterior;
        private Button btnSiguiente;
        private PictureBox pictureBox2;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()



        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.btnModificar_Click = new System.Windows.Forms.Button();
            this.btnEliminar_Click = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtFiltro_TextChanged = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCategoria = new System.Windows.Forms.Button();
            this.buttonMarca = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(433, 55);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(179, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Categorias";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Marcas";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Limpiar Filtros";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(113, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.Size = new System.Drawing.Size(603, 210);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 41);
            this.button3.TabIndex = 9;
            this.button3.Text = "Agregar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnModificar_Click
            // 
            this.btnModificar_Click.Location = new System.Drawing.Point(12, 172);
            this.btnModificar_Click.Name = "btnModificar_Click";
            this.btnModificar_Click.Size = new System.Drawing.Size(86, 41);
            this.btnModificar_Click.TabIndex = 10;
            this.btnModificar_Click.Text = "Modificar";
            this.btnModificar_Click.UseVisualStyleBackColor = true;
            this.btnModificar_Click.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnEliminar_Click
            // 
            this.btnEliminar_Click.Location = new System.Drawing.Point(12, 237);
            this.btnEliminar_Click.Name = "btnEliminar_Click";
            this.btnEliminar_Click.Size = new System.Drawing.Size(86, 41);
            this.btnEliminar_Click.TabIndex = 11;
            this.btnEliminar_Click.Text = "Eliminar";
            this.btnEliminar_Click.UseVisualStyleBackColor = true;
            this.btnEliminar_Click.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(736, 93);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(210, 210);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.VisibleChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // txtFiltro_TextChanged
            // 
            this.txtFiltro_TextChanged.Location = new System.Drawing.Point(113, 28);
            this.txtFiltro_TextChanged.Name = "txtFiltro_TextChanged";
            this.txtFiltro_TextChanged.Size = new System.Drawing.Size(499, 20);
            this.txtFiltro_TextChanged.TabIndex = 32;
            this.txtFiltro_TextChanged.TextChanged += new System.EventHandler(this.TextChanged_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Buscar";
            // 
            // buttonCategoria
            // 
            this.buttonCategoria.Location = new System.Drawing.Point(298, 53);
            this.buttonCategoria.Name = "buttonCategoria";
            this.buttonCategoria.Size = new System.Drawing.Size(83, 23);
            this.buttonCategoria.TabIndex = 34;
            this.buttonCategoria.Text = "Administrar";
            this.buttonCategoria.UseVisualStyleBackColor = true;
            this.buttonCategoria.Click += new System.EventHandler(this.buttonCategoria_Click);
            // 
            // buttonMarca
            // 
            this.buttonMarca.Location = new System.Drawing.Point(618, 54);
            this.buttonMarca.Name = "buttonMarca";
            this.buttonMarca.Size = new System.Drawing.Size(83, 23);
            this.buttonMarca.TabIndex = 35;
            this.buttonMarca.Text = "Administrar";
            this.buttonMarca.UseVisualStyleBackColor = true;
            this.buttonMarca.Click += new System.EventHandler(this.buttonMarca_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(763, 310);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 36;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(845, 310);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 37;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // frmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(982, 375);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.buttonMarca);
            this.Controls.Add(this.buttonCategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltro_TextChanged);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnEliminar_Click);
            this.Controls.Add(this.btnModificar_Click);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private List<Articulo> listaArticulos;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.Listar();

            dataGridView1.DataSource = listaArticulos;
            OcultarColumnas();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            List<Categoria> listaCategorias = catNegocio.Listar();// Guardamos la lista en una variable
            Categoria opcionTodos = new Categoria();// Creamos nuestra opción
            opcionTodos.Id = 0;
            opcionTodos.Descripcion = "Todas las categorias";
            listaCategorias.Insert(0, opcionTodos);// La metemos en la primera posición (índice 0)
            comboBox1.DataSource = listaCategorias;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "Id";


            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            MarcaNegocio marNegocio = new MarcaNegocio();
            List<Marca> listaMarcas = marNegocio.Listar();
            Marca opcionTodas = new Marca();
            opcionTodas.Id = 0;
            opcionTodas.Descripcion = "Todas las marcas";
            listaMarcas.Insert(0, opcionTodas);
            comboBox2.DataSource = listaMarcas;
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "Id";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Resetear combos
            comboBox1.SelectedIndex = 0; // Categoría
            comboBox2.SelectedIndex = 0; // Marca

            // Volver a cargar todos los artículos
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaArticulos;
            OcultarColumnas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAltaArticulo ventanaAlta = new frmAltaArticulo();
            ventanaAlta.ShowDialog();
            CargarGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo antes de modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Articulo selecionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
            frmAltaArticulo modificar = new frmAltaArticulo(selecionado);
            modificar.ShowDialog();
            CargarGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo antes de eliminarlo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que desea eliminar el artículo seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
                    negocio.Eliminar(seleccionado.Id);
                    MessageBox.Show("Artículo eliminado correctamente.");
                    // Refrescar la lista de artículos después de eliminar
                    listaArticulos = negocio.Listar();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = listaArticulos;
                    OcultarColumnas();
                    CargarGrid();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("No podés eliminar esta categoría porque hay artículos que la están usando. Cambiales la categoría primero.", "Ataque bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error en la base de datos: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el artículo: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;

                imagenesActuales = seleccionado.Imagenes;
                indiceImagen = 0;

                MostrarImagen();
            }
        }

        private void MostrarImagen()
        {
            try
            {
                if (imagenesActuales != null && imagenesActuales.Count > 0)
                {
                    pictureBox2.LoadAsync(imagenesActuales[indiceImagen].ImagenUrl);
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
            catch
            {
                pictureBox2.Image = null;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CargarGrid()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            listaArticulos = negocio.Listar();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaArticulos;
            OcultarColumnas();
        }

        private void CargarCombos()
        {
            MarcaNegocio marNegocio = new MarcaNegocio();

            comboBox2.DataSource = null;
            comboBox2.Items.Clear();

            List<Marca> listaMarcas = marNegocio.Listar();

            Marca opcionTodas = new Marca();
            opcionTodas.Id = 0;
            opcionTodas.Descripcion = "Todas las marcas";

            listaMarcas.Insert(0, opcionTodas);

            comboBox2.DataSource = listaMarcas;
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "Id";
        }

        private void buttonMarca_Click(object sender, EventArgs e)
        {
            frmAdministrarMarca ventana = new frmAdministrarMarca();
            ventana.ShowDialog();
            CargarGrid();
            CargarCombos();
        }

        private void buttonCategoria_Click(object sender, EventArgs e)
        {
            frmAdministrarCategoria ventana = new frmAdministrarCategoria();
            ventana.ShowDialog();
            CargarGrid();
            CargarCombos();
        }

        private int indiceImagen = 0;
        private List<Imagen> imagenesActuales = new List<Imagen>();

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (imagenesActuales == null || imagenesActuales.Count == 0)
                return;

            indiceImagen++;

            if (indiceImagen >= imagenesActuales.Count)
                indiceImagen = 0; // vuelve al inicio

            MostrarImagen();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (imagenesActuales == null || imagenesActuales.Count == 0)
                return;

            indiceImagen--;

            if (indiceImagen < 0)
                indiceImagen = imagenesActuales.Count - 1;

            MostrarImagen();
        }
        private void OcultarColumnas()
        {
            if (dataGridView1.Columns["Id"] != null)
            {
                dataGridView1.Columns["Id"].Visible = false;
            }

            if (dataGridView1.Columns["ImagenUrl"] != null)
            {
                dataGridView1.Columns["ImagenUrl"].Visible = false;
            }

            if (dataGridView1.Columns["Imagenes"] != null)
            {
                dataGridView1.Columns["Imagenes"].Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosAvanzados();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosAvanzados();
        }

        private void TextChanged_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltrosAvanzados();
        }

        private void AplicarFiltrosAvanzados()
        {
            List<Articulo> listaFiltrada = listaArticulos;

            // Aplicamos el filtro de TEXTO (sobre la lista completa)
            string filtroTexto = txtFiltro_TextChanged.Text;
            if (filtroTexto.Length >= 2)
            {
                listaFiltrada = listaFiltrada.FindAll(x =>
                    x.Nombre.ToUpper().Contains(filtroTexto.ToUpper()) ||
                    x.Codigo.ToUpper().Contains(filtroTexto.ToUpper()));
            }

            // Aplicamos el filtro de CATEGORÍA (sobre lo que quedó del texto)
            if (comboBox1.SelectedValue != null)
            {
                int idCategoria;
                if (int.TryParse(comboBox1.SelectedValue.ToString(), out idCategoria) && idCategoria != 0)
                {
                    listaFiltrada = listaFiltrada.FindAll(x => x.Categoria != null && x.Categoria.Id == idCategoria);
                }
            }

            // Aplicamos el filtro de MARCA (sobre lo que quedó del texto y la categoría)
            if (comboBox2.SelectedValue != null)
            {
                int idMarca;
                if (int.TryParse(comboBox2.SelectedValue.ToString(), out idMarca) && idMarca != 0)
                {
                    listaFiltrada = listaFiltrada.FindAll(x => x.Marca != null && x.Marca.Id == idMarca);
                }
            }

            // Mandamos la lista súper filtrada a la grilla
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaFiltrada;
            OcultarColumnas();
        }
    }
}
