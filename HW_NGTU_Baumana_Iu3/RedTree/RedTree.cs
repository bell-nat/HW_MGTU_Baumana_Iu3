using System.Drawing;

namespace HW_NGTU_Baumana_Iu3.RedTree;

public class RedTree(int data)
{
    private Node? _head = new(data);

    public void Insert(int value)
    {
        Node newNode = new(value);

        Node? current = _head;
        Node? parent = null;
        while (current is not null)
        {
            parent = current;
            current = value < current.Value ? current.Left : current.Right;
        }

        newNode.Parent = parent;
        if (value < parent.Value) { parent.Left = newNode; }
        else { parent.Right = newNode; }

        FixTreeInsert(newNode);
    }

    public void Remove(int value)
    {
        Node? node = FindNode(value);
        if (node is null) { return; }
        RemoveNode(node);
    }

    private Node? FindNode(int value)
    {
        Node? current = _head;
        while (current is not null)
        {
            if (value == current.Value) { return current; }
            current = value < current.Value ? current.Left : current.Right;
        }
        return null;
    }

    private Node? FindInOrderSuccessor(Node node)
    {
        Node? current = node.Right;
        while (current?.Left is not null)
        {
            current = current.Left;
        }
        return current;
    }

    private void SwapNodes(Node first, Node second)
    {
        (first.Value, second.Value) = (second.Value, first.Value);
        (first.NodeColor, second.NodeColor) = (second.NodeColor, first.NodeColor);
    }

    private void RemoveNode(Node node)
    {
        if (node is { Left: not null, Right: not null })
        {
            Node? replaceNode = FindInOrderSuccessor(node);
            SwapNodes(node, replaceNode);
            node = replaceNode;
        }

        Node? child = node.Left ?? node.Right;

        Node? parent = node.Parent;

        if (child is not null) { child.Parent = parent; }
        if (parent is null) { _head = child; }
        else
        {
            if (node == parent.Left) { parent.Left = child; }
            else { parent.Right = child; }
            if (node.NodeColor == Color.Black)
            {
                FixTreeRemove(child, parent);
            }
        }
    }

    private void FixTreeRemove(Node node, Node parent)
    {
        while (node != _head && (node is null || node.NodeColor == Color.Black))
        {
            Node sibling;
            if (node == parent.Left)
            {
                sibling = parent.Right;
                if (sibling.NodeColor == Color.Red)
                {
                    sibling.NodeColor = Color.Black;
                    parent.NodeColor = Color.Red;
                    RotateLeft(parent);
                    sibling = parent.Right;
                }

                if ((sibling.Left == null || sibling.Left.NodeColor == Color.Black) &&
                    (sibling.Right == null || sibling.Right.NodeColor == Color.Black))
                {
                    sibling.NodeColor = Color.Red;
                    node = parent;
                    parent = node.Parent;
                }
                else
                {
                    if (sibling.Right == null || sibling.Right.NodeColor == Color.Black)
                    {
                        sibling.Left.NodeColor = Color.Black;
                        sibling.NodeColor = Color.Red;
                        RotateRight(sibling);
                        sibling = parent.Right;
                    }
                    sibling.NodeColor = parent.NodeColor;
                    parent.NodeColor = Color.Black;
                    sibling.Right.NodeColor = Color.Black;
                    RotateLeft(parent);
                    node = _head;
                }
            }
            else
            {
                sibling = parent.Left;
                if (sibling.NodeColor == Color.Red)
                {
                    sibling.NodeColor = Color.Black;
                    parent.NodeColor = Color.Red;
                    RotateRight(parent);
                    sibling = parent.Left;
                }

                if
                (
                    (sibling.Right == null || sibling.Right.NodeColor == Color.Black) &&
                    (sibling.Left == null || sibling.Left.NodeColor == Color.Black))
                {
                    sibling.NodeColor = Color.Red;
                    node = parent;
                    parent = node.Parent;
                }
                else
                {
                    if (sibling.Left == null || sibling.Left.NodeColor == Color.Black)
                    {
                        sibling.Right.NodeColor = Color.Black;
                        sibling.NodeColor = Color.Red;
                        RotateLeft(sibling);
                        sibling = parent.Left;
                    }

                    sibling.NodeColor = parent.NodeColor;
                    parent.NodeColor = Color.Black;
                    sibling.Left.NodeColor = Color.Black;
                    RotateRight(parent);
                    node = _head;
                }
            }
        }

        if (node is not null) { node.NodeColor = Color.Black; }
    }

    public void Print()
    {
        Console.WriteLine();
        _head?.Print(string.Empty, true);
    }

    private void FixTreeInsert(Node node)
    {
        while (node.Parent != null && node != _head && node.Parent.NodeColor == Color.Red)
        {
            if (node.Parent == node.Parent.Parent?.Left)
            {
                Node? uncle = node.Parent.Parent.Right;

                if (uncle is not null && uncle.NodeColor == Color.Red)
                {
                    node.Parent.NodeColor = Color.Black;
                    uncle.NodeColor = Color.Black;
                    node.Parent.Parent.NodeColor = Color.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Right)
                    {
                        node = node.Parent;
                        RotateLeft(node);
                    }

                    node.Parent.NodeColor = Color.Black;
                    if (node.Parent.Parent != null)
                    {
                        node.Parent.Parent.NodeColor = Color.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
            }
            else
            {
                Node? uncle = node.Parent.Parent?.Left;

                if (uncle != null && uncle.NodeColor == Color.Red)
                {
                    node.Parent.NodeColor = Color.Black;
                    uncle.NodeColor = Color.Black;
                    if (node.Parent.Parent is not null)
                    {
                        node.Parent.Parent.NodeColor = Color.Red;
                        node = node.Parent.Parent;
                    }
                }
                else
                {
                    if (node == node.Parent.Left)
                    {
                        node = node.Parent;
                        RotateRight(node);
                    }

                    if (node.Parent != null)
                    {
                        node.Parent.NodeColor = Color.Black;
                        if (node.Parent.Parent is not null)
                        {
                            node.Parent.Parent.NodeColor = Color.Red;
                            RotateLeft(node.Parent.Parent);
                        }
                    }
                }
            }
        }

        _head.NodeColor = Color.Black;
    }

    private void RotateLeft(Node node)
    {
        Node? rightChild = node.Right;
        node.Right = rightChild?.Left;

        if (rightChild?.Left is not null) { rightChild.Left.Parent = node; }

        if (rightChild is not null)
        {
            rightChild.Parent = node.Parent;
            if (node.Parent is null) { _head = rightChild; }
            else if (node == node.Parent.Left) { node.Parent.Left = rightChild; }
            else { node.Parent.Right = rightChild; }

            rightChild.Left = node;
            node.Parent = rightChild;
        }
    }

    private void RotateRight(Node node)
    {
        Node? leftChild = node.Left;
        node.Left = leftChild?.Right;

        if (leftChild?.Right is not null)
            leftChild.Right.Parent = node;

        if (leftChild is not null)
        {
            leftChild.Parent = node.Parent;
            if (node.Parent == null) { _head = leftChild; }
            else if (node == node.Parent.Left) { node.Parent.Left = leftChild; }
            else { node.Parent.Right = leftChild; }
        }
    }
}