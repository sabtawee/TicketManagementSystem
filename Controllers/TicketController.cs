using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TicketManagementSystem.Controllers
{
    public class TicketController
    {
        private readonly string connectionString;

        public TicketController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TicketDB"].ConnectionString;
        }

        public List<Ticket> GetAll(string? status = null)
        {
            List<Ticket> result = new List<Ticket>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tickets";

                if (!string.IsNullOrEmpty(status))
                {
                    query += " WHERE Status = @Status";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(status))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Ticket
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                Owner = reader["Owner"].ToString(),
                                Status = reader["Status"].ToString(),
                                CreatedAt = (DateTime)reader["CreatedAt"]
                            });
                        }
                    }
                }
            }

            return result;
        }

        public void Create(Ticket ticket)
        {
            //console.WriteLine("Creating ticket: " + ticket.Title);
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(
                    "INSERT INTO Tickets (Title, Description, Owner, Status) VALUES (@Title, @Desc, @Owner, @Status)", conn);
                cmd.Parameters.AddWithValue("@Title", ticket.Title);
                cmd.Parameters.AddWithValue("@Desc", ticket.Description);
                cmd.Parameters.AddWithValue("@Owner", ticket.Owner);
                cmd.Parameters.AddWithValue("@Status", ticket.Status);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Obsolete]
        public void Update(Ticket ticket)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(
                    "UPDATE Tickets SET Title=@Title, Description=@Desc, Owner=@Owner, Status=@Status WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Title", ticket.Title);
                cmd.Parameters.AddWithValue("@Desc", ticket.Description);
                cmd.Parameters.AddWithValue("@Owner", ticket.Owner);
                cmd.Parameters.AddWithValue("@Status", ticket.Status);
                cmd.Parameters.AddWithValue("@Id", ticket.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Obsolete]
        public void Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Tickets WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Ticket> SearchByStatus(string status)
        {
            List<Ticket> result = new List<Ticket>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tickets WHERE Status = @Status";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Ticket
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                Status = reader["Status"].ToString(),
                                CreatedAt = (DateTime)reader["CreatedAt"]
                            });
                        }
                    }
                }
            }

            return result;
        }
    }
}