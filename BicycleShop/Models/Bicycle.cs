namespace BicycleShop.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        public string Name_bicycle { get; set; }
        public decimal Price_bicycle { get; set; }
        public bool Status_bicycle { get; set; }
        public int TypeId { get; set; }
        public TypeBicycle Type { get; set; }
    }
}
