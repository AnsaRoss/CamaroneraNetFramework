using CamaroneraNetFramework.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CamaroneraNetFramework.Controlador
{
    public static class ProductoControlador
    {
        public static List<Camaron> ListadoAD()
        {
            string cn = Properties.Settings.Default.CONEXION;
            List<Camaron> lista = new List<Camaron>();
            Camaron item;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(cn);
            SqlDataReader _dr;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CAMARON";
                cmd.Parameters.AddWithValue("@opcion", "LISTAR");
                cmd.Connection.Open();
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    item = new Camaron();
                    item.Id = Convert.ToInt32(_dr.IsDBNull(_dr.GetOrdinal("ID")) ? 0 : _dr["ID"]);
                    item.Nombre = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("NOMBRE")) ? "" : _dr["NOMBRE"]);
                    item.Descripcion = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("DESCRIPCION")) ? "" : _dr["DESCRIPCION"]);
                    item.Cantidad = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("CANTIDAD")) ? "" : _dr["CANTIDAD"]);

                    lista.Add(item);
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                _dr = null;

                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
                item = null;
            }
            return lista;
        }
        public static List<Camaron> ListarProductoAD()
        {
            string cn = Properties.Settings.Default.CONEXION;
            List<Camaron> lista = new List<Camaron>();
            Camaron item;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(cn);
            SqlDataReader _dr;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CAMARON";
                cmd.Parameters.AddWithValue("@opcion", "LISTAR PRODUCTO");
                cmd.Connection.Open();
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    item = new Camaron();
                    item.Id = Convert.ToInt32(_dr.IsDBNull(_dr.GetOrdinal("ID")) ? 0 : _dr["ID"]);
                    item.Nombre = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("NOMBRE")) ? "" : _dr["NOMBRE"]);

                    lista.Add(item);
                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
                _dr = null;
                item = null;
            }
            return lista;
        }
        public static Camaron ObtenerInformacionCamaronAD(int id)
        {
            string cn = Properties.Settings.Default.CONEXION;
            Camaron item = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(cn);
            SqlDataReader _dr;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CAMARON";
                cmd.Parameters.AddWithValue("@opcion", "LISTAR POR ID");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection.Open();
                _dr = cmd.ExecuteReader();
                if (_dr.Read())
                {
                    item = new Camaron();
                    item.Id = Convert.ToInt32(_dr.IsDBNull(_dr.GetOrdinal("ID")) ? 0 : _dr["ID"]);
                    item.Nombre = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("NOMBRE")) ? "" : _dr["NOMBRE"]);
                    item.Descripcion = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("DESCRIPCION")) ? "" : _dr["DESCRIPCION"]);
                    item.Cantidad = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("CANTIDAD")) ? "" : _dr["CANTIDAD"]);

                }
            }
            catch (Exception)
            {


            }
            finally
            {
                _dr = null;

                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return item;
        }
        public static string EditarAD(int id, string nombre, string descripcion, int cantidad)
        {
            string cn = Properties.Settings.Default.CONEXION;
            string Resultado = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(cn);
            SqlDataReader _dr;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.CommandText = "EDITAR";
                cmd.CommandText = "SP_CAMARON";
                cmd.Parameters.AddWithValue("@opcion", "EDITAR");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Connection.Open();
                _dr = cmd.ExecuteReader();
                if (_dr.Read())
                {
                    Resultado = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("Resultado")) ? "" : _dr["Resultado"]);

                }
            }
            catch (Exception)
            {


            }
            finally
            {
                _dr = null;

                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return Resultado;
        }
        public static string GuardarAD( string nombre, string descripcion, int cantidad)
        {
            string cn = Properties.Settings.Default.CONEXION;
            string Resultado = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(cn);
            SqlDataReader _dr;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.CommandText = "INSERTAR";
                cmd.CommandText = "SP_CAMARON";
                cmd.Parameters.AddWithValue("@opcion", "INSERTAR");
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Connection.Open();
                _dr = cmd.ExecuteReader();
                if (_dr.Read())
                {
                    Resultado = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("Resultado")) ? "" : _dr["Resultado"]);

                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                _dr = null;
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return Resultado;
        }
        public static string RegitrarSalidaAD(int id, int cantidad)
        {
            var Resultado = "";
            if (GuardarHistorialAD(id, cantidad) == 1)
            {
                Resultado = GuardarSalidaAD(id, cantidad);
            }
            return Resultado;
        }
        public static int GuardarHistorialAD(int id, int cantidad)
        {
            string cn = Properties.Settings.Default.CONEXION;
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(cn);
            SqlDataReader _dr;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_HISTORIAL";
                cmd.Parameters.AddWithValue("@opcion", "INSERTAR");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Connection.Open();
                _dr = cmd.ExecuteReader();
                if (_dr.Read())
                {
                    Resultado = Convert.ToInt32(_dr.IsDBNull(_dr.GetOrdinal("Resultado")) ? 0 : _dr["Resultado"]);

                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                _dr = null;

                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return Resultado;
        }
        public static string GuardarSalidaAD(int id, int cantidad)
        {
            string cn = Properties.Settings.Default.CONEXION;
            string Resultado = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(cn);
            SqlDataReader _dr;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CAMARON";
                cmd.Parameters.AddWithValue("@opcion", "SALIDA PRODUCTO");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Connection.Open();
                _dr = cmd.ExecuteReader();
                if (_dr.Read())
                {
                    Resultado = Convert.ToString(_dr.IsDBNull(_dr.GetOrdinal("Resultado")) ? "" : _dr["Resultado"]);

                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                _dr = null;
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return Resultado;
        }
    }
}