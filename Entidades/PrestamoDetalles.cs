using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PrestamoDetalles
    {
        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int NCuota { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey("PrestamoId")]
        public virtual Prestamos prestamos { get; set; }

        public PrestamoDetalles()
        {
            Id = 0;
            PrestamoId = 0;
            NCuota = 0;
            Fecha = DateTime.Now;
            Interes = 0;
            Capital = 0;
            Balance = 0;
        }

        public PrestamoDetalles(int cuota, int prestamoId, int ncuota, DateTime fecha, decimal interes, decimal capital, decimal balance)
        {
            Id = cuota;
            PrestamoId = prestamoId;
            NCuota = ncuota;
            Fecha = fecha;
            Interes = interes;
            Capital = capital;
            Balance = balance;
        }
    }
}
