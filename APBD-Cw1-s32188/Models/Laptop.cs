namespace APBD_Cw1_s32188.Models;

public class Laptop(string name, string manufacturer, int productionYear, string cpu, int ramSizeGb) : Equipment(name, manufacturer, productionYear)
{
    public string Cpu { get; set; } = cpu;
    public int RamSizeGb { get; set; } = ramSizeGb;
}
