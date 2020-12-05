using MovieAPI.BusinessService;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MovieAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [Route("login")]
        [HttpPost]
        public string CheckUser(User user)
        {
            ILoginInterFace loginBusinessService = new LoginBusinessService();
            return loginBusinessService.CheckUser(user);
        }
    }
}