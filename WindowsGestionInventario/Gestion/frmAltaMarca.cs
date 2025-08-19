using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Gestion
{
    public partial class frmAltaMarca : Form
    {
        private List<Marca> listaMarcas;
        private Marca marca;

        public frmAltaMarca()
        {
            InitializeComponent();

            this.Text = "Marcas";
            TemaColores.elegirTema("Naranja");
            this.BackColor = TemaColores.PanelPadre;

            this.lblMarca.BackColor = TemaColores.PanelPadre;
            this.lblMarca.ForeColor = TemaColores.FuenteIconos;

            btnAgregar.BackColor = TemaColores.PanelBotones;
            btnAgregar.ForeColor = TemaColores.FuenteIconos;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;
            btnVolver.BackColor = TemaColores.PanelBotones;
            btnVolver.ForeColor = TemaColores.FuenteIconos;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;
            btnEliminar.BackColor = TemaColores.PanelBotones;
            btnEliminar.ForeColor = TemaColores.FuenteIconos;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;
        }

        // metodos

        public void cargarDatos()
        {
            MarcasNegocio marcasNegocio = new MarcasNegocio();

            try
            {
                listaMarcas = marcasNegocio.listarMarcas();

                dgvMarcas.AutoGenerateColumns = true;
                dgvMarcas.DataSource = null;
                dgvMarcas.DataSource = listaMarcas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // eventos

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {
            this.btnAgregar.Cursor = Cursors.Hand;
            this.btnVolver.Cursor = Cursors.Hand;
            this.btnEliminar.Cursor = Cursors.Hand;

            cargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MarcasNegocio marcasNegocio = new MarcasNegocio();
            marca = new Marca();

            try
            {
                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (marcasNegocio.listarMarcas().Any(a => a.Nombre == marca.Nombre))
                {
                    MessageBox.Show("Ya existe una marca con el mismo nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    marca.Nombre = txtMarca.Text;
                    marcasNegocio.agregarMarca(marca);
                    MessageBox.Show("Marca agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MarcasNegocio marcasNegocio = new MarcasNegocio();
            Marca marcaSeleccionada;
            try
            {
                DialogResult resultado = MessageBox.Show("¿Seguro quieres eliminar esta marca?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    marcaSeleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                    marcasNegocio.eliminarMarca(marcaSeleccionada.Nombre);
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
