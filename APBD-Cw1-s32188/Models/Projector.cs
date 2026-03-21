namespace APBD_Cw1_s32188.Models;

public class Projector(string name, string manufacturer, int productionYear, string resolution, int lumens) : Equipment(name, manufacturer, productionYear)
{
    public string Resolution { get; set; } = resolution;
    public int Lumens { get; set; } = lumens;
}
