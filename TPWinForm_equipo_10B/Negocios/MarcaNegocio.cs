using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWinForm_equipo_10B.AccesoDatos;
using TPWinForm_equipo_10B.Dominio;

namespace TPWinForm_equipo_10B.Negocios
{
    internal class MarcaNegocio
    {

        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

    }
}
