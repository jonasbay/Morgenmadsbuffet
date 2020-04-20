using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    public class KitchenModel
    {
        public List<BreakfastBookingsModel> BreakfastBookingsModels { get; set; }
        public List<CheckInsModel> CheckInsModels { get; set; }
        public List<String> Dates { get; set; }
    }
}
