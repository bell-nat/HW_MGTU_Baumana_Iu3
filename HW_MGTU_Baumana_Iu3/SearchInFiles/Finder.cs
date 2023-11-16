namespace HW_MGTU_Baumana_Iu3.SearchInFiles;

public class Finder(List<string> laws, List<string> decisions)
{
    public List<string> SearchLaws(string query)
        => Search(query, laws);

    public List<string> SearchDecisions(string query)
        => Search(query, decisions);


    private List<string> Search(string query, List<string> list)
    {
        List<string> result = [];
        int length = query.Length;
        foreach (string item in list)
        {
            for (int i = 0, j = 0; i < item.Length; i++)
            {
                if (item[i] == query[j]) { j++; }

                if (j == length)
                {
                    result.Add(item);
                    break;
                }
            }
        }

        return result;
    }
}