namespace HW_NGTU_Baumana_Iu3.Dijkstra;

public class Handler : BaseHandler
{
    private readonly int[,] _graph =
    {
        { 0, 7, 0, 0, 0,  0, 0,  0, 0, 0 },
        { 7, 0, 4, 2, 4,  0, 0,  0, 0, 0 },
        { 0, 4, 0, 1, 0,  0, 0,  0, 0, 0 },
        { 0, 2, 1, 0, 0,  0, 0,  0, 0, 0 },
        { 0, 4, 0, 0, 0,  2, 2,  0, 0, 0 },
        { 0, 0, 0, 0, 2,  0, 2, 12, 0, 0 },
        { 0, 0, 0, 0, 2,  2, 0,  3, 0, 0 },
        { 0, 0, 0, 0, 0, 12, 3,  0, 2, 1 },
        { 0, 0, 0, 0, 0,  0, 0,  2, 0, 1 },
        { 0, 0, 0, 0, 0,  0, 0,  1, 1, 0 }
    };
    
    public override void Start()
    {
        Logic logic = new();
        Console.WriteLine("Дан граф");
        for (int i = 0; i < _graph.GetLength(0); i++)
        {
            for (int j = 0; j < _graph.GetLength(1); j++)
            {
                Console.Write($"{_graph[i, j]} ");
            }
            Console.WriteLine();
        }

        logic.Algorithm(_graph, 1, 10);
        Console.ReadKey();
    }
}