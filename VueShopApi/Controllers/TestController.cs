using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VueShopApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get() {
            return "this is get all";
        }
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return id;
        }
        [HttpGet("{id1}/{id2}")]
        public string Get(int id1,string id2)
        {
            return id1+id2;
        }
    }
}