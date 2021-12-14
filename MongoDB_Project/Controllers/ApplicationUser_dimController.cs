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
    public class ApplicationUser_dimController : Controller
    {
     
        private IMongoCollection<ApplicationUser_dim> _applicationUser;

        public ApplicationUser_dimController(IMongoClient client)
        {
            var database = client.GetDatabase("IoT");
            _applicationUser = database.GetCollection<Vlan_dim>("Vlan");
        }

        [HttpGet]
        public ActionResult Index()
        {
           
            var vlan = _applicationUser.Find(s => s.AccessibleByUser == "Admin").ToList();


            return View(vlan);
        }
    }
}
