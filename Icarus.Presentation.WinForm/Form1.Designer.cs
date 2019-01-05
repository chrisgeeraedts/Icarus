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
            this.listBoxHand = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxDeck = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxExhaust = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxDiscard = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelExhaust = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.groupBoxCardDetail = new System.Windows.Forms.GroupBox();
            this.labelDescription = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.listBoxEnemy = new System.Windows.Forms.ListBox();
            this.labelmonsterName = new System.Windows.Forms.Label();
            this.labelMonsterCurrentHealth = new System.Windows.Forms.Label();
            this.labelMonsterMaxHealth = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxStatValues = new System.Windows.Forms.ListBox();
            this.listBoxPlayerStatusValues = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxCardDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCards
            // 
            this.listBoxCards.AllowDrop = true;
            this.listBoxCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxCards.FormattingEnabled = true;
            this.listBoxCards.Location = new System.Drawing.Point(12, 38);
            this.listBoxCards.Name = "listBoxCards";
            this.listBoxCards.Size = new System.Drawing.Size(254, 537);
            this.listBoxCards.TabIndex = 0;
            this.listBoxCards.SelectedIndexChanged += new System.EventHandler(this.listBoxCards_SelectedIndexChanged);
            this.listBoxCards.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxCards_DragDrop);
            this.listBoxCards.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxCards_DragEnter);
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
            // listBoxHand
            // 
            this.listBoxHand.AllowDrop = true;
            this.listBoxHand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxHand.FormattingEnabled = true;
            this.listBoxHand.Location = new System.Drawing.Point(532, 415);
            this.listBoxHand.Name = "listBoxHand";
            this.listBoxHand.Size = new System.Drawing.Size(254, 160);
            this.listBoxHand.TabIndex = 3;
            this.listBoxHand.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBoxHand.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
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
            // listBoxDeck
            // 
            this.listBoxDeck.AllowDrop = true;
            this.listBoxDeck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxDeck.FormattingEnabled = true;
            this.listBoxDeck.Location = new System.Drawing.Point(272, 415);
            this.listBoxDeck.Name = "listBoxDeck";
            this.listBoxDeck.Size = new System.Drawing.Size(254, 160);
            this.listBoxDeck.TabIndex = 5;
            this.listBoxDeck.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox2_DragDrop);
            this.listBoxDeck.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox2_DragEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1195, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Exhaust";
            // 
            // listBoxExhaust
            // 
            this.listBoxExhaust.AllowDrop = true;
            this.listBoxExhaust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxExhaust.FormattingEnabled = true;
            this.listBoxExhaust.Location = new System.Drawing.Point(986, 405);
            this.listBoxExhaust.Name = "listBoxExhaust";
            this.listBoxExhaust.Size = new System.Drawing.Size(254, 82);
            this.listBoxExhaust.TabIndex = 8;
            this.listBoxExhaust.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox4_DragDrop);
            this.listBoxExhaust.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox4_DragEnter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1197, 575);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Discard";
            // 
            // listBoxDiscard
            // 
            this.listBoxDiscard.AllowDrop = true;
            this.listBoxDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDiscard.FormattingEnabled = true;
            this.listBoxDiscard.Location = new System.Drawing.Point(986, 493);
            this.listBoxDiscard.Name = "listBoxDiscard";
            this.listBoxDiscard.Size = new System.Drawing.Size(254, 82);
            this.listBoxDiscard.TabIndex = 10;
            this.listBoxDiscard.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox3_DragDrop);
            this.listBoxDiscard.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox3_DragEnter);
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
            this.groupBoxCardDetail.Location = new System.Drawing.Point(272, 166);
            this.groupBoxCardDetail.Name = "groupBoxCardDetail";
            this.groupBoxCardDetail.Size = new System.Drawing.Size(251, 207);
            this.groupBoxCardDetail.TabIndex = 13;
            this.groupBoxCardDetail.TabStop = false;
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
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1252, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(375, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 26);
            this.button3.TabIndex = 16;
            this.button3.Text = "First draw";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(272, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 26);
            this.button4.TabIndex = 17;
            this.button4.Text = "Add to Deck";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(272, 70);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 26);
            this.button5.TabIndex = 18;
            this.button5.Text = "Add to Hand";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(272, 102);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(97, 26);
            this.button6.TabIndex = 19;
            this.button6.Text = "Add to Discard";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(272, 134);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(97, 26);
            this.button7.TabIndex = 20;
            this.button7.Text = "Add to Exhaust";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.SystemColors.MenuBar;
            this.richTextBoxLog.Location = new System.Drawing.Point(986, 70);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(254, 316);
            this.richTextBoxLog.TabIndex = 19;
            this.richTextBoxLog.Text = "";
            // 
            // listBoxEnemy
            // 
            this.listBoxEnemy.AllowDrop = true;
            this.listBoxEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEnemy.FormattingEnabled = true;
            this.listBoxEnemy.Location = new System.Drawing.Point(532, 38);
            this.listBoxEnemy.Name = "listBoxEnemy";
            this.listBoxEnemy.Size = new System.Drawing.Size(448, 69);
            this.listBoxEnemy.TabIndex = 21;
            this.listBoxEnemy.SelectedIndexChanged += new System.EventHandler(this.listBoxEnemy_SelectedIndexChanged);
            // 
            // labelmonsterName
            // 
            this.labelmonsterName.AutoSize = true;
            this.labelmonsterName.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelmonsterName.Location = new System.Drawing.Point(529, 110);
            this.labelmonsterName.Name = "labelmonsterName";
            this.labelmonsterName.Size = new System.Drawing.Size(73, 13);
            this.labelmonsterName.TabIndex = 22;
            this.labelmonsterName.Text = "MonsterName";
            // 
            // labelMonsterCurrentHealth
            // 
            this.labelMonsterCurrentHealth.AutoSize = true;
            this.labelMonsterCurrentHealth.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelMonsterCurrentHealth.Location = new System.Drawing.Point(529, 123);
            this.labelMonsterCurrentHealth.Name = "labelMonsterCurrentHealth";
            this.labelMonsterCurrentHealth.Size = new System.Drawing.Size(76, 13);
            this.labelMonsterCurrentHealth.TabIndex = 23;
            this.labelMonsterCurrentHealth.Text = "MonsterHealth";
            // 
            // labelMonsterMaxHealth
            // 
            this.labelMonsterMaxHealth.AutoSize = true;
            this.labelMonsterMaxHealth.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelMonsterMaxHealth.Location = new System.Drawing.Point(626, 123);
            this.labelMonsterMaxHealth.Name = "labelMonsterMaxHealth";
            this.labelMonsterMaxHealth.Size = new System.Drawing.Size(76, 13);
            this.labelMonsterMaxHealth.TabIndex = 24;
            this.labelMonsterMaxHealth.Text = "MonsterHealth";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label8.Location = new System.Drawing.Point(608, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "/";
            // 
            // listBoxStatValues
            // 
            this.listBoxStatValues.AllowDrop = true;
            this.listBoxStatValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxStatValues.FormattingEnabled = true;
            this.listBoxStatValues.Location = new System.Drawing.Point(773, 113);
            this.listBoxStatValues.Name = "listBoxStatValues";
            this.listBoxStatValues.Size = new System.Drawing.Size(207, 43);
            this.listBoxStatValues.TabIndex = 26;
            // 
            // listBoxPlayerStatusValues
            // 
            this.listBoxPlayerStatusValues.AllowDrop = true;
            this.listBoxPlayerStatusValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPlayerStatusValues.FormattingEnabled = true;
            this.listBoxPlayerStatusValues.Location = new System.Drawing.Point(792, 327);
            this.listBoxPlayerStatusValues.Name = "listBoxPlayerStatusValues";
            this.listBoxPlayerStatusValues.Size = new System.Drawing.Size(188, 82);
            this.listBoxPlayerStatusValues.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label6.Location = new System.Drawing.Point(789, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Player Stat Values";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 592);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBoxPlayerStatusValues);
            this.Controls.Add(this.listBoxStatValues);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelMonsterMaxHealth);
            this.Controls.Add(this.labelMonsterCurrentHealth);
            this.Controls.Add(this.labelmonsterName);
            this.Controls.Add(this.listBoxEnemy);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBoxCardDetail);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxDiscard);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxExhaust);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxDeck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxHand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxCards);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.ListBox listBoxHand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxDeck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxExhaust;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxDiscard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelExhaust;
        private System.Windows.Forms.GroupBox groupBoxCardDetail;
        private System.Windows.Forms.RichTextBox labelDescription;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.ListBox listBoxEnemy;
        private System.Windows.Forms.Label labelmonsterName;
        private System.Windows.Forms.Label labelMonsterCurrentHealth;
        private System.Windows.Forms.Label labelMonsterMaxHealth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBoxStatValues;
        private System.Windows.Forms.ListBox listBoxPlayerStatusValues;
        private System.Windows.Forms.Label label6;
    }
}

