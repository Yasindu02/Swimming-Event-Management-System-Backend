using EbillAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;

namespace EbillAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        [HttpGet]
        public IHttpActionResult GetStudents(int age, string gender, string house)
        {
            try
            {
                _connection.Open();

                string sql = @"SELECT s.id, s.name, s.birthday, s.age, s.gender, s.house, s.institute, s.address, s.phone, sc.eventname
                           FROM students s
                           LEFT JOIN score sc ON s.score_id = sc.id
                           WHERE s.age < @age AND s.gender = @gender AND s.house = @house";

                using (MySqlCommand command = new MySqlCommand(sql, _connection))
                {
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@house", house);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        List<StudentModel> students = new List<StudentModel>();

                        while (reader.Read())
                        {
                            StudentModel student = new StudentModel
                            {
                                id = Convert.ToInt32(reader["id"]),
                                name = Convert.ToString(reader["name"]),
                                birthday = Convert.ToString(reader["birthday"]),
                                age = Convert.ToInt32(reader["age"]),
                                gender = Convert.ToString(reader["gender"]),
                                house = Convert.ToString(reader["house"]),
                                institute = Convert.ToString(reader["institute"]),
                                address = Convert.ToString(reader["address"]),
                                phone = Convert.ToString(reader["phone"]),
                                eventname = Convert.ToString(reader["eventname"])
                            };

                            students.Add(student);
                        }

                        return Ok(new { Status = "Success", Result = students });
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

        [HttpPost]
        public IHttpActionResult CreateStudent([FromBody] StudentModel student)
        {
            try
            {
                _connection.OpenAsync();

                var sql = "INSERT INTO students (`name`, `birthday`, `age`, `gender`, `house`, `institute`, `address`, `phone`, `task_id`) " +
                          "VALUES (@Name, @Birthday, @Age, @Gender, @House, @Institute, @Address, @Phone, @TaskId)";
                using (var cmd = new MySqlCommand(sql, _connection))
                {
                    cmd.Parameters.AddWithValue("@Name", student.name);
                    cmd.Parameters.AddWithValue("@Birthday", student.birthday);
                    cmd.Parameters.AddWithValue("@Age", student.age);
                    cmd.Parameters.AddWithValue("@Gender", student.gender);
                    cmd.Parameters.AddWithValue("@House", student.house);
                    cmd.Parameters.AddWithValue("@Institute", student.institute);
                    cmd.Parameters.AddWithValue("@Address", student.address);
                    cmd.Parameters.AddWithValue("@Phone", student.phone);
                    cmd.Parameters.AddWithValue("@TaskId", student.task_id); // Add this line
                

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
