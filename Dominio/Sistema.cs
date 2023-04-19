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





        }

        //verifico si el proveedor ya existe en la lista.
        public void VerificarProveedorNoExiste(Proveedor proveedor)
        {
            if (proveedores.Contains(proveedor))
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
                proveedores.Add(proveedor);
                
            }
            catch (Exception ex)
            {

                throw ex;// mensaje de error
            }
        }
    }
}



