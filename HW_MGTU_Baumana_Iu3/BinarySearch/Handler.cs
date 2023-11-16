namespace HW_MGTU_Baumana_Iu3.BinarySearch;

public class Handler : BaseHandler
{
    public override void Start()
    {
        Binary binary = new();
        List<int> array = [1, 2, 4, 5, 6, 7, 80, 91, 100, 102, 376, 999];
        Console.WriteLine($"Дан массив: {string.Join(" ", array)}");
        Console.WriteLine("Введите число для поиска");
        int search = int.Parse(Console.ReadLine());
        int index = binary.Search(array, search);
        Console.WriteLine($"Индекс: {index}, для числа {search}");
    }
}