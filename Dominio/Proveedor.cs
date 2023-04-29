using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor: IComparable<Proveedor>
    {
        private static int cuentaProveedor = 0;
        int idProveedor;
        string? nombreProveedor;
        string? telefonoProveedor;
        string? direccionProveedor;
        int descuentoParaTodaActividadTercearizada;

        
        public string? NombreProveedor { get => nombreProveedor; set => nombreProveedor = value; }
        public string? TelefonoProveedor { get => telefonoProveedor; set => telefonoProveedor = value; }
        public string? DireccionProveedor { get => direccionProveedor; set => direccionProveedor = value; }
        public int DescuentoParaTodaActividadTercearizada { get => descuentoParaTodaActividadTercearizada; set => descuentoParaTodaActividadTercearizada = value; }
        public static int CuentaProveedor { get => cuentaProveedor; }
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }

        public Proveedor() { }
        public Proveedor(string? nombreProveedor, string? telefonoProveedor, string? direccionProveedor, int descuentoParaTodaActividadTercearizada)
        {
            this.nombreProveedor = nombreProveedor;
            this.telefonoProveedor = telefonoProveedor;
            this.direccionProveedor = direccionProveedor;
            this.descuentoParaTodaActividadTercearizada = descuentoParaTodaActividadTercearizada;
            this.IdProveedor = cuentaProveedor++;
        }

        public void Validar()
        {

            ValidarNombreProveedor();
            ValidarTelefono();
            ValidarDireccion();


        }

        private void ValidarNombreProveedor()
        {
            if (!(this.nombreProveedor != ""))
            {
               throw new Exception($"Nombre de proveedor {CuentaProveedor} no puede ser nulo.");
            }
        }

        private void ValidarTelefono()
        {
            if (!(this.telefonoProveedor != ""))
            {
                throw new Exception($"Teléfono de proveedor {CuentaProveedor} inválido.");
            }
        }

        private void ValidarDireccion()
        {
            if (!(this.direccionProveedor != ""))
            {
                throw new Exception($"Direccion de proveedor {CuentaProveedor} no puede ser vacía.");
            }
        }



        //tengo que controlar que el proveedor no exista, por lo que comparo dos objetos
        public override bool Equals(object? obj)
        {
            //aca lo que hace es transformar el parametro proveedorNombre en un objeto Equals
            Proveedor? proveedorNombre = obj as Proveedor;

            //si el parametro es nulo me devuelve false
            if (proveedorNombre == null) return false;
            //comparo el nombre del proveedor con los nombres de la lista
            return this.nombreProveedor.Equals(proveedorNombre.nombreProveedor);
        }

        //esto tiene que ir
        public override int GetHashCode()
        {
            return this.nombreProveedor.GetHashCode();
        }

        //compareTo me sirve para ordenar una lista

        public int CompareTo(Proveedor proveedor)
        {
            return this.nombreProveedor.CompareTo(proveedor.nombreProveedor);
        }


        //me permite imprimir la lista de los proveedores

        public override string ToString()
        {
            return $"{this.IdProveedor} {this.nombreProveedor}, Telefono: {this.telefonoProveedor}, Direccion: {this.direccionProveedor} Descuento: {this.descuentoParaTodaActividadTercearizada}";
        }



    }
}
