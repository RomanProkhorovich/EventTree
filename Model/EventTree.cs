namespace KSR.Model;

internal abstract class EventTree
{
    protected List<Node> Nodes = new();

    protected List<Node> FindReasons(string name)
    {
        var node = Nodes.Find(n => n.Name == name);
        if (node!=null)
        {
            return node.Reasons;
        }

        throw new ArgumentOutOfRangeException(name);
    }

    protected List<Node> FindResults(string name)
    {
        var node = Nodes.Find(n => n.Name == name);
        if (node != null)
        {
            return node.Results;
        }

        throw new ArgumentOutOfRangeException(name);
    }

    //useless??
    protected void AddNode(string name, List<Node> reasons, List<Node> results)
    {
        var n = new Node(name);
        if (results != null)
            n.Results.AddRange(results);
        if (reasons != null)
            n.Reasons.AddRange(reasons);
        Nodes.Add(n);

        if (reasons != null)
            foreach (var item in reasons)
            {
                if (Nodes.Find(n => n.Name == item.Name) == null) Nodes.Add(item);

                item.Results.Add(n);
            }

        if (results != null)
            foreach (var item in results)
            {
                if (Nodes.Find(n => n.Name == item.Name) == null) Nodes.Add(item);

                item.Reasons.Add(n);
            }
    }

    
    protected void AddNode(string name, string[]? reasons, string[]? results)
    {
        var n = new Node(name);

        Nodes.Add(n);
        if (reasons != null)
            foreach (var item in reasons)
            {
                var node = Nodes.Find(node1 => node1.Name == item);
                if (node == null)
                {
                    node=new Node(item);
                    Nodes.Add(node);
                }
                n.Reasons.Add(node);
                node.Results.Add(n);
            }

        if (results != null)
            foreach (var item in results)
            {
                var node = Nodes.Find(node1 => node1.Name == item);
                if (node == null)
                {
                    node = new Node(item);
                    Nodes.Add(node);
                }
                n.Reasons.Add(node);
                node.Reasons.Add(n);
            }
    }
}