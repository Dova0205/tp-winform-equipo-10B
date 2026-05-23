using System;
using System.Windows.Forms;
using TPWinForm_equipo_10B.Dominio;
using TPWinForm_equipo_10B.Negocio;
using TPWinForm_equipo_10B.Negocios;

namespace TPWinForm_equipo_10B.Vistas
{
    public partial class frmAdministrarMarca : Form
    {
        public frmAdministrarMarca()
        {
            InitializeComponent();
        }

        private void frmAdministrarMarca_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                dgvMarcas.DataSource = negocio.Listar();
                dgvMarcas.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al cargar las marcas: " + ex.Message);
            }
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;

                textMarca.Text = seleccionada.Descripcion;
            }
        }


        private void buttonAMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                negocio.Agregar(textMarca.Text);

                MessageBox.Show("¡Marca agregada exitosamente!");

                CargarGrid();
                textMarca.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al agregar la marca: " + ex.Message);
            }
        }

        private void buttonEMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
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
                    seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;

                    negocio.Eliminar(seleccionada.Id);

                    MessageBox.Show("Marca eliminada correctamente.");

                    CargarGrid();
                    textMarca.Clear();
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
                MessageBox.Show("Hubo un error al eliminar la marca: " + ex.Message);
            }
        }
    }
}
