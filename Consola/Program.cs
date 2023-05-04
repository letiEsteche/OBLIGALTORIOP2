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
            string[] opciones = { "Alta de huesped", "Listar todas las actividades", "Listar todos los proveedores", "Listar actividades por rango de fecha y costo", "Listar Huesped", "Cambiar porcentaje de promocion de proveedor" };

            //CREAR UNA INSTANCIA PARA MOSTRAR ANTES QUE EL MENU LOS ERRORES DE LA PRECARGA
            Sistema UnS = Sistema.Instancia;
            Console.WriteLine("Resultado de la precarga");
            foreach (string s in UnS.ErroresPrecarga)
            {
                MensajeError(s);
            }
            Console.Write("Enter para continuar");
            Console.ReadLine();


            //MENU
            do
            {
                //Console.Clear();
                Menu(opciones);

                opcion = LeerNumero();
                switch (opcion)
                {
                    case 1:
                        AltaHuesped();
                        break;
                    case 2:
                        ListarActividades();
                        break;
                    case 3:
                        ListarProveedores();
                        break;
                    case 4:
                        ListarActividadEntreFechas();
                        break;
                    case 5:
                        ListarHuesped();
                        break;
                    case 6:
                        CambiarPorcentajeDePromocionDeProveedor();
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
            Console.Write("Ingrese número: ");
            while (!(int.TryParse(Console.ReadLine(), out opcion)))
            {
                Console.WriteLine("El valor ingresado no es correcto");
                Console.Write("Ingrese número:");
            }
            return opcion;
        }

        static void ConfirmacionLectura()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
        }

        static void AltaHuesped()
        {
            Sistema unHues = Sistema.Instancia;
            try
            {
                Huesped.TipoDocumento tipoDoc = PedirTipoDoc("Ingrese tipo de docmuento: CI, PASAPORTE U OTROS: ");
                string? nroDoc = PedirTexto("Ingrese numero de documento: ");
                string? nombre = PedirTexto("Ingrese nombre: ");
                string? apellido = PedirTexto("Ingrese apellido: ");
                string? habitacion = PedirTexto("Ingrese habitación: ");
                DateTime fechaNac = PedirFecha("Ingrese fecha nacimiento (AAAA.MM.DD): ");
                Huesped.Fidelizacion fidel = PedirFidel("Ingrese nivel de fidelización: NIVEL1, NIVEL2, NIVEL3 o NIVEL4: ");
                string? email = PedirTexto("Ingrese mail: ");
                string? pass = PedirTexto("Ingrese contraseña: ");

                bool huespedValido = unHues.AltaHuesped(new Huesped(tipoDoc, nroDoc, nombre, apellido, habitacion, fechaNac, fidel, email, pass));

                if (huespedValido)
                {
                    MensajeConfirmacion("Se ingresó el cliente correctamente");
                }
                else
                {
                    MensajeError("Cliente no fue agregado ");
                }
               

                
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

        static int PedirCosto(string mensaje = "Ingrese costo: ")
        {
            bool exito;
            int costo;
            do
            {
                Console.Write(mensaje);
                costo = int.Parse(Console.ReadLine());
                if (costo == null)
                {
                    MensajeError("No se ha ingresado nada");
                    exito = false;
                }
                else
                {
                    exito = true;
                }

            } while (!exito);
            return costo;
        }


        //metodo para ingresar fecha en el menu
        public static DateTime PedirFecha(string mensaje = "Ingrese fecha (AAAA.MM.DD): ")
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

        public static int PedirPorcentaje(string mensaje = "Ingrese un porcentaje")
        {
            int porcentaje;
            bool exito;
            do
            {
                Console.Write(mensaje);
                exito = int.TryParse(Console.ReadLine(), out porcentaje);
                if (!exito)
                {
                    Console.WriteLine("Error en el formatom, debe ingresar un número");
                }

            } while (!exito);

            return porcentaje;
        }

        public static int PedirIdProveedor (string mensaje = "Ingrese el numero de Id")
        {
            int idProv;
            bool exito;
            do
            {
                Console.Write(mensaje);
                exito = int.TryParse(Console.ReadLine(), out idProv);
                if (!exito)
                {
                    Console.WriteLine("Error en el formatom, debe ingresar un número");
                }

            } while (!exito);

            return idProv;
        }

    

    //MENSAJES DE ERROR Y CONFIRMACION PARA UTILIZAR
    static void MensajeError(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"---Error----> {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
            ConfirmacionLectura();
        }
        static void MensajeConfirmacion(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"---Confirmado----> {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            ConfirmacionLectura();
        }

        //-------------------LISTAR----------------------------------------------

        //listar los proveedores
        static public void ListarProveedores()
        {
            Sistema unS = Sistema.Instancia;
            Console.WriteLine("LISTA DE PROVEEDORES POR ORDEN ALFABETICO");
            unS.MostrarListaProveedores("nombre");
            ConfirmacionLectura();
        }

        //listar los huespedes
        static public void ListarHuesped()
        {
            Sistema unS = Sistema.Instancia;
            Console.WriteLine("LISTA DE HUESPED");
            unS.MostrarListarHuesped();

            ConfirmacionLectura();
        }


        //listar actividades
        static public void ListarActividades()
        {
            Sistema unS = Sistema.Instancia;
            Console.WriteLine("LISTAR ACTIVIDADES");

            unS.MostrarListarActividades();
            ConfirmacionLectura();

        }

        //dato un rango de fechas y un costo, listar las actividades que tengan un costo mayor al dado y
        //comprendidas dentro de eses rango de fechas
        //ordenar por orden descendente por costo


        static public void ListarActividadEntreFechas()
        {

            Sistema unS = Sistema.Instancia;
            DateTime fechaInicio = PedirFecha("Ingrese fecha desde (AAAA.MM.DD): ");
            DateTime fechaFin = PedirFecha("Ingrese fecha hasta (AAAA.MM.DD): ");
            int costoDato = PedirCosto("Ingrese un costo: ");
            List<Actividad> auxLista = unS.ListarActividadMayorACostoYEntreFechas(fechaInicio, fechaFin, costoDato);

            if (auxLista.Count > 0)
            {
                foreach (Actividad unaA in auxLista)
                {
                    Console.WriteLine(unaA.ToString());
                }

             }
            else
            {
                MensajeError("La solicitud no genero resultados");
            }

            ConfirmacionLectura();
        }


        static public void CambiarPorcentajeDePromocionDeProveedor()
        {
            Sistema unS = Sistema.Instancia;
            unS.MostrarListaProveedores("nombre");
            int idProveedor = PedirIdProveedor("Ingrese un Id de proveedor: ");
            int porcentaje = PedirPorcentaje("Ingrese un porcentaje nuevo: ");
            
            if(unS.EstablecerValorPromoción(idProveedor, porcentaje))
            {
                Console.WriteLine("Proveedor modificado");
            }
            else
            {
                Console.WriteLine("No se pudo modificar");
            }

            ConfirmacionLectura();

        }



    }
}
