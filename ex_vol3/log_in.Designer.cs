namespace ex_vol3
{
    partial class log_in
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.login_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.show_pas_checkBox = new System.Windows.Forms.CheckBox();
            this.log_textBox = new System.Windows.Forms.TextBox();
            this.log_in_button = new System.Windows.Forms.Button();
            this.registration_button = new System.Windows.Forms.Button();
            this.pas_textBox1 = new System.Windows.Forms.TextBox();
            this.capcha_textBox = new System.Windows.Forms.TextBox();
            this.capcha_pictureBox = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.capcha_reload_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.capcha_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_label.Location = new System.Drawing.Point(375, 97);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(63, 28);
            this.login_label.TabIndex = 0;
            this.login_label.Text = "login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(375, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(430, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "capcha";
            // 
            // show_pas_checkBox
            // 
            this.show_pas_checkBox.AutoSize = true;
            this.show_pas_checkBox.Location = new System.Drawing.Point(489, 245);
            this.show_pas_checkBox.Name = "show_pas_checkBox";
            this.show_pas_checkBox.Size = new System.Drawing.Size(99, 17);
            this.show_pas_checkBox.TabIndex = 3;
            this.show_pas_checkBox.Text = "show password";
            this.show_pas_checkBox.UseVisualStyleBackColor = true;
            this.show_pas_checkBox.CheckedChanged += new System.EventHandler(this.show_pas_checkBox_CheckedChanged);
            // 
            // log_textBox
            // 
            this.log_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_textBox.Location = new System.Drawing.Point(377, 128);
            this.log_textBox.Multiline = true;
            this.log_textBox.Name = "log_textBox";
            this.log_textBox.Size = new System.Drawing.Size(211, 33);
            this.log_textBox.TabIndex = 4;
            this.log_textBox.TextChanged += new System.EventHandler(this.log_textBox_TextChanged);
            // 
            // log_in_button
            // 
            this.log_in_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_in_button.Location = new System.Drawing.Point(417, 451);
            this.log_in_button.Name = "log_in_button";
            this.log_in_button.Size = new System.Drawing.Size(118, 54);
            this.log_in_button.TabIndex = 7;
            this.log_in_button.Text = "log in";
            this.log_in_button.UseVisualStyleBackColor = true;
            this.log_in_button.Click += new System.EventHandler(this.log_in_button_Click);
            // 
            // registration_button
            // 
            this.registration_button.Location = new System.Drawing.Point(902, 12);
            this.registration_button.Name = "registration_button";
            this.registration_button.Size = new System.Drawing.Size(94, 30);
            this.registration_button.TabIndex = 8;
            this.registration_button.Text = "registration";
            this.registration_button.UseVisualStyleBackColor = true;
            this.registration_button.Click += new System.EventHandler(this.registration_button_Click);
            // 
            // pas_textBox1
            // 
            this.pas_textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pas_textBox1.Location = new System.Drawing.Point(377, 206);
            this.pas_textBox1.Multiline = true;
            this.pas_textBox1.Name = "pas_textBox1";
            this.pas_textBox1.PasswordChar = '*';
            this.pas_textBox1.Size = new System.Drawing.Size(211, 33);
            this.pas_textBox1.TabIndex = 9;
            // 
            // capcha_textBox
            // 
            this.capcha_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.capcha_textBox.Location = new System.Drawing.Point(417, 384);
            this.capcha_textBox.Multiline = true;
            this.capcha_textBox.Name = "capcha_textBox";
            this.capcha_textBox.Size = new System.Drawing.Size(117, 34);
            this.capcha_textBox.TabIndex = 10;
            // 
            // capcha_pictureBox
            // 
            this.capcha_pictureBox.Location = new System.Drawing.Point(393, 314);
            this.capcha_pictureBox.Name = "capcha_pictureBox";
            this.capcha_pictureBox.Size = new System.Drawing.Size(170, 64);
            this.capcha_pictureBox.TabIndex = 11;
            this.capcha_pictureBox.TabStop = false;
            // 
            // capcha_reload_button
            // 
            this.capcha_reload_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.capcha_reload_button.Location = new System.Drawing.Point(569, 331);
            this.capcha_reload_button.Name = "capcha_reload_button";
            this.capcha_reload_button.Size = new System.Drawing.Size(52, 33);
            this.capcha_reload_button.TabIndex = 12;
            this.capcha_reload_button.Text = "🗘";
            this.capcha_reload_button.UseVisualStyleBackColor = true;
            this.capcha_reload_button.Click += new System.EventHandler(this.capcha_reload_button_Click);
            // 
            // log_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 669);
            this.Controls.Add(this.capcha_reload_button);
            this.Controls.Add(this.capcha_pictureBox);
            this.Controls.Add(this.capcha_textBox);
            this.Controls.Add(this.pas_textBox1);
            this.Controls.Add(this.registration_button);
            this.Controls.Add(this.log_in_button);
            this.Controls.Add(this.log_textBox);
            this.Controls.Add(this.show_pas_checkBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_label);
            this.Name = "log_in";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.capcha_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox show_pas_checkBox;
        private System.Windows.Forms.TextBox log_textBox;
        private System.Windows.Forms.Button log_in_button;
        private System.Windows.Forms.Button registration_button;
        private System.Windows.Forms.TextBox pas_textBox1;
        private System.Windows.Forms.TextBox capcha_textBox;
        private System.Windows.Forms.PictureBox capcha_pictureBox;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button capcha_reload_button;
    }
}

