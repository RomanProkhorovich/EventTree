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
                    return new OfficeEventTree();
                case EventTreeType.University:
                    return new UniversityEventTree();
                case EventTreeType.Factory:
                    return new ManufactoryEventTree();
            }
            throw new ArgumentNullException("type");
        }
    }
}
