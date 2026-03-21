using APBD_Cw1_s32188.Enums;

namespace APBD_Cw1_s32188.Models;

public abstract class Equipment(string name, string manufacturer, int productionYear)
{
    private static int _nextId = 1;
    
    public int Id { get; } = _nextId++;
    public string Name { get; set; } = name;
    public string Manufacturer { get; set; } = manufacturer;
    public int ProductionYear { get; set; } = productionYear;
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
}
