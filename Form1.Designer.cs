namespace Math_Game_Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.log_out_bt = new System.Windows.Forms.Button();
            this.log_in_bt = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.min_label = new System.Windows.Forms.Label();
            this.max_label = new System.Windows.Forms.Label();
            this.min_tb = new System.Windows.Forms.TextBox();
            this.max_tb = new System.Windows.Forms.TextBox();
            this.search_bt = new System.Windows.Forms.Button();
            this.remove_bt = new System.Windows.Forms.Button();
            this.log_in_name = new System.Windows.Forms.Label();
            this.log_in_pwd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(838, 692);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // log_out_bt
            // 
            this.log_out_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_out_bt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.log_out_bt.Location = new System.Drawing.Point(12, 692);
            this.log_out_bt.Name = "log_out_bt";
            this.log_out_bt.Size = new System.Drawing.Size(150, 46);
            this.log_out_bt.TabIndex = 5;
            this.log_out_bt.Text = "Log out";
            this.log_out_bt.UseVisualStyleBackColor = true;
            this.log_out_bt.Visible = false;
            this.log_out_bt.Click += new System.EventHandler(this.log_out);
            // 
            // log_in_bt
            // 
            this.log_in_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_in_bt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.log_in_bt.Location = new System.Drawing.Point(379, 423);
            this.log_in_bt.Name = "log_in_bt";
            this.log_in_bt.Size = new System.Drawing.Size(150, 46);
            this.log_in_bt.TabIndex = 2;
            this.log_in_bt.Text = "Log in";
            this.log_in_bt.UseVisualStyleBackColor = true;
            this.log_in_bt.Click += new System.EventHandler(this.log_in);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.password.Location = new System.Drawing.Point(353, 383);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(225, 34);
            this.password.TabIndex = 1;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.name.Location = new System.Drawing.Point(353, 316);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(225, 34);
            this.name.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(603, 512);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Scores",
            "Users"});
            this.comboBox1.Location = new System.Drawing.Point(151, 554);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 37);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.tableShow);
            // 
            // min_label
            // 
            this.min_label.AutoSize = true;
            this.min_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.min_label.ForeColor = System.Drawing.Color.Black;
            this.min_label.Location = new System.Drawing.Point(710, 54);
            this.min_label.Name = "min_label";
            this.min_label.Size = new System.Drawing.Size(130, 29);
            this.min_label.TabIndex = 7;
            this.min_label.Text = "Min-Score:";
            this.min_label.Visible = false;
            // 
            // max_label
            // 
            this.max_label.AutoSize = true;
            this.max_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.max_label.ForeColor = System.Drawing.Color.Black;
            this.max_label.Location = new System.Drawing.Point(710, 123);
            this.max_label.Name = "max_label";
            this.max_label.Size = new System.Drawing.Size(135, 29);
            this.max_label.TabIndex = 8;
            this.max_label.Text = "Max-Score:";
            this.max_label.Visible = false;
            // 
            // min_tb
            // 
            this.min_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.min_tb.Location = new System.Drawing.Point(715, 86);
            this.min_tb.Name = "min_tb";
            this.min_tb.Size = new System.Drawing.Size(100, 34);
            this.min_tb.TabIndex = 9;
            this.min_tb.Visible = false;
            this.min_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // max_tb
            // 
            this.max_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.max_tb.Location = new System.Drawing.Point(715, 155);
            this.max_tb.Name = "max_tb";
            this.max_tb.Size = new System.Drawing.Size(100, 34);
            this.max_tb.TabIndex = 10;
            this.max_tb.Visible = false;
            // 
            // search_bt
            // 
            this.search_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_bt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.search_bt.Location = new System.Drawing.Point(715, 209);
            this.search_bt.Name = "search_bt";
            this.search_bt.Size = new System.Drawing.Size(150, 46);
            this.search_bt.TabIndex = 11;
            this.search_bt.Text = "Search";
            this.search_bt.UseVisualStyleBackColor = true;
            this.search_bt.Visible = false;
            this.search_bt.Click += new System.EventHandler(this.search);
            // 
            // remove_bt
            // 
            this.remove_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_bt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.remove_bt.Location = new System.Drawing.Point(715, 383);
            this.remove_bt.Name = "remove_bt";
            this.remove_bt.Size = new System.Drawing.Size(174, 46);
            this.remove_bt.TabIndex = 12;
            this.remove_bt.Text = "Delete score";
            this.remove_bt.UseVisualStyleBackColor = true;
            this.remove_bt.Visible = false;
            this.remove_bt.Click += new System.EventHandler(this.delete);
            // 
            // log_in_name
            // 
            this.log_in_name.AutoSize = true;
            this.log_in_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.log_in_name.ForeColor = System.Drawing.Color.Black;
            this.log_in_name.Location = new System.Drawing.Point(348, 284);
            this.log_in_name.Name = "log_in_name";
            this.log_in_name.Size = new System.Drawing.Size(84, 29);
            this.log_in_name.TabIndex = 13;
            this.log_in_name.Text = "Name:";
            // 
            // log_in_pwd
            // 
            this.log_in_pwd.AutoSize = true;
            this.log_in_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.log_in_pwd.ForeColor = System.Drawing.Color.Black;
            this.log_in_pwd.Location = new System.Drawing.Point(348, 353);
            this.log_in_pwd.Name = "log_in_pwd";
            this.log_in_pwd.Size = new System.Drawing.Size(126, 29);
            this.log_in_pwd.TabIndex = 14;
            this.log_in_pwd.Text = "Password:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.ControlBox = false;
            this.Controls.Add(this.log_in_pwd);
            this.Controls.Add(this.log_in_name);
            this.Controls.Add(this.remove_bt);
            this.Controls.Add(this.search_bt);
            this.Controls.Add(this.max_tb);
            this.Controls.Add(this.min_tb);
            this.Controls.Add(this.max_label);
            this.Controls.Add(this.min_label);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.password);
            this.Controls.Add(this.log_in_bt);
            this.Controls.Add(this.log_out_bt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button log_out_bt;
        private System.Windows.Forms.Button log_in_bt;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label min_label;
        private System.Windows.Forms.Label max_label;
        private System.Windows.Forms.TextBox min_tb;
        private System.Windows.Forms.TextBox max_tb;
        private System.Windows.Forms.Button search_bt;
        private System.Windows.Forms.Button remove_bt;
        private System.Windows.Forms.Label log_in_name;
        private System.Windows.Forms.Label log_in_pwd;
    }
}

