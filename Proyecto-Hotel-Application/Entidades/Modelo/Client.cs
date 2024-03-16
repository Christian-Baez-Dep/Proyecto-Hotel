namespace Entidades.Modelo
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set;}
        public DateTime BirthDate {  get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Reservation> Reservations { get; set; }



    }
}
