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
            log_out_bt.Visible = false;
            name.Visible = true;
            password.Visible = true;
            log_in_bt.Visible=false;
            dataGridView1.Visible = false;
            log_in_bt.Visible = true;
            comboBox1.Visible = false;
        }

        private void log_in(object sender, EventArgs e)
        {
            if(name.Text == "admin" &&  password.Text == "admin")
            {
                name.Text = "";
                name.Visible = false;
                password.Text = "";
                password.Visible = false;
                log_in_bt.Visible = false;
                log_out_bt.Visible = true;
                dataGridView1.Visible = true;
                comboBox1.Visible = true;
                dataGridView1.DataSource = DataBase.show("SELECT * FROM Scores");
            }
        }

        private void tableShow(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBase.show("SELECT * FROM " + comboBox1.SelectedItem?.ToString());
        }
    }

}
