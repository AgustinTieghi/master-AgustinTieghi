using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto()
        {
            Id = 0;
            Descripciones = string.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }

        public List<Producto> traerProducto(int IdUs)
        {
            
            var listaProductos = new List<Producto>();
            var query = @"SELECT * FROM producto where IdUsuario = @IdUs";
            string connectionString = "Server=AgusPC; Database=SistemaGestion;Trusted_Connection=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdUs";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdUs;
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
            }
            return listaProductos;

        }



    }
}