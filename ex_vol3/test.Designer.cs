namespace ex_vol3
{
    partial class test
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.save_change_buton = new System.Windows.Forms.Button();
            this.add_new_product_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.Size = new System.Drawing.Size(639, 326);
            this.dataGridView1.TabIndex = 0;
            // 
            // save_change_buton
            // 
            this.save_change_buton.Location = new System.Drawing.Point(391, 402);
            this.save_change_buton.Name = "save_change_buton";
            this.save_change_buton.Size = new System.Drawing.Size(119, 43);
            this.save_change_buton.TabIndex = 1;
            this.save_change_buton.Text = "save change";
            this.save_change_buton.UseVisualStyleBackColor = true;
            this.save_change_buton.Click += new System.EventHandler(this.save_change_buton_Click);
            // 
            // add_new_product_button
            // 
            this.add_new_product_button.Location = new System.Drawing.Point(253, 402);
            this.add_new_product_button.Name = "add_new_product_button";
            this.add_new_product_button.Size = new System.Drawing.Size(119, 43);
            this.add_new_product_button.TabIndex = 2;
            this.add_new_product_button.Text = "add new product";
            this.add_new_product_button.UseVisualStyleBackColor = true;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(869, 485);
            this.Controls.Add(this.add_new_product_button);
            this.Controls.Add(this.save_change_buton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "test";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button save_change_buton;
        private System.Windows.Forms.Button add_new_product_button;
    }
}