using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    public class CheckInsModel
    {
        public int CheckInsModelId { get; set; }

        [Display(Name = "Room no.")]
        public int RoomId { get; set; }

        [Display(Name = "Date")]
        public string Date { get; set; }

        [Display(Name = "Adults")]
        public int AdultCount { get; set; }

        [Display(Name = "Children")]
        public int ChildCount { get; set; }

        public BreakfastBookingsModel BreakfastBookingsModels { get; set; }
    }
}
