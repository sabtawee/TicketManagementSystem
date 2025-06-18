using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Models;
using TicketManagementSystem.Controllers;
using System.Windows.Forms;


namespace TicketManagementSystem.Views
{
    public class TicketForm : Form
    {
        private readonly TicketController controller = new TicketController();
        private DataGridView grid = new DataGridView();
        private Button btnCreate, btnUpdate, btnDelete, btnRefresh;

        private ComboBox filterStatusBox;
        private Button btnSearch;

        public TicketForm()
        {
            this.Text = "Ticket Management System";
            this.Width = 1040;
            this.Height = 800;

            filterStatusBox = new ComboBox
            {
                Top = 30,
                Left = 20,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            filterStatusBox.Items.AddRange(new string[] { "All", "Pending", "In Progress", "Completed" });
            filterStatusBox.SelectedIndex = 0;

            // ปุ่ม Search
            btnSearch = new Button
            {
                Text = "Search",
                Top = 30,
                Left = 240,
                Width = 100
            };
            btnSearch.Click += (sender, e) =>
            {
                string selectedStatus = filterStatusBox.SelectedItem.ToString();
                if (selectedStatus == "All")
                {
                    grid.DataSource = controller.GetAll();
                }
                else
                {
                    grid.DataSource = controller.GetAll(selectedStatus);
                }
            };
            // buttons Create
            btnCreate = new Button
            {
                Text = "Create Ticket",
                Top = 60,
                Left = 20,
                Width = 100
            };
            btnCreate.Click += (sender, e) =>
            {
                // goto create ticket from
                var createForm = new TicketCreateForm();
                createForm.ShowDialog();
                // open the create ticket form
                grid.DataSource = controller.GetAll(); // Refresh grid after creating a ticket
            };

            // buttons Update
            btnUpdate = new Button
            {
                Text = "Update Ticket",
                Top = 60,
                Left = 130,
                Width = 100
            };
            btnUpdate.Click += (sender, e) =>
            {
                if (grid.SelectedRows.Count > 0)
                {
                    var selectedTicket = (Ticket)grid.SelectedRows[0].DataBoundItem;
                    Console.WriteLine($"Selected Ticket ID: {selectedTicket.Id}");
                    // goto edit ticket form
                    var editForm = new TicketEditForm(selectedTicket);
                    editForm.ShowDialog();
                    // open the edit ticket form
                    grid.DataSource = controller.GetAll();

                }
            };

            btnDelete = new Button
            {
                Text = "Delete Ticket",
                Top = 60,
                Left = 240,
                Width = 100
            };
            btnDelete.Click += (sender, e) =>
            {
                if (grid.SelectedRows.Count > 0)
                {
                    var selectedTicket = (Ticket)grid.SelectedRows[0].DataBoundItem;
                    controller.Delete(selectedTicket.Id);
                    grid.DataSource = controller.GetAll(); // Refresh grid
                    MessageBox.Show("Ticket deleted successfully!");
                }
            };

            btnRefresh = new Button
            {
                Text = "Refresh",
                Top = 60,
                Left = 350,
                Width = 100
            };
            btnRefresh.Click += (sender, e) =>
            {
                grid.DataSource = controller.GetAll();
            };

            // DataGridView
            grid.Top = 100;
            grid.Left = 20;
            grid.Width = 995;
            grid.Height = 600;
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 50
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Title",
                DataPropertyName = "Title",
                Width = 200
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                DataPropertyName = "Description",
                Width = 300
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Owner",
                DataPropertyName = "Owner",
                Width = 150
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Created At",
                DataPropertyName = "CreatedAt",
                Width = 150
            });

            grid.DataSource = controller.GetAll();
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            

            this.Controls.Add(btnCreate);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(grid);
            this.Controls.Add(filterStatusBox);
            this.Controls.Add(btnSearch);

        }
    }
}