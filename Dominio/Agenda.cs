using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agenda
    {
        #region Atributos

        static int ultimoNumero = 0;
        int idAgenda;
        public enum EstadoAgenda { PENDIENTE_PAGO,CONFIRMADA};
        DateTime fechaDeAgenda;
        int cuposDisponibles;

        #endregion

        #region Propiedades

        public static int UltimoNumero { get => ultimoNumero; }
        public int IdAgenda { get => idAgenda; set => idAgenda = value; }
        public DateTime FechaDeAgenda { get => fechaDeAgenda; set => fechaDeAgenda = value; }
        public int CuposDisponibles { get => cuposDisponibles; set => cuposDisponibles = value; }

        #endregion

        #region Constructores

        public Agenda() { }

        public Agenda(DateTime fechaDeAgenda) 
        {
            this.idAgenda = ++ultimoNumero;
            this.fechaDeAgenda = fechaDeAgenda;
            this.cuposDisponibles = 0;
        }
        #endregion

        #region Métodos

        // agenda va a tener un huesped y una actividad


        #endregion

    }
}