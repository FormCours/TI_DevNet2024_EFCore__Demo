namespace Demo_EF.Models
{
    public class Car
    {
        public enum StateEnum {
            NEW,
            OCCASION,
            FOR_PARTS
        }

        public int Id { get; set; }
        // TODO Add Brand with relation
        public required string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public StateEnum State { get; set; }
    }
}
