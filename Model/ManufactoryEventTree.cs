using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Model
{
    internal class ManufactoryEventTree : EventTree
    {
        public ManufactoryEventTree()
        {
            // List<Node> nodes = new List<Node>();
            /*nodes.Add(new Node("Node1"));
            this.AddNode("name1", null,nodes);
            this.AddNode("name2", nodes, null);*/


            // nodes.Add(new Node("Node1"));

          
        }

        public override void Init()
        {
            AddNode("Дефекты при проектировании здания", null, 
                new[]
                    {
                    "Обрушение здания",
                    "Ухудшение условий труда",
                    "Отсутствие качественной вентиляции",
                    "Недостаточная освещенность"
                     });

            AddNode("Профзаболевания", 
                new[]
                {
                    "Ухудшение условий труда",
                    "Отсутствие качественной вентиляции"
                },
                new[]
                {
                    "Инвалидность и(или) травмы",
                    "Смерть"
                });
            AddNode("Отсутствие качественной вентиляции",
                new []{ "Дефекты при проектировании здания" },
                new []{"Ухудшение условий труда", "Профзаболевания" });
            AddNode("Недостаточная освещенность",
                new []{ "Дефекты при проектировании здания"},
                new [] {"Ухудшение условий труда"});
            
            AddNode("Обрушение здания",
                new[] { "Пожар" },
                new[] 
                { 
                    "Пожар",
                    "Инвалидность и(или) травмы",
                    "Смерть"
                });
            AddNode("Ухудшение условий труда",
                new[]
                {
                    "Дефекты при проектировании здания",
                    "Отсутствие качественной вентиляции",
                    "Недостаточная освещенность",
                    "Дефекты оборудования",
                    "Нарушение техники производства или техники безопасности"

                },
                new[]
                {
                    "Нарушение техники производства или техники безопасности",
                    "Профзаболевания"
                });
            AddNode("Пожар",
                new[]
                {
                    "Обрушение здания",
                    "Нарушение техники производства или техники безопасности",
                    "Дефекты оборудования",
                    "Авария при работы с электричеством"
                },
                new[] {"Инвалидность и(или) травмы", "Смерть", "Обрушение здания"});
            AddNode("",
                new[] { "" },
                new[] { "" });
            AddNode("",
                new[] { "" },
                new[] { "" });
            AddNode("",
                new[] { "" },
                new[] { "" });
            AddNode("",
                new[] { "" },
                new[] { "" });
            AddNode("",
                new[] { "" },
                new[] { "" });
            AddNode("",
                new[] { "" },
                new[] { "" });
            /*AddNode("",
                new[] { "" },
                new[] { "" });*/





            foreach (var item in Nodes)
            {
                MessageBox.Show(item.ToString());
            }
        }



    }
}