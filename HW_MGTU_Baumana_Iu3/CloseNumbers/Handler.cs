namespace HW_MGTU_Baumana_Iu3.CloseNumbers;

public class Handler : BaseHandler
{
    public override void Start()
    {
        int sizeA = ConsoleWrapper.GetInt("Введите размер массива А");
        int[] arrayA = new int[sizeA];
        for (int i = 0; i < sizeA; i++)
        {
            arrayA[i] = ConsoleWrapper.GetInt("Введите значение");
        }
        Array.Sort(arrayA);
        Array.Reverse(arrayA);

        int sizeB = ConsoleWrapper.GetInt("Введите размер массива B");
        int[] arrayB = new int[sizeB];
        for (int i = 0; i < sizeB; i++)
        {
            arrayB[i] = ConsoleWrapper.GetInt("Введите значение");
        }

        Console.Write("Массив А: ");
        Console.WriteLine(string.Join(", ", arrayA));
        Console.Write("Массив B: ");
        Console.WriteLine(string.Join(", ", arrayB));

        for (int i = 0; i < sizeB; i++)
        {
            List<int> difference = new();
            for (int j = 0; j < sizeA; j++)
            {
                difference.Add(arrayB[i] - arrayA[j]);
            }

            difference = difference.Select(item =>
            {
                if (item < 0) { item *= -1; }
                return item;
            }).ToList();

            int min = difference.Min();

            List<int> indexes = new();
            for (int j = 0; j < sizeA; j++)
            {
                if (difference[j] == min) { indexes.Add(j); }
            }
            Console.WriteLine($"{arrayB[i]} - {string.Join(" ", indexes.Select(index => arrayA[index]))}");
        }
    }
}