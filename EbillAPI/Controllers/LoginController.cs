using EbillAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EbillAPI.Controllers
{
    public class LoginController : ApiController
    {
        private MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        // Login Post
        [HttpPost]
        public IHttpActionResult Login([System.Web.Http.FromBody] LoginModel login)
        {
            try
            {
                _connection.Open();

                var sql = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password";
                using (var cmd = new MySqlCommand(sql, _connection))
                {
                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Password", login.Password);

                    var result = cmd.ExecuteScalar();

                    if (Convert.ToInt32(result) == 1)
                    {
                        return (IHttpActionResult)Ok(new { Status = "Success" });
                    }
                    else
                    {
                        return Ok(new { Status = "Failure" });
                    }
                }
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
      
    }
}
