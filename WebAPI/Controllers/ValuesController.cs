﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private DataModel data;

        public ValuesController(DataModel data)
        {
            this.data = data;
        }

        public ValuesController()
        {

        }


        // GET api/values
        public IEnumerable<Models.Product> Get()
        {
            List<Models.Product> prods = data.Products.ToList();
            return prods;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
