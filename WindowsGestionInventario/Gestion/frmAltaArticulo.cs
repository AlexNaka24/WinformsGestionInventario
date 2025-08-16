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
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();

            TemaColores.elegirTema("Naranja");
            this.BackColor = TemaColores.PanelPadre;

            this.lblCodigo.BackColor = TemaColores.PanelPadre;
            this.lblCodigo.ForeColor = TemaColores.FuenteIconos;
            this.lblNombre.BackColor = TemaColores.PanelPadre;
            this.lblNombre.ForeColor = TemaColores.FuenteIconos;
            this.lblDescripcion.BackColor = TemaColores.PanelPadre;
            this.lblDescripcion.ForeColor = TemaColores.FuenteIconos;
            this.lblMarca.BackColor = TemaColores.PanelPadre;
            this.lblMarca.ForeColor = TemaColores.FuenteIconos;
            this.lblCategoria.BackColor = TemaColores.PanelPadre;
            this.lblCategoria.ForeColor = TemaColores.FuenteIconos;
            this.lblUrl.BackColor = TemaColores.PanelPadre;
            this.lblUrl.ForeColor = TemaColores.FuenteIconos;
            this.lblPrecio.BackColor = TemaColores.PanelPadre;
            this.lblPrecio.ForeColor = TemaColores.FuenteIconos;

            btnAceptar.BackColor = TemaColores.PanelBotones;
            btnAceptar.ForeColor = TemaColores.FuenteIconos;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;

            btnCancelar.BackColor = TemaColores.PanelBotones;
            btnCancelar.ForeColor = TemaColores.FuenteIconos;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseOverBackColor = TemaColores.PanelBotones;
        }

        // metodos

        private void cargarImagen(string url)
        {
            try
            {
                pbxUrl.Load(url);
            }
            catch
            {
                pbxUrl.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"); // imagen por defecto
            }
        }



        // eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.UrlImg = txtUrl.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Fabricante = (Marca)cboMarca.SelectedItem;
                articulo.Tipo = (Categoria)cboCategoria.SelectedItem;

                if (string.IsNullOrWhiteSpace(articulo.Codigo) || string.IsNullOrWhiteSpace(articulo.Nombre) ||
                    string.IsNullOrWhiteSpace(articulo.Descripcion) || string.IsNullOrWhiteSpace(articulo.UrlImg) ||
                    articulo.Precio <= 0 || articulo.Fabricante == null || articulo.Tipo == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

                articuloNegocio.agregarArticulo(articulo);
                MessageBox.Show("Artículo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el artículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            btnAceptar.Cursor = Cursors.Hand;
            btnCancelar.Cursor = Cursors.Hand;

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcasNegocio marcaNegocio = new MarcasNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.listarMarcas();
                cboCategoria.DataSource = categoriaNegocio.listarCategorias();

                cboCategoria.DataSource = categoriaNegocio.listarCategorias();
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.ValueMember = "Id";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrl.Text);
        }
    }
}
