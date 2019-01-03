namespace SHITTYTEST
{
    partial class Form4
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.userControl51 = new SHITTYTEST.UserControl5();
            this.userControl41 = new SHITTYTEST.UserControl4();
            this.userControl31 = new SHITTYTEST.UserControl3();
            this.userControl21 = new SHITTYTEST.UserControl2();
            this.userControl11 = new SHITTYTEST.UserControl1();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 35);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(865, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вопрос №";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 650);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(900, 50);
            this.panel3.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Azure;
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(720, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 50);
            this.button4.TabIndex = 1;
            this.button4.Text = "Предыдущий вопрос";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Azure;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(810, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 50);
            this.button3.TabIndex = 0;
            this.button3.Text = "Следующий вопрос ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(325, 50);
            this.progressBar1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(340, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вопросов n из m";
            // 
            // userControl51
            // 
            this.userControl51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl51.Location = new System.Drawing.Point(0, 35);
            this.userControl51.Name = "userControl51";
            this.userControl51.Size = new System.Drawing.Size(900, 615);
            this.userControl51.TabIndex = 7;
            this.userControl51.Visible = false;
            // 
            // userControl41
            // 
            this.userControl41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl41.Location = new System.Drawing.Point(0, 35);
            this.userControl41.Name = "userControl41";
            this.userControl41.Size = new System.Drawing.Size(900, 615);
            this.userControl41.TabIndex = 6;
            this.userControl41.Visible = false;
            // 
            // userControl31
            // 
            this.userControl31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl31.Location = new System.Drawing.Point(0, 35);
            this.userControl31.Name = "userControl31";
            this.userControl31.Size = new System.Drawing.Size(900, 615);
            this.userControl31.TabIndex = 5;
            // 
            // userControl21
            // 
            this.userControl21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl21.Location = new System.Drawing.Point(0, 35);
            this.userControl21.Name = "userControl21";
            this.userControl21.Size = new System.Drawing.Size(900, 615);
            this.userControl21.TabIndex = 4;
            // 
            // userControl11
            // 
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(0, 35);
            this.userControl11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(900, 615);
            this.userControl11.TabIndex = 3;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.userControl51);
            this.Controls.Add(this.userControl41);
            this.Controls.Add(this.userControl31);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(401, 222);
            this.Name = "Form4";
            this.Text = "--------";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private UserControl1 userControl11;
        private UserControl2 userControl21;
        private UserControl3 userControl31;
        private UserControl4 userControl41;
        private UserControl5 userControl51;
    }
}