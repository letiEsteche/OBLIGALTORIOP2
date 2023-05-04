using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Operador: Validable
    {
        #region Atributos

        private static int ultimoNumero = 1;
        int idUsuario;
        string? email;
        string? contraseña;

        #endregion

        #region Propiedades

        public static int UltimoNumero { get => ultimoNumero; }
        public string? Email { get => email; set => email = value; }
        public string? Contraseña { get => contraseña; set => contraseña = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        #endregion

        #region Constructores

        public Operador() { }

        public Operador(string email, string contraseña)
        {
            this.idUsuario = ultimoNumero++;
            this.email = email;
            this.contraseña = contraseña;

        }

        #endregion

        #region Métodos

        public void Validar()
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
            //Validar: si el mail no contiene @, comienza con o finaliza con @, etnonces tirar la excepcion
            if (!(this.email.Contains("@")) || this.email.StartsWith("@") || this.email.EndsWith("@"))
            {
                
                throw new Exception("Email inválido");
            }
        }

        //validar contraseña no tenga menos de 8 digitos
        private void ValidarContraseña()
        {
            if (!(this.contraseña.Length > 8))
            {
                throw new Exception("Contraseña inválida");
            }
        }

        //publicar mensaje con el contenido de operador
        public override string ToString()
        {
            return $"{this.idUsuario} {this.email} {this.contraseña}";
        }
        #endregion
    }

}
