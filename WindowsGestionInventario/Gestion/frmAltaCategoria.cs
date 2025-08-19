using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion
{
    public partial class frmAltaCategoria : Form
    {
        private List<Categoria> listaCategorias;
        private Categoria categoria;

        public frmAltaCategoria()
        {
            InitializeComponent();

            TemaColores.elegirTema("Naranja");
            this.BackColor = TemaColores.PanelPadre;
            this.lblCategoria.BackColor = TemaColores.PanelPadre;
            this.lblCategoria.ForeColor = TemaColores.FuenteIconos;
            btnAgregar.BackColor = TemaColores.PanelBotones;
            btnAgregar.ForeColor = TemaColores.FuenteIconos;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;
            btnVolver.BackColor = TemaColores.PanelBotones;
            btnVolver.ForeColor = TemaColores.FuenteIconos;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;
            btnEliminar.BackColor = TemaColores.PanelBotones;
            btnEliminar.ForeColor = TemaColores.FuenteIconos;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;
        }

        // metodos

        public void cargarDatos()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                listaCategorias = categoriaNegocio.listarCategorias();

                dgvCategorias.AutoGenerateColumns = true;
                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = listaCategorias;

                if (dgvCategorias.Columns["Nombre"] != null)
                    dgvCategorias.Columns["Nombre"].Visible = false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // eventos

        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {
            btnAgregar.Cursor = Cursors.Hand;
            btnVolver.Cursor = Cursors.Hand;
            btnEliminar.Cursor = Cursors.Hand;

            cargarDatos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            categoria = new Categoria();

            try
            {
                if (string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para la categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (categoriaNegocio.listarCategorias().Any(a => a.Descripcion == categoria.Descripcion))
                {
                    MessageBox.Show("Ya existe una categoria con el mismo id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    categoria.Descripcion = txtCategoria.Text;
                    categoriaNegocio.agregarCategoria(categoria);
                    MessageBox.Show("Categoria agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria categoriaSeleccionada;
            try
            {
                DialogResult resultado = MessageBox.Show("¿Seguro quieres eliminar esta categoria?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    categoriaSeleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    categoriaNegocio.eliminarCategoria(categoriaSeleccionada.Id);
                    cargarDatos();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
