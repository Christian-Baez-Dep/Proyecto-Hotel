namespace Entidades.Modelo
{
    public class Room
    {
        public int Id { get; set; }
        public string CodeRoom { get; set; }
        public float Rating { get; set; }
        public double Price { get; set; }
        public int Beds {  get; set; }
        public bool isAvailable { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
