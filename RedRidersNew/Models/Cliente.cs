namespace RedRidersNew.Models
{

    public class Cliente
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? endereco { get; set; }
        public string? distanciaMoradia { get; set; }
        public string? FormaDePagamento { get; set; }
        public string? FormaDeContato { get; set; }
        public int idCresFk { get; set; }
        public int idCaloFk { get; set; }
    }
}
