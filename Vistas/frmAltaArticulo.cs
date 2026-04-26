using System;
using System.Windows.Forms;
using TPWinForm_equipo_10B.Dominio;
using TPWinForm_equipo_10B.Negocio;
using TPWinForm_equipo_10B.Negocios;


namespace TPWinForm_equipo_10B.Vistas
{
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Artículo";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                // Llenamos el combo de Marcas
                cboMarca.DataSource = marcaNegocio.Listar();
                cboMarca.ValueMember = "Id"; // El dato oculto que se guarda (la clave primaria)
                cboMarca.DisplayMember = "Descripcion"; // El texto que ve el usuario (ej: "Motorola")

                // Llenamos el combo de Categorías
                cboCategoria.DataSource = categoriaNegocio.Listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al cargar los desplegables: " + ex.Message);
            }

            if (articulo != null)
            {
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString();
                cboMarca.SelectedValue = articulo.Marca.Id;
                cboCategoria.SelectedValue = articulo.Categoria.Id;

                try
                {
                    if (!string.IsNullOrEmpty(articulo.ImagenUrl))
                    {
                        pbxArticulo.LoadAsync(articulo.ImagenUrl);
                        rutaImagen = articulo.ImagenUrl;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al cargar la imagen: " + ex.Message);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.ImagenUrl = rutaImagen;

                if (articulo.Id != 0)
                {
                    negocio.Modificar(articulo);
                    MessageBox.Show("Artículo modificado correctamente.");
                }
                else
                {
                    negocio.Agregar(articulo);
                    MessageBox.Show("Artículo agregado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private string rutaImagen = "";
        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = archivo.FileName;
                pbxArticulo.Load(rutaImagen);
            }
        }

        private Articulo articulo = null;

        private void pbxArticulo_Click(object sender, EventArgs e)
        {

        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
