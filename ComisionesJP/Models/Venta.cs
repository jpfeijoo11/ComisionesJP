using System;
using System.ComponentModel.DataAnnotations;

namespace ComisionesJP.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaVenta { get; set; }

        // Esto le dice a C# que hay una relación con la tabla Vendedor
        public Vendedor Vendedor { get; set; }
    }
}