using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class RecuperadoNegocio
    {
        public List<Articulo> listaRecuperar()
        {
            List<Articulo> listaRecuperados = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT A.Id, Codigo, Nombre, A.Descripcion, IdCategoria, IdMarca, ImagenUrl, Precio, " +
                                  "M.Descripcion Marca, C.Descripcion Categoria " +
                                  "FROM ARTICULOS A " +
                                  "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                                  "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id " +
                                  "WHERE CODIGO LIKE '%(BAJA)%'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo auxiliar = new Articulo();

                    auxiliar.Id = (int)datos.Lector["Id"];
                    auxiliar.Codigo = Convert.ToString(datos.Lector["Codigo"]);
                    auxiliar.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    auxiliar.Descripcion = datos.Lector["Descripcion"] is DBNull ? "" : Convert.ToString(datos.Lector["Descripcion"]);

                    auxiliar.Fabricante = new Marca();
                    auxiliar.Fabricante.Id = (int)datos.Lector["IdMarca"];
                    auxiliar.Fabricante.Nombre = Convert.ToString(datos.Lector["Marca"]);

                    auxiliar.Tipo = new Categoria();
                    auxiliar.Tipo.Id = (int)datos.Lector["IdCategoria"];
                    auxiliar.Tipo.Descripcion = Convert.ToString(datos.Lector["Categoria"]);

                    auxiliar.UrlImg = datos.Lector["ImagenUrl"] is DBNull ? "" : Convert.ToString(datos.Lector["ImagenUrl"]);
                    auxiliar.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);

                    listaRecuperados.Add(auxiliar);
                }

                return listaRecuperados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void restaurarRegistro(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("UPDATE ARTICULOS " +
                                  "SET Codigo = REPLACE(Codigo, '(BAJA)', '') " +
                                  $"WHERE Id = {id}");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }



}
