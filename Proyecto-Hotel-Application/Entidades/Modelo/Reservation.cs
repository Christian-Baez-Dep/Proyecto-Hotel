namespace Entidades.Modelo
{
    public class Reservation
    {
        public int Id {  get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public int IdRoom { get; set; }
        public Room Room { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

    }
}