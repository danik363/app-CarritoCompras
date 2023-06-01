using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Security.Cryptography.X509Certificates;
using Negocio;
using System.Net;
using System.Collections;
using System.Security.Policy;

namespace Negocio
{
    public class ArticuloNegocio
    {
		public void modificar(Articulo articulo)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("Update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio Where Id = @IdArticulo");
				datos.setearParametros("@IdArticulo", articulo.Id);
				datos.setearParametros("@Codigo", articulo.Codigo);
				datos.setearParametros("@Nombre", articulo.Nombre);
				datos.setearParametros("@Descripcion", articulo.Descripcion);
				datos.setearParametros("@IdMarca", articulo.Marca.Id);
				datos.setearParametros("@IdCategoria", articulo.Categoria.Id);
				datos.setearParametros("@Precio", articulo.Precio);

                articulo.Imagen.IdArticulo = datos.ejecutarReturnQuery(); //Retorna el id del articulo ingresado a la tabla

                datos.cerrarConexion();

                datos.setearConsulta("Update IMAGENES Set ImagenUrl = @Imagen Where IdArticulo = @IdArt");
                datos.setearParametros("@IdArt", articulo.Id);
                datos.setearParametros("@Imagen", articulo.Imagen.Url);

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


		public List<Articulo> listarConSP()
		{
			List<Articulo> lista = new List<Articulo>();
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsultaAlmacenada("storedListar");
				datos.ejecutarConsulta();

				while (datos.Lector.Read())
				{
					Articulo aux = new Articulo();

					aux.Id = (int)datos.Lector["Id"];
					aux.Codigo = (string)datos.Lector["Codigo"];
					aux.Nombre = (string)datos.Lector["Nombre"];
					aux.Descripcion = (string)datos.Lector["Descripcion"]; //El modelo que se esta creando no necesita una validacion de null al momento de traer los datos de la db
					aux.Imagen = new Imagen();
					if (!(datos.Lector["ImagenUrl"] is DBNull))
					{
						aux.Imagen.Url = (string)datos.Lector["ImagenUrl"];//Debido a que desde el lado de la app se obliga a colocar todos los datos 
					}
					else
					{
						aux.Imagen.Url = "http://www.https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg";

					}


					aux.Marca = new Marca();
					aux.Marca.Id = (int)datos.Lector["IDMarca"];
					aux.Marca.Descripcion = (string)datos.Lector["Marca"];
					aux.Categoria = new Categoria();
					aux.Categoria.Id = (int)datos.Lector["IDCategoria"];
					aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
					aux.Precio = (decimal)datos.Lector["Precio"];

					lista.Add(aux);
				}
				return lista;
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
		public void agregar(Articulo nuevo)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio); SELECT SCOPE_IDENTITY();");
				datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
				datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@precio", nuevo.Precio);

                nuevo.Imagen.IdArticulo = datos.ejecutarReturnQuery(); //Retorna el id del articulo ingresado a la tabla
				
				datos.cerrarConexion();

				datos.setearConsulta("Insert into IMAGENES (IdArticulo, ImagenUrl) values (@articulo, @url)");
                datos.setearParametros("@articulo", nuevo.Imagen.IdArticulo);
                datos.setearParametros("@url", nuevo.Imagen.Url);

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
        public List<Articulo> listar()
        {
			List<Articulo> lista = new List<Articulo>();
            string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, I.ImagenUrl, M.Descripcion as Marca, C.Descripcion as Categoria, A.Precio, M.Id as IDMarca, C.Id as IDCategoria From ARTICULOS A Inner Join IMAGENES I ON A.Id = I.IdArticulo Inner Join MARCAS M ON A.IdMarca = M.Id Inner Join CATEGORIAS C ON A.IdCategoria = C.Id";
            AccesoDatos datos = new AccesoDatos();
            try
			{
				datos.setearConsulta(consulta);
				datos.ejecutarConsulta();

				while (datos.Lector.Read())
				{
					Articulo aux = new Articulo();

					aux.Id = (int)datos.Lector["Id"];
					aux.Codigo = (string)datos.Lector["Codigo"];
					aux.Nombre = (string)datos.Lector["Nombre"];
					aux.Descripcion = (string)datos.Lector["Descripcion"]; //El modelo que se esta creando no necesita una validacion de null al momento de traer los datos de la db
					aux.Imagen = new Imagen();
					if(!(datos.Lector["ImagenUrl"] is DBNull)){
                        aux.Imagen.Url = (string)datos.Lector["ImagenUrl"];//Debido a que desde el lado de la app se obliga a colocar todos los datos 
					}
					else
					{
						aux.Imagen.Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";

                    }
					
					
					aux.Marca = new Marca();
					aux.Marca.Id = (int)datos.Lector["IDMarca"];
					aux.Marca.Descripcion = (string)datos.Lector["Marca"];
					aux.Categoria = new Categoria();
					aux.Categoria.Id = (int)datos.Lector["IDCategoria"];
					aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
					aux.Precio = (decimal)datos.Lector["Precio"];

					lista.Add(aux);
				}
				return lista;
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

		public List<Articulo> filtrar(string codigo, string nombre, string descripcion, decimal precio)
		{
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, I.ImagenUrl, M.Descripcion as Marca, C.Descripcion as Categoria, A.Precio, M.Id as IDMarca, C.Id as IDCategoria From ARTICULOS A Inner Join IMAGENES I ON A.Id = I.IdArticulo Inner Join MARCAS M ON A.IdMarca = M.Id Inner Join CATEGORIAS C ON A.IdCategoria = C.Id";
			List<string> queryWhere = new List<string>();

            if (codigo != "")
			{
				queryWhere.Add("A.Codigo like '%" + codigo + "%'");
			}
			if(nombre != "")
			{
				queryWhere.Add("A.Nombre like '%" + nombre + "%'");
            }
            if (descripcion != "")
            {
				queryWhere.Add("A.Descripcion like '%" + descripcion + "%'");
            }
            if (precio != 0)
			{
                
                queryWhere.Add("A.Precio = CAST(REPLACE('"+precio+"', ',', '.') AS money)"); 
			}
			if(queryWhere.Count > 0)
			{
				consulta += " where ";
                consulta += string.Join(" And ", queryWhere);
            }
			Console.WriteLine(consulta);
			
            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"]; //El modelo que se esta creando no necesita una validacion de null al momento de traer los datos de la db
                    aux.Imagen = new Imagen();
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.Imagen.Url = (string)datos.Lector["ImagenUrl"];//Debido a que desde el lado de la app se obliga a colocar todos los datos 
                    }
                    else
                    {
                        aux.Imagen.Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";

                    }


                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IDMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IDCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }
                return lista;
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
		
		public void eliminar (int Id)
		{
			try
			{
				AccesoDatos datos = new AccesoDatos();
				datos.setearConsulta("delete from articulos where id = @id");
				datos.setearParametros("@id", Id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}

}
