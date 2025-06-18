using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagementSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Owner { get; set; } = "";
        public string Status { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}