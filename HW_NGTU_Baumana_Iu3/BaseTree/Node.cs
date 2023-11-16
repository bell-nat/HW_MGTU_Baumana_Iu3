namespace HW_NGTU_Baumana_Iu3.BaseTree;

public class Node(int data)
{
    public int Data { get; set; } = data;
    public int Hash => data;
    public Node? Right { get; set; } = null;
    public Node? Left { get; set; } = null;

    public void Print(string indent, bool last)
    {
        Console.Write(indent);
        Console.Write(last ? "└─" : "├─");
        indent += last ? "  " : "| ";
        Console.WriteLine(Data);

        List<Node> children = [];
        if (Left is not null) { children.Add(Left); }
        if (Right is not null) { children.Add(Right); }

        for (int i = 0; i < children.Count; i++)
        {
            children[i].Print(indent, i == children.Count - 1);
        }
    }
}