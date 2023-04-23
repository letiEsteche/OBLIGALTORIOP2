using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadTercearizada:Actividad
    {
        Proveedor proveedor;
        bool confirmadaPorEmpresa;
        DateTime fechaConfirmacion;

       
        public bool ConfirmadaPorEmpresa { get => confirmadaPorEmpresa; set => confirmadaPorEmpresa = value; }
        public DateTime FechaConfirmacion { get => fechaConfirmacion; set => fechaConfirmacion = value; }

        public ActividadTercearizada(Proveedor proveedor, bool confirmadaPorEmpresa, DateTime fechaConfirmacion, string nombreActividad, string descripcionActividad, DateTime fechaDeActividad, int cantMaxPersonas, int edadMinimaParaActividad, decimal costoPorPersona) : base(nombreActividad, descripcionActividad, fechaDeActividad, cantMaxPersonas, edadMinimaParaActividad, costoPorPersona)
        {
            this.proveedor = proveedor;
            this.confirmadaPorEmpresa = confirmadaPorEmpresa;
            this.fechaConfirmacion = fechaConfirmacion;
        }





    }
}
