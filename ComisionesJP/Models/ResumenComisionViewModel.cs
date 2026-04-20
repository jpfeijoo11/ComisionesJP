namespace ComisionesJP.Models
{
    public class ResumenComisionViewModel
    {
        public string NombreVendedor { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal PorcentajeAplicado { get; set; }
        public decimal ComisionCalculada { get; set; }
    }
}
