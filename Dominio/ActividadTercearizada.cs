﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadTercearizada:Actividad
    {
        public enum ConfirmaEmpresa { SI, NO };
        Proveedor proveedor;
        DateTime fechaConfirmacion;
        ConfirmaEmpresa confirmacionEmpresa;

       
        
        public DateTime FechaConfirmacion { get => fechaConfirmacion; set => fechaConfirmacion = value; }
        public ConfirmaEmpresa ConfirmacionEmpresa1 { get => confirmacionEmpresa; set => confirmacionEmpresa = value; }

        public ActividadTercearizada(Proveedor proveedor,  ConfirmaEmpresa confirmacionEmpresa, DateTime fechaConfirmacion, string nombreActividad, string descripcionActividad, DateTime fechaDeActividad, int cantMaxPersonas, int edadMinimaParaActividad, decimal costoPorPersona) : base(nombreActividad, descripcionActividad, fechaDeActividad, cantMaxPersonas, edadMinimaParaActividad, costoPorPersona)
        {
            this.proveedor = proveedor;
            this.confirmacionEmpresa = confirmacionEmpresa;
            this.fechaConfirmacion = fechaConfirmacion;

        }

        public override void ValidarActividad()
        {
            base.ValidarActividad(); //llama a la validacion de actividad
           
        }


        public override string ToString()
        {

            return base.ToString() + $" {this.confirmacionEmpresa} {this.fechaConfirmacion.ToShortDateString()} PROVEEDOR: { this.proveedor}";

        }


    }
}
