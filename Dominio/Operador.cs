using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Operador
    {
        private static int ultimoNumero = 0;
        int idActividad;
        string emailOperador;
        string contraseñaOperador;

        public static int UltimoNumero { get => ultimoNumero; }
        public string EmailOperador { get => emailOperador; set => emailOperador = value; }
        public string ContraseñaOperador { get => contraseñaOperador; set => contraseñaOperador = value; }
        public int IdActividad { get => idActividad; set => idActividad = value; }

        public Operador() { }

        public Operador(string emailOperador, string contraseñaOperador)
        {
            this.idActividad = ultimoNumero++;
            this.emailOperador = emailOperador;
            this.contraseñaOperador = contraseñaOperador;
           
        }



    }




}
