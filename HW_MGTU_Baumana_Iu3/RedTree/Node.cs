using System.Drawing;

namespace HW_MGTU_Baumana_Iu3.RedTree;

public class Node(int value)
{
    public int Value { get; set; } = value;
    public Color NodeColor { get; set; } = Color.Red;
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public Node? Parent { get; set; }
    
    public void Print(string indent, bool last)
    {
        Console.Write(indent);
        Console.Write(last ? "└─" : "├─");
        indent += last ? "  " : "| ";

        Console.ForegroundColor = NodeColor == Color.Black ? ConsoleColor.Blue : ConsoleColor.Red;
        Console.WriteLine(Value);
        Console.ForegroundColor = ConsoleColor.White;

        List<Node> children = [];
        if (Left is not null) { children.Add(Left); }
        if (Right is not null) { children.Add(Right); }

        for (int i = 0; i < children.Count; i++)
        {
            children[i].Print(indent, i == children.Count - 1);
        }
    }
}