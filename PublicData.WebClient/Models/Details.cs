using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicData.WebClient.Models
{
    public class Details
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string Value { get; set; }
        public string ExtraField { get; set; }
    }
}
