namespace AppRedRidersBlazor.Models
{
    public class Entregador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string cnh { get; set; }
        public string telefone { get; set; }
        public int idCaloFk { get; set; }
    }
}
