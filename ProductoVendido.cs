using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido()
        {
            Id = 0;
            Stock = 0;
            IdProducto = 0;
            IdVenta = 0;
        }

        public List<ProductoVendido> TraerProductosVendidos(string Username)
        {
            var listaProductosVendidos = new List<ProductoVendido>();
            var listaProductos = new List<Producto>();
            var query = @"SELECT producto.* 
             FROM Producto INNER JOIN ProductoVendido ON producto.Id = productoVendido.IdProducto INNER JOIN Venta ON venta.Id = productoVendido.IdVenta 
             INNER JOIN Usuario ON Usuario.Id = venta.IdUsuario 
             WHERE Usuario.NombreUsuario = @Username";
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
                        while (dr.Read())
                        {
                            var producto = new Producto();

                            producto.Id = Convert.ToInt32(dr.GetValue(0));
                            producto.Descripciones = dr.GetValue(1).ToString();
                            producto.Costo = Convert.ToInt64(dr.GetValue(2));
                            producto.PrecioVenta = Convert.ToInt32(dr.GetValue(3));
                            producto.Stock = Convert.ToInt32(dr.GetValue(4));
                            producto.IdUsuario = Convert.ToInt32(dr.GetValue(5));

                            listaProductos.Add(producto);

                        }

                        foreach (var producto in listaProductos)
                        {
                            Console.WriteLine("id = " + producto.Id);
                            Console.WriteLine("Descripcion = " + producto.Descripciones);
                            Console.WriteLine("Costo = " + producto.Costo);
                            Console.WriteLine("PrecioVenta = " + producto.PrecioVenta);
                            Console.WriteLine("Stock = " + producto.Stock);
                            Console.WriteLine("IdUsuario = " + producto.IdUsuario);
                            Console.WriteLine("--------------");

                        }
                        dr.Close();
                    }
                }

                return new List<ProductoVendido>();
            }
        }
    }
}
