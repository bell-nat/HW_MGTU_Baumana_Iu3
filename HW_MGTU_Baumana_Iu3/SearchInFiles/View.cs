namespace HW_MGTU_Baumana_Iu3.SearchInFiles
{
    public class Viewer
    {
        public void View(ref List<string> laws, ref List<string> decisions, ref string query)
        {
            Console.WriteLine($"Запрос: {query}");
            Console.WriteLine();
            Console.WriteLine("Законы:");
            laws.ForEach(Console.WriteLine);
            Console.WriteLine("----------------");
            Console.WriteLine("Решения:");
            decisions.ForEach(Console.WriteLine);
        }
    }
}