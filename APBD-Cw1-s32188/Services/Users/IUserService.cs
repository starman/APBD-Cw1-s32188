using APBD_Cw1_s32188.Models;

namespace APBD_Cw1_s32188.Services.Users;

public interface IUserService
{
    void AddUser(User user);
    User GetUserById(int userId);
    List<User> GetAll();
}