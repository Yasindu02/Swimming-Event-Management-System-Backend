using EbillAPI.Models;
using EbillAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EbillAPI.Controllers
{
    public class UserMasterController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Login(string username,string pasword) 
        {
            try
            {
                UserMasterService userMasterService = new UserMasterService(); 
                var result = userMasterService.Login(username, pasword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Register(RegisterMaper registerMaper)  
        {
            try
            {
                RegisterMaper result = new RegisterMaper { Firstname = registerMaper.Firstname,  Lastname = registerMaper.Lastname, Password = registerMaper.Password};
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
