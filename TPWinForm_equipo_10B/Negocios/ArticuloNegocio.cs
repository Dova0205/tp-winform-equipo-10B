using System;
using System.Collections.Generic;
using TPWinForm_equipo_10B.AccesoDatos;
using TPWinForm_equipo_10B.Dominio;

namespace TPWinForm_equipo_10B.Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionBD datos = new ConexionBD();

            try
            {
                string query = @"SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, 
                                        m.Id AS IdMarca, m.Descripcion AS MarcaDesc, 
                                        c.Id AS IdCategoria, c.Descripcion AS CatDesc 
                                        FROM ARTICULOS a 
                                        LEFT JOIN MARCAS m ON a.IdMarca = m.Id 
                                        LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id";

                datos.SetearConsulta(query);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    ImagenNegocio imagenNegocio = new ImagenNegocio();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagenes = imagenNegocio.ListarPorArticulo(aux.Id);
                    // Si la lista de imágenes trajo al menos una foto...
                    if (aux.Imagenes != null && aux.Imagenes.Count > 0)
                    {
                        // copiamos la URL de la primera foto a la propiedad principal del artículo
                        aux.ImagenUrl = aux.Imagenes[0].ImagenUrl;
                    }
                    else
                    {
                        // Si no tiene foto, le ponemos un texto para saberlo o lo dejamos vacío
                        aux.ImagenUrl = "";
                    }

                    // --- ESCUDO ANTI-NULL PARA LA MARCA ---
                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                    {
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    }
                    if (!(datos.Lector["MarcaDesc"] is DBNull))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["MarcaDesc"];
                    }

                    // --- ESCUDO ANTI-NULL PARA LA CATEGORIA ---
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    if (!(datos.Lector["CatDesc"] is DBNull))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["CatDesc"];
                    }

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
                datos.CerrarConexion();
            }
        }

        public void Agregar(Articulo nuevo)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.SetearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@codigo, @nombre, @desc, @idMarca, @idCat, @precio)");
                datos.SetearParametro("@codigo", nuevo.Codigo);
                datos.SetearParametro("@nombre", nuevo.Nombre);
                datos.SetearParametro("@desc", nuevo.Descripcion);
                datos.SetearParametro("@idMarca", nuevo.Marca.Id);
                datos.SetearParametro("@idCat", nuevo.Categoria.Id);
                datos.SetearParametro("@precio", nuevo.Precio);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(Articulo modificar)
        {
            // --- ACTUALIZAR EL ARTÍCULO ---
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.SetearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCat, Precio = @precio WHERE Id = @id");
                datos.SetearParametro("@codigo", modificar.Codigo);
                datos.SetearParametro("@nombre", modificar.Nombre);
                datos.SetearParametro("@desc", modificar.Descripcion);
                datos.SetearParametro("@idMarca", modificar.Marca != null ? (object)modificar.Marca.Id : DBNull.Value);
                datos.SetearParametro("@idCat", modificar.Categoria != null ? (object)modificar.Categoria.Id : DBNull.Value);
                datos.SetearParametro("@precio", modificar.Precio);
                datos.SetearParametro("@id", modificar.Id);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            // --- ACTUALIZAR LA IMAGEN ---
            ConexionBD datosImg = new ConexionBD();
            try
            {
                // Borramos la imagen vinculada a este artículo e insertamos la nueva
                datosImg.SetearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @idArt; INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArt, @url)");
                datosImg.SetearParametro("@idArt", modificar.Id);
                datosImg.SetearParametro("@url", modificar.ImagenUrl);

                datosImg.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosImg.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.SetearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @id; DELETE FROM ARTICULOS WHERE Id = @id;");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
