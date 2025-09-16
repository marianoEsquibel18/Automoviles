namespace ApiAutomoviles.Models
{
    public class Automovil
    {
        public int Id { get; set; } // autoincremental
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Fabricacion { get; set; }
        public string NumeroMotor { get; set; } // único
        public string NumeroChasis { get; set; } // único
    }
}
