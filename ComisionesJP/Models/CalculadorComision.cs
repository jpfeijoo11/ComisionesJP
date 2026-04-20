using System.ComponentModel.DataAnnotations;

namespace ComisionesJP.Models
{
    public class CalculadorComision
    {
        [Key]
        public int Id { get; set; }
        public decimal MontoMinimo { get; set; }
        public decimal MontoMaximo { get; set; }
        public decimal Porcentaje { get; set; }
    }
}