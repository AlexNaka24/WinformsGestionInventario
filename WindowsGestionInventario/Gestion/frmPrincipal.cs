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
    public partial class frmPrincipal : Form
    {
        private List<Articulo> listaArticulos;

        public frmPrincipal()
        {
            InitializeComponent();

            this.Width = 900;
            this.Height = 600;

            TemaColores.elegirTema("Naranja");

            Panel panelIzq = new Panel();         
            panelIzq.Dock = DockStyle.Left;
            panelIzq.Width = this.ClientSize.Width / 4;
            panelIzq.BackColor = TemaColores.PanelPadre;

            Panel panelDer = new Panel();
            panelDer.Dock = DockStyle.Right;
            panelDer.Width = this.ClientSize.Width / 4;
            panelDer.BackColor = TemaColores.PanelPadre;

            Panel panelCentro = new Panel();
            panelCentro.Dock = DockStyle.Fill;
            panelCentro.BackColor = TemaColores.PanelBotones;

            this.Controls.Add(panelCentro);
            this.Controls.Add(panelDer);
            this.Controls.Add(panelIzq);

            btnNuevoArticulo.BackColor = TemaColores.PanelBotones;
            btnNuevoArticulo.ForeColor = TemaColores.FuenteIconos;
            btnNuevoArticulo.FlatStyle = FlatStyle.Flat;
            btnNuevoArticulo.FlatAppearance.BorderSize = 0;
            btnNuevoArticulo.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;

            btnModificar.BackColor = TemaColores.PanelBotones;
            btnModificar.ForeColor = TemaColores.FuenteIconos;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;

            btnEliminar.BackColor = TemaColores.PanelBotones;
            btnEliminar.ForeColor = TemaColores.FuenteIconos;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;

            btnCerrar.BackColor = TemaColores.PanelBotones;
            btnCerrar.ForeColor = TemaColores.FuenteIconos;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;

            lblFiltro.BackColor = TemaColores.PanelBotones;
            lblFiltro.ForeColor = TemaColores.FuenteIconos;

            lblCampo.BackColor = TemaColores.PanelBotones;
            lblCampo.ForeColor = TemaColores.FuenteIconos;

            lblCriterio.BackColor = TemaColores.PanelBotones;
            lblCriterio.ForeColor = TemaColores.FuenteIconos;

            lblFiltroAvanzado.BackColor = TemaColores.PanelBotones;
            lblFiltroAvanzado.ForeColor = TemaColores.FuenteIconos;

            btnBuscar.BackColor = TemaColores.PanelBotones;
            btnBuscar.ForeColor = TemaColores.FuenteIconos;

            btnLimpiar.ForeColor = TemaColores.FuenteIconos;
            btnLimpiar.BackColor = TemaColores.PanelBotones;

            btnRecuperar.BackColor = TemaColores.PanelBotones;
            btnRecuperar.ForeColor = TemaColores.FuenteIconos;
        }

        // metodos

        private void cargarDatos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaArticulos = negocio.listarArticulos();

                dgvListadoArticulos.AutoGenerateColumns = true;
                dgvListadoArticulos.DataSource = null;
                dgvListadoArticulos.DataSource = listaArticulos;

                // Ocultar columnas que no quieras mostrar
                if (dgvListadoArticulos.Columns["UrlImg"] != null)
                    dgvListadoArticulos.Columns["UrlImg"].Visible = false;
                if (dgvListadoArticulos.Columns["Tipo"] != null)
                    dgvListadoArticulos.Columns["Tipo"].Visible = false;

                // Mostrar la primera imagen si hay datos
                if (listaArticulos.Count > 0)
                    cargarImagen(listaArticulos[0].UrlImg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbxImagenArticulo.Load(url);
            }
            catch
            {
                pbxImagenArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"); // imagen por defecto
            }
        }

        // eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Fabricante");
            cboCampo.SelectedIndex = 0; // Seleccionar el primer campo por defecto

            btnNuevoArticulo.Cursor = Cursors.Hand;
            btnModificar.Cursor = Cursors.Hand;
            btnEliminar.Cursor = Cursors.Hand;
            btnCerrar.Cursor = Cursors.Hand;
            btnBuscar.Cursor = Cursors.Hand;
            btnLimpiar.Cursor = Cursors.Hand;
            btnRecuperar.Cursor = Cursors.Hand;
        }

        private void dgvListadoArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListadoArticulos.SelectedRows.Count > 0)
            {
                var articuloSeleccionado = (Articulo)dgvListadoArticulos.SelectedRows[0].DataBoundItem;
                cargarImagen(articuloSeleccionado.UrlImg);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saliendo de la aplicación, gracias!");
            this.Close();
        }

        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo frmAltaArticulo = new frmAltaArticulo();
            frmAltaArticulo.ShowDialog();
            cargarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo frmModificar = new frmAltaArticulo(seleccionado);
            frmModificar.ShowDialog();
            cargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articuloSeleccionado;
            try
            {
                DialogResult resultado = MessageBox.Show("¿Seguro quieres eliminar este articulo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    articuloSeleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;
                    articuloNegocio.eliminarArticulo(articuloSeleccionado);
                    cargarDatos();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro != "")
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                x.Fabricante.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvListadoArticulos.DataSource = null;
            dgvListadoArticulos.DataSource = listaFiltrada;

            if (dgvListadoArticulos.Columns["UrlImg"] != null)
                dgvListadoArticulos.Columns["UrlImg"].Visible = false;
            if (dgvListadoArticulos.Columns["Tipo"] != null)
                dgvListadoArticulos.Columns["Tipo"].Visible = false;
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            txtFiltro.Enabled = true; // siempre habilitado para texto y precio
            txtFiltro.Text = "";

            cboCriterio.Items.Clear();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
            }
            else // Nombre o Descripción
            {
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }

            cboCriterio.SelectedIndex = 0; // seleccionar el primer criterio por defecto
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string campo = cboCampo.SelectedItem?.ToString() ?? "";
            string criterio = cboCriterio.SelectedItem?.ToString() ?? "";
            string filtro = txtFiltro.Text.Trim();

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvListadoArticulos.DataSource = null; // limpiar antes de asignar
                dgvListadoArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                if (dgvListadoArticulos.Columns["UrlImg"] != null)
                    dgvListadoArticulos.Columns["UrlImg"].Visible = false;
                if (dgvListadoArticulos.Columns["Tipo"] != null)
                    dgvListadoArticulos.Columns["Tipo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            frmRecuperar frmRecuperar = new frmRecuperar();
            frmRecuperar.ShowDialog();
            cargarDatos();
        }
    }
}
