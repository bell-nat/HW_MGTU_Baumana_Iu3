namespace HW_NGTU_Baumana_Iu3.ArrayInversions;

public class Handler : BaseHandler
{
    public override void Start()
    {
        int[] array = [56, 23, 13, 46, 66, 12, 78, 1, 90];
        Console.WriteLine(string.Join(" ", array));

        Inversions inversions = new();
        int count = inversions.CheckInversions(array);

        Console.WriteLine(string.Join(" ", array));
        Console.WriteLine($"Количество инверсий: {count}");
    }
}