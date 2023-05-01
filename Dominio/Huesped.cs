using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Huesped;

namespace Dominio
{
    public class Huesped : Operador , Validable
    {
        //ATRIBUTOS:
        public enum TipoDocumento { CI, PASAPORTE, OTROS };
        public enum Fidelizacion { NIVEL1, NIVEL2, NIVEL3, NIVEL4 };
        TipoDocumento documento;
        string? numeroDocumento;
        string? nombreHuesped;
        string? apellidoHuesped;
        string? habitacionHuesped;
        DateTime fechaNacimiento;
        Fidelizacion nroFidelizacion;



        public TipoDocumento Documento { get => documento; set => documento = value; }
        public string? NumeroDocumento { get => numeroDocumento; set => numeroDocumento = value; }
        public string? NombreHuesped { get => nombreHuesped; set => nombreHuesped = value; }
        public string? ApellidoHuesped { get => apellidoHuesped; set => apellidoHuesped = value; }
        public string? HabitacionHuesped { get => habitacionHuesped; set => habitacionHuesped = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public Fidelizacion NroFidelizacion { get => nroFidelizacion; set => nroFidelizacion = value; }


        public Huesped() { }
        public Huesped(TipoDocumento documento, string numeroDocumento, string nombreHuesped, string apellidoHuesped, string habitacionHuesped, DateTime fechaNacimiento, Fidelizacion nroFidelizacion, string email, string contraseña) : base(email, contraseña)
        {
            this.Documento = documento;
            this.NumeroDocumento = numeroDocumento;
            this.NombreHuesped = nombreHuesped;
            this.ApellidoHuesped = apellidoHuesped;
            this.HabitacionHuesped = habitacionHuesped;
            this.FechaNacimiento = fechaNacimiento;
            this.NroFidelizacion = nroFidelizacion;

        }

        //VERIFICACIONES DE HUESPED
        public void Validar()
        {
            VerificarNombreHuesped();
            VerificarApellidoHuesped();
            VerificarHabitacion();
            VerificarCedulaValida();
        }

        private void VerificarNombreHuesped()
        {
            if (!(this.nombreHuesped != ""))
            {
                //Se duplica mensaje debido a la precarga
                Console.WriteLine("Nombre no puede ser vacio.");
                throw new Exception("Nombre no puede ser vacio.");
            }
        }

        private void VerificarApellidoHuesped()
        {
            if (!(this.apellidoHuesped != ""))
            {
                //Se duplica mensaje debido a la precarga
                Console.WriteLine("Apellido no puede ser vacio.");
                throw new Exception("Apellido no puede ser vacio.");
            }
        }

        private void VerificarHabitacion()
        {
            if (!(this.habitacionHuesped != ""))
            {
                //Se duplica mensaje debido a la precarga
                Console.WriteLine("Habitacion no puede ser vacio.");
                throw new Exception("Habitacion no puede ser vacio.");
            }
        }

        private void VerificarCedulaValida()
        {
            if (!(this.documento.Equals(TipoDocumento.CI))) 
            {
                //salgo del void
                return;
            }
            if (!(ComprobarCI(this.numeroDocumento)))
            {
                //Se duplica mensaje debido a la precarga
                throw new Exception("La cédula de identidad es incorrecta.");
            }

        }



        //VALIDAR CEDULA
        public bool ComprobarCI(string? cedula)
        {
            

            //Verifica cantidad de digitos
            if (cedula.Length != 8)
            {
                Console.WriteLine("Cedula tiene que tener 8 digitos, de ser necesario insertar un cero al comienzo.");
                return false;
                

            }

            // Convertir la cédula a una lista de dígitos
            char[] cedulaArray = cedula.ToCharArray();

            // Verificar que todos los caracteres de la cédula sean dígitos
            if (!cedulaArray.All(char.IsDigit))
            {
                Console.WriteLine("Todos los digitos deben ser numeros.");
                return false;

            }

            //Condicion que debe cumplir para verificar digito verificador
            int[] coeficientes = { 2, 9, 8, 7, 6, 3, 4 };
            int suma = 0;

            for (int i = 0; i < coeficientes.Length; i++)
            {
                suma += coeficientes[i] * int.Parse(cedulaArray[i].ToString());
            }

            int resto = suma % 10;
            int verificador = 0;

            if (resto != 0)
            {
                verificador = 10 - resto;
            }

            //Devuelve un booleano si el digito verificador calculado es igual al ultimo numero de la cedula
            bool verificado = (verificador == int.Parse(cedulaArray[7].ToString()));

            if (!verificado) 
            { 
                Console.WriteLine("El digito verificador es invalido");
            }

            return verificado;
        }


        //Esto es para poder usar contains
        public override bool Equals(object? obj)
        {
            Huesped? huesped = obj as Huesped;

            if (huesped == null) return false;

            return this.numeroDocumento.Equals(huesped.numeroDocumento) && this.documento.Equals(huesped.documento);

        }


        //esto tiene que ir
        public override int GetHashCode()
        {
            return this.numeroDocumento.GetHashCode();
        }


        //mostrar huesped AGREGAR LOS DEMAS ATRIBUTOS
        public override string ToString()
        {
            return $"Huesped  {this.Documento} {this.NumeroDocumento}, Nombre {this.nombreHuesped} {this.apellidoHuesped}, Habitacion {habitacionHuesped}, Fecha nacimiento {fechaNacimiento.ToShortDateString()}, Fidelizacion {nroFidelizacion}";

        }

      


    }

}

