namespace Icarus.Presentation.WinForm
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
            this.listBoxCards = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelExhaust = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.groupBoxCardDetail = new System.Windows.Forms.GroupBox();
            this.labelDescription = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxCardDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCards
            // 
            this.listBoxCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxCards.FormattingEnabled = true;
            this.listBoxCards.Location = new System.Drawing.Point(12, 38);
            this.listBoxCards.Name = "listBoxCards";
            this.listBoxCards.Size = new System.Drawing.Size(254, 537);
            this.listBoxCards.TabIndex = 0;
            this.listBoxCards.SelectedIndexChanged += new System.EventHandler(this.listBoxCards_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Cards";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Deck";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(532, 415);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(254, 160);
            this.listBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hand";
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(272, 415);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(254, 160);
            this.listBox2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(983, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Exhaust";
            // 
            // listBox4
            // 
            this.listBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(986, 225);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(254, 160);
            this.listBox4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(983, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Discard";
            // 
            // listBox3
            // 
            this.listBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(986, 415);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(254, 160);
            this.listBox3.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(792, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 26);
            this.button1.TabIndex = 11;
            this.button1.Text = "Use Card";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelExhaust
            // 
            this.labelExhaust.AutoSize = true;
            this.labelExhaust.Location = new System.Drawing.Point(6, 187);
            this.labelExhaust.Name = "labelExhaust";
            this.labelExhaust.Size = new System.Drawing.Size(58, 13);
            this.labelExhaust.TabIndex = 16;
            this.labelExhaust.Text = "EXHAUST";
            this.labelExhaust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(232, 8);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(13, 13);
            this.labelCost.TabIndex = 17;
            this.labelCost.Text = "0";
            this.labelCost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBoxCardDetail
            // 
            this.groupBoxCardDetail.Controls.Add(this.labelDescription);
            this.groupBoxCardDetail.Controls.Add(this.labelExhaust);
            this.groupBoxCardDetail.Controls.Add(this.labelCost);
            this.groupBoxCardDetail.Location = new System.Drawing.Point(275, 38);
            this.groupBoxCardDetail.Name = "groupBoxCardDetail";
            this.groupBoxCardDetail.Size = new System.Drawing.Size(251, 207);
            this.groupBoxCardDetail.TabIndex = 13;
            this.groupBoxCardDetail.TabStop = false;
            this.groupBoxCardDetail.Enter += new System.EventHandler(this.groupBoxCardDetail_Enter);
            // 
            // labelDescription
            // 
            this.labelDescription.BackColor = System.Drawing.SystemColors.MenuBar;
            this.labelDescription.Location = new System.Drawing.Point(9, 37);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.ReadOnly = true;
            this.labelDescription.Size = new System.Drawing.Size(236, 138);
            this.labelDescription.TabIndex = 18;
            this.labelDescription.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(792, 447);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 26);
            this.button2.TabIndex = 14;
            this.button2.Text = "End Turn";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 592);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBoxCardDetail);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxCards);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxCardDetail.ResumeLayout(false);
            this.groupBoxCardDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelExhaust;
        private System.Windows.Forms.GroupBox groupBoxCardDetail;
        private System.Windows.Forms.RichTextBox labelDescription;
        private System.Windows.Forms.Button button2;
    }
}

