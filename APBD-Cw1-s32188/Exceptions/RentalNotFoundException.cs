namespace APBD_Cw1_s32188.Exceptions;

public class RentalNotFoundException(int rentalId) : Exception($"Rental with id {rentalId} not found.");