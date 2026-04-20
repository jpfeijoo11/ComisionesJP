using System.ComponentModel.DataAnnotations;

namespace ComisionesJP.Models
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
    }
}