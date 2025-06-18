using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Models;
using TicketManagementSystem.Controllers;
using System.Windows.Forms;

namespace TicketManagementSystem.Views
{
    public class TicketEditForm : Form
    {

        private readonly TicketController controller = new TicketController();
        private DataGridView grid = new DataGridView();
        private TextBox titleBox = new TextBox();
        private TextBox descBox = new TextBox();
        private TextBox ownerBox = new TextBox();
        private ComboBox statusBox = new ComboBox();

        public TicketEditForm(Ticket ticket)
        {
            this.Text = "Ticket Management System Edit Ticket";
            this.Width = 380;
            this.Height = 340;
            // Initialize components
            InitializeComponents(ticket);
        }

        private void InitializeComponents(Ticket ticket)
        {
             // DataGridView
            titleBox.Top = 20;
            titleBox.Left = 20;
            titleBox.Width = 300;
            titleBox.PlaceholderText = "Title";
            titleBox.Text = ticket.Title; // Pre-fill with existing ticket data

            descBox.Top = 60;
            descBox.Left = 20;
            descBox.Width = 300;
            descBox.Height = 100;
            descBox.Multiline = true;
            descBox.PlaceholderText = "Description";
            descBox.Text = ticket.Description; // Pre-fill with existing ticket data

            ownerBox.Top = 180;
            ownerBox.Left = 20;
            ownerBox.Width = 300;
            ownerBox.PlaceholderText = "Owner";
            ownerBox.Text = ticket.Owner; // Pre-fill with existing ticket data

            statusBox.Top = 220;
            statusBox.Left = 20;
            statusBox.Width = 300;
            statusBox.Items.AddRange(new string[] { "Pending", "In Progress", "Completed" });
            statusBox.SelectedIndex = 0; // Default to "Open"
            if (ticket.Status != null && statusBox.Items.Contains(ticket.Status))
            {
                statusBox.SelectedItem = ticket.Status; // Pre-fill with existing ticket data
            }



            this.Controls.Add(titleBox);
            this.Controls.Add(descBox);
            this.Controls.Add(ownerBox);
            this.Controls.Add(statusBox);
            // buttons
            Button btnCreate = new Button
            {
                Text = "Update Ticket",
                Top = 260,
                Left = 20,
                Width = 100
            };
            btnCreate.Click += (sender, e) =>
            {
                var newTicket = new Ticket
                {
                    Id = ticket.Id, // Ensure we update the existing ticket
                    Title = titleBox.Text,
                    Description = descBox.Text,
                    Owner = ownerBox.Text,
                    Status = statusBox.SelectedItem.ToString(),
                    CreatedAt = DateTime.Now
                };
                controller.Update(newTicket);
                this.Close(); // Close the form after update
                grid.DataSource = controller.GetAll(); // Refresh grid
                MessageBox.Show("Ticket Update successfully!");
            };

            this.Controls.Add(btnCreate);
            
        }

    }

    
}