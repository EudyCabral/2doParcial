using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PrestamoDetalles
    {
        [Key]
        public int Cuota { get; set; }
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Balance { get; set; }

        public PrestamoDetalles()
        {
            Cuota = 0;
            PrestamoId = 0;
            Fecha = DateTime.Now;
            Interes = 0;
            Capital = 0;
            Balance = 0;
        }

        public PrestamoDetalles(int cuota, int prestamoId, DateTime fecha, decimal interes, decimal capital, decimal balance)
        {
            Cuota = cuota;
            PrestamoId = prestamoId;
            Fecha = fecha;
            Interes = interes;
            Capital = capital;
            Balance = balance;
        }
    }
}
