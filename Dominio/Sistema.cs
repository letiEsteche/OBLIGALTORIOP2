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
        //aca van las precargas
        }


    }
}
