using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_CapaEntidad
{
    public class VentaProductos
    {
        private string Nombre1;
        private double PrecioUnitario1;
        private int Cantidad1;
        private double Subtotal1;

        public VentaProductos()
        {
            Nombre1 = string.Empty;
            PrecioUnitario1 = 0;
            Cantidad1 = 0;
            Subtotal1 = 0;
        }

        public VentaProductos(string nombre, double precioUnitario, int cantidad, double subtotal)
        {
            Nombre1 = nombre;
            PrecioUnitario1 = precioUnitario;
            Cantidad1 = cantidad;
            Subtotal1 = subtotal;
        }

        public string Nombre
        {
            get
            {
                return Nombre1;
            }

            set
            {
                Nombre1 = value;
            }
        }

        public double PrecioUnitario
        {
            get
            {
                return PrecioUnitario1;
            }

            set
            {
                PrecioUnitario1 = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return Cantidad1;
            }

            set
            {
                Cantidad1 = value;
            }
        }

        public double Subtotal
        {
            get
            {
                return Subtotal1;
            }

            set
            {
                Subtotal1 = value;
            }
        }
    }
}
