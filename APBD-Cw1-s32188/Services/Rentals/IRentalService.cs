using APBD_Cw1_s32188.Models;

namespace APBD_Cw1_s32188.Services.Rentals;

public interface IRentalService
{
    void RentEquipment(int equipmentId, int userId, int days);
    void ReturnEquipment(int rentalId);
    
    List<Rental> GetActiveUserRentals(int userId);
    List<Rental> GetOverdueRentals();
    
    string GenerateSummaryReport();
}