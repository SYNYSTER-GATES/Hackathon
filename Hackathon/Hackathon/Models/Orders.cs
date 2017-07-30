using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public String customer { get; set; }
        public String item { get; set; }
        public int quantity { get; set; }
        public String Lat { get; set; }
        public String Long { get; set; }

    }
}