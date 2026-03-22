using APBD_Cw1_s32188.Models;

namespace APBD_Cw1_s32188.Services.Rentals;

public interface IRentalService
{
    Rental RentEquipment(int equipmentId, int userId, int days, DateTime? rentDate = null);
    void ReturnEquipment(int rentalId);
    
    List<Rental> GetActiveUserRentals(int userId);
    List<Rental> GetOverdueRentals();
    
    string GenerateSummaryReport();
}