namespace SkiLand.Domain.Entities
{
    public class Equipment : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public EquipmentState EquipmentState { get; set; }
        public EquipmentRental EquipmentRental { get; set; }
        public decimal Price { get; set; }
    }
}
