using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Model
{
    internal class ManufactoryEventTree: EventTree
    {
        public ManufactoryEventTree()
        {
           // List<Node> nodes = new List<Node>();
            /*nodes.Add(new Node("Node1"));
            this.AddNode("name1", null,nodes);
            this.AddNode("name2", nodes, null);*/


           // nodes.Add(new Node("Node1"));
            this.AddNode("name1", null, new []{"Node1"});
            this.AddNode("name2", new[] { "Node1" }, null);
            foreach (var item in Nodes)
            {
                MessageBox.Show(item.ToString());
            }
        }
    }
}
