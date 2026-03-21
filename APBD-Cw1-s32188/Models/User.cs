namespace APBD_Cw1_s32188.Models;

public abstract class User(string firstName, string lastName)
{
    private static int _nextId = 1;
    
    public int Id { get; set; } = _nextId++;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
}
