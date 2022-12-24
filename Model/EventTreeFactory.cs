using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Model
{
    enum  EventTreeType
    {
        Office,
        University,
        Factory
    }
    internal class EventTreeFactory
    {

      public static EventTree CreateTree( EventTreeType type)
        {
            switch (type)
            {
                case EventTreeType.Office:
                {
                    var m = new OfficeEventTree();
                    m.Init();
                    return m;
                }
                case EventTreeType.Factory:
                {
                    var m = new ManufactoryEventTree();
                    m.Init();
                    return m;
                }
            }
            throw new ArgumentNullException("type");
        }
    }
}
