using APBD_Cw1_s32188.Models;
using APBD_Cw1_s32188.Services.Equipments;
using APBD_Cw1_s32188.Services.Rentals;
using APBD_Cw1_s32188.Services.Users;

IUserService userService = new UserService();
IEquipmentService equipmentService = new EquipmentService();
IRentalService rentalService = new RentalService(userService, equipmentService);

// Add equipment of different types
var laptop = new Laptop("YOGA", "Lenovo", 2023, "Intel i7", 16);
var camera = new Camera("alfa7", "Sony", 2020, 24, true);
var projector = new Projector("N3", "JMGO", 2025, "3840 x 2160", 1800);

equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(camera);
equipmentService.AddEquipment(projector);

// Add users of different types
var student = new Student("Anna", "Nowak");
var employee = new Employee("Jan", "Kowalski");

userService.AddUser(student);
userService.AddUser(employee);

// Equipment rental example
Rental rental = rentalService.RentEquipment(laptop.Id, student.Id, 3);
Rental overdueRental = rentalService.RentEquipment(projector.Id, employee.Id, 2, new DateTime(2026, 3, 1));

// Invalid rental attempt example
try
{
    rentalService.RentEquipment(student.Id, laptop.Id, 2);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Return equipment in time
rentalService.ReturnEquipment(rental.Id);

// Return equipment - penalty applied
rentalService.ReturnEquipment(overdueRental.Id);
Console.WriteLine($"Penalty: {overdueRental.Penalty}");


// Show summary report
string report = rentalService.GenerateSummaryReport();
Console.WriteLine(report);
