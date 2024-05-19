namespace ex_vol3
{
    partial class Product_str
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
            this.text_richTextBox = new System.Windows.Forms.RichTextBox();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.pictureBox_product3 = new System.Windows.Forms.PictureBox();
            this.id_label = new System.Windows.Forms.Label();
            this.label_id2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_product3)).BeginInit();
            this.SuspendLayout();
            // 
            // text_richTextBox
            // 
            this.text_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_richTextBox.Location = new System.Drawing.Point(530, 91);
            this.text_richTextBox.Name = "text_richTextBox";
            this.text_richTextBox.Size = new System.Drawing.Size(418, 259);
            this.text_richTextBox.TabIndex = 3;
            this.text_richTextBox.Text = "";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.BackColor = System.Drawing.SystemColors.Window;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productNameLabel.Location = new System.Drawing.Point(549, 42);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(0, 24);
            this.productNameLabel.TabIndex = 6;
            // 
            // pictureBox_product3
            // 
            this.pictureBox_product3.Location = new System.Drawing.Point(35, 56);
            this.pictureBox_product3.Name = "pictureBox_product3";
            this.pictureBox_product3.Size = new System.Drawing.Size(435, 294);
            this.pictureBox_product3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_product3.TabIndex = 8;
            this.pictureBox_product3.TabStop = false;
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Location = new System.Drawing.Point(858, 353);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(60, 13);
            this.id_label.TabIndex = 9;
            this.id_label.Text = "ID product:";
            // 
            // label_id2
            // 
            this.label_id2.AutoSize = true;
            this.label_id2.Location = new System.Drawing.Point(913, 353);
            this.label_id2.Name = "label_id2";
            this.label_id2.Size = new System.Drawing.Size(35, 13);
            this.label_id2.TabIndex = 10;
            this.label_id2.Text = "label1";
            // 
            // Product_str
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1034, 596);
            this.Controls.Add(this.label_id2);
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.pictureBox_product3);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.text_richTextBox);
            this.Name = "Product_str";
            this.Text = "Product_str";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_product3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox text_richTextBox;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.PictureBox pictureBox_product3;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label label_id2;
    }
}