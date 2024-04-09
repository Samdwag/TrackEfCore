using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace TrackEfCore
{
    public class TrackResult
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal Result { get; set; } 
    }

}
