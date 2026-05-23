using System;
using System.Collections.Generic;
using System.Linq;
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
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

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

            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                List<Articulo> listaActual = negocio.Listar();

                bool codigoRepetido = listaActual.Any(x => x.Codigo.ToUpper() == txtCodigo.Text.ToUpper() && x.Id != articulo.Id);

                if (codigoRepetido)
                {
                    MessageBox.Show("Ya existe un artículo con ese Código en el inventario. Elegí otro.", "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

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
                    MessageBox.Show("¡Artículo modificado exitosamente!");
                }
                else
                {
                    negocio.Agregar(articulo);
                    MessageBox.Show("¡Artículo agregado exitosamente!");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups, hubo un error al guardar: " + ex.Message);
            }
        }

        private string rutaImagen = "";
        /*
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
        */
        private void btnImagen_Click(object sender, EventArgs e)
        {

            string url = txtUrlImagen.Text;

            if (url == "")
            {
                MessageBox.Show("Ingrese una URL de imagen.");
                return;
            }

            listaUrls.Add(url);

            try
            {
                pbxArticulo.LoadAsync(url);
            }
            catch
            {
                MessageBox.Show("No se pudo cargar la imagen.");
            }

            txtUrlImagen.Text = ""; // limpia el campo

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
                MessageBox.Show("El precio ingresado no es válido. Asegurate de usar solo numeros.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboMarca.SelectedItem == null || cboMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccioná una Marca para el artículo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboCategoria.SelectedItem == null || cboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccioná una Categoría para el artículo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' &&
                e.KeyChar != '.')
            {
                e.Handled = true;

                MessageBox.Show("No puedes ingresar letras en el campo de precio.",
                    "Atencion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private List<string> listaUrls = new List<string>();

    }
}
