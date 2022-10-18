using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        public Usuario()
        {
            Id = 0;
            Nombre = String.Empty;
            Apellido = String.Empty;
            NombreUsuario = String.Empty;
            Contraseña = String.Empty;
            Mail = String.Empty;

        }
        public Usuario traerUsuario(string Username)
        {
   
            var query = @"SELECT * FROM usuario where NombreUsuario = @Username";
            string connectionString = "Server=AgusPC; Database=SistemaGestion;Trusted_Connection=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Username";
                    parametro.SqlDbType = SqlDbType.VarChar;
                    parametro.Value = Username;
                    comando.Parameters.Add(parametro);

                    connection.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            var usuario = new Usuario();

                            usuario.Id = Convert.ToInt32(dr.GetValue(0));
                            usuario.Nombre = dr.GetValue(1).ToString();
                            usuario.Apellido = dr.GetValue(2).ToString();
                            usuario.NombreUsuario = dr.GetValue(3).ToString();
                            usuario.Contraseña = dr.GetValue(4).ToString();
                            usuario.Mail = dr.GetValue(5).ToString();

                            

                            Console.WriteLine("id = " + usuario.Id);
                            Console.WriteLine("Nombre = " + usuario.Nombre);
                            Console.WriteLine("Apellido = " + usuario.Apellido);
                            Console.WriteLine("Nombre de Usuario = " + usuario.NombreUsuario);
                            Console.WriteLine("Contraseña = " + usuario.Contraseña);
                            Console.WriteLine("Mail = " + usuario.Mail);
                            Console.WriteLine("--------------");

                            return usuario;
                        }
                        else
                        {
                            Usuario usuario = new Usuario();
                            Console.WriteLine("El usuario ingresado no existe.");
                            return usuario;
                        }
                    }
                }
            }
            
        }

        public Usuario InicioSesion(string Username, string pass)
        {

            var query = @"SELECT * FROM usuario where NombreUsuario = @Username AND Contraseña = @pass";
            string connectionString = "Server=AgusPC; Database=SistemaGestion;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Username";
                    parametro.SqlDbType = SqlDbType.VarChar;
                    parametro.Value = Username;
                    comando.Parameters.Add(parametro);

                    var parametro2 = new SqlParameter();
                    parametro2.ParameterName = "pass";
                    parametro2.SqlDbType = SqlDbType.VarChar;
                    parametro2.Value = pass;
                    comando.Parameters.Add(parametro2);

                    connection.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            var usuario = new Usuario();

                            usuario.Id = Convert.ToInt32(dr.GetValue(0));
                            usuario.Nombre = dr.GetValue(1).ToString();
                            usuario.Apellido = dr.GetValue(2).ToString();
                            usuario.NombreUsuario = dr.GetValue(3).ToString();
                            usuario.Contraseña = dr.GetValue(4).ToString();
                            usuario.Mail = dr.GetValue(5).ToString();

                            Console.WriteLine("id = " + usuario.Id);
                            Console.WriteLine("Nombre = " + usuario.Nombre);
                            Console.WriteLine("Apellido = " + usuario.Apellido);
                            Console.WriteLine("Nombre de Usuario = " + usuario.NombreUsuario);
                            Console.WriteLine("Contraseña = " + usuario.Contraseña);
                            Console.WriteLine("Mail = " + usuario.Mail);
                            Console.WriteLine("--------------");

                            return usuario;
                            
                        }
                        else
                        {
                            var usuario = new Usuario();

                            Console.WriteLine("id = " + usuario.Id);
                            Console.WriteLine("Nombre = " + usuario.Nombre);
                            Console.WriteLine("Apellido = " + usuario.Apellido);
                            Console.WriteLine("Nombre de Usuario = " + usuario.NombreUsuario);
                            Console.WriteLine("Contraseña = " + usuario.Contraseña);
                            Console.WriteLine("Mail = " + usuario.Mail);
                            Console.WriteLine("--------------");

                            return usuario;
                        }

                    }
                }
            }




        }

    }
}