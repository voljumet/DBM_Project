using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VlanController : Controller
    {

        private IMongoCollection<Vlan_dim> _vlan;

        public VlanController(IMongoClient client)
        {
            var database = client.GetDatabase("IoT");
            _vlan = database.GetCollection<Vlan_dim>("Vlan");
        }

        [HttpGet]
        public ActionResult Index()
        {
            BsonDocument filter = new BsonDocument();
            filter.Add("$or", new BsonArray()
                  .Add(new BsonDocument()
                          .Add("AccessibleByUser", "Admin")
                  )
                  .Add(new BsonDocument()
                          .Add("AccessibleByUser", "Student")
                  )
          );
            var vlan = _vlan.Find(filter).ToList();


            return View(vlan);
        }
    }
}
