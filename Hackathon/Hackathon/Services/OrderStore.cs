using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon.Models;

namespace Hackathon.Services
{
    public class OrderStore
    {
        public static Dictionary<int, Orders> orders = new Dictionary<int, Orders>();

        public void StoreDictionary(Dictionary<int, Orders> CopyDict)
        {
            orders = CopyDict;
        }

        public Dictionary<int, Orders> getDictionary()
        {
            return orders;
        }
    }
}