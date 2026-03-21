namespace APBD_Cw1_s32188.Models;

public class Camera(string name, string manufacturer, int productionYear, int megapixels, bool isDigital) : Equipment(name, manufacturer, productionYear)
{
    public int Megapixels { get; set; } = megapixels;
    public bool IsDigital { get; set; } = isDigital;
}
