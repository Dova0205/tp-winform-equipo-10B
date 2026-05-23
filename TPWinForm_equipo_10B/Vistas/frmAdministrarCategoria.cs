using System;
using System.Windows.Forms;
using TPWinForm_equipo_10B.Dominio;
using TPWinForm_equipo_10B.Negocio;

namespace TPWinForm_equipo_10B.Vistas
{
    public partial class frmAdministrarCategoria : Form
    {
        public frmAdministrarCategoria()
        {
            InitializeComponent();
        }

        private void frmAdministrarCategoria_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                dgvCategorias.DataSource = negocio.Listar();
                dgvCategorias.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al cargar las marcas: " + ex.Message);
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // evita cabeceras
            var row = dgvCategorias.Rows[e.RowIndex];
            if (row?.DataBoundItem is Categoria seleccionada)
            {
                textCategoria.Text = seleccionada.Descripcion;
            }
        }

        private void textCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonACategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                negocio.Agregar(textCategoria.Text);

                MessageBox.Show("¡Marca agregada exitosamente!");

                CargarGrid();
                textCategoria.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al agregar la marca: " + ex.Message);
            }
        }

        private void buttonECategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Marca seleccionada;

            try
            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Seguro que desea eliminar la marca seleccionada?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    seleccionada = (Marca)dgvCategorias.CurrentRow.DataBoundItem;

                    negocio.Eliminar(seleccionada.Id);

                    MessageBox.Show("Marca eliminada correctamente.");

                    CargarGrid();
                    textCategoria.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al eliminar la marca: " + ex.Message);
            }
        }
    }
}
