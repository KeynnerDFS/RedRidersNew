namespace RedRidersNew.Models
{
	public class Veiculo
    {  
        public int Id { get; set; }
        public string nome { get; set; }
        public string modelo { get; set;}
        public string marca { get; set; }
        public string placa { get; set; }
        public string cor {  get; set; }

        public string rotaimg { get; set; }
        public string idCentFk { get; set; }
        public string idCaloFk { get; set; }
    }
}
