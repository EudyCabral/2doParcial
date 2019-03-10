using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cuenta { get; set; }
        public string NombreCuenta { get; set; }
        public decimal Capital { get; set; }
        public int Interes { get; set; }
        public int Tiempo { get; set; }
        public decimal Balance { get; set; }

        public virtual List<PrestamoDetalles> Detalles { get; set; }

        public Prestamos()
        {
            this.Detalles = new List<PrestamoDetalles>();
            PrestamoId = 0;
            Fecha = DateTime.Now;
            NombreCuenta = string.Empty;
            Cuenta = 0;
            Capital = 0;
            Interes = 0;
            Tiempo = 0;
            Balance = 0;
        }

        public void AgregarDetalle(int id, int prestamoId,int ncuota, DateTime fecha, decimal interes, decimal capital, decimal balance)
        {
            this.Detalles.Add(new PrestamoDetalles(id, prestamoId,ncuota, fecha, interes, capital, balance));
        }

        

    }
}
