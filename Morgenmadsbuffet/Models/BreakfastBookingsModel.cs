﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    public class BreakfastBookingsModel
    {
        // Composite Key
        public int BreakfastBookingsModelId { get; set; }
        public int RoomId { get; set; }
        public string Date { get; set; }

        public int AdultCount { get; set; }
        public int ChildCount { get; set; }

        // Navigational property
        public List<CheckInsModel> CheckInsModelList { get; set; }
    }
}
