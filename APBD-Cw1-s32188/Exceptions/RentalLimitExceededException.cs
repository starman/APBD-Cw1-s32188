namespace APBD_Cw1_s32188.Exceptions;

public class RentalLimitExceededException(int userId) : Exception($"User with id {userId} exceeded rental limit.");