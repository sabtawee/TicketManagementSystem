using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Models;
using TicketManagementSystem.Controllers;
using System.Windows.Forms;

namespace TicketManagementSystem.Views
{
    public class TicketCreateForm : Form
    {
        private readonly TicketController controller = new TicketController();
        private DataGridView grid = new DataGridView();
        private TextBox titleBox = new TextBox();
        private TextBox descBox = new TextBox();
        private TextBox ownerBox = new TextBox();
        private ComboBox statusBox = new ComboBox();

        public TicketCreateForm()
        {
            this.Text = "Ticket Management System Create Ticket";
            this.Width = 380;
            this.Height = 340;
            // Initialize components
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // DataGridView
            titleBox.Top = 20;
            titleBox.Left = 20;
            titleBox.Width = 300;
            titleBox.PlaceholderText = "Title";

            descBox.Top = 60;
            descBox.Left = 20;
            descBox.Width = 300;
            descBox.Height = 100;
            descBox.Multiline = true;
            descBox.PlaceholderText = "Description";

            ownerBox.Top = 180;
            ownerBox.Left = 20;
            ownerBox.Width = 300;
            ownerBox.PlaceholderText = "Owner";

            statusBox.Top = 220;
            statusBox.Left = 20;
            statusBox.Width = 300;
            statusBox.Items.AddRange(new string[] { "Pending", "In Progress", "Completed" });
            statusBox.SelectedIndex = 0; // Default to "Open"


            this.Controls.Add(titleBox);
            this.Controls.Add(descBox);
            this.Controls.Add(ownerBox);
            this.Controls.Add(statusBox);
            // buttons
            Button btnCreate = new Button
            {
                Text = "Create Ticket",
                Top = 260,
                Left = 20,
                Width = 100
            };
            btnCreate.Click += (sender, e) =>
            {
                var newTicket = new Ticket
                {
                    Title = titleBox.Text,
                    Description = descBox.Text,
                    Owner = ownerBox.Text,
                    Status = statusBox.SelectedItem.ToString(),
                    CreatedAt = DateTime.Now
                };
                controller.Create(newTicket);
                titleBox.Clear();
                descBox.Clear();
                ownerBox.Clear();

                // close form
                statusBox.SelectedIndex = 0; // Reset to default status
                MessageBox.Show("Ticket created successfully!");
                this.Close();
                grid.DataSource = controller.GetAll(); // Refresh grid
            };

            this.Controls.Add(btnCreate);
            
        }
        // textbox
        
    }
}