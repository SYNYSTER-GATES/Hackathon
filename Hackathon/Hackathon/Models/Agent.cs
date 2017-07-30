using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class Agent
    {
        public int ID { get; set; }
        public String name { get; set; }
        public Boolean status { get; set; }
        public String Lat { get; set; }
        public String Long { get; set; }
    }
}