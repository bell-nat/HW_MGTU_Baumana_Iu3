namespace HW_NGTU_Baumana_Iu3.RedTree;

/// <summary>
/// 1. Для наборов чисел из строки «Добавить» в варианте построить красно-черное дерево.
/// Необходимо добавить элементы в дерево в том порядке, в котором они даны.
/// При необходимости выполнить балансировку дерева.
/// 2. Удалить из дерева указанные элементы из строки \"Удалить\" в варианте в том порядке,
/// в котором они даны. При необходимости выполнить балансировку дерева.
/// Пункт 2 выполняется после завершения пункта 1.
/// </summary>
public class Handler : BaseHandler
{
    public override void Start()
    {
        int[] array = [1,2,3,4,5,6,7,8,9];
        Console.Write("Дан массив");
        Console.WriteLine(string.Join(" ", array));
        RedTree redTree = new(array.First());
        foreach (int digital in array.Skip(1))
        {
            redTree.Insert(digital);
        }
        redTree.Print();

        int[] remove = [6, 5, 9];
        Console.Write("Удаляем");
        Console.WriteLine(string.Join(" ", remove));
        foreach (int digital in remove)
        {
            redTree.Remove(digital);
        }
        redTree.Print();
    }
}