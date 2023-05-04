using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadHostal : Actividad
    {
        #region Atributos
        public enum UbicacionActividad {AIRE_LIBRE, INTERIOR };
        string personaResponsable;
        string lugarEnHostel;
        UbicacionActividad dondeEsActividad;

        #endregion

        #region Propiedades

        public string PersonaResponsable { get => personaResponsable; set => personaResponsable = value; }
        public string LugarEnHostel { get => lugarEnHostel; set => lugarEnHostel = value; }
        public UbicacionActividad DondeEsActividad { get => dondeEsActividad; set => dondeEsActividad = value; }

        #endregion

        #region Constructor

        public ActividadHostal(string personaResponsable, string lugarEnHostel, UbicacionActividad dondeEsActividad, string nombreActividad, string descripcionActividad, DateTime fechaDeActividad, int cantMaxPersonas, int edadMinimaParaActividad, decimal costoPorPersona): base (nombreActividad, descripcionActividad, fechaDeActividad, cantMaxPersonas, edadMinimaParaActividad, costoPorPersona)
        {
            this.personaResponsable = personaResponsable;
            this.lugarEnHostel = lugarEnHostel;
            this.dondeEsActividad = dondeEsActividad;
             
          
        }
        #endregion

        #region Validaciones

        public override void Validar()
        {
            base.Validar(); //llama a la validacion de actividad con el virtual que puse en Validacion Actividad
            ValidarNombre(); //llama a validacion de hostal
        }

        //verifica que nombre de responsable de hostel no sea vacio

        private void ValidarNombre()
        {
            if (!(this.personaResponsable != ""))
            {
                throw new Exception("Nombre no puede ser nulo.");
            }
        }

        #endregion

        #region Metodo
        //Desceutno dee hostal que le corresponde a cada huesped segun su fidelizacion
        public decimal DescuentoHostal(string nivelHuesped)
        {
            decimal descuento = 0;

            if (nivelHuesped == "NIVEL2")
            {
                descuento = 10;
            }
            else if (nivelHuesped == "NIVEL3")
            {
                descuento = 15;
            }else if(nivelHuesped == "NIVEL4")
            {
                descuento = 20;
            }

            return descuento;
        }

        #endregion

    }
}
