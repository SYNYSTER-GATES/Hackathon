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
    public class OrdersController : ApiController
    {
        static Dictionary<int, Orders> orders = new Dictionary<int, Orders>();

        OrderStore orderStore = new OrderStore();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/values/getorders/{id}")]
        public IHttpActionResult GetOrder(int id)
        {

            orders = orderStore.getDictionary();

            foreach (KeyValuePair<int, Orders> entry in orders)
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
        [Route("api/values/addorder")]
        public IHttpActionResult AddCustomer(Orders orderadd)
        {

            orders = orderStore.getDictionary();
            Boolean b = true;
            foreach (KeyValuePair<int, Orders> entry in orders)
            {
                if (entry.Key == orderadd.ID)
                {
                    b = false;
                    break;
                }
            }

            if (b == true)
            {
                orders.Add(orderadd.ID, orderadd);
                return Content(HttpStatusCode.Created, orders);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Order already exists");
            }

            orderStore.StoreDictionary(orders);

        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/values/updateorder")]
        public IHttpActionResult UpdateOrder(Orders orderupdate)
        {

            orders = orderStore.getDictionary();
            if (orders.Remove(orderupdate.ID))
            {
                orders.Add(orderupdate.ID, orderupdate);
                return Content(HttpStatusCode.OK, orders);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No Such record exists");
            }

            orderStore.StoreDictionary(orders);

        }
        // DELETE api/values/5
        [HttpDelete]
        [Route("api/values/deleteorder/{id}")]
        public IHttpActionResult DeleteOrder(int id)
        {

            orders = orderStore.getDictionary();

            if (orders.Remove(id))
            {
                return Content(HttpStatusCode.OK,orders);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No Such record exists");
            }
            orderStore.StoreDictionary(orders);
        }
    }
}
