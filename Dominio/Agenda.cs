using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agenda: Validable
    {
        #region Atributos
        public enum EstadoAgenda { PENDIENTE_PAGO, CONFIRMADA };
        Actividad? actividad;
        Huesped? huesped;
        static int ultimoNumero = 0;
        int idAgenda;
        DateTime fechaDeAgenda;
        int cuposDisponibles;

        #endregion

        #region Propiedades

        public static int UltimoNumero { get => ultimoNumero; }
        public int IdAgenda { get => idAgenda; set => idAgenda = value; }
        public DateTime FechaDeAgenda { get => fechaDeAgenda; set => fechaDeAgenda = value; }
        public int CuposDisponibles { get => cuposDisponibles; set => cuposDisponibles = value; }
        public Actividad Actividad { get => actividad; set => actividad = value; }
        public Huesped Huesped { get => huesped; set => huesped = value; }

        #endregion

        #region Constructores

        public Agenda() { }

        public Agenda(DateTime fechaDeAgenda, Actividad Actividad, Huesped Huesped) 
        {
            this.idAgenda = ++ultimoNumero;
            this.fechaDeAgenda = fechaDeAgenda;
            this.Actividad = Actividad;
            this.huesped = Huesped;
            this.cuposDisponibles = 0;
        }
        #endregion

        #region Métodos

        // agenda va a tener un huesped y una actividad

        //para esta entrega no se realizan validaciones de agenda
        public void Validar()
        {
            return;
        }

        #endregion

    }
}