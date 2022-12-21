using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Model
{
    internal abstract class EventTree
    {
        protected List<Node> Nodes = new List<Node>();
        protected List<Node> FindReasons(string name)
        {
            foreach (var item in Nodes)
            {
                if (item.Name == name)
                {
                    return item.Reasons;
                }
            }

            throw new ArgumentOutOfRangeException();
        }

        protected List<Node> FindResults(string name)
        {
            foreach (var item in Nodes)
            {
                if (item.Name == name)
                {
                    return item.Results;
                }
            }

            throw new ArgumentOutOfRangeException();
        }


        protected void AddNode(string name, List<Node> reasons, List<Node> results)
        {
            Node n = new Node(name);
            if (results != null)
                n.Results.AddRange(results);
            if (reasons != null)
                n.Reasons.AddRange(reasons);
            Nodes.Add(n);

            if (reasons != null)
                foreach (var item in reasons)
                {
                    if (Nodes.Find(n => n.Name == item.Name) == null)
                    {
                        Nodes.Add(item);
                    }

                    item.Results.Add(n);
                }
            if (results != null)
                foreach (var item in results)
                {
                    if (Nodes.Find(n => n.Name == item.Name) == null)
                    {
                        Nodes.Add(item);
                    }

                    item.Reasons.Add(n);

                }


        }

        protected void AddNode(string name, string[] reasons, string[] results)
        {
            
        }
    }
}
