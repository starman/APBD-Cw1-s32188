namespace APBD_Cw1_s32188.Exceptions;

public class EquipmentNotAvailableException(int equipmentId) : Exception($"Equipment with id {equipmentId} is not available.");