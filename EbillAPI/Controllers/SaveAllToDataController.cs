using EbillAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace EbillAPI.Controllers
{
    public class SaveAllToDataController : ApiController
    {
        private MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        [HttpPost]
        public IHttpActionResult SaveAllToData([FromBody] List<ScoreMapper> scores) // Assume userId is provided in the request user_id
        {
            try
            {
                _connection.OpenAsync();

                var sql = "INSERT INTO score (`user_id`, `eventname`, `date`,`name`,`age`,`gender`,`house`,`birthday`,`timing`,`classes`) " +
                          "VALUES (@UserId, @EventName, @Date, @Name, @Age, @Gender, @House, @Birthday,  @Timing, @Classes)";

                using (var cmd = new MySqlCommand(sql, _connection))
                {
                    foreach (var score in scores)
                    {
                        cmd.Parameters.Clear(); // Clear parameters from the previous iteration

                        cmd.Parameters.AddWithValue("@UserId", score.user_id); // Add this line
                        cmd.Parameters.AddWithValue("@EventName", score.eventname);
                        cmd.Parameters.AddWithValue("@Name", score.name);
                        cmd.Parameters.AddWithValue("@Date", score.date);
                        cmd.Parameters.AddWithValue("@Age", score.age);
                        cmd.Parameters.AddWithValue("@Gender", score.gender);
                        cmd.Parameters.AddWithValue("@House", score.house);
                        cmd.Parameters.AddWithValue("@Birthday", score.birthday);
                        cmd.Parameters.AddWithValue("@Timing", score.timing);
                        cmd.Parameters.AddWithValue("@Classes", score.classes);

                        cmd.ExecuteNonQuery();
                    }
                  

                    return Ok("Data saved successfully.");
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
