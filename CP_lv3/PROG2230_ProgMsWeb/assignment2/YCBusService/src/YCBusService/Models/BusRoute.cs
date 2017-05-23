using System;
using System.Collections.Generic;

namespace YCBusService.Models
{
    public partial class BusRoute : IComparable
    {
        public BusRoute()
        {
            RouteSchedule = new HashSet<RouteSchedule>();
            RouteStop = new HashSet<RouteStop>();
        }

        public string BusRouteCode { get; set; }
        public string RouteName { get; set; }

        public virtual ICollection<RouteSchedule> RouteSchedule { get; set; }
        public virtual ICollection<RouteStop> RouteStop { get; set; }

        public int CompareTo(object obj)
        {
            int returnValueType = 0;
            int thisValue = Int32.Parse(BusRouteCode);
            string objValue = ((BusRoute)obj).BusRouteCode;
            int passedValue = Int32.Parse(objValue);
            if (thisValue > passedValue) returnValueType = 1;
            if (thisValue < passedValue) returnValueType = -1;
            return returnValueType;
        }
    }
}
