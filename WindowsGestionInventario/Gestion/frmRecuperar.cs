using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion
{
    public partial class frmRecuperar : Form
    {
        private List<Articulo> listaRecuperados = null;   

        public frmRecuperar()
        {
            InitializeComponent();

            TemaColores.elegirTema("Naranja");

            this.BackColor = TemaColores.PanelPadre;

            this.lblFiltro.BackColor = TemaColores.PanelPadre;
            this.lblFiltro.ForeColor = TemaColores.FuenteIconos;

            this.btnRecuperar.BackColor = TemaColores.PanelBotones;
            this.btnRecuperar.ForeColor = TemaColores.FuenteIconos;

            this.btnCerrar.BackColor = TemaColores.PanelBotones;
            this.btnCerrar.ForeColor = TemaColores.FuenteIconos;
        }

        private void cargarDatos()
        {
            RecuperadoNegocio recuperadoNegocio = new RecuperadoNegocio();

            try
            {
                listaRecuperados = recuperadoNegocio.listaRecuperar();

                dgvRecuperar.AutoGenerateColumns = true;
                dgvRecuperar.DataSource = null;
                dgvRecuperar.DataSource = listaRecuperados;

                // Ocultar columnas que no quieras mostrar
                if (dgvRecuperar.Columns["UrlImg"] != null)
                    dgvRecuperar.Columns["UrlImg"].Visible = false;
                if (dgvRecuperar.Columns["Tipo"] != null)
                    dgvRecuperar.Columns["Tipo"].Visible = false;

                // Mostrar la primera imagen si hay datos
                if (listaRecuperados.Count > 0)
                    cargarImagen(listaRecuperados[0].UrlImg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarImagen(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    pbxRecuperar.Load(url);
                }
                else
                {
                    pbxRecuperar.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"); // imagen por defecto // Si no hay URL, limpiar la imagen
                }
            }
            catch (Exception)
            {
                pbxRecuperar.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"); // imagen por defecto
            }
        }

        private void frmRecuperar_Load(object sender, EventArgs e)
        {
            cargarDatos();

            btnRecuperar.Cursor = Cursors.Hand;
            btnCerrar.Cursor = Cursors.Hand;
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            RecuperadoNegocio articuloNegocio = new RecuperadoNegocio();
            Articulo articuloSeleccionado = new Articulo();

            try
            {
                DialogResult resultado = MessageBox.Show("¿Seguro quieres restaurar este articulo?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    articuloSeleccionado = (Articulo)dgvRecuperar.CurrentRow.DataBoundItem;
                    articuloNegocio.restaurarRegistro(articuloSeleccionado.Id);
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
                listaFiltrada = listaRecuperados.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                x.Fabricante.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaRecuperados;
            }

            dgvRecuperar.DataSource = null;
            dgvRecuperar.DataSource = listaFiltrada;

            if (dgvRecuperar.Columns["UrlImg"] != null)
                dgvRecuperar.Columns["UrlImg"].Visible = false;
            if (dgvRecuperar.Columns["Tipo"] != null)
                dgvRecuperar.Columns["Tipo"].Visible = false;
        }

        private void dgvRecuperar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecuperar.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvRecuperar.CurrentRow.DataBoundItem;
                if (seleccionado != null)
                    cargarImagen(seleccionado.UrlImg);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
