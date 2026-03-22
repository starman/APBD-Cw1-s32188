using APBD_Cw1_s32188.Models;

namespace APBD_Cw1_s32188.Services.Equipments;

public interface IEquipmentService
{
    public void AddEquipment(Equipment equipment);
    public Equipment GetEquipmentById(int equipmentId);
    public List<Equipment> GetAll();
    public List<Equipment> GetAvailable();
    public void SetAvailable(int equipmentId);
    public void SetUnavailable(int equipmentId);
}