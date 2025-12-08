namespace RedRidersNew.Models

{

    public class Pratos
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public float? preco { get; set; }
        public string? descricao { get; set; }
        public int? idCcarFk { get; set; }
        public int? idCaloFk { get; set; }
    }
}
