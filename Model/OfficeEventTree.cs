using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Model
{
    internal class OfficeEventTree: EventTree
    {
        public override void Init()
        {
            Node deskJob = new("Сидячая работа");
            Node building = new ("Проблемы при проектировании здания");
            Node power = new("Большая нагрузка на электросеть");
            Node ventilation = new("Неподходящая или отсутствующая вентиляция");
            Node dust = new Node("Слишком большая концентрация пыли в воздухе");
            Node dryAir = new Node("Слишком сухой воздух");
            Node light = new("Недостаточное или слишком яркое освещение");
            Node coldHot = new("Нарушение теплового режима");
            Node noise = new("Высокий уровень шума");
            Node crushing = new("Обрушение");
            Node sickness = new("Заболевания");
            Node injury = new("Травмы и(или) инвалидность");
            Node fire = new("Пожар");
            Node industrialSafety = new("Несоблюдение техники безопасности");
            Node death = new("Смерть");

            AddNode(deskJob,null,new []{sickness});
            AddNode(ventilation, null, new[] {dust, dryAir});
            AddNode(building,null,new Node[]{power,ventilation,light,coldHot,noise,crushing});
            AddNode(industrialSafety, null, new Node[] {power,fire, injury,death});

            AddReasons(sickness,new []{light,coldHot,noise});
            AddReasons(death,new []{sickness, injury});
            AddResults(power,new []{fire,death});
            AddResults(fire,new []{crushing,death});
            AddResults(dust,new []{sickness});
            AddResults(dryAir, new[] {sickness});
            AddReasons(fire,new []{crushing});
            PrintInfo();

        }
    }
}
