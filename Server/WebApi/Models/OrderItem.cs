namespace WebApi.Models
{
    public class OrderItem
    {
        public string ItemName { get; set; }
        
        public EquipmentType Type { get; set; }

        public int Days { get; set; }
    }

    public enum EquipmentType
    {
        Heavy = 1,
        Regular = 2,
        Specialized = 3
    }
}
