using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace Math_Game_Server
{
    public partial class Form1 : Form
    {
        private Server server;
        public Form1()
        {
            InitializeComponent();
            gridviewDesign();
            server = new Server("http://*:5001/");
            try
            {
                server.Start();
                MessageBox.Show("Server started successfully!", "Notification", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Stop();
            this.Close();
        }

        private void log_out(object sender, EventArgs e)
        {
            log_in_name.Visible = true;
            name.Visible = true;
            log_in_pwd.Visible = true;
            password.Visible = true;
            log_in_bt.Visible = true;
            log_out_bt.Visible = false;
            dataGridView1.Visible = false;
            comboBox1.Visible = false;
            min_label.Visible = false;
            min_tb.Visible = false;
            max_label.Visible = false;
            max_tb.Visible = false;
            search_bt.Visible = false;
            remove_bt.Visible = false;
        }

        private void log_in(object sender, EventArgs e)
        {
            if(name.Text == "admin" &&  password.Text == "admin")
            {
                log_in_name.Visible = false;
                name.Text = "";
                name.Visible = false;
                log_in_pwd.Visible = false;
                password.Text = "";
                password.Visible = false;
                log_in_bt.Visible = false;
                log_out_bt.Visible = true;
                dataGridView1.Visible = true;
                min_label.Visible = true;
                min_tb.Visible = true;
                max_label.Visible = true; 
                max_tb.Visible = true;
                search_bt.Visible = true;
                remove_bt.Visible = true;
                //comboBox1.Visible = true;
                dataGridView1.DataSource = DataBase.show("SELECT s.score_id, u.user_name, s.score, s.date FROM dbo.Scores s JOIN dbo.Users u ON s.user_id = u.user_id ORDER BY s.score_id;");
            }
            else
            {
                MessageBox.Show("Wrong name or password");
            }
        }

        private void tableShow(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBase.show("SELECT * FROM " + comboBox1.SelectedItem?.ToString());
        }

        private void gridviewDesign()
        {
            // Change background color
            dataGridView1.BackgroundColor = Color.LightGray;

            // Set the alternating row background color
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            // Change the default row background color
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;

            // Change the font and text color
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;

            // Change the header background and text colors
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Add grid line color
            dataGridView1.GridColor = Color.Black;

            // Enable visual styles (if needed)
            dataGridView1.EnableHeadersVisualStyles = false;

            // Set row/column headers font
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Arial", 9);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block the key press
            }
        }

        private void search(object sender, EventArgs e)
        {
            Int32 min = Int32.Parse(min_tb.Text);
            Int32 max = Int32.Parse(max_tb.Text);
            if (min > max)
            {
                DialogResult result = MessageBox.Show("Min is bigger than the max.\nThis way the search will show nothing.","Notification",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dataGridView1.DataSource = null; 
                }
            }
            else
            {
                MessageBox.Show("Min: " + min + ",max: " + max);
                dataGridView1.DataSource = DataBase.show("SELECT s.score_id, u.user_name, s.score, s.date FROM dbo.Scores s JOIN dbo.Users u ON s.user_id = u.user_id WHERE s.score BETWEEN " + min + " AND " + max + "ORDER BY s.score_id;");
            }
        }

        private void delete(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Retrieve the primary key value (assuming "score_id" is bound to a column)
            int selectedScoreId = Convert.ToInt32(selectedRow.Cells["score_id"].Value); // Replace "score_id" with your actual column name

            // SQL command to delete the record
            string deleteCommand = $"DELETE FROM Scores WHERE score_id = {selectedScoreId}";

            try
            {
                // Call your database method to execute the delete command
                DataBase.delet(deleteCommand);

                // Remove the row from the DataGridView
                dataGridView1.Rows.Remove(selectedRow);

                MessageBox.Show("Record deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record: {ex.Message}");
            }
        }


    }

}
