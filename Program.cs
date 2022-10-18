using ConsoleApp1;
using ConsoleApp1;
using System.Data;
using System.Data.SqlClient;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a mi menú, ingrese una tecla para continuar:" +
            "\n1 = Traer Usuario" +
            "\n2 = Traer Producto" +
            "\n3 = Traer ProductoVendido" +
            "\n4 = Traer Venta" +
            "\n5 = Iniciar Sesión" +
            "\n6 = Salir");

        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1: Usuario usuario = new Usuario();
                Console.WriteLine("Bienvenido, a continuación, ingrese un Nombre de Usuario:");
                string nombreUsuario = Console.ReadLine();
                usuario.traerUsuario(nombreUsuario);
                break;
            case 2:
                Producto producto = new Producto();
                Console.WriteLine("Ingrese el Id del Usuario que desea traer:");
                int IdUsuario = Convert.ToInt32(Console.ReadLine());
                producto.traerProducto(IdUsuario);
                break;
            case 3:
                ProductoVendido productoVendido = new ProductoVendido();
                Console.WriteLine("Ingrese el ID del usuario que realizó la venta");
                string User = Console.ReadLine();
                productoVendido.TraerProductosVendidos(User);
                break;
            case 4:
                Venta venta = new Venta();
                Console.WriteLine("Ingrese el Id del Usuario que desea traer:");
                int IdUsu = Convert.ToInt32(Console.ReadLine());
                venta.traerVenta(IdUsu);
                break;
            case 5:
                Usuario usu = new Usuario();
                Console.WriteLine("Bienvenido, ingrese su usuario: ");
                string Username = Console.ReadLine();
                Console.WriteLine("Ahora ingrese su contraseña: ");
                string pass = Console.ReadLine();
                usu.InicioSesion(Username, pass);
                break;
            default: 
                Console.WriteLine("Adiós.");
                break;
        }
    }
}
