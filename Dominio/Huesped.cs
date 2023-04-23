using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Huesped;

namespace Dominio
{
    public class Huesped : Operador
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
        public void ValidarHuesped()
        {
            try
            {
                VerificarNombreHuesped();
                VerificarApellidoHuesped();
                VerificarHabitacion();
                VerificarCedulaValida();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocurrio un error: " + ex.Message);
            }



        }

        private void VerificarNombreHuesped()
        {
            if (!(this.nombreHuesped != ""))
            {
                throw new Exception("Nombre no puede ser vacio.");
            }
        }

        private void VerificarApellidoHuesped()
        {
            if (!(this.apellidoHuesped != ""))
            {
                throw new Exception("Apellido no puede ser vacio.");
            }
        }

        private void VerificarHabitacion()
        {
            if (!(this.habitacionHuesped != ""))
            {
                throw new Exception("Habitacion no puede ser vacio.");
            }
        }

        private void VerificarCedulaValida()
        {
            if (!(ComprobarCI(this.numeroDocumento)))
            {
                throw new Exception("La cédula de identidad es incorrecta, si contiene menos de 8 números, ingresar un cero al comienzo.");
            }
        }

        private void VerificarDocumentoUnico()
        {
            if (!(true))
            {
                throw new Exception("Documento ya existente");
            }

        }

        //VALIDAR CEDULA
        private bool ComprobarCI(string? cedula)
        {
            //Verifica cantidad de digitos
            if (cedula.Length != 8)
            {
                return false;
            }

            // Convertir la cédula a una lista de dígitos
            char[] cedulaArray = cedula.ToCharArray();

            // Verificar que todos los caracteres de la cédula sean dígitos
            if (!cedulaArray.All(char.IsDigit))
            {
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

            
            return verificador == int.Parse(cedulaArray[7].ToString());
        }

        public override bool Equals(object? obj)
        {
            Huesped nroDoc = obj as Huesped;
            
            if(nroDoc != null)
            {
                return false;
            }

            return this.numeroDocumento.Equals(nroDoc.numeroDocumento);
           
        }


        //esto tiene que ir
        public override int GetHashCode()
        {
            return this.numeroDocumento.GetHashCode();
        }

        //mostrar huesped AGREGAR LOS DEMAS ATRIBUTOS
        public override string ToString()
        {
            return $"Huesped {this.Documento}, numero {this.NumeroDocumento}, nombre {this.nombreHuesped} y apellido {this.apellidoHuesped}";
        }



    }

}

