
namespace CharacterGUI
{
    partial class Form1
    {




        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
      
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Random = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statsbox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DumpBox = new System.Windows.Forms.TextBox();
            this.CharismaBox = new System.Windows.Forms.TextBox();
            this.WisomBox = new System.Windows.Forms.TextBox();
            this.IntelligenceBox = new System.Windows.Forms.TextBox();
            this.ConstitutionBox = new System.Windows.Forms.TextBox();
            this.DexterityBox = new System.Windows.Forms.TextBox();
            this.StrengthBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Rollmethod4d6d1 = new System.Windows.Forms.RadioButton();
            this.Rollmethod3d6r2 = new System.Windows.Forms.RadioButton();
            this.Rollmethod3d6 = new System.Windows.Forms.RadioButton();
            this.statsbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Character Generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Classes";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Fighter ",
            "Thief",
            "Wizard ",
            "cleric",
            "Paladin",
            "Ranger",
            "Bard"});
            this.checkedListBox1.Location = new System.Drawing.Point(56, 82);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 139);
            this.checkedListBox1.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(56, 227);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(148, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Make this character elite?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(56, 281);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(212, 157);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Random
            // 
            this.Random.Location = new System.Drawing.Point(330, 406);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(75, 23);
            this.Random.TabIndex = 14;
            this.Random.Text = "Random";
            this.toolTip1.SetToolTip(this.Random, "Generates a random character ");
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Random_Click);
            // 
            // statsbox
            // 
            this.statsbox.Controls.Add(this.label10);
            this.statsbox.Controls.Add(this.label9);
            this.statsbox.Controls.Add(this.label8);
            this.statsbox.Controls.Add(this.label7);
            this.statsbox.Controls.Add(this.label6);
            this.statsbox.Controls.Add(this.label5);
            this.statsbox.Controls.Add(this.label4);
            this.statsbox.Controls.Add(this.DumpBox);
            this.statsbox.Controls.Add(this.CharismaBox);
            this.statsbox.Controls.Add(this.WisomBox);
            this.statsbox.Controls.Add(this.IntelligenceBox);
            this.statsbox.Controls.Add(this.ConstitutionBox);
            this.statsbox.Controls.Add(this.DexterityBox);
            this.statsbox.Controls.Add(this.StrengthBox);
            this.statsbox.Controls.Add(this.label3);
            this.statsbox.Location = new System.Drawing.Point(529, 82);
            this.statsbox.Name = "statsbox";
            this.statsbox.Size = new System.Drawing.Size(200, 309);
            this.statsbox.TabIndex = 15;
            this.statsbox.TabStop = false;
            this.statsbox.Enter += new System.EventHandler(this.statsbox_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Perception";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Dexterity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Constitution";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Intelligence";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Wisom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Charisma(Rizz)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Strength";
            // 
            // DumpBox
            // 
            this.DumpBox.Location = new System.Drawing.Point(100, 181);
            this.DumpBox.Name = "DumpBox";
            this.DumpBox.Size = new System.Drawing.Size(100, 20);
            this.DumpBox.TabIndex = 7;
            // 
            // CharismaBox
            // 
            this.CharismaBox.Location = new System.Drawing.Point(100, 155);
            this.CharismaBox.Name = "CharismaBox";
            this.CharismaBox.Size = new System.Drawing.Size(100, 20);
            this.CharismaBox.TabIndex = 6;
            // 
            // WisomBox
            // 
            this.WisomBox.Location = new System.Drawing.Point(100, 129);
            this.WisomBox.Name = "WisomBox";
            this.WisomBox.Size = new System.Drawing.Size(100, 20);
            this.WisomBox.TabIndex = 5;
            // 
            // IntelligenceBox
            // 
            this.IntelligenceBox.Location = new System.Drawing.Point(100, 103);
            this.IntelligenceBox.Name = "IntelligenceBox";
            this.IntelligenceBox.Size = new System.Drawing.Size(100, 20);
            this.IntelligenceBox.TabIndex = 4;
            // 
            // ConstitutionBox
            // 
            this.ConstitutionBox.Location = new System.Drawing.Point(100, 77);
            this.ConstitutionBox.Name = "ConstitutionBox";
            this.ConstitutionBox.Size = new System.Drawing.Size(100, 20);
            this.ConstitutionBox.TabIndex = 3;
            // 
            // DexterityBox
            // 
            this.DexterityBox.Location = new System.Drawing.Point(100, 51);
            this.DexterityBox.Name = "DexterityBox";
            this.DexterityBox.Size = new System.Drawing.Size(100, 20);
            this.DexterityBox.TabIndex = 2;
            // 
            // StrengthBox
            // 
            this.StrengthBox.Location = new System.Drawing.Point(100, 25);
            this.StrengthBox.Name = "StrengthBox";
            this.StrengthBox.Size = new System.Drawing.Size(100, 20);
            this.StrengthBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stats";
            // 
            // Rollmethod4d6d1
            // 
            this.Rollmethod4d6d1.AutoSize = true;
            this.Rollmethod4d6d1.Location = new System.Drawing.Point(214, 77);
            this.Rollmethod4d6d1.Name = "Rollmethod4d6d1";
            this.Rollmethod4d6d1.Size = new System.Drawing.Size(55, 17);
            this.Rollmethod4d6d1.TabIndex = 16;
            this.Rollmethod4d6d1.Text = "4d6d1";
            this.Rollmethod4d6d1.UseVisualStyleBackColor = true;
            this.Rollmethod4d6d1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Rollmethod3d6r2
            // 
            this.Rollmethod3d6r2.AutoSize = true;
            this.Rollmethod3d6r2.Location = new System.Drawing.Point(214, 100);
            this.Rollmethod3d6r2.Name = "Rollmethod3d6r2";
            this.Rollmethod3d6r2.Size = new System.Drawing.Size(52, 17);
            this.Rollmethod3d6r2.TabIndex = 17;
            this.Rollmethod3d6r2.TabStop = true;
            this.Rollmethod3d6r2.Text = "3d6r2";
            this.Rollmethod3d6r2.UseVisualStyleBackColor = true;
            // 
            // Rollmethod3d6
            // 
            this.Rollmethod3d6.AutoSize = true;
            this.Rollmethod3d6.Checked = true;
            this.Rollmethod3d6.Location = new System.Drawing.Point(214, 123);
            this.Rollmethod3d6.Name = "Rollmethod3d6";
            this.Rollmethod3d6.Size = new System.Drawing.Size(43, 17);
            this.Rollmethod3d6.TabIndex = 18;
            this.Rollmethod3d6.TabStop = true;
            this.Rollmethod3d6.Text = "3d6";
            this.Rollmethod3d6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Rollmethod3d6);
            this.Controls.Add(this.Rollmethod3d6r2);
            this.Controls.Add(this.Rollmethod4d6d1);
            this.Controls.Add(this.statsbox);
            this.Controls.Add(this.Random);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statsbox.ResumeLayout(false);
            this.statsbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Random;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox statsbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DumpBox;
        private System.Windows.Forms.TextBox CharismaBox;
        private System.Windows.Forms.TextBox WisomBox;
        private System.Windows.Forms.TextBox IntelligenceBox;
        private System.Windows.Forms.TextBox ConstitutionBox;
        private System.Windows.Forms.TextBox DexterityBox;
        private System.Windows.Forms.TextBox StrengthBox;
        private System.Windows.Forms.RadioButton Rollmethod4d6d1;
        private System.Windows.Forms.RadioButton Rollmethod3d6r2;
        private System.Windows.Forms.RadioButton Rollmethod3d6;
    }
}

