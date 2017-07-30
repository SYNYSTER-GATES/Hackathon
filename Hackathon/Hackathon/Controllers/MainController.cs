using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hackathon.Services;
using Hackathon.Models;
using Newtonsoft.Json;

namespace Hackathon.Controllers
{
    
    public class MainController : ApiController
    {


        AgentStore agentstore = new AgentStore();
        OrderStore orderstore = new OrderStore();
        static Dictionary<int, Agent> agents = new Dictionary<int, Agent>();
        static Dictionary<int, Orders> orders = new Dictionary<int, Orders>();

        public async static int getDistance(String lat1,String long1,String lat2,String long2)
        {
            HttpClient client = new HttpClient();
            Uri url=new Uri("https://maps.googleapis.com/maps/api/distancematrix/json/?units=imperial&origins="+lat1+","+long1+"&destinations=" + lat2 + "," + long2);
            var result = await client.GetAsync(url);
            var json = await result.Content.ReadAsStringAsync();
            dynamic jsonObj = JsonConvert.DeserializeObject<object>(json);
            int a = jsonObj.rows[0].elements[0].distance.value;
            return a;
        }



        // GET: api/Main
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Main/5
        [HttpGet]
        [Route("api/values/getmin/{id}")]
        public IHttpActionResult Getmin(int OrderID)
        {
            agents = agentstore.getDictionary();
            orders = orderstore.getDictionary();
            Orders orderfound = new Orders();
            Boolean b = false;
            foreach (KeyValuePair<int, Orders> entry in orders)
            {
                if(entry.Key==OrderID)
                {
                    orderfound = entry.Value;
                    b = true;
                }
            }
            if( b == false)
            {
                return Content(HttpStatusCode.NoContent, "OrderId not found");
            }
            Agent nearestagent = new Agent();
            int min = 1000;
            int dis;
            foreach(KeyValuePair<int, Agent> entry in agents)
            {
                dis = getDistance(orderfound.Lat, orderfound.Long, entry.Value.Lat, entry.Value.Long);
                if(dis<min&&entry.Value.status==true)
                {
                    nearestagent = entry.Value;
                }
            }

            return Content(HttpStatusCode.OK, nearestagent);
        }
        
    }
}
