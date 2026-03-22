using APBD_Cw1_s32188.Enums;
using APBD_Cw1_s32188.Exceptions;
using APBD_Cw1_s32188.Models;

namespace APBD_Cw1_s32188.Services.Equipments;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipments = new List<Equipment>();
    
    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
    }

    public Equipment GetEquipmentById(int equipmentId)
    {
        return _equipments.FirstOrDefault(equipment => equipment.Id == equipmentId) 
               ?? throw new EquipmentNotFoundException(equipmentId);
    }

    public List<Equipment> GetAll()
    {
        return _equipments;
    }

    public List<Equipment> GetAvailable()
    {
        return _equipments.Where(equipment => equipment.Status == EquipmentStatus.Available).ToList();
    }

    public void SetAvailable(int equipmentId)
    {
        GetEquipmentById(equipmentId).Status = EquipmentStatus.Available;
    }

    public void SetUnavailable(int equipmentId)
    {
        GetEquipmentById(equipmentId).Status = EquipmentStatus.Unavailable;
    }
}
