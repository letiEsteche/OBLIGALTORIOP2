using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Huesped:Operador
    {
        //ATRIBUTOS:
        public enum TipoDocumento { CI, PASAPORTE, OTROS };
        public enum Fidelizacion { NIVEL1, NIVEL2, NIVEL3, NIVEL4 };
        TipoDocumento documento;
        string numeroDocumento;
        string nombreHuesped;
        string apellidoHuesped;
        string habitacionHuesped;
        DateTime fechaNacimiento;
        Fidelizacion nroFidelizacion;

        public TipoDocumento Documento { get => documento; set => documento = value; }
        public string NumeroDocumento { get => numeroDocumento; set => numeroDocumento = value; }
        public string NombreHuesped { get => nombreHuesped; set => nombreHuesped = value; }
        public string ApellidoHuesped { get => apellidoHuesped; set => apellidoHuesped = value; }
        public string HabitacionHuesped { get => habitacionHuesped; set => habitacionHuesped = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public Fidelizacion NroFidelizacion { get => nroFidelizacion; set => nroFidelizacion = value; }


        public Huesped() { }
        public Huesped(TipoDocumento documento, string numeroDocumento, string nombreHuesped, string apellidoHuesped, string habitacionHuesped, DateTime fechaNacimiento, Fidelizacion nroFidelizacion)
        {
            this.Documento = documento;
            this.NumeroDocumento = numeroDocumento;
            this.NombreHuesped = nombreHuesped;
            this.ApellidoHuesped = apellidoHuesped;
            this.HabitacionHuesped = habitacionHuesped;
            this.FechaNacimiento = fechaNacimiento;
            this.NroFidelizacion = nroFidelizacion;


        }

        private void ValidarNombreHuesped()
        {
            if (!(this.nombreHuesped != null && this.nombreHuesped.Length < 25))
            {
                throw new Exception("Nombre inválido");
            }
        }


    }
}
