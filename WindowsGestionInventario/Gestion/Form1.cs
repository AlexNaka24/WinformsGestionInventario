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
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulos;

        public Form1()
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

            btnNuevoArticulo.Cursor = Cursors.Hand;
            btnModificar.Cursor = Cursors.Hand;
            btnEliminar.Cursor = Cursors.Hand;
            btnCerrar.Cursor = Cursors.Hand;
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
    }
}
