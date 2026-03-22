using APBD_Cw1_s32188.Enums;
using APBD_Cw1_s32188.Exceptions;
using APBD_Cw1_s32188.Models;
using APBD_Cw1_s32188.Services.Equipments;
using APBD_Cw1_s32188.Services.Users;

namespace APBD_Cw1_s32188.Services.Rentals;

public class RentalService(IUserService userService, IEquipmentService equipmentService)
    : IRentalService
{
    private readonly IUserService _userService = userService;
    private readonly IEquipmentService _equipmentService = equipmentService;
    private readonly List<Rental> _rentals = new();

    public Rental RentEquipment(int equipmentId, int userId, int days, DateTime? rentalDate = null)
    {
        var user = _userService.GetUserById(userId);
        var equipment = _equipmentService.GetEquipmentById(equipmentId);
        
        if (equipment.Status != EquipmentStatus.Available)
            throw new EquipmentNotAvailableException(equipmentId);
        
        int activeRentals = _rentals.Count(r => r.User.Id == userId && r.ReturnDate == null);
        if (activeRentals >= user.MaxRentals)
            throw new RentalLimitExceededException(userId);
        
        var rental = new Rental(user, equipment, rentalDate ?? DateTime.Now, days);
        
        _equipmentService.SetUnavailable(equipmentId);
        _rentals.Add(rental);
        
        return rental;
    }

    public void ReturnEquipment(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId)
                     ?? throw new RentalNotFoundException(rentalId);
        
        if (rental.ReturnDate != null)
            throw new Exception("Rental already returned");
        
        rental.ReturnDate = DateTime.Now;
        _equipmentService.SetAvailable(rental.Equipment.Id);
        
        var dueDate = rental.RentalDate.AddDays(rental.Days);

        if (rental.ReturnDate > dueDate)
        {
            int daysLate = (rental.ReturnDate.Value - dueDate).Days;
            rental.Penalty = CalculatePenalty(daysLate);
        }
    }

    public List<Rental> GetActiveUserRentals(int userId)
    {
        return _rentals
            .Where(r => r.User.Id == userId && r.ReturnDate == null)
            .ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals
            .Where(r => r.ReturnDate == null && r.RentalDate.AddDays(r.Days) < DateTime.Now)
            .ToList();
    }

    public string GenerateSummaryReport()
    {
        int totalEquipment = _equipmentService.GetAll().Count;
        int availableEquipment = _equipmentService.GetAvailable().Count;
        int unavailableEquipment = totalEquipment - availableEquipment;
        
        int totalRentals = _rentals.Count;
        int activeRentals = _rentals.Count(r => r.ReturnDate == null);
        int overdueRentals = _rentals.Count(r => r.ReturnDate == null && r.RentalDate.AddDays(r.Days) < DateTime.Now);
        
        decimal totalPenalties = _rentals.Sum(r => r.Penalty);
        
        return $@"
            Rental Summary Report
            ---------------------
            Total equipment: {totalEquipment}
            Available: {availableEquipment}
            Unavailable: {unavailableEquipment}

            Total rentals: {totalRentals}
            Active rentals: {activeRentals}
            Overdue rentals: {overdueRentals}

            Total penalties: {totalPenalties}
            ";
    }

    private decimal CalculatePenalty(int daysLate)
    {
        return daysLate * 10;
    }
}