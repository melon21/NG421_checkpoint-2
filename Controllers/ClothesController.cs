using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace capstone.Controllers
{
     [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClothesController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Clothes> Get()
        {
            Clothes[] Clothes = null;
            using (var context = new ApplicationDbContext())
            {
                Clothes = context.Clothes.ToArray();
            }
            return Clothes;

        }
        [HttpPost]
        public Clothes Post([FromBody]Clothes clothes)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Clothes.Add(clothes);
                context.SaveChanges();
            }
            return clothes;
        }
    }
}
