using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public class CategoriasNegocio
        {
            public List<Categoria> listarCategorias()
            {
                List<Categoria> lista = new List<Categoria>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setConsulta("SELECT Descripcion, Id FROM Categorias");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Categoria aux = new Categoria();
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Id = (int)datos.Lector["Id"];

                        lista.Add(aux);
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
