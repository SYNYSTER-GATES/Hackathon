using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon.Models;

namespace Hackathon.Services
{
    public class AgentStore
    {
        public static Dictionary<int, Agent> agents = new Dictionary<int, Agent>();

        public void StoreDictionary(Dictionary<int, Agent> CopyDict)
        {
            agents = CopyDict;
        }

        public Dictionary<int,Agent> getDictionary()
        {
            return agents;
        }
    }
}