namespace APBD_Cw1_s32188.Exceptions;

public class UserNotFoundException(int userId) : Exception($"User with id {userId} not found.");