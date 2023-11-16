namespace HW_NGTU_Baumana_Iu3.DamerauLevenshteinDistance;

public class Distance
{
    public int DamerauLevenshteinDistance(string first, string second)
    {
        int[,] distance = new int[first.Length + 1, second.Length + 1];

        for (int i = 0; i <= first.Length; i++) { distance[i, 0] = i; }
        for (int i = 0; i <= second.Length; i++) { distance[0, i] = i; }

        for (int i = 1; i <= first.Length; i++)
        {
            for (int j = 1; j <= second.Length; j++)
            {
                int cost = (first[i - 1] == second[j - 1]) ? 0 : 1;

                distance[i, j] = Math.Min
                (
                    Math.Min
                    (
                        distance[i - 1, j] + 1,
                        distance[i, j - 1] + 1
                    ),
                    distance[i - 1, j - 1] + cost
                );

                if (i > 1 && j > 1 && first[i - 1] == second[j - 2] && first[i - 2] == second[j - 1])
                {
                    distance[i, j] = Math.Min(distance[i, j], distance[i - 2, j - 2] + cost);
                }
            }
        }

        return distance[first.Length, second.Length];
    }
}