using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    public static class TemaColores
    {
        public static Color PanelPadre;
        public static Color PanelBotones;
        public static Color BarraTitulo;
        public static Color TextBusqueda;
        public static Color FuenteIconos;

        private static readonly Color PanelPadreN = Color.FromArgb(51, 35, 3);
        private static readonly Color PanelBotonesN = Color.FromArgb(99, 68, 6);
        private static readonly Color BarraTituloN = Color.FromArgb(125, 85, 4);
        private static readonly Color TextBusquedaN = Color.FromArgb(181, 124, 11);
        private static readonly Color FuenteIconosN = Color.White;

        public static void elegirTema(string tema)
        {
            if (tema == "Naranja")
            {
                PanelPadre = PanelPadreN;
                PanelBotones = PanelBotonesN;
                BarraTitulo = BarraTituloN;
                TextBusqueda = TextBusquedaN;
                FuenteIconos = FuenteIconosN;
            }
        }
    }
}
