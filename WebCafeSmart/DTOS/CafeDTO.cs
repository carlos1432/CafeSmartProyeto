namespace WebCafeSmart.DTOS
{
    public class CafeDTO
    {
        public int IdCafe { get; set; }
        public string CafeNombre { get; set; }
        public string CafeDescripcion { get; set; }
        public decimal PrecioBase { get; set; }
        public string Tipo { get; set; }
        public string Caracteristicas { get; set; }  // Lista de características concatenadas
        public decimal PrecioAjusteCaracteristica { get; set; }
        public string DescripcionTipo { get; set; }
        public decimal PrecioFinal { get; set; }
    }
}
