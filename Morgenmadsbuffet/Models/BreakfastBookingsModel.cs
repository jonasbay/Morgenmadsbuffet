using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    public class BreakfastBookingsModel
    {
        // Keys
        public int RoomId { get; set; }
        public string Date { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
    }
}
