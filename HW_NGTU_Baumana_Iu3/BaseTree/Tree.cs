namespace HW_NGTU_Baumana_Iu3.BaseTree;

public class Tree(int first)
{
    public Node Head { get; set; } = new(first);

    public void Insert(int data) => Head = Insert(Head, data);

    private Node Insert(Node? node, int data)
    {
        if (node is null)
        {
            node = new Node(data);
            return node;
        }

        int hash = data.GetHashCode();
        if (hash < node.Hash)
        {
            node.Left = Insert(node.Left, data);
        }
        else if (hash > node.Hash)
        {
            node.Right = Insert(node.Right, data);
        }

        return node;
    }

    public void Remove(int key) => Head = Remove(Head, key);

    public Node? Remove(Node? node, int key)
    {
        if (node is null) { return null; }
        int hash = key.GetHashCode();
        if (hash < node.Hash)
        {
            node.Left = Remove(node.Left, key);
        }
        else if (hash > node.Hash)
        {
            node.Right = Remove(node.Right, key);
        }
        else
        {
            if (node.Left is null) { return node.Right; }
            else if (node.Right is null) { return node.Left; }
            node.Data = MinValue(node.Right);
            node.Right = Remove(node.Right, node.Data);
        }

        return node;
    }

    private int MinValue(Node node)
    {
        int value = node.Data;
        while (node.Left is not null)
        {
            value = node.Left.Data;
            node = node.Left;
        }
        return value;
    }

    public void Print()
    {
        Console.WriteLine();
        Head.Print(string.Empty, true);
    }
}