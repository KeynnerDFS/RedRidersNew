using Microsoft.AspNetCore.Http.HttpResults;

namespace AppRedRidersBlazor.Models
{

    public class Pedido
    {
        public int id { get; set; }
        public string nomeRestaurante { get; set; }
        public float? PrecoPelaEntrega { get; set; }
        public string? OndeEntregar { get; set; }
        public string? OndeBuscar { get; set; }
        public string? distancia { get; set; }
        public int? Quantidade { get; set; }
        public string? Descricao { get; set; }
        public string? Cliente { get; set; }
        public string? Status { get; set; }
        public int idCresFk { get; set; }
        public int idCentFk { get; set; }
        public int idCaloFk { get; set; }
    }
}

