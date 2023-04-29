using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Operador
    {
        private static int ultimoNumero = 1;
        int idUsuario;
        string? email;
        string? contraseña;
        

        public static int UltimoNumero { get => ultimoNumero; }
        public string? Email { get => email; set => email = value; }
        public string? Contraseña { get => contraseña; set => contraseña = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        

        public Operador() { }

        public Operador(string email, string contraseña)
        {
            this.idUsuario = ultimoNumero++;
            this.email = email;
            this.contraseña = contraseña;

        }



        public void ValidarOperador()
        {
            try
            {
                ValidarEmail();
                ValidarContraseña();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error: " + ex.Message);
            }
            
        }


        // validar que mail contenga @ pero no sea al principio y al final
        private void ValidarEmail()
        {
            if (!(this.email.Contains("@")) || this.email.StartsWith("@") || this.email.EndsWith("@"))
            {
                
                throw new Exception("Email inválido");
            }
        }

        //validar contraseña
        private void ValidarContraseña()
        {
            if (!(this.contraseña.Length > 8))
            {
                throw new Exception("Contraseña inválida");
            }
        }

        public override string ToString()
        {
            return $"{this.idUsuario} {this.email} {this.contraseña}";
        }

    }




}
