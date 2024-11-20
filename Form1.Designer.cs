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
            this.button1 = new System.Windows.Forms.Button();
            this.log_out_bt = new System.Windows.Forms.Button();
            this.log_in_bt = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.button1.TabIndex = 0;
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
            this.log_out_bt.TabIndex = 1;
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
            this.password.TabIndex = 3;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.name.Location = new System.Drawing.Point(353, 343);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(225, 34);
            this.name.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(566, 642);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.ControlBox = false;
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
    }
}

