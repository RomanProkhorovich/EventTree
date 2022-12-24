using System.Drawing;

namespace KSR.Model;

internal abstract class EventTree
{
    protected List<Node> Nodes = new();

    protected List<Node> FindReasons(string name)
    {
        var node = Nodes.Find(n => n.Name == name);
        if (node != null)
        {
            return node.Reasons;
        }

        throw new ArgumentOutOfRangeException(name);
    }

    public abstract void Init();

    protected List<Node> FindResults(string name)
    {
        var node = Nodes.Find(n => n.Name == name);
        if (node != null)
        {
            return node.Results;
        }

        throw new ArgumentOutOfRangeException(name);
    }


    protected void AddNode(Node node, Node[]? reasons, Node[]? results)
    {
        AppendNode(node);

        AddReasons(node, reasons);

        AddResults(node,results);
    }

    private void AppendNode(Node node)
    {
        if (IsUniqueNode(node.Name))
        {
            Nodes.Add(node);
        }
    }

    public void AddReasons(Node node, Node[]? reasons)
    {
        if (reasons != null)
        {
            node.AddReasons(reasons);
            foreach (var reason in reasons)
            {
                AppendNode((reason));
                var find = Nodes.Find(node1 => node1 == reason);

                node.AddReason(find);
                find.AddResult(node);
            }
        }
    }

    public void AddResults(Node node, Node[]? results)
    {
        if (results != null)
        {
            node.AddResults(results);
            foreach (var variable in results)
            {
                AppendNode((variable));
                var find = Nodes.Find(node1 => node1 == variable);

                node.AddResult(find);
                find.AddReason(node);
            }
        }
    }

    protected void AddNode(string name, string[]? reasons, string[]? results)
    {
        var n = new Node(name);
        AppendNode(n);
        if (reasons != null)
            foreach (var item in reasons)
            {
                AppendNode(new Node(item));
                var node = Nodes.Find(node1 => node1.Name == item);

                n.AddReason(node);
                node.AddResult(n);
            }

        if (results != null)
            foreach (var item in results)
            {
                AppendNode(new Node(item));
                var node = Nodes.Find(node1 => node1.Name == item);
                n.AddResult(node);
                node.AddReason(n);
            }
    }

    private bool IsUniqueNode(string name)
    {
        return Nodes.Find(node1 => node1.Name == name) == null;
    }

    public void PrintInfo()
    {
        foreach (var item in Nodes)
        {
            MessageBox.Show(item.ToString());
        }
    }
}