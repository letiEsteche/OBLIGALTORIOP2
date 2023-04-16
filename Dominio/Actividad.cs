using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Actividad
    {
        //ATRIBUTOS
        static int ultimoNumero = 0;
        int idActividad;
        string? nombreActividad;
        string? descripcionActividad;
        DateTime fechaDeActividad;
        int cantMaxPersonas;
        int edadMinimaParaActividad;
        decimal costoPorPersona;
        
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
        

        //CONSTRUCTORES

        public Actividad() { }

        public Actividad(string nombreActividad, string descripcionActividad, DateTime fechaDeActividad, int cantMaxPersonas, int edadMinimaParaActividad) 
        {
            this.idActividad = ultimoNumero++;
            this.nombreActividad = nombreActividad;
            this.descripcionActividad = descripcionActividad;
            this.fechaDeActividad = fechaDeActividad;
            this.cantMaxPersonas = cantMaxPersonas;
            this.edadMinimaParaActividad = edadMinimaParaActividad;
            
        }

        //VALIDACIONES

        public void Validar()
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


        //las actividades tienen un costo sino se cuenta con esto es gratuita
        private bool CostoDeLaActividad()
        {
            if (this.costoPorPersona > 0)
            {
                return true;
            }

            return false;
        }

    }
}
