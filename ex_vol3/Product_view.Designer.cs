namespace ex_vol3
{
    partial class Product_view
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product_view));
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
            this.text_richTextBox.Location = new System.Drawing.Point(111, 362);
            this.text_richTextBox.Name = "text_richTextBox";
            this.text_richTextBox.ReadOnly = true;
            this.text_richTextBox.Size = new System.Drawing.Size(606, 186);
            this.text_richTextBox.TabIndex = 3;
            this.text_richTextBox.Text = "";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.BackColor = System.Drawing.SystemColors.Window;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productNameLabel.Location = new System.Drawing.Point(107, 335);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(201, 24);
            this.productNameLabel.TabIndex = 6;
            this.productNameLabel.Text = "dasddasdsadasdasdas";
            this.productNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox_product3
            // 
            this.pictureBox_product3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_product3.Location = new System.Drawing.Point(197, 27);
            this.pictureBox_product3.Name = "pictureBox_product3";
            this.pictureBox_product3.Size = new System.Drawing.Size(435, 294);
            this.pictureBox_product3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_product3.TabIndex = 8;
            this.pictureBox_product3.TabStop = false;
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Location = new System.Drawing.Point(649, 346);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(60, 13);
            this.id_label.TabIndex = 9;
            this.id_label.Text = "ID product:";
            // 
            // label_id2
            // 
            this.label_id2.AutoSize = true;
            this.label_id2.Location = new System.Drawing.Point(704, 346);
            this.label_id2.Name = "label_id2";
            this.label_id2.Size = new System.Drawing.Size(35, 13);
            this.label_id2.TabIndex = 10;
            this.label_id2.Text = "label1";
            // 
            // Product_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(858, 584);
            this.Controls.Add(this.label_id2);
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.pictureBox_product3);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.text_richTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Product_view";
            this.Text = "INFORMATION ";
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