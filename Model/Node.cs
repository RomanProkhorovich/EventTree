using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                reasons += item.Name+"\n";
            }
            string res = "";
            foreach (var item in Results)
            {
                res += item.Name + "\n";
            }
            return Name+"Reasons:\n"+ reasons + "Results:\n" + res;
        }

        // public void AddNewReasonByReasons

    }
}
