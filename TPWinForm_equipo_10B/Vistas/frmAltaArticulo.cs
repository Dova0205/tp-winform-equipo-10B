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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Articulo nuevoArticulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                nuevoArticulo.Codigo = txtCodigo.Text;
                nuevoArticulo.Nombre = txtNombre.Text;
                nuevoArticulo.Descripcion = txtDescripcion.Text;

                nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text);

                nuevoArticulo.Marca = (Marca)cboMarca.SelectedItem;
                nuevoArticulo.Categoria = (Categoria)cboCategoria.SelectedItem;

                nuevoArticulo.ImagenUrl = rutaImagen;

                negocio.Agregar(nuevoArticulo);

                MessageBox.Show("¡Artículo agregado exitosamente!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups, hubo un error al guardar: " + ex.Message);
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
    }
}
