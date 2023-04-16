namespace Consola
{
   
    public class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            string[] opciones = { "Alta de huesped", "Listar todas las actividades", "Listar todos los proveedores", };

            do
            {
                Menu(opciones);
                opcion = LeerNumero();
                switch (opcion)
                {
                    case 1:
                        //AltaDeHuesped;
                        break;
                    case 2:
                        //ListarTodasLasActividades;
                        break;
                }
            } while (opcion != 0);


        }

        static void Menu(string[] opciones)
        {
            int numero = 1;
            Console.Clear();
            Console.WriteLine("Ingrese una de las siguientes opciones (0 para terminar)");
            foreach (string opcion in opciones)
            {
                Console.WriteLine($"{numero} - {opcion} ");
                numero++;
            }
        }

        static int LeerNumero()
        {
            int opcion;
            Console.Write("Ingrese número:");
            while (!(int.TryParse(Console.ReadLine(), out opcion)))
            {
                Console.WriteLine("El valor ingresado no es correcto");
                Console.Write("Ingrese número:");
            }
            return opcion;
        }




    }
}