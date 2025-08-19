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
        
        public void agregarCategoria(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta($"INSERT INTO CATEGORIAS (Descripcion) VALUES ('{nueva.Descripcion}')");
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarCategoria(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta($"DELETE FROM CATEGORIAS WHERE Id = {id}");
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
