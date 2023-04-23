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

            AltaHuesped(new Huesped(Huesped.TipoDocumento.CI, "42970570", "Ana", "Gomez", "204",new DateTime(2023, 01, 21), Huesped.Fidelizacion.NIVEL1, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.PASAPORTE, "48923692", "rosa", "rodriguez", "a202", new DateTime(2024, 01, 21), Huesped.Fidelizacion.NIVEL2, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.OTROS, "12345672", "Ana", "Gomez", "204", new DateTime(2026, 01, 21), Huesped.Fidelizacion.NIVEL3, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.CI, "12345688", "rosa", "rodriguez", "a202", new DateTime(2025, 01, 21), Huesped.Fidelizacion.NIVEL4, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.PASAPORTE, "12345694", "Ana", "Gomez", "204", new DateTime(2023, 12, 21), Huesped.Fidelizacion.NIVEL1, "ss@asdf", "123456"));
            AltaHuesped(new Huesped(Huesped.TipoDocumento.OTROS, "12345616", "rosa", "rodriguez", "a202", new DateTime(2024, 02, 21), Huesped.Fidelizacion.NIVEL2, "ss@asdf", "123456"));


        }

        //verifico si el proveedor ya existe en la lista.
        public void VerificarProveedorNoExiste(Proveedor proveedor)
        {
            if (Proveedores.Contains(proveedor))
            {
                throw new Exception("Proveedor ya existe");
            }
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

                throw ex;// mensaje de error
            }
        }


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

                throw ex;// mensaje de error
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



