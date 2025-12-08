using System.Security.Cryptography.Xml;

namespace RedRidersNew.Models
{

    public class Cardapio
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }
        public int idCresFk { get; set; }
       

    }
}
