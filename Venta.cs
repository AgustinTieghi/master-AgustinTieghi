using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta()
        {
            Id = 0;
            Comentarios = String.Empty;
            IdUsuario = 0;
        }


        public List<Venta> traerVenta(int IdUsu)
        {

            var listaVenta = new List<Venta>();
            var query = @"SELECT * FROM Venta where IdUsuario = @IdUsu";
            string connectionString = "Server=AgusPC; Database=SistemaGestion;Trusted_Connection=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdUsu";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdUsu;
                    comando.Parameters.Add(parametro);

                    connection.Open();

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var venta = new Venta();

                            venta.Id = Convert.ToInt32(dr.GetValue(0));
                            venta.Comentarios = dr.GetValue(1).ToString();
                            venta.IdUsuario = Convert.ToInt32(dr.GetValue(2));

                            listaVenta.Add(venta);

                        }

                        foreach (var venta in listaVenta)
                        {
                            Console.WriteLine("id = " + venta.Id);
                            Console.WriteLine("Comentario = " + venta.Comentarios);
                            Console.WriteLine("IdUsuario = " + venta.IdUsuario);
                        }
                        dr.Close();
                    }
                }
            }
            return listaVenta;

        }
    }
}
