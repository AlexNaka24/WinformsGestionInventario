using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Fabricante { get; set; }
        public Categoria Tipo { get; set; }
        public string UrlImg { get; set; }

        public decimal Precio { get; set; }
    }
}
