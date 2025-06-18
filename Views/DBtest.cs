using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.SqlClient;


namespace TicketManagementSystem.Views
{
    public class DBtest : Form
   {
        private Button testConnectionButton;

        public DBtest()
        {
            this.Text = "Test SQL Connection";
            this.Width = 300;
            this.Height = 150;

            testConnectionButton = new Button
            {
                Text = "Test Connection",
                Width = 200,
                Height = 40,
                Top = 40,
                Left = 40
            };
            testConnectionButton.Click += TestConnectionButton_Click;
            this.Controls.Add(testConnectionButton);
        }

        [Obsolete]
        private void TestConnectionButton_Click(object sender, EventArgs e)
        {
            // 🔧 Connection string: แก้ตามเครื่องคุณ
            string connectionString = "Data Source=10.31.2.75;Initial Catalog=THSQLDATA;User ID=ThUniTechMESUser;Password=wtazMLw60E#L";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("✅ Connected to SQL Server successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Failed to connect.\n\nError:\n" + ex.Message);
            }
        }
    }
}