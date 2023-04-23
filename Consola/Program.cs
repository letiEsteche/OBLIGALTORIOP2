namespace Consola
{
    using Dominio;
    using System.Globalization;
    using System.Threading.Channels;

    public class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            string[] opciones = { "Alta de huesped", "Listar todas las actividades", "Listar todos los proveedores","Listar Huesped", "Listar Actividades" };


            //Operador operador = new Operador("juancarlos", "passwo");
            //operador.Validar();
            //Console.WriteLine(operador.Email);




            /* Si vamo a testear un objeto que requiere otros objetos, tenemos que instanciarlos primero
            Actividad actividad = new Actividad("", "");
            Huesped huesped = new Huesped("carlos");
            Agenda agenda = new Agenda (huesped, actividad)*/
            do
            {
                Menu(opciones);
               
                opcion = LeerNumero();
                switch (opcion)
                {
                    case 1:
                        AltaHuesped();
                        break;
                    case 2:
                        //ListarTodasLasActividades;
                        break;
                    case 3:
                        ListarProveedores();
                        break;
                    case 4:
                        ListarHuesped();
                        break;
                    case 5: 
                        ListarActividades();
                        break;
                }
            } while (opcion != 0);


        }

        static void Menu(string[] opciones)
        {
            int numero = 1;
           
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

        static void AltaHuesped()
        {
            Sistema unHues = Sistema.Instancia;
            try
            {
                Huesped.TipoDocumento tipoDoc = PedirTipoDoc("Ingrese tipo de docmuento: CI, PASSAPORTE U OTROS");
                string? nroDoc = PedirTexto("Ingrese numero de documento:");
                string? nombre = PedirTexto("Ingrese nombre:");
                string? apellido = PedirTexto("Ingrese apellido:");
                string? habitacion = PedirTexto("Ingrese habitación:");
                DateTime fechaNac = PedirFecha("Ingrese fecha de nacimiento:");
                Huesped.Fidelizacion fidel = PedirFidel("Ingrese nivel de fidelización: NIVEL1, NIVEL2, NIVEL3 o NIVEL4");
                string? email = PedirTexto("Ingrese mail:");
                string? pass = PedirTexto("Ingrese contraseña");



                unHues.AltaHuesped(new Huesped(tipoDoc, nroDoc, nombre, apellido, habitacion, fechaNac, fidel, email, pass));
                MensajeConfirmacion("Se ingresó el cliente correctamente");
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }


        //Metodo para poder ingresar ociones del menú
        static string? PedirTexto(string mensaje = "Ingrese número.")
        {
            bool exito;
            string? valor;
            do
            {
                Console.Write(mensaje);
                valor = Console.ReadLine();
                if (valor == null)
                {
                    MensajeError("No se ha ingresado nada");
                    exito = false;
                }
                else
                {
                    exito = true;
                }

            } while (!exito);
            return valor;
        }


        //metodo para ingresar fecha en el menu
        public static DateTime PedirFecha(string mensaje = "Ingrese fecha.")
        {
            DateTime fecha;
            bool exito;
            do
            {
                Console.Write(mensaje);
                exito = DateTime.TryParse(Console.ReadLine(), out fecha);
                if (!exito)
                {
                    Console.WriteLine("Fecha con error en el formato");
                }

            } while (!exito);

            return fecha;
        }

        //Metodo para pedir y guardar opcion de enum Tipo de documento
       static Huesped.TipoDocumento PedirTipoDoc(string mensaje = "Ingresar tipo:")
        {
            bool exito;

            Huesped.TipoDocumento valor;

            do
            {
                Console.Write(mensaje);
                exito = Enum.TryParse(Console.ReadLine(), out valor);
                if (!exito)
                {
                    MensajeError("No es un tipo");
                   
                }
                else
                {
                    exito = true;
                }

            } while (!exito);

            return valor;
        }

        //Metodo para pedir y guardar opcion de enum Fidelizacion
        static Huesped.Fidelizacion PedirFidel(string mensaje = "Ingresar Fidelización")
        {
            bool exito;

            Huesped.Fidelizacion valor;

            do
            {
                Console.Write(mensaje);
                exito = Enum.TryParse(Console.ReadLine(), out valor);
                if (!exito)
                {
                    MensajeError("No es un nivel");

                }
                else
                {
                    exito = true;
                }

            } while (!exito);

            return valor;
        }

        //MENSAJES DE ERROR Y CONFIRMACION PARA UTILIZAR
        static void MensajeError(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"---Error----> {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }
        static void MensajeConfirmacion(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"---Confirmado----> {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }



        //listar los proveedores
        static public void ListarProveedores()
        {
            Sistema unS = Sistema.Instancia;
            foreach (Proveedor unP in unS.Proveedores)
            {
                Console.WriteLine(unP.ToString());
            }
            Console.ReadLine();
           
        }


        //listar los huespedes
        static public void ListarHuesped()
        {
            Sistema unS = Sistema.Instancia;
            foreach (Huesped unH in unS.Huespedes)
            {
                Console.WriteLine(unH.ToString());
            }
            Console.ReadLine();
           
        }

        static public void ListarActividades()
        {
            Sistema unS = Sistema.Instancia;
            foreach (Actividad unA in unS.Actividades)
            {
                Console.WriteLine(unA.ToString());
            }
            Console.ReadLine();

        }


    }
}