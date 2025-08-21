using dominio;
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
    public partial class frmDetalles : Form
    {
        private Articulo articulo = null;

        public frmDetalles()
        {
            InitializeComponent();
            TemaColores.elegirTema("Naranja");
            this.BackColor = TemaColores.PanelPadre;
        }

        public frmDetalles(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            TemaColores.elegirTema("Naranja");
            this.BackColor = TemaColores.PanelPadre;
        }

        // metodos

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {

                pbxImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        // eventos

        private void frmDetalles_Load(object sender, EventArgs e)
        {
            if (articulo == null)
            {
                MessageBox.Show("No hay artículo seleccionado.");
                this.Close();
                return;
            }

            lblNombre.Text = articulo.Nombre;
            lblCodigo.Text = "Código: " + articulo.Codigo;
            lblMarca.Text = "Marca: " + articulo.Fabricante.Nombre;
            lblCategoria.Text = "Categoría: " + articulo.Tipo.Descripcion;
            lblPrecio.Text = "Precio: " + articulo.Precio.ToString("C");
            lblDescripcion.Text = articulo.Descripcion;

            cargarImagen(articulo.UrlImg);
        }
    }
}
