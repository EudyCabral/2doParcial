﻿using System;
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
        public decimal Capital { get; set; }
        public int Interes { get; set; }
        public int Tiempo { get; set; }

        public virtual List<PrestamoDetalles> Detalles { get; set; }

        public Prestamos()
        {
            this.Detalles = new List<PrestamoDetalles>();
        }

        public void AgregarDetalle(int cuota, int prestamoId, DateTime fecha, decimal interes, decimal capital, decimal balance)
        {
            this.Detalles.Add(new PrestamoDetalles(cuota, prestamoId, fecha, interes, capital, balance));
        }

        
    }
}
