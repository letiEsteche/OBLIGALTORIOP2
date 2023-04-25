using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private static Sistema instancia;

        List<Actividad> actividades = new List<Actividad>();
        List<Proveedor> proveedores = new List<Proveedor>();    
        List<Agenda> agendas = new List<Agenda>();
        List<Operador> operadores = new List<Operador>();
        List<Huesped> huespedes = new List<Huesped>();       

        //SINGLETON
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

        public List<Actividad> Actividades { get => actividades; set => actividades = value; }
        public List<Proveedor> Proveedores { get => proveedores; set => proveedores = value; }
        public List<Agenda> Agendas { get => agendas; set => agendas = value; }
        public List<Operador> Operadores { get => operadores; set => operadores = value; }
        public List<Huesped> Huespedes { get => huespedes; set => huespedes = value; }

        private Sistema()
        {
            AltaProveedor(new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 10));
            AltaProveedor(new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7));
            AltaProveedor(new Proveedor("TravelFun", "29152020", "Misiones 1140", 9));
            AltaProveedor(new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 11));
            AltaProveedor(new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10));
            AltaProveedor(new Proveedor("Electric Blue", "26018945", "Cooper 678", 5));
            AltaProveedor(new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 4));
            AltaProveedor(new Proveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 7));
            AltaProveedor(new Proveedor("", "22041120", "Agraciada 2512 Apto. 1", 8));
            AltaProveedor(new Proveedor("Norberto Molina", "22001189", "Paraguay 2100", 9));
            AltaProveedor(new Proveedor("Norberto Molina", "22001189", "uruguay", 9));

            AltaHuesped(new Huesped(Huesped.TipoDocumento.CI, "42970570", "Ana", "Gomez", "204",new DateTime(2023, 01, 21), Huesped.Fidelizacion.NIVEL1, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.PASAPORTE, "48923692", "rosa", "rodriguez", "a202", new DateTime(2024, 01, 21), Huesped.Fidelizacion.NIVEL2, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.OTROS, "12345672", "Ana", "Gomez", "204", new DateTime(2026, 01, 21), Huesped.Fidelizacion.NIVEL3, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.CI, "12345688", "rosa", "rodriguez", "a202", new DateTime(2025, 01, 21), Huesped.Fidelizacion.NIVEL4, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.PASAPORTE, "12345694", "Ana", "Gomez", "204", new DateTime(2023, 12, 21), Huesped.Fidelizacion.NIVEL1, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.OTROS, "12345616", "rosa", "rodriguez", "a202", new DateTime(2024, 02, 21), Huesped.Fidelizacion.NIVEL2, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.OTROS, "12345616", "rosa", "rodriguez", "a202", new DateTime(2024, 02, 21), Huesped.Fidelizacion.NIVEL2, "ss@asdf", "123456"));

            AltaActividadHostal(new ActividadHostal("Rosa", "comedor", ActividadHostal.UbicacionActividad.INTERIOR, "Comida china", "Aprender recetas de comida china", new DateTime(2024,02,02), 10, 18,0));
            AltaActividadHostal(new ActividadHostal("Karen", "jardín", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Yoga", "Hacer ejercicios de Yoga Kundalini", new DateTime(2024, 02, 02), 10, 18,0));
            AltaActividadHostal(new ActividadHostal("Juan", "playa", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Tenis", "Campeonato de tenis en equipos", new DateTime(2024, 02, 02), 10, 18, 1000));
            AltaActividadHostal(new ActividadHostal("Santiago", "gimnasio", ActividadHostal.UbicacionActividad.INTERIOR, "Spinnin", "Clases de Spinnin", new DateTime(2024, 02, 02), 10, 18, 1000));
            AltaActividadHostal(new ActividadHostal("Karen", "gimnasio", ActividadHostal.UbicacionActividad.INTERIOR, "Yoga", "Clase Yoga Kundalini", new DateTime(2024, 02, 02), 10, 18, 1000));
            AltaActividadHostal(new ActividadHostal("Juan", "sala de juegos", ActividadHostal.UbicacionActividad.INTERIOR, "Lotería", "Jugar a la lotaría", new DateTime(2024, 02, 02), 10, 18, 1000));
            AltaActividadHostal(new ActividadHostal("Santiago", "plaza", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Tejo", "Campeonato de tejo en parejas", new DateTime(2024, 02, 02), 10, 18, 1000));
            AltaActividadHostal(new ActividadHostal("Richard", "playa", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Pájaros", "Observación de áves autoctonas", new DateTime(2024, 02, 02), 10, 18, 1000));
            AltaActividadHostal(new ActividadHostal("Susana", "comedor", ActividadHostal.UbicacionActividad.INTERIOR, "Comida Mexicana", "Aprender recetas de comida mexicana", new DateTime(2024, 02, 02), 10, 18, 1000));
            AltaActividadHostal(new ActividadHostal("Juan", "jardín", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Juego de mesa", "Campeonato de Truco", new DateTime(2024, 02, 02), 10, 18, 1000));
            AltaActividadHostal(new ActividadHostal("Juan", "jardín", ActividadHostal.UbicacionActividad.AIRE_LIBRE, "Juego de mesa", "Campeonato de Ajedrez", new DateTime(2024, 02, 02), 10, 18, 1000));


            AltaActividadTercerizada(new ActividadTercearizada(proveedores[0], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Juego de mesa", "Jugar cartas", new DateTime(2022, 06, 01), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[0], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Juego de mesa", "Jugar ajedrez", new DateTime(2022, 06, 02), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[0], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Juego de mesa", "Jugar damas", new DateTime(2022, 06, 03), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[1], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Bailes", "Zumba", new DateTime(2022, 06, 12), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[1], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Bailes", "Tango", new DateTime(2022, 06, 22), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[1], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Bailes", "Salsa", new DateTime(2022, 06, 30), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[2], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Gimansia", "Correr", new DateTime(2022, 06, 13), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[2], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Gimnasia", "Saltar", new DateTime(2022, 06, 09), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[2], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Gimnasia", "Caminar", new DateTime(2022, 06, 01), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[3], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Juego de mesa", "Jugar poker", new DateTime(2022, 06, 0), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[3], ActividadTercearizada.ConfirmaEmpresa.NO, new DateTime(), "", "Jugar", new DateTime(2022, 06, 02), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[4], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Juego de mesa", "Jugar", new DateTime(2022, 06, 22), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[4], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Escalar", "Escalar de dia", new DateTime(2022, 06, 12), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[4], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Escalar", "Escalar de noche", new DateTime(2022, 06, 07), 10, 18, 1000));
            AltaActividadTercerizada(new ActividadTercearizada(proveedores[4], ActividadTercearizada.ConfirmaEmpresa.SI, new DateTime(2022, 01, 01), "Escalar", "Escalar y caminar ", new DateTime(2022, 07, 11), 10, 18, 1000));


        }


        //alta de proveedor para que cargue con la precarga que dio el profesor
        public void AltaProveedor(Proveedor proveedor)
        {
            try
            {
                if(proveedor == null)
                {
                    throw new Exception("Proveedor nulo");
                }
                proveedor.Validar();
                VerificarProveedorNoExiste(proveedor);
                Proveedores.Add(proveedor);
                
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocurrio un error" + ex.Message);
            }
        }

        //alta de huesped con precarga 
        public void AltaHuesped(Huesped huesped)
        {
            try
            {
                if (huesped == null)
                {
                    throw new Exception("Huesped nulo");
                }
                huesped.ValidarHuesped();
                VerificarHuespedNoExiste(huesped);
                Huespedes.Add(huesped);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocurrio un error" + ex.Message);

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
                actividad.ValidarActividad();
                //actividad.ValidarActividadHostal; ESTA VALDACION TOMA LAS VALIDACIONES DE TODO??
                Actividades.Add(actividad);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocurrio un error" + ex.Message);

            }

        }

        public void AltaActividadTercerizada(ActividadTercearizada actividad)
        {
            try
            {
                if(actividad == null)
                {
                    throw new Exception("Actividad nula");
                }
                actividad.ValidarActividad();
                Actividades.Add(actividad);

            }
            catch(Exception ex) 
            {
                Console.WriteLine("Ocurrio un error" + ex.Message);
            }
        }



        //verifico si el proveedor ya existe en la lista.
        public void VerificarProveedorNoExiste(Proveedor proveedor)
        {
            if (Proveedores.Contains(proveedor))
            {
                throw new Exception("Proveedor ya existe");
            }
        }

        //verificar si ya existe huesped

        public void VerificarHuespedNoExiste(Huesped huespedNew)
        {
            if (Huespedes.Contains(huespedNew))
            {
                throw new Exception("Huesped ya existe");
            }
        }

       


    }
}



