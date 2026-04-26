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
            Articulo nuevoArticulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (!ValidarCampos())
            {
                return;
            }

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

        private Articulo articulo = null;

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El articulo necesita un código.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El articulo necesita un nombre.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio ingresado no es válido. Asegurate de usar solo numeros", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        
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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.'  )
            {
                e.Handled = true;
                MessageBox.Show("No puedes ingresar letras en el campo de precio.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
