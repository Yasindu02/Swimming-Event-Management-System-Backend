using EbillAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace EbillAPI.Controllers
{
    public class TasksController : ApiController
    {
        private MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        // GET: api/Task
        [HttpGet]
        public IHttpActionResult GetTasks()
        {
            try
            {
                _connection.Open();

                using (var cmd = new MySqlCommand("SELECT * FROM tasks", _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    var tasks = new List<object>(); // Change object to your actual model class

                    while (reader.Read())
                    {
                        // Map the database fields to your model properties
                        var task = new TaskMapper
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            EventName = reader["eventname"].ToString(),

                            // Add other properties as needed
                        };

                        tasks.Add(task);
                    }

                    return Ok(tasks);
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

        // POST: api/Tasks
        [HttpPost]
        public IHttpActionResult CreateTask([FromBody] TaskMapper task)
        {
            try
            {
                _connection.OpenAsync();

                // Assuming the user_id is provided in the task object
                var sql = "INSERT INTO tasks (`id`, `eventname`, `user_id`) VALUES (null, @EventName, @UserId)";
                using (var cmd = new MySqlCommand(sql, _connection))
                {
                    cmd.Parameters.AddWithValue("@EventName", task.EventName);
                    cmd.Parameters.AddWithValue("@UserId", task.UserId);

                    cmd.ExecuteNonQueryAsync();

                    return Ok(new { Status = "Success" });
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
