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

                dgvListadoArticulos.DataSource = listaArticulos.Select(a => new
                {
                    a.Id,
                    a.Codigo,
                    a.Nombre,
                    a.Descripcion,
                    Fabricante = a.Fabricante.Nombre,
                    Categoria = a.Tipo.Descripcion,
                    a.UrlImg,
                    a.Precio
                }).ToList();

                // Ocultar columna UrlImg si no querés mostrar la URL
                if (dgvListadoArticulos.Columns["UrlImg"] != null)
                    dgvListadoArticulos.Columns["UrlImg"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        // eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
