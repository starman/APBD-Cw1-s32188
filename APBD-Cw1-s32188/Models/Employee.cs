namespace APBD_Cw1_s32188.Models;

public class Employee(string firstName, string lastName) : User(firstName, lastName)
{
    public override int MaxRentals => 5;
}
