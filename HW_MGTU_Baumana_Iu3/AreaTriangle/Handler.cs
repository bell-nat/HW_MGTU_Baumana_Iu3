namespace HW_MGTU_Baumana_Iu3.AreaTriangle;

public class Handler : BaseHandler
{
    public override void Start()
    {
        float a = ConsoleWrapper.GetFloat("Введите сторону а");
        float h = ConsoleWrapper.GetFloat("Введите высоту h");
        Math math = new();
        float result = math.GetAreaTriangle(a, h);
        Console.WriteLine(result);
        Console.WriteLine("Нажмите Enter для выхода");
        Console.ReadLine();
    }
}