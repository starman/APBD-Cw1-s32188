namespace APBD_Cw1_s32188.Models;

public class Rental(User user, Equipment equipment, DateTime rentalDate, int days)
{
    private static int _nextId = 1;
    
    public int Id { get; set; } = _nextId++;
    public User user { get; set; } = user;
    public Equipment equipment { get; set; } = equipment;
    public DateTime RentalDate { get; set; } = rentalDate;
    public int Days { get; set; } = days;
    public DateTime? ReturnDate { get; set; } = null;
}
