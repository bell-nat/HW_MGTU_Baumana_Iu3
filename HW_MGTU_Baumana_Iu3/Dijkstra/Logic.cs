namespace HW_MGTU_Baumana_Iu3.Dijkstra;

public class Logic
{
    public void Algorithm(int[,] graph, int source, int verticesCount)
    {
        int[] distance = new int[verticesCount];
        bool[] shortestPathTreeSet = new bool[verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            distance[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
        }

        distance[source] = 0;

        for (int index = 0; index < verticesCount - 1; index++)
        {
            int min = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
            shortestPathTreeSet[min] = true;

            for (int j = 0; j < verticesCount; ++j)
            {
                if
                (
                    !shortestPathTreeSet[j] &&
                    Convert.ToBoolean(graph[min, j]) &&
                    distance[min] != int.MaxValue &&
                    distance[min] + graph[min, j] < distance[j]
                )
                { distance[j] = distance[min] + graph[min, j]; }
            }
        }
        View(distance, verticesCount);
    }

    private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int i = 0; i < verticesCount; i++)
        {
            if (shortestPathTreeSet[i] || distance[i] > min) { continue; }
            min = distance[i];
            minIndex = i;
        }

        return minIndex;
    }

    private void View(int[] distance, int verticesCount)
    {
        Console.WriteLine("Вершина\tРасстояние от источника");

        for (int i = 0; i < verticesCount; ++i)
        {
            Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }
    }
}