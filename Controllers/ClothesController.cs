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
            Clothes[] clothes = null;
            using (var context = new ApplicationDbContext())
            {
                clothes =  context.Clothes.ToArray();
            }
            return clothes;
            
        }
    }
}
