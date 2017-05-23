﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YCBusService.Models
{
    public partial class RouteStop
    {
        public int RouteStopId { get; set; }
        public string BusRouteCode { get; set; }
        public int? BusStopNumber { get; set; }
        public int? OffsetMinutes { get; set; }

        public virtual BusRoute BusRouteCodeNavigation { get; set; }
        public virtual BusStop BusStopNumberNavigation { get; set; }
    }
}