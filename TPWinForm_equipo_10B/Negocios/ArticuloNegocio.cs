using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
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
                                 INNER JOIN MARCAS m ON a.IdMarca = m.Id 
                                 INNER JOIN CATEGORIAS c ON a.IdCategoria = c.Id";

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
                    //aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Imagenes = imagenNegocio.ListarPorArticulo(aux.Id);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["MarcaDesc"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["CatDesc"];

                   


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
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.SetearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCat, Precio = @precio WHERE Id = @id");
                datos.SetearParametro("@codigo", modificar.Codigo);
                datos.SetearParametro("@nombre", modificar.Nombre);
                datos.SetearParametro("@desc", modificar.Descripcion);
                datos.SetearParametro("@idMarca", modificar.Marca.Id);
                datos.SetearParametro("@idCat", modificar.Categoria.Id);
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
