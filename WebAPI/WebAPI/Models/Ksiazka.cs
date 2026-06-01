namespace WebAPI.Models
{
    public class Ksiazka
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public double Cena { get; set; }
        public DateOnly DataWydania { get; set; }
    }
}
