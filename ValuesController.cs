using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using Newtonsoft.Json;
using PrimeNumber.Service;

namespace PrimeNumber.Controllers
{
    public class ValuesController : ApiController
    {

        private IPrimeNumberService _primenumberservice = null;

        public ValuesController(IPrimeNumberService primenumberservice)
        {
            _primenumberservice = primenumberservice;
        }

        // GET api/values
        public string Get(int number)
        {
            string str = "";
            if (number > 0)
            {
                if (number > 300)
                {
                    str = "bignumber";
                }
                else
                {
                    int cnt = 0;
                    int[] a = new int[number];

                    int[] listprimenumbers = _primenumberservice.Recursive(2, cnt, a, number);

                    str = _primenumberservice.GenerateMultidimensionArray(listprimenumbers);    
                }
            }
            else
            {
                str = "wrongnumber";
            }
            return str;
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