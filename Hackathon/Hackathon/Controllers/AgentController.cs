using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hackathon.Models;
using Hackathon.Services;

namespace Hackathon.Controllers
{
    public class AgentController : ApiController
    {
        static Dictionary<int, Agent> agents = new Dictionary<int, Agent>();
        AgentStore agentStore = new AgentStore();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/values/getagents/{id}")]
        public IHttpActionResult GetAgent(int id)
        {

            agents=agentStore.getDictionary();
            foreach (KeyValuePair<int, Agent> entry in agents)
            {
                if (entry.Key == id)
                {
                    return Content(HttpStatusCode.OK, entry.Value);
                }
            }

            return Content(HttpStatusCode.NoContent, "Not Found");

        }

        // POST api/values
        [HttpPost]
        [Route("api/values/addagent")]
        public IHttpActionResult AddAgent(Agent agentadd)
        {

            agents = agentStore.getDictionary();
            Boolean b = true;
            foreach(KeyValuePair<int, Agent> entry in agents)
            {
                if(entry.Key==agentadd.ID)
                {
                    b = false;
                    break;
                }
            }

            if (b == true)
            {
                agents.Add(agentadd.ID,agentadd);
                return Content(HttpStatusCode.Created, agents);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "agent already exists");
            }
            agentStore.StoreDictionary(agents);


        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/values/updateagent")]
        public IHttpActionResult UpdateAgent(Agent agentupdate)
        {

            agents = agentStore.getDictionary();

            if (agents.Remove(agentupdate.ID))
            {
                agents.Add(agentupdate.ID,agentupdate);
                return Content(HttpStatusCode.OK, agents);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No Such record exists");
            }
            agentStore.StoreDictionary(agents);

        }
        // DELETE api/values/5
        [HttpDelete]
        [Route("api/values/deleteagent/{id}")]
        public IHttpActionResult DeleteStudent(int id)
        {

            agents = agentStore.getDictionary();

            if (agents.Remove(id))
            {
                return Content(HttpStatusCode.OK, "Deleted Succefully");
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No Such record exists");
            }

            agentStore.StoreDictionary(agents);

        }
    }
}
