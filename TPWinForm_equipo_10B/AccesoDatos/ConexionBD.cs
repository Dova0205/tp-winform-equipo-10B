using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TPWinForm_equipo_10B.AccesoDatos
{
    public class ConexionBD
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public ConexionBD()
        {
            //Asegurate de que ".\\SQLEXPRESS" sea el nombre de tu servidor local
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void SetearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void EjecutarLectura()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EjecutarAccion()
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader Lector => lector;

        public void CerrarConexion()
        {
            if (lector != null) lector.Close();
            conexion.Close();
        }
    }
}
