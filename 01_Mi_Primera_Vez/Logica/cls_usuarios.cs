using _01_Mi_Primera_Vez.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Mi_Primera_Vez.Logica
{
    internal class cls_usuarios
    {
        private readonly conexion con = new conexion();
        public bool insertar(dto_usuarios user)
        {
            using (SqlConnection connection = con.obtenerConexion())
            {
                SqlCommand command = new SqlCommand("sp_InsertarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Cedula", user.Cedula);
                command.Parameters.AddWithValue("@Nombres", user.Nombres);
                command.Parameters.AddWithValue("@Direccion", user.Direccion);
                command.Parameters.AddWithValue("@Telefono", user.Telefono);
                command.Parameters.AddWithValue("@idPais", user.idPais);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar: " + ex.Message);
                    return false;
                }
            }
        }

        public bool modificar(dto_usuarios user)
        {
            using (SqlConnection connection = con.obtenerConexion())
            {
                SqlCommand command = new SqlCommand("sp_ModificarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idUsuario", user.idUsuario);
                command.Parameters.AddWithValue("@Cedula", user.Cedula);
                command.Parameters.AddWithValue("@Nombres", user.Nombres);
                command.Parameters.AddWithValue("@Direccion", user.Direccion);
                command.Parameters.AddWithValue("@Telefono", user.Telefono);
                command.Parameters.AddWithValue("@idPais", user.idPais);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al modificar: " + ex.Message);
                    return false;
                }
            }
        }

        public List<dto_usuarios> Leer()
        {
            List<dto_usuarios> usuarios = new List<dto_usuarios>();
            using (SqlConnection connection = con.obtenerConexion())
            {
                SqlCommand command = new SqlCommand("sp_LeerUsuarios", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dto_usuarios user = new dto_usuarios
                        {
                            idUsuario = (int)reader["idUsuario"],
                            Cedula = reader["Cedula"].ToString(),
                            Nombres = reader["Nombres"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            idPais = (int)reader["idPais"]
                        };
                        usuarios.Add(user);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer: " + ex.Message);
                }
            }
            return usuarios;
        }

        public bool eliminar(int idUsuario)
        {
            using (SqlConnection connection = con.obtenerConexion())
            {
                SqlCommand command = new SqlCommand("sp_EliminarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
