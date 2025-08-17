using dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace negocio
{
    public class ArticuloNegocio
    {
        // listar

        public List<Articulo> listarArticulos()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"
                    SELECT A.Id, Codigo, Nombre, A.Descripcion, IdCategoria, IdMarca, ImagenUrl, Precio, 
                    M.Descripcion Marca, C.Descripcion Categoria
                    FROM ARTICULOS A
                    INNER JOIN MARCAS M ON A.IdMarca = M.Id
                    INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                    WHERE CODIGO NOT LIKE '%(BAJA)%'
                ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo auxiliar = new Articulo();

                    // Verificación de DBNull
                    auxiliar.Id = datos.Lector["Id"] != DBNull.Value ? (int)datos.Lector["Id"] : 0;
                    auxiliar.Codigo = datos.Lector["Codigo"] != DBNull.Value ? (string)datos.Lector["Codigo"] : "";
                    auxiliar.Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : "";
                    auxiliar.Descripcion = datos.Lector["Descripcion"] != DBNull.Value ? (string)datos.Lector["Descripcion"] : "";

                    auxiliar.Fabricante = new Marca();
                    auxiliar.Fabricante.Id = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0;
                    auxiliar.Fabricante.Nombre = datos.Lector["Marca"] != DBNull.Value ? (string)datos.Lector["Marca"] : "";

                    auxiliar.Tipo = new Categoria();
                    auxiliar.Tipo.Id = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0;
                    auxiliar.Tipo.Descripcion = datos.Lector["Categoria"] != DBNull.Value ? (string)datos.Lector["Categoria"] : "";

                    auxiliar.UrlImg = datos.Lector["ImagenUrl"] != DBNull.Value ? (string)datos.Lector["ImagenUrl"] : "";
                    auxiliar.Precio = datos.Lector["Precio"] != DBNull.Value ? Math.Round((decimal)datos.Lector["Precio"], 2) : 0;

                    listaArticulos.Add(auxiliar);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaArticulos;
        }


        // agregar

        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta($"Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdCategoria, IdMarca, ImagenUrl, Precio) values ('{nuevo.Codigo}', '{nuevo.Nombre}','{nuevo.Descripcion}', {nuevo.Tipo.Id},{nuevo.Fabricante.Id},'{nuevo.UrlImg}',{nuevo.Precio.ToString(new CultureInfo("en-US"))})");
                datos.ejecutarLectura();
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

        // modificar

        public void modificarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta($"update ARTICULOS set Codigo = '{articulo.Codigo}', Nombre = '{articulo.Nombre}', Descripcion = '{articulo.Descripcion}', ImagenUrl = '{articulo.UrlImg}', Precio = @precio, IdCategoria = {articulo.Tipo.Id}, IdMarca = {articulo.Fabricante.Id} where Id = {articulo.Id}");
                datos.setParams("precio", articulo.Precio);
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

        // eliminar

        public void eliminarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta($"update ARTICULOS set Codigo = '{articulo.Codigo} (BAJA)' where Id = {articulo.Id}");
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

        // filtrar







    }
}