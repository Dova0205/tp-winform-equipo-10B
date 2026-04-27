using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPWinForm_equipo_10B.Dominio;
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


        private void dgvMarcas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

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
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al eliminar la marca: " + ex.Message);
            }
        }
    }
}
