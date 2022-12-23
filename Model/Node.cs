namespace KSR.Model
{
    internal class Node: Result,Reason
    {
        public string Name { get; set; }
        public List<Node > Reasons{ get; set; } = new List<Node>();
        public List<Node> Results{ get; set; } = new List<Node> ();
        public Node(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string reasons = "";
            foreach (var item in Reasons)
            {
                reasons += "\t"+item.Name+"\n";
            }
            string res = "";
            foreach (var item in Results)
            {
                res +="\t"+ item.Name + "\n";
            }
            return Name+"\nReasons:\n"+ reasons + "Results:\n" + res;
        }

        public void AddReason(Node node)
        {
            if (string.IsNullOrEmpty(node.Name) && Reasons.Find(n=>n.Name==node.Name)==null)
            {
                Reasons.Add(node);
            }
        }
        public void AddResult(Node node)
        {
            if (string.IsNullOrEmpty(node.Name) &&Results.Find(n => n.Name == node.Name) == null)
            {
                Results.Add(node);
            }
        }

    }
}
