namespace ex_vol3
{
    partial class registration
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.real_name_textBox = new System.Windows.Forms.TextBox();
            this.user_name_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.registration_button = new System.Windows.Forms.Button();
            this.log_in_back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(219, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTRATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(151, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "user name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(166, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(161, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "real name";
            // 
            // real_name_textBox
            // 
            this.real_name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.real_name_textBox.Location = new System.Drawing.Point(299, 195);
            this.real_name_textBox.Multiline = true;
            this.real_name_textBox.Name = "real_name_textBox";
            this.real_name_textBox.Size = new System.Drawing.Size(223, 27);
            this.real_name_textBox.TabIndex = 4;
            // 
            // user_name_textBox
            // 
            this.user_name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user_name_textBox.Location = new System.Drawing.Point(296, 262);
            this.user_name_textBox.Multiline = true;
            this.user_name_textBox.Name = "user_name_textBox";
            this.user_name_textBox.Size = new System.Drawing.Size(223, 27);
            this.user_name_textBox.TabIndex = 5;
            // 
            // password_textBox
            // 
            this.password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_textBox.Location = new System.Drawing.Point(296, 334);
            this.password_textBox.Multiline = true;
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(223, 27);
            this.password_textBox.TabIndex = 6;
            // 
            // registration_button
            // 
            this.registration_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registration_button.Location = new System.Drawing.Point(284, 457);
            this.registration_button.Name = "registration_button";
            this.registration_button.Size = new System.Drawing.Size(132, 52);
            this.registration_button.TabIndex = 7;
            this.registration_button.Text = "create accaunt";
            this.registration_button.UseVisualStyleBackColor = true;
            // 
            // log_in_back_button
            // 
            this.log_in_back_button.Location = new System.Drawing.Point(754, 12);
            this.log_in_back_button.Name = "log_in_back_button";
            this.log_in_back_button.Size = new System.Drawing.Size(75, 23);
            this.log_in_back_button.TabIndex = 8;
            this.log_in_back_button.Text = "log in";
            this.log_in_back_button.UseVisualStyleBackColor = true;
            this.log_in_back_button.Click += new System.EventHandler(this.log_in_back_button_Click);
            // 
            // registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 662);
            this.Controls.Add(this.log_in_back_button);
            this.Controls.Add(this.registration_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.user_name_textBox);
            this.Controls.Add(this.real_name_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "registration";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox real_name_textBox;
        private System.Windows.Forms.TextBox user_name_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Button registration_button;
        private System.Windows.Forms.Button log_in_back_button;
    }
}