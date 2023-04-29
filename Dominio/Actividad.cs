using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Actividad: IComparable<Actividad>
    {
        //ATRIBUTOS
        static int ultimoNumero = 1;
        int idActividad;
        string? nombreActividad;
        string? descripcionActividad;
        DateTime fechaDeActividad;
        int cantMaxPersonas;
        int edadMinimaParaActividad;
        decimal costoPorPersona;
        int cuposDisponibles;

        List<Agenda> agendas = new List<Agenda>();

        //PROPIEDADES
        public static int UltimoNumero { get => ultimoNumero; }
        public int IdActividad { get => idActividad; set => idActividad = value; }
        public string? NombreActividad { get => nombreActividad; set => nombreActividad = value; }
        public string? DescripcionActividad { get => descripcionActividad; set => descripcionActividad = value; }
        public DateTime FechaDeActividad { get => fechaDeActividad; set => fechaDeActividad = value; }
        public int CantMaxPersonas { get => cantMaxPersonas; set => cantMaxPersonas = value; }
        public int EdadMinimaParaActividad { get => edadMinimaParaActividad; set => edadMinimaParaActividad = value; }
        public decimal CostoPorPersona { get => costoPorPersona; set => costoPorPersona = value; }
        public int CuposDisponibles { get => cuposDisponibles; set => cuposDisponibles = value; }


        //CONSTRUCTORES

        public Actividad() { }

        public Actividad(string nombreActividad, string descripcionActividad, DateTime fechaDeActividad, int cantMaxPersonas, int edadMinimaParaActividad, decimal costoPorPersona)
        {
            this.idActividad = ultimoNumero++;
            this.nombreActividad = nombreActividad;
            this.descripcionActividad = descripcionActividad;
            this.fechaDeActividad = fechaDeActividad;
            this.cantMaxPersonas = cantMaxPersonas;
            this.edadMinimaParaActividad = edadMinimaParaActividad;
            this.costoPorPersona = costoPorPersona;
            this.cuposDisponibles = cantMaxPersonas;

        }

        //VALIDACIONES
        //virtual significa que puedo usar esta validacion en las hijas
        public virtual void ValidarActividad()
        {
            ValidarNombreActividad();
            ValidarDescripcionActividad();
            ValidarFecha();
        }

        private void ValidarNombreActividad()
        {
            if (!(this.nombreActividad != null && this.nombreActividad.Length < 25))
            {
                throw new Exception("Nombre inválido");
            }
        }

        private void ValidarDescripcionActividad()
        {
            if (!(this.descripcionActividad != null))
            {
                throw new Exception("Descripcion inválida");
            }
        }

        //fecha debe ser mayor que el dia de la fecha
        //se puede llamar desde agenda?
        private void ValidarFecha()
        {
            if (!(this.fechaDeActividad > DateTime.Today))
            {
                throw new Exception("Fecha inválida");
            }
        }




        public bool VerificarSiHayCuposLibres()
        {
            if (this.cuposDisponibles > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RestarCupoDeCupoDisponible()
        {
            this.cuposDisponibles--;
        }

        public override string ToString()
        {
          
            return $" {this.idActividad} Nombre: {this.nombreActividad} Descripcion: {this.descripcionActividad} Fecha: {this.fechaDeActividad.ToShortDateString()} MAX Personas: {this.cantMaxPersonas} Edad minima: {this.edadMinimaParaActividad} Costo: {this.costoPorPersona}";
        }

        //este comparTO me sirve para utilizar el sort en el orden por costo
        public int CompareTo(Actividad actividad)
        {
            return this.costoPorPersona.CompareTo(actividad.costoPorPersona);
        }


    }
}
