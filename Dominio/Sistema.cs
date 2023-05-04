namespace Dominio
{
    public class Sistema
    {
        #region Atributos

        private static Sistema instancia;

        List<Actividad> actividades = new List<Actividad>();
        List<Proveedor> proveedores = new List<Proveedor>();
        List<Agenda> agendas = new List<Agenda>();
        List<Operador> operadores = new List<Operador>();
        List<Huesped> huespedes = new List<Huesped>();
        List<string> erroresPrecarga = new List<string>(); //lista para guardar los errores de precarga

        #endregion

        #region Sinlgeton
        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }

        #endregion

        #region Propiedades

        public List<Actividad> Actividades { get => actividades; set => actividades = value; }
        public List<Proveedor> Proveedores { get => proveedores; set => proveedores = value; }
        public List<Agenda> Agendas { get => agendas; set => agendas = value; }
        public List<Operador> Operadores { get => operadores; set => operadores = value; }
        public List<Huesped> Huespedes { get => huespedes; set => huespedes = value; }
        public List<string> ErroresPrecarga { get => erroresPrecarga; }

        #endregion

        #region Precargas

        private Sistema()
        {
            AltaProveedor(new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 10));
            AltaProveedor(new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7));
            AltaProveedor(new Proveedor("TravelFun", "29152020", "Misiones 1140", 9));
            AltaProveedor(new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 11));
            AltaProveedor(new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10));
            AltaProveedor(new Proveedor("Electric Blue", "26018945", "Cooper 678", 5));
            AltaProveedor(new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 4));
            AltaProveedor(new Proveedor("Gimenez S.R.L.", "29001010", "", 7));
            AltaProveedor(new Proveedor("", "22041120", "Agraciada 2512 Apto. 1", 8));
            AltaProveedor(new Proveedor("Norberto Molina", "", "Paraguay 2100", 9));
            AltaProveedor(new Proveedor("Norberto Molina", "22001189", "uruguay", 9));
            
            AltaHuesped(new Huesped(Huesped.TipoDocumento.CI, "42970570", "Ana", "Gomez", "204", new DateTime(2023, 01, 21), Huesped.Fidelizacion.NIVEL1, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.PASAPORTE, "12345688", "Rosa", "Rodriguez", "a202", new DateTime(2024, 01, 21), Huesped.Fidelizacion.NIVEL2, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.OTROS, "12345672", "Ana", "Gomez", "204", new DateTime(2026, 01, 21), Huesped.Fidelizacion.NIVEL3, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.CI, "48923692", "Rosa", "Rodriguez", "a202", new DateTime(2025, 01, 21), Huesped.Fidelizacion.NIVEL4, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.PASAPORTE, "12345", "Ana", "Gomez", "204", new DateTime(2023, 12, 21), Huesped.Fidelizacion.NIVEL1, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.OTROS, "12345616", "Rosa", "Rodriguez", "a202", new DateTime(2024, 02, 21), Huesped.Fidelizacion.NIVEL2, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.OTROS, "1234561655", "Rosa", "Rodriguez", "a202", new DateTime(2024, 02, 21), Huesped.Fidelizacion.NIVEL2, "ss@asdf", "123456"));

            AltaActividadHostal(new ActividadHostal("Rosa", "comedor", ActividadHostal.UbicacionActividad.INTERIOR, "Comida china", "Aprender recetas de comida china", new DateTime(2024, 02, 02), 10, 18, 0));
            AltaActividadHostal(new ActividadHostal("Karen", "jardín", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Yoga", "Hacer ejercicios de Yoga Kundalini", new DateTime(2024, 02, 02), 10, 18, 0));
            AltaActividadHostal(new ActividadHostal("Juan", "playa", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Tenis", "Campeonato de tenis en equipos", new DateTime(2024, 02, 02), 10, 18, 600));
            AltaActividadHostal(new ActividadHostal("Santiago", "gimnasio", ActividadHostal.UbicacionActividad.INTERIOR, "Spinnin", "Clases de Spinnin", new DateTime(2024, 02, 02), 10, 18, 500));
            AltaActividadHostal(new ActividadHostal("Karen", "gimnasio", ActividadHostal.UbicacionActividad.INTERIOR, "Yoga", "Clase Yoga Kundalini", new DateTime(2024, 02, 02), 10, 18, 500));
            AltaActividadHostal(new ActividadHostal("Juan", "sala de juegos", ActividadHostal.UbicacionActividad.INTERIOR, "Lotería", "Jugar a la lotaría", new DateTime(2024, 02, 02), 10, 18, 700));
            AltaActividadHostal(new ActividadHostal("Santiago", "plaza", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Tejo", "Campeonato de tejo en parejas", new DateTime(2024, 02, 02), 10, 18, 900));
            AltaActividadHostal(new ActividadHostal("Richard", "playa", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Pájaros", "Observación de áves autoctonas", new DateTime(2024, 02, 02), 10, 18, 100));
            AltaActividadHostal(new ActividadHostal("Susana", "comedor", ActividadHostal.UbicacionActividad.INTERIOR, "Comida Mexicana", "Aprender recetas de comida mexicana", new DateTime(2024, 02, 02), 10, 18, 100));
            AltaActividadHostal(new ActividadHostal("Juan", "jardín", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Juego de mesa", "Campeonato de Truco", new DateTime(2024, 02, 02), 10, 18, 140));
            AltaActividadHostal(new ActividadHostal("Juan", "jardín", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Juego de mesa", "Campeonato de Ajedrez", new DateTime(2024, 02, 02), 10, 18, 1400));

            AltaActividadTercerizada(new ActividadTercearizada(proveedores[0], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Juego de mesa", "Jugar cartas", new DateTime(2024, 06, 01), 10, 18, 1050));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[0], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Juego de mesa", "Jugar ajedrez", new DateTime(2024, 06, 02), 10, 18, 400));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[0], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Juego de mesa", "Jugar damas", new DateTime(2024, 06, 03), 10, 18, 350));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[1], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Bailes", "Zumba", new DateTime(2024, 06, 12), 10, 18, 990));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[1], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Bailes", "Tango", new DateTime(2024, 06, 22), 10, 18, 980));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[1], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Bailes", "Salsa", new DateTime(2024, 06, 30), 10, 18, 154));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[2], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Gimansia", "Correr", new DateTime(2024, 06, 13), 10, 18, 350));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[2], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Gimnasia", "Saltar", new DateTime(2024, 06, 09), 10, 18, 1001));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[2], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Gimnasia", "Caminar", new DateTime(2024, 06, 01), 10, 18, 1010));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[3], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Juego de mesa", "Jugar poker", new DateTime(2024, 06, 02), 10, 18, 890));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[3], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Juego de mesa", "Jugar", new DateTime(2024, 06, 02), 10, 18, 780));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[4], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Juego de mesa", "Jugar", new DateTime(2024, 06, 22), 10, 18, 800));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[4], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Escalar", "Escalar de dia", new DateTime(2024, 06, 12), 10, 18, 770));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[4], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Escalar", "Escalar de noche", new DateTime(2024, 06, 07), 10, 18, 600));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[4], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2024, 06, 01), "Escalar", "Escalar y caminar ", new DateTime(2024, 07, 11), 10, 18, 500));


        }
        #endregion

        #region Métodos

        //alta de proveedor para que cargue con la precarga que se dio en clase
        public void AltaProveedor(Proveedor proveedor)
        {
            try
            {
                if (proveedor == null)
                {
                    throw new Exception("Proveedor nulo.");
                }
                proveedor.Validar();
                VerificarProveedorNoExiste(proveedor);
                Proveedores.Add(proveedor);

            }
            catch (Exception ex)
            {

                erroresPrecarga.Add("Ocurrio un error: " + ex.Message);

            }
        }

        //alta de huesped con precarga y para cargar un huesped por consola
        public bool AltaHuesped(Huesped huesped)
        {
            try
            {
                if (huesped == null)
                {
                    throw new Exception("Huesped nulo.");
                }
                huesped.Validar();
                VerificarHuespedNoExiste(huesped);
                Huespedes.Add(huesped);
                return true;
            }
            catch (Exception ex)
            {

                erroresPrecarga.Add("Ocurrio un error: " + ex.Message);
                return false;

            }
        }

        //alta de actividades del hostal

        public void AltaActividadHostal(ActividadHostal actividad)
        {
            try
            {
                if (actividades == null)
                {
                    throw new Exception("Actividad nulo");
                }
                actividad.Validar();
                Actividades.Add(actividad);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocurrio un error: " + ex.Message);


            }

        }

        //Alta de actividad tercerizada
        public void AltaActividadTercerizada(ActividadTercearizada actividad)
        {
            try
            {
                if (actividad == null)
                {
                    throw new Exception("Actividad nula");
                }
                actividad.Validar();
                Actividades.Add(actividad);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocurrio un error: " + ex.Message);

            }
        }

        //Alta de operador
        public void AltaOperador(Operador operador)
        {
            try
            {
                if (operador == null)
                {
                    throw new Exception("Actividad nula");

                }
                operador.Validar();
                Operadores.Add(operador);
            }
            catch (Exception ex)
            {

                erroresPrecarga.Add("Ocurrio un error: " + ex.Message);

            }
        }


        //verifico si el proveedor ya existe en la lista.
        public void VerificarProveedorNoExiste(Proveedor proveedor)
        {
            if (Proveedores.Contains(proveedor))
            {

                throw new Exception("EN PRECARGA: Proveedor ya existe");


            }
        }

        //verificar si ya existe huesped comparando tipo de documento y numero

        public void VerificarHuespedNoExiste(Huesped huespedNew)
        {
            if (Huespedes.Contains(huespedNew))
            {
                Console.WriteLine("Huesped ya existe");
                throw new Exception("EN PRECARGA: Huesped ya existe");
            }
        }


        //guarda en una lista actividades entre fechas dadas y un costo mayor dado
        

        public List<Actividad> ListarActividadMayorACostoYEntreFechas(DateTime fechaInicio, DateTime fechaFin, int costoDato)
        {
            List<Actividad> listaAuxiliar = new List<Actividad>();
            Actividades.Sort();
            Actividades.Reverse();

            foreach (Actividad unaActividad in actividades)
            {
                if (unaActividad.FechaDeActividad.CompareTo(fechaInicio) >= 0 && unaActividad.FechaDeActividad.CompareTo(fechaFin) <= 0)
                {
                    if (unaActividad.CostoPorPersona.CompareTo(costoDato) >= 0)
                    {
                        listaAuxiliar.Add(unaActividad);
                    }

                }

            }

            return listaAuxiliar;
        }

        //Listar listas de proveedor
        public void MostrarListaProveedores(string atributoOrden)
        {
           //Si se le pide que ordene por id
            if (atributoOrden.Equals("id"))
                //El metodo sort ordena elementos de una lista, y la funcion lambda es el criterio de ordenamiento, en este caso por idProveedor
                //Si el primer objeto es menor que el segundo devuelve un valor negativo, indica que el primer elemento debe ordenarse antes que el segundo
                //Si el primer objeto es mayor que el segundo devuelve un valor positivo, indica que el primer elemento debe ordenarse despues que el segundo
                //Si son iguales devuelve 0, por lo que son elementos iguales y no varian su orden 
                Proveedores.Sort((proveedorAnterior, proveedorSiguiente) => proveedorAnterior.IdProveedor.CompareTo(proveedorSiguiente.IdProveedor));
            //si se pide que ordene por nombre
            else if (atributoOrden.Equals("nombre"))
                Proveedores.Sort();//toma el compareTo para metodo de ordenamiento

            //despues de ordenados los elementos de la lista, los imprime por pantalla.
            foreach (Proveedor unProveedor in Proveedores)
            {
                Console.WriteLine(unProveedor.ToString());
            }
        }


        // Listar los huespedes
        public void MostrarListarHuesped()
        {
            foreach (Huesped unHuesped in huespedes)
            {
                Console.WriteLine(unHuesped.ToString());
            }
        }

        // Listar actividades
        public void MostrarListarActividades()
        {
            foreach (Actividad unaActividad in Actividades)
            {
                Console.WriteLine(unaActividad.ToString());
            }
        }

        // Cambiarle valor de promocion
        //Le damos un IdProveedor y un nuevoPorcentaje para modificarlo
        public bool EstablecerValorPromoción(int unIdProveedor, int nuevoPorcentaje)
        {
            //verifica que el porcentaje este entre 0 y 99
            if (!(nuevoPorcentaje < 99 && nuevoPorcentaje > 0))
            {
                Console.WriteLine("El porcentaje no puede ser menor que 0 ni mayor que 100.");
                return false;
            }

            // Aca trae al proveedor obtenido por el numero de ID
            Proveedor provedorAModificar = ObtenerProveedorPorId(unIdProveedor);
            //verifica que el proveedor no sea nulo
            if (provedorAModificar == null) {
                Console.WriteLine("El proveedor no existe.");
                return false;
            }
            // Si el porcentaje es correcto y el proveedor existe modifica el porcentaje de descuento por el nuevoPorcentaje
            provedorAModificar.DescuentoParaTodaActividadTercearizada = nuevoPorcentaje;
            return true;
        }

        // Se usa para obtener el proveedor a partir de su id, y asi poder 'trabajar' con el objeto
        // Al encontrarlo, hacemos break para no seguir buscando
        public Proveedor ObtenerProveedorPorId(int idBuscado)
        { 
            Proveedor proveedorEncontrado = null;
            foreach (Proveedor unProv in proveedores)
            {
                if (unProv.IdProveedor.Equals(idBuscado))
                {
                    proveedorEncontrado = unProv;
                    break;
                }
            }
            return proveedorEncontrado;
        }

        #endregion

    }
}








