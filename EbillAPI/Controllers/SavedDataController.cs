using EbillAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace EbillAPI.Controllers
{
    public class SavedDataController : ApiController
    {
        private MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        [HttpGet]
        public IHttpActionResult GetSavedData()
        {
            try
            {
                _connection.Open();

                string sql = @"SELECT eventname, name, age, date, gender, house, timing, classes
                               FROM score";

                using (var cmd = new MySqlCommand(sql, _connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var scores = new List<ScoreMapper>();

                        while (reader.Read())
                        {
                            var score = new ScoreMapper
                            {
                                eventname = reader["eventname"].ToString(),
                                name = reader["name"].ToString(),
                                date = reader["date"].ToString(),
                                age = Convert.ToString(reader["age"]),
                                gender = reader["gender"].ToString(),
                                house = reader["house"].ToString(),
                             // birthday = Convert.ToString(reader["birthday"]),
                                timing = reader["timing"].ToString(),
                                classes = reader["classes"].ToString()
                            };

                            scores.Add(score);
                        }

                        return Ok(new { Status = "Success", Result = scores });
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
