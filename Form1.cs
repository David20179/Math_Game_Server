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
    }

}
