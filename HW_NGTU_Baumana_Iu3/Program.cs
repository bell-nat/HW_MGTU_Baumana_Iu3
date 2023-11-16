using HW_NGTU_Baumana_Iu3;

while (true)
{
    Console.WriteLine("Выберите задание");
    Console.WriteLine(" 1. AreaTriangle");
    Console.WriteLine(" 2. ArrayInversions");
    Console.WriteLine(" 3. CloseNumbers");
    Console.WriteLine(" 4. BinarySearch");
    Console.WriteLine(" 5. HashTable");
    Console.WriteLine(" 6. Tree");
    Console.WriteLine(" 7. RedTree");
    Console.WriteLine(" 8. D-L Distance");
    Console.WriteLine(" 9. Dijkstra");
    Console.WriteLine("10. SearchInFiles");
    int index = int.Parse(Console.ReadLine());
    BaseHandler handler = index switch
    {
        1 => new HW_NGTU_Baumana_Iu3.AreaTriangle.Handler(),
        2 => new HW_NGTU_Baumana_Iu3.ArrayInversions.Handler(),
        3 => new HW_NGTU_Baumana_Iu3.CloseNumbers.Handler(),
        4 => new HW_NGTU_Baumana_Iu3.BinarySearch.Handler(),
        5 => new HW_NGTU_Baumana_Iu3.HashTable.Handler(),
        6 => new HW_NGTU_Baumana_Iu3.BaseTree.Handler(),
        7 => new HW_NGTU_Baumana_Iu3.RedTree.Handler(),
        8 => new HW_NGTU_Baumana_Iu3.DamerauLevenshteinDistance.Handler(),
        9 => new HW_NGTU_Baumana_Iu3.Dijkstra.Handler(),
        10 => new HW_NGTU_Baumana_Iu3.SearchInFiles.Handler(),
    };
    handler.Start();
    Console.WriteLine("Для выхода нажмите Esc, для продолжения любую клавишу");
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.Escape)
    {
        break;
    }
}